# Changelog

All notable changes to this project will be documented in this file.

This project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)

- **Added** — new features.
- **Changed** — changes in existing functionality.
- **Fixed** — any bug fixes.
- **Security** — case of vulnerabilities.

## [0.7.0] - 2026-07-16

### Added

- Initial release of the Bundledocs.net API wrapper
- `BundledocsApiClient` entry point with `IDisposable` support
- Users endpoints: `Me()`, `MeLazy()`
- Groups endpoints: `GetGroups()`, `GetGroupMembers()`
- Briefs endpoints: `SendBundleMigrationInvitation()`, `GetBundleMigrations()`
- `BundledocsApiException` for structured error handling
- Apache 2.0 license
- GitHub Actions CI and NuGet publish workflows
