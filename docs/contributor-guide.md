# Contributor guide

This guide standardizes how we extend the Alexandria Lab sandbox. It consolidates repository structure notes, workflow expectations, coding standards, and validation checklists so every contribution remains reproducible and discoverable.

## Quick start

1. **Plan the work.** Draft or reference an issue that captures the problem, scope, and acceptance criteria.
2. **Create a topic branch.** Use `feature/<summary>`, `fix/<summary>`, or `docs/<summary>` naming.
3. **Make focused commits.** Commit in logical slices with imperative messages (for example, `Add attractor curve presets`).
4. **Document the change.** Update Markdown files, Grasshopper metadata, and datasets that describe or depend on your update.
5. **Validate assets.** Run Grasshopper tests, sanity-check data additions, and note manual validation steps.
6. **Open a pull request.** Summarize scope, list validation steps, and link supporting screenshots or renders.

## Repository architecture

| Path | Ownership notes |
| --- | --- |
| `README.md` | High-level mission statement and quick links to documentation. Update when the project's scope evolves. |
| `docs/` | Living documentation, including this contributor guide and the end-user guide. Keep sections organized with sentence-case headings. |
| `alexandria-application-files/` | Shipping assets for the Alexandria Grasshopper plugin. Preserve semantic versioning and bundled release folders. |
| `artificial-intelligence-dataset/` | Research notebooks, prompt collections, and CSV indices. Append dated entries instead of overwriting history. |
| `parametric-design-literature/` | Reference PDFs and manuals. Maintain descriptive filenames and record additions in dataset indices. |

## Workflow expectations

### Issues and planning

- Open issues for new features, documentation overhauls, or data imports.
- Capture Rhino/Grasshopper version numbers, plugin dependencies, and validation steps in the issue description when relevant.

### Branching and commits

- Branch from `main` using `feature/`, `fix/`, or `docs/` prefixes.
- Keep commits scoped to a single concern and use imperative tense.
- Reference issues in commit messages or pull requests when applicable.

### Pull requests

Include the following details in every PR description:

- Summary of the change and why it matters.
- Checklist or bullet list of validation steps performed.
- Screenshots, GIFs, or renders for user-facing updates.
- Notes about follow-up work or known limitations.

## Coding and asset standards

### Grasshopper libraries and user objects

- Place compiled `.gha` files under `alexandria-application-files/Libraries/`. Maintain nested release folders such as `Alexandria 1.0.0/` and include a short README if you ship a new build.
- Store user objects (`.ghuser`) in `alexandria-application-files/UserObjects/`. Use semantic version suffixes (`Pattern 3.5.7.ghuser`) to track compatibility changes.
- Provide rich component metadata: name, description, category, subcategory, and version that align with documentation.
- Supply a sandbox example (`.gh`) or animated GIF for each user-facing feature when feasible.

### Scripts (`.py`, `.cs`)

- Follow PEP 8 for Python and conventional .NET naming for C#.
- Document inputs, outputs, and assumptions in a module-level docstring or XML summary comments.
- Reference Rhino tolerances via `Rhino.RhinoDoc.ActiveDoc.ModelAbsoluteTolerance` instead of hard-coding values.
- Keep side effects isolated to Grasshopper entry points (for example, `RunScript`).

### Data tables (`.csv`)

- Preserve header rows exactly as defined. Update companion documentation when you add or rename fields.
- Append new rows at the end of the file. Avoid trailing commas and ensure UTF-8 encoding.
- Reuse existing categorical vocabularies (`PDF`, `web`, `data`, `graphic`; `low`, `med`, `high`).

### Documentation (`.md`)

- Use sentence case headings and wrap text to a readable width (~100 characters).
- Embed links with descriptive text instead of bare URLs.
- Dated research notes should use ISO format (for example, `## 2025-10-01`).
- Store supporting media in a local `media/` subdirectory near the content it illustrates.

## Validation checklist

Before requesting review, confirm that you:

- [ ] Updated documentation that references your changes.
- [ ] Verified Grasshopper components or scripts load without missing dependencies.
- [ ] Ran applicable automated or manual tests and documented the results.
- [ ] Confirmed third-party libraries are licensed for redistribution and tracked with Git LFS when necessary.
- [ ] Avoided committing oversized binaries (>50 MB) without coordinating storage strategy.

## Review tips

- **For reviewers:** Compare the change against the validation checklist, open linked sandbox files when necessary, and verify documentation clarity.
- **For authors:** Address feedback promptly, push follow-up commits with clear messages, and update the PR summary if scope changes.

## Communication and knowledge sharing

- Capture experimental insights in the relevant notebook under `artificial-intelligence-dataset/`, prefacing entries with the current date.
- Highlight new workflows or design learnings in release notes or the repository README so other contributors can discover them quickly.
- When adding third-party dependencies, document their source, license, and version in both the PR description and an appropriate Markdown file.

## Additional references

- [User guide](user-guide.md) – Installation steps and usage patterns for designers.
- [Alexandria Lab agent guide](../agent.md) – Repository-wide expectations provided to automation agents.
