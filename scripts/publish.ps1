<#
.SYNOPSIS
    Publishes a new version of the Bundledocs.net NuGet package.

.DESCRIPTION
    Automates the release process:
    1. Validates the build
    2. Updates the version in .csproj
    3. Updates CHANGELOG.md
    4. Commits, tags, and pushes to trigger GitHub Actions publish

.PARAMETER Version
    The version to publish (e.g., "0.8.0" or "0.8.0-beta.1")

.EXAMPLE
    .\scripts\publish.ps1 -Version "0.8.0-beta.1"
    .\scripts\publish.ps1 -Version "0.8.0"
#>

param(
    [Parameter(Mandatory = $true)]
    [string]$Version,

    [switch]$DryRun
)

$ErrorActionPreference = "Stop"
$RepoRoot = Split-Path $PSScriptRoot -Parent
$CsprojPath = Join-Path $RepoRoot "Bundledocs.Api.Wrapper\Bundledocs.Api.Wrapper.csproj"
$ChangelogPath = Join-Path $RepoRoot "CHANGELOG.md"

# --- Validate ---
Write-Host "`n=== Bundledocs.net Release Script ===" -ForegroundColor Cyan
if ($DryRun) { Write-Host "[DRY RUN] No changes will be made.`n" -ForegroundColor Magenta }
Write-Host "Version: $Version"
Write-Host ""

# Check we're in the repo
if (-not (Test-Path $CsprojPath)) {
    Write-Error "Cannot find .csproj at $CsprojPath. Run this script from the repo root."
}

# Check clean working tree
$gitStatus = git -C $RepoRoot status --porcelain
if ($gitStatus) {
    if ($DryRun) {
        Write-Host "  WARNING: Working directory is not clean (ignored in DryRun)." -ForegroundColor Yellow
    }
    else {
        Write-Error "Working directory is not clean. Commit or stash changes first."
    }
}

# Check we're on main
$currentBranch = git -C $RepoRoot branch --show-current
if ($currentBranch -ne "main") {
    Write-Error "Must be on 'main' branch. Currently on: $currentBranch"
}

# Check tag doesn't already exist
$tagName = "v$Version"
$existingTag = git -C $RepoRoot tag -l $tagName
if ($existingTag) {
    Write-Error "Tag '$tagName' already exists."
}

# --- Build and test ---
Write-Host "`n[1/6] Building and packing..." -ForegroundColor Yellow
$packOutput = Join-Path $RepoRoot "nuget"
if (Test-Path $packOutput) { Remove-Item -Recurse -Force $packOutput }

dotnet pack $CsprojPath --configuration Release --output $packOutput
if ($LASTEXITCODE -ne 0) { Write-Error "dotnet pack failed." }

$nupkg = Get-ChildItem "$packOutput\*.nupkg" | Select-Object -First 1
Write-Host "  Package: $($nupkg.Name) ($([math]::Round($nupkg.Length / 1024, 1)) KB)" -ForegroundColor Green

# --- Update version in .csproj ---
Write-Host "`n[2/6] Updating version in .csproj..." -ForegroundColor Yellow
if ($DryRun) {
    Write-Host "  [DRY RUN] Would update .csproj to $Version" -ForegroundColor Magenta
}
else {
    $csprojContent = Get-Content $CsprojPath -Raw
    $csprojContent = $csprojContent -replace '<Version>[^<]+</Version>', "<Version>$Version</Version>"
    Set-Content $CsprojPath -Value $csprojContent -NoNewline
    Write-Host "  .csproj updated to $Version" -ForegroundColor Green
}

# --- Check CHANGELOG ---
Write-Host "`n[3/6] Checking CHANGELOG.md..." -ForegroundColor Yellow
$changelog = Get-Content $ChangelogPath -Raw
if ($changelog -notmatch [regex]::Escape("[$Version]")) {
    Write-Host "  WARNING: CHANGELOG.md does not contain an entry for [$Version]." -ForegroundColor Red
    Write-Host "  Please update CHANGELOG.md before continuing." -ForegroundColor Red
    Write-Host ""
    $continue = Read-Host "  Continue anyway? (y/N)"
    if ($continue -ne "y") {
        Write-Host "  Aborted. Update CHANGELOG.md and run again." -ForegroundColor Yellow
        exit 1
    }
}
else {
    Write-Host "  CHANGELOG.md contains entry for [$Version]" -ForegroundColor Green
}

# --- Commit ---
Write-Host "`n[4/6] Committing changes..." -ForegroundColor Yellow
$commitMsg = if ($Version -match "-") { "chore: bump to $Version" } else { "chore: release $Version" }
if ($DryRun) {
    Write-Host "  [DRY RUN] Would commit: $commitMsg" -ForegroundColor Magenta
}
else {
    git -C $RepoRoot add -A
    git -C $RepoRoot commit -m $commitMsg --allow-empty
    Write-Host "  Committed: $commitMsg" -ForegroundColor Green
}

# --- Tag ---
Write-Host "`n[5/6] Creating tag $tagName..." -ForegroundColor Yellow
if ($DryRun) {
    Write-Host "  [DRY RUN] Would create tag: $tagName" -ForegroundColor Magenta
}
else {
    git -C $RepoRoot tag $tagName
    Write-Host "  Tag created: $tagName" -ForegroundColor Green
}

# --- Push ---
Write-Host "`n[6/6] Pushing to GitHub..." -ForegroundColor Yellow
if ($DryRun) {
    Write-Host "  [DRY RUN] Would push to origin + tag $tagName" -ForegroundColor Magenta
}
else {
    git -C $RepoRoot push
    git -C $RepoRoot push origin $tagName
    Write-Host "  Pushed to origin" -ForegroundColor Green
}

# --- Done ---
Write-Host "`n=== Done ===" -ForegroundColor Cyan
Write-Host "GitHub Actions will now build and publish the package."
Write-Host "Monitor: https://github.com/Bundledocs/bundledocs-dotnet/actions"
Write-Host ""

# Cleanup
Remove-Item -Recurse -Force $packOutput

if ($Version -match "-") {
    Write-Host "This is a PRE-RELEASE. After validating, run:" -ForegroundColor Yellow
    $stableVersion = $Version -replace "-.*", ""
    Write-Host "  .\scripts\publish.ps1 -Version `"$stableVersion`"" -ForegroundColor White
}
else {
    Write-Host "STABLE release published. Verify at:" -ForegroundColor Green
    Write-Host "  https://www.nuget.org/packages/Bundledocs.net/$Version" -ForegroundColor White
}
