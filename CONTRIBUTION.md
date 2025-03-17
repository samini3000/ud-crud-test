# Contributing Guide 🤝

Thank you for your interest in contributing! This guide explains our development process and conventions.

## Table of Contents
- [Development Workflow](#development-workflow)
- [Issue Creation](#issue-creation)
- [Branch Naming Convention](#branch-naming-convention)
- [Commit & PR Convention](#commit--pr-convention)
- [Version Impact](#version-impact)
- [Pull Request Process](#pull-request-process)
- [Changelog Generation](#changelog-generation)
- [Code Standards](#code-standards)

## Development Workflow

1. Create an Issue
2. Create a Branch
3. Make Changes & Commit
4. Create Pull Request
5. Address Reviews
6. Merge & Release

## Issue Creation 🎯

All issues should be created with appropriate labels and detailed descriptions.

### Issue Title Format
```
<type>: <short description>
```

### Issue Types and Examples

#### Feature Request
```markdown
Title: feat: 🚀 Add user authentication system

Labels:
- feature
- enhancement

Description:
## Overview
Brief description of the feature

## Requirements
- [ ] User registration endpoint
- [ ] Login endpoint
- [ ] Password reset functionality

## Additional Context
- Must support OAuth providers
- Should comply with GDPR requirements
```

#### Bug Report
```markdown
Title: fix: 🐛 User session expires prematurely

Labels:
- bug
- fix

Description:
## Current Behavior
Describe what's happening now

## Expected Behavior
Describe what should happen

## Steps to Reproduce
1. Step 1
2. Step 2
3. Step 3

## Environment
- Browser: Chrome 98.0
- OS: Windows 11
- Device: Desktop

## Additional Context
Add any other context about the problem
```

### Issue Templates
We provide several issue templates for common scenarios:
- 🚀 Feature request
- 🐛 Bug report
- 🔐 Security issue
- 📄 Documentation
- 👷 CI/CD
- ♻️ Enhancement

### Labels
Common labels to use:
- `feature` - New features
- `bug` - Something isn't working
- `documentation` - Documentation improvements
- `enhancement` - Feature enhancements
- `security` - Security related
- `ci-cd` - CI/CD improvements
- `test` - Testing related
- `dependencies` - Dependencies updates
- `breaking-changes` - Breaking changes
- `good first issue` - Good for newcomers

## Branch Naming Convention 🌿

All branches should follow this format:
```
<type>([optional-scope])/descriptive-name
```

## Commit & PR Convention 📝

We follow [Conventional Commits](https://www.conventionalcommits.org/). Format:
```
type(scope): <emoji> <description>
```

## Types and Examples 🔍

### build: Build System
```bash
# Branch
build/webpack-config
build(deps)/webpack

# Commit
build: 🏗️ update webpack configuration
build(deps): 🧩 upgrade webpack dependencies

# PR Title
build: 🏗️ Update webpack configuration
build(deps): 🧩 Upgrade webpack dependencies
```

### chore: Maintenance
```bash
# Branch
chore/cleanup
chore(deps)/upgrade

# Commit
chore: 🧰 clean unused code
chore(deps): 🧩 update dependencies

# PR Title
chore: 🧰 Clean unused code
chore(deps): 🧩 Update dependencies
```

### ci: Continuous Integration
```bash
# Branch
ci/github-actions
ci(jenkins)/pipeline

# Commit
ci: 👷 setup GitHub Actions
ci(jenkins): 👷 optimize pipeline

# PR Title
ci: 👷 Setup GitHub Actions
ci(jenkins): 👷 Optimize pipeline
```

### docs: Documentation
```bash
# Branch
docs/api-guide
docs(auth)/setup

# Commit
docs: 📄 update API documentation
docs(auth): 📄 add authentication guide

# PR Title
docs: 📄 Update API documentation
docs(auth): 📄 Add authentication guide
```

### feat: Features
```bash
# Branch
feat/user-auth
feat(api)/endpoints

# Commit
feat: 🚀 implement user authentication
feat(api): 🚀 add new endpoints

# PR Title
feat: 🚀 Implement user authentication
feat(api): 🚀 Add new endpoints
```

### fix: Bug Fixes
```bash
# Branch
fix/login-error
fix(api)/validation

# Commit
fix: 🐛 resolve login timeout issue
fix(api): 🐛 fix validation errors

# PR Title
fix: 🐛 Resolve login timeout issue
fix(api): 🐛 Fix validation errors
```

### perf: Performance
```bash
# Branch
perf/query-optimize
perf(cache)/redis

# Commit
perf: ⚡️ optimize database queries
perf(cache): ⚡️ implement Redis caching

# PR Title
perf: ⚡️ Optimize database queries
perf(cache): ⚡️ Implement Redis caching
```

### refactor: Code Refactoring
```bash
# Branch
refactor/auth-flow
refactor(api)/structure

# Commit
refactor: ♻️ simplify authentication flow
refactor(api): ♻️ restructure endpoints

# PR Title
refactor: ♻️ Simplify authentication flow
refactor(api): ♻️ Restructure endpoints
```

### revert: Reverts
```bash
# Branch
revert/feature-x
revert(auth)/changes

# Commit
revert: ⏪️ revert user authentication
revert(auth): ⏪️ roll back changes

# PR Title
revert: ⏪️ Revert user authentication
revert(auth): ⏪️ Roll back changes
```

### style: Code Style
```bash
# Branch
style/formatting
style(css)/cleanup

# Commit
style: 🎨 format JavaScript files
style(css): 🎨 clean up stylesheets

# PR Title
style: 🎨 Format JavaScript files
style(css): 🎨 Clean up stylesheets
```

### test: Testing
```bash
# Branch
test/integration
test(api)/coverage

# Commit
test: 🧪 add integration tests
test(api): 🧪 improve test coverage

# PR Title
test: 🧪 Add integration tests
test(api): 🧪 Improve test coverage
```

## Version Impact 🔢

- **Major** (1.x.x): Breaking changes (with `breaking-changes` label or `!` notation)
- **Minor** (x.1.x): New features (`feat` type)
- **Patch** (x.x.1): Bug fixes and other changes

## Pull Request Process 🔄

1. Ensure branch name follows convention
2. Create PR with conventional title
3. Add description detailing changes
4. Link related issues
5. Request reviews
6. Address feedback
7. Merge when approved

## Changelog Generation 📋

Changelogs are auto-generated using Release Drafter based on PR labels and titles. PRs with `skip-changelog` label are excluded.

## Code Standards 📌

- Keep commits atomic and focused
- Follow existing code style
- Add tests for new features
- Update documentation
- Use `dotnet format` and `dotnet csharpier .` before committing

For detailed examples of each change type, see our [releases page](https://github.com/pouryanoufallah96/cybernod/releases).
