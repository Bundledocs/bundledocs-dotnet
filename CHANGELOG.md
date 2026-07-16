# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.7.0] - Unreleased

### Added
- `BundledocsApiClient` — unified entry point implementing `IDisposable` for consuming the Bundledocs API
- Groups endpoints: `GetGroups()`, `GetGroupMembers()`
- Briefs endpoints: `SendBundleMigrationInvitation()`, `GetBundleMigrations()`
- `BundledocsApiException` — structured error handling with HTTP status code and response content
- `IBundledocsApiGroups` and `IBundledocsApiBriefs` interfaces
- `IsExternalInit` polyfill for record class support on .NET Standard 2.0
- `System.Text.Json` dependency for JSON serialization
- Package icon for NuGet.org
- CODEOWNERS file
- .NET code analyzers (nullable annotations mode)
- Trusted Publishing (OIDC) for NuGet.org

### Changed
- `BundledocsApiRequestProvider` rewritten with `Get<T>`, `GetList<T>`, `Post<TRequest, TResponse>` methods
- Models moved to `Models/Response/` subfolder
- `BundledocsApiResponseBrief` simplified (removed unused properties)
- RestSharp kept at 114.0.0 (security fix from 110.2.0)

## [0.1.0] - 2026-06-11

### Added
- Initial release of the Bundledocs .NET API Wrapper
- `BundledocsApiRequestProvider` — HTTP client with OAuth2 Bearer token authentication via RestSharp
- `BundledocsApiUsers` — `/users/me` and `/users/me/lazy` endpoints
- Response models: `BundledocsApiResponseUser`, `BundledocsApiResponseBrief`, `BundledocsApiResponseMessage`
- xUnit test project
- Apache 2.0 license
- GitHub Actions CI and NuGet publish workflows
