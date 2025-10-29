# Contribution Standards

This document describes the expectations for contributing to the Alexandria Lab repository. It is designed to preserve the clarity of the research artifacts collected here and to keep the Grasshopper tooling in `alexandria-application-files/` production ready.

## Repository Structure & Ownership

- **Root documentation (`README.md`)** – outlines the vision, objectives, and deliverables for Alexandria's computational design practice. Update this file when the overall scope or objectives shift.
- **`alexandria-application-files/`** – shipping assets for the Alexandria Grasshopper plugin, including:
  - `Libraries/` – external dependencies (`*.gha`, `*.dll`) and Alexandria library builds (e.g., `Alexandria 1.0.0`).
  - `UserObjects/` – Grasshopper user objects (`*.ghuser`) named with version numbers (`Pattern 1.2.4.ghuser`, `Attractor Curve_1.ghuser`, etc.).
  - `scripts/` – Grasshopper Python/C# scripts such as `cell creator.py`, `cluster unlocker.cs`, and `image sampler.py`.
  - `sandbox-files/` – exploratory Grasshopper (`*.gh`) and Rhino (`*.3dm`) working files.
- **`artificial-intelligence-dataset/`** – AI research assets, including structured CSV indices (`resource-index.csv`, `web-resource-index.csv`, `outputs.csv`) and living documentation (`llm-master.md`, `prompts-notebook.md`, `working-notes.md`).
- **`parametric-design-literature/`** – curated reference PDFs (Grasshopper manuals, Hopific guides, etc.) and related documentation bundles.

Each contribution should target the appropriate directory and respect the existing naming and organizational conventions.

## Workflow Expectations

1. **Plan your change** – open an issue describing the update or reference an existing issue.
2. **Create a feature branch** – prefer `topic/<short-description>` or `fix/<short-description>` naming.
3. **Keep commits focused** – each commit should cover a single logical change with a descriptive message (e.g., `Add Pattern 1.8 attractor tool` rather than `updates`).
4. **Document your work** – update or create markdown files when workflows, data sources, or design assets change.
5. **Run validations** – execute any relevant Grasshopper checks or data linters where applicable; document manual validation steps in the pull request if automated tests are unavailable.
6. **Submit a pull request** – summarize scope, highlight affected files, and link supporting documentation or renders.

## Standards by Asset Type

### Documentation & Notes (`*.md`)

- Use sentence case headings and wrap text at ~100 characters for readability.
- Provide context for new experiments in `working-notes.md` and cite external resources in `llm-master.md` and `prompts-notebook.md`.
- Append new notes chronologically (newest at the top) with ISO-formatted dates (e.g., `## 2025-10-01`).
- Embed hyperlinks in Markdown format and ensure shared ChatGPT conversations or references are accessible.

### Data Tables (`*.csv`)

- Preserve header rows exactly as defined (e.g., `resource name,type (PDF / web / data / graphic),content type,notes,value (low / med / high)`).
- Append new rows at the end of the file and maintain comma-separated formatting without trailing delimiters.
- Keep categorical values consistent with existing taxonomy (`PDF`, `web`, `data`, `graphic`; `low`, `med`, `high`).
- When ingesting new resources, cross-reference `resource-index.csv` and `web-resource-index.csv` to avoid duplicates.

### Grasshopper Libraries & User Objects

- Place compiled plugin builds in `alexandria-application-files/Libraries/` and ensure version directories (such as `Alexandria 1.0.0`) contain a `README` or release notes when applicable.
- Name user objects with semantic version components (`Pattern 3.5.7.ghuser`) and update version suffixes only when functionality changes.
- For new user objects:
  - Include a succinct description in the Grasshopper component metadata.
  - Provide example usage in `sandbox-files/` or link to a `.gh` test file.
  - Verify compatibility with bundled libraries (e.g., `Starfish.gha`, `parakeet`).

### Scripts (`*.py`, `*.cs`)

- Keep script filenames human-readable and aligned with their component counterparts (`cell creator.py`, `cell patternizer.py`).
- Document required Grasshopper inputs and expected outputs in leading docstrings.
- Follow PEP 8 for Python scripts and standard C# conventions for `.cs` files.
- Avoid hard-coded absolute paths; use relative references or Rhino document paths.

### Sandbox & Experimentation Files

- Store exploratory Grasshopper/Rhino files in `sandbox-files/` and prefix filenames with the experiment type (`trial-gh-`, `trial-ghpython-`).
- Include inline notes or a companion Markdown snippet describing the objective of each experiment.
- Promote stable experiments into `UserObjects/` or documentation once they are ready for reuse.

### Parametric Design Literature

- Save reference PDFs with descriptive, kebab-cased names (`grasshopper-manual.pdf`, `voronoi-diagrams-definitions-formal-properties.pdf`).
- When adding new literature, update the relevant CSV indices in `artificial-intelligence-dataset/` to keep the library searchable.

## Review Checklist

Before requesting review, confirm that you:

- [ ] Updated documentation and indices affected by the change.
- [ ] Validated new Grasshopper components or scripts in Rhino.
- [ ] Added sample files or screenshots for user-facing features where practical.
- [ ] Confirmed licensing compatibility for third-party libraries placed in `Libraries/`.
- [ ] Ensured large binary assets (PDFs, `*.gha`, `*.dll`) are essential and versioned appropriately.

Following these standards helps keep Alexandria Lab's research archive and tooling cohesive, discoverable, and production ready.