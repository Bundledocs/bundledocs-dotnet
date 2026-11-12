# Changelog

All notable changes to this project will be documented in this file.

This project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)

- **Added** — new features.
- **Changed** — changes in existing functionality.
- **Fixed** — any bug fixes.
- **Security** — case of vulnerabilities.

## [0.8.0] - 2026-10-29

### Added

- `BundledocsApiClient(string accessToken)`: creates a client for the Bundledocs production API, so the API address is now optional
- `MeExpand` constants with the values supported by `MeRequestOptions.Expand` (`MeExpand.Bundles`)

### Changed

- **Breaking:** asynchronous methods now end with `Async`, and `Briefs` is now `Bundles`:

  | Before | Now |
  |---|---|
  | `Users.Me(CancellationToken)` | `Users.GetMeAsync(MeRequestOptions options = null, CancellationToken cancellationToken = default)`. If you pass only a token, name it: `GetMeAsync(cancellationToken: token)` |
  | `Groups.GetGroups()` | `Groups.GetGroupsAsync()` |
  | `Groups.GetGroupMembers()` | `Groups.GetGroupMembersAsync()` |
  | `Briefs.SendBundleMigrationInvitation()` | `Bundles.SendMigrationInvitationAsync()` |
  | `Briefs.GetBundleMigrations()` | `Bundles.GetMigrationInvitationsAsync()` |
  | `IBundledocsApiBriefs` | `IBundledocsApiBundles` |
  | `IBundledocsApiBriefs.BriefMigrationInvitationCreateOptions` (record) | `BundleMigrationInvitationCreateOptions` (class in `Bundledocs.Api.Wrapper.Models`) |

- **Breaking:** response models drop the `BundledocsApiResponse` prefix and use "Bundle" instead of "Brief". Their properties keep the same names as the API fields:

  | Before | Now |
  |---|---|
  | `BundledocsApiResponseBase` | `BundledocsEntity` |
  | `BundledocsApiResponseUser` | `User` |
  | `BundledocsApiResponseGroup` | `Group` |
  | `BundledocsApiResponseGroupMember` | `GroupMember` |
  | `BundledocsApiResponseBrief` | `Bundle` |
  | `BundledocsApiResponseBriefMigrationInvitation` | `BundleMigrationInvitation` |

- `Users.GetMeAsync()` returns a lightweight user (no bundles) by default; pass `MeRequestOptions { Expand = { MeExpand.Bundles } }` to include bundles
- Added all user properties returned by the `/me` endpoint to the response model, including the user's bundles, with the new models `UserPinnedBundle`, `BundleDocument`, `BundleDocumentAnnotation`, `BundleDocumentAnnotationAutomation`, `BundleDocumentPermission`, `BundleReceipt`, `BundleShare`, `BundleCollaborator`, `BundleVisibleTo`, `BundleAnnotationExclusion`, `DownloadInvitation`, `StampTemplateField`, `SystemTag` and `VisibleTo`

### Removed

- **Breaking:** `Users.MeLazy()`. Use `Users.GetMeAsync()` instead

### Security

- Each `BundledocsApiClient` now always sends its own access token. In 0.7.0, clients created with the same API address in the same process shared one HTTP connection, and every request carried the access token of the first client created, even after that client was disposed. Applications that use more than one access token (for example, several users, or a token renewed after it expired) could make calls as the wrong user or get unexpected `401 Unauthorized` errors. If your application uses more than one access token, upgrade to this version

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
