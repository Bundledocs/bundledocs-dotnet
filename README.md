# Bundledocs.net

[![NuGet](https://img.shields.io/nuget/v/Bundledocs.net.svg)](https://www.nuget.org/packages/Bundledocs.net/)
[![CI](https://github.com/Bundledocs/bundledocs-dotnet/actions/workflows/ci.yml/badge.svg)](https://github.com/Bundledocs/bundledocs-dotnet/actions/workflows/ci.yml)
[![License](https://img.shields.io/badge/license-Apache%202.0-blue.svg)](LICENSE)

The official [Bundledocs](https://www.bundledocs.com) .NET library, supporting .NET Standard 2.0+.

## Installation

Using the [.NET Core CLI](https://docs.microsoft.com/en-us/dotnet/core/tools/):

```bash
dotnet add package Bundledocs.net
```

Using the [NuGet CLI](https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference):

```bash
nuget install Bundledocs.net
```

Using the [Package Manager Console](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console):

```powershell
Install-Package Bundledocs.net
```

From within Visual Studio: open **Manage NuGet Packages**, search for `Bundledocs.net` and install.

### Requirements

.NET Standard 2.0+ (compatible with .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5+)

## Usage

```csharp
using Bundledocs.Api.Wrapper;
using Bundledocs.Api.Wrapper.Models;

// Create the client with your OAuth 2.0 access token (uses the Bundledocs production API)
using BundledocsApiClient client = new BundledocsApiClient("your-access-token");

// Users
User user = await client.Users.GetMeAsync();

// Expand extra data (supported values: MeExpand)
User userWithBundles = await client.Users.GetMeAsync(new MeRequestOptions { Expand = { MeExpand.Bundles } });

// Groups
Group[] groups = await client.Groups.GetGroupsAsync();
GroupMember[] members = await client.Groups.GetGroupMembersAsync(partitionKey, rowKey);

// Bundles
BundleMigrationInvitation[] invitations = await client.Bundles.GetMigrationInvitationsAsync(partitionKey, rowKey);

// To use another API address (for example, a test environment), pass it first:
// new BundledocsApiClient("https://app.bundledocs.com/api/v1", "your-access-token")
```

## Documentation

For the full Bundledocs REST API reference, visit [API Documentation - Bundledocs](https://kb.bundledocs.com/api-documentation).

## Development

Requirements: [.NET 10 SDK](https://dotnet.microsoft.com/download) or later.

```bash
git clone https://github.com/Bundledocs/bundledocs-dotnet.git
cd bundledocs-dotnet
dotnet restore
dotnet build
```

Running tests requires a valid access token:

```bash
# Windows
set BUNDLEDOCS_ACCESS_TOKEN=your-token

# macOS/Linux
export BUNDLEDOCS_ACCESS_TOKEN=your-token

dotnet test
```

## Contributing

See [CONTRIBUTING.md](https://github.com/Bundledocs/bundledocs-dotnet/blob/main/CONTRIBUTING.md).

## Support

New features and bug fixes are released on the latest version of this library. If you are on an older version, we recommend upgrading to receive the latest security fixes and improvements.

To report a bug or request a feature, [open an issue](https://github.com/Bundledocs/bundledocs-dotnet/issues/new/choose).

## License

[Apache License 2.0](LICENSE)
