# User guide

The Alexandria Grasshopper plugin bundles curated components, scripts, and example files that accelerate parametric design research. This guide explains how to install the toolkit, load example content, and explore the sandbox safely.

## System requirements

| Requirement | Recommended specification |
| --- | --- |
| Rhinoceros | Rhino 7 SR24 or newer with Grasshopper enabled |
| Operating system | Windows 10/11 64-bit |
| Storage | At least 2 GB free for plugin libraries, user objects, and sandbox files |
| Permissions | Ability to install Rhino plugins and write to the Rhino `Libraries` directory |

> **Tip:** The sandbox ships with binaries compiled against .NET Framework 4.8. Ensure your Rhino installation is up to date to avoid missing dependency warnings.

## Install the Alexandria plugin bundle

1. **Download or clone this repository.** Place it in a location that Rhino can access (e.g., `C:\\Projects\\alexandria-lab-sandbox`).
2. **Copy Grasshopper libraries.**
   - Navigate to `alexandria-application-files/Libraries/`.
   - Copy the contents into your Rhino `Libraries` folder (typically `%APPDATA%\\Grasshopper\\Libraries`). Maintain the existing folder structure so bundled releases remain grouped (for example, `Alexandria 1.0.0/`).
3. **Install user objects.**
   - Copy files from `alexandria-application-files/UserObjects/` into `%APPDATA%\\Grasshopper\\UserObjects`.
   - Keep semantic version suffixes intact. They identify compatibility between components and documentation.
4. **Sync supporting scripts.**
   - If you rely on standalone Python or C# scripts, import the files from `alexandria-application-files/scripts/` directly into your Grasshopper definition or copy them into a custom scripts directory tracked by Grasshopper.
5. **Restart Rhino.** Launch Rhino and open Grasshopper (`File → New`). Confirm that the Alexandria components appear under their designated tab.

## Directory tour

Use the following map to understand where assets live:

| Path | Purpose |
| --- | --- |
| `alexandria-application-files/Libraries/` | Compiled `.gha` libraries and third-party dependencies required by the plugin. |
| `alexandria-application-files/UserObjects/` | Alexandria user objects (`.ghuser`) grouped by feature and version. |
| `alexandria-application-files/scripts/` | Source scripts that back experimental or lightweight components. |
| `alexandria-application-files/sandbox-files/` | Sample `.gh` and `.3dm` workflows that demonstrate component combinations. |
| `artificial-intelligence-dataset/` | Prompt notebooks, working notes, and CSV indexes documenting AI-driven design research. |
| `parametric-design-literature/` | Reference PDFs and manuals that contextualize the toolkit. |

## First-run checklist

Follow this quick exercise to confirm everything is configured correctly:

1. **Open the `sandbox-files` examples.** Launch `alexandria-application-files/sandbox-files/intro-tour.gh` (or any example provided).
2. **Verify component loading.** Grasshopper should load Alexandria tabs without orange or red dependency warnings. If warnings appear, confirm you copied every file from `Libraries/`.
3. **Inspect user object metadata.** Right-click an Alexandria component and select *Help*. Ensure the description and version match the documentation.
4. **Review bundled documentation.** Open `docs/user-guide.md` (this file) or `docs/contributor-guide.md` to cross-check feature descriptions.
5. **Save your test definition under a new name.** Avoid overwriting sandbox files so the repository remains a reliable reference.

## Working with sandbox examples

- **Duplicate before editing.** Copy sandbox files into a personal workspace before experimenting. This prevents accidental changes to reference assets.
- **Log variations.** If you discover a new workflow, capture notes in a new Markdown file under `artificial-intelligence-dataset/` or append to the relevant notebook with an ISO-formatted date.
- **Share renders and screenshots.** Store media alongside the experiment that produced it (for example, `sandbox-files/media/intro-tour.png`).

## Troubleshooting

| Symptom | Recommended action |
| --- | --- |
| Alexandria components fail to load | Confirm Rhino's *Block Unblock* setting allows third-party plugins and that every file in `Libraries/` is unblocked (right-click → *Properties* → enable *Unblock*). |
| User objects reference missing scripts | Copy the latest contents of `alexandria-application-files/scripts/` and relink script components inside Grasshopper. |
| Sample files open with missing dependencies | Review the README inside each sandbox directory for required third-party plugins such as Parakeet or Starfish. Install matching versions before reopening the definition. |
| Documentation feels outdated | Check the repository's `main` branch for updates or open an issue describing the discrepancy so contributors can refresh the guides. |

## Additional resources

- [Contributor guide](contributor-guide.md) – Learn how to propose changes, follow coding standards, and document research.
- [Rhino plugin management](https://discourse.mcneel.com/c/plug-ins/7) – Official Rhino forum for plugin troubleshooting.
- [Grasshopper primer](https://www.grasshopper3d.com/page/tutorials-1) – Refresh core Grasshopper concepts if you are new to visual scripting.
