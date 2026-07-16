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

// Create the client with your API base URL and OAuth2 Bearer token
using BundledocsApiClient client = new BundledocsApiClient(
    apiBasePath: "https://app.bundledocs.com/api/v1",
    accessToken: "your-access-token"
);

// Users
var user = await client.Users.Me();
var lazyUser = await client.Users.MeLazy();

// Groups
var groups = await client.Groups.GetGroups();
var members = await client.Groups.GetGroupMembers(partitionKey, rowKey);

// Briefs (Bundles)
var migrations = await client.Briefs.GetBundleMigrations(partitionKey, rowKey);
```

## Documentation

For the full Bundledocs REST API reference, visit [API Documentation - Bundledocs](https://kb.bundledocs.com/api-documentation).

## Development

Requirements: [.NET 8 SDK](https://dotnet.microsoft.com/download) or later.

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

See [CONTRIBUTING.md](CONTRIBUTING.md).

## Support

New features and bug fixes are released on the latest version of this library. If you are on an older version, we recommend upgrading to receive the latest security fixes and improvements.

To report a bug or request a feature, [open an issue](https://github.com/Bundledocs/bundledocs-dotnet/issues/new/choose).

## License

[Apache License 2.0](LICENSE)
