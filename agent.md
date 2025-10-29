# Alexandria Lab Agent Guide

## Repository Overview
- **Purpose:** Curated knowledge base and tooling for Alexandria Lab's computational design workflows, including Grasshopper components, research datasets, and reference literature.
- **Primary Domains:** Rhinoceros/Grasshopper development, AI-assisted design research, and documentation of parametric design methodologies.

### Top-Level Structure
- `alexandria-application-files/` – Authoring assets for the Alexandria Grasshopper plugin.
  - `Libraries/` – Third-party `.gha`, `.dll`, and related binaries required by the plugin. Treat these as read-only unless a dependency update is coordinated.
  - `UserObjects/` – Packaged Grasshopper user objects/components. Maintain semantic versioning within metadata when updating.
  - `scripts/` – Source code for Grasshopper scripts and custom components (primarily Python, with occasional C#).
  - `sandbox-files/` – Experimental `.gh` and `.3dm` models. Useful for reproducing workflows; avoid committing oversized or proprietary data.
- `artificial-intelligence-dataset/` – Notes, prompt collections, and structured CSV resources relating to AI experiments.
- `parametric-design-literature/` – Reference PDFs and manuals; keep additions organized and ensure file names remain descriptive.
- `README.md` – High-level mission statement and project outline.

## Contribution Principles
1. **Preserve design reproducibility.** Document any workflow assumptions, plugin versions, and Rhino/Grasshopper build numbers in accompanying notes or script headers.
2. **Respect binary assets.** Do not modify or version large binaries without confirming licensing and compatibility. Use LFS for new assets above 50 MB.
3. **Prefer additive documentation.** When extending research notes or datasets, append dated sections instead of overwriting historical context.

## Coding Guidelines
### Python (Grasshopper & Rhino Scripts)
- Follow PEP 8 while accommodating RhinoCommon naming (e.g., `Point3d`).
- Include module metadata (`__author__`, `__version__`) and a docstring describing component inputs/outputs, as seen in existing scripts.
- Access RhinoCommon via `import Rhino` / `from Rhino.Geometry import *`; avoid wrapping these imports in `try/except`.
- Validate Grasshopper inputs defensively—check types (`Polyline`, `PolylineCurve`) before using geometry operations.
- Prefer pure functions where possible; isolate Grasshopper component side effects to the `RunScript` entry point or explicit output assignments.
- Use Rhino document tolerances (`Rhino.RhinoDoc.ActiveDoc.ModelAbsoluteTolerance`) when offsetting or comparing geometry, and guard against `None` returns from Rhino API calls.

### C# Script Components
- Target .NET Framework conventions compatible with Grasshopper (usually 4.8).
- Provide XML documentation comments (`///`) for public members so end users can access inline help.
- Keep namespaces aligned with component grouping (e.g., `Alexandria.Components.Patterns`).

### Data & Research Notes
- CSV files should include header rows and UTF-8 encoding. When adding fields, document schema changes in the corresponding Markdown notebooks.
- Markdown notebooks (`*-notebook.md`, `working-notes.md`) should use second-level headings (`##`) for dated entries and include links to relevant experiments or outputs.

## Testing & Validation
- For Python scripts, run Grasshopper test definitions or minimal RhinoPython consoles to confirm geometry outputs before committing.
- When changes affect binary libraries or user objects, open a representative `.gh` file from `sandbox-files/` and validate component loading.
- Document validation steps in commit messages or accompanying Markdown updates.

## Documentation Standards
- Maintain consistent terminology with the README (e.g., "Alexandria Grasshopper Plugin", "Knowledge Base").
- Embed external references using descriptive link text; avoid bare URLs.
- Keep diagrams or captures organized under a directory named `media/` (create within the relevant section if needed).

## Workflow Expectations
- Branch naming: `feature/<topic>`, `fix/<topic>`, or `docs/<topic>`.
- Write concise, action-oriented commit messages (imperative mood) summarizing the change scope.
- Run `git lfs track` for any newly added binary formats not already tracked.
- Coordinate major dependency updates through issues/PR discussion to avoid breaking existing Grasshopper definitions.

## Communication Notes
- When introducing new components or scripts, include a short usage example or GIF in the PR description or associated docs.
- Clearly flag experimental work placed in `sandbox-files/` so collaborators understand stability expectations.
