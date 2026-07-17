# Contributing

We welcome bug reports, feature requests, and pull requests from the community.

## How Contributions Are Handled

This repository is the **public mirror** of an internal codebase. All contributions go through an internal review and integration process before being published back here.

### What this means for your Pull Request

1. You open a PR against `main` as usual.
2. Our team reviews your PR on GitHub (comments, change requests, etc.).
3. Once approved, your changes are **applied internally** via a patch file, tested against our internal test suite, and merged into our internal repository.
4. A sync pipeline then publishes the updated code back to this GitHub repository.
5. Your original PR is **closed** (not merged directly) with a comment confirming your contribution was accepted.

> **Your PR will not show as "Merged" on GitHub**, but your contribution is fully integrated. We will credit you in the changelog and release notes.

### Why this process?

- Our internal repository contains additional integration tests and tooling that validate changes against the full Bundledocs platform.
- This ensures every contribution is thoroughly tested before release.
- The public repository always reflects a stable, validated state.

## Reporting Issues

Before opening a new issue, please search existing issues to avoid duplicates.
When reporting a bug, include:
- Library version
- .NET runtime version
- Minimal reproduction steps
- Expected vs. actual behaviour

Open an issue at: https://github.com/Bundledocs/bundledocs-dotnet/issues/new/choose

## Pull Requests

1. Fork the repository and create your branch from `main`.
2. Make your changes, adding tests where applicable.
3. Ensure all tests pass: `dotnet test`
4. Submit your pull request with a clear description of the change.

## Development Setup

Requirements: .NET 8 SDK or later.

```bash
git clone https://github.com/Bundledocs/bundledocs-dotnet.git
cd bundledocs-dotnet
dotnet restore
dotnet build
```

Running tests requires a valid `BUNDLEDOCS_ACCESS_TOKEN` environment variable:

```bash
export BUNDLEDOCS_ACCESS_TOKEN=your-token
dotnet test
```

## Code Style

- Follow existing naming and formatting conventions.
- Keep public API changes additive where possible.
- Document any breaking changes in `CHANGELOG.md`.

## License

By contributing, you agree that your contributions will be licensed under the [Apache License 2.0](LICENSE).
