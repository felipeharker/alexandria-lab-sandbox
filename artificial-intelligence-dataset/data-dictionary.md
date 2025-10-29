# AI dataset data dictionary

This reference explains the CSV resources that accompany Alexandria Lab's AI experiments.
Update the appropriate section whenever you add a column, adjust allowed values, or create a
new dataset.

## `resource-index.csv`

| Column | Description | Allowed values / format | Notes |
| --- | --- | --- | --- |
| `resource name` | Slug used to reference the asset in notebooks and scripts. | Lowercase kebab case. | Match the filename when possible for easier tracing. |
| `type (PDF / web / data / graphic)` | High-level medium classification. | `PDF`, `web`, `data`, `graphic`. | Extend only after discussing new categories in a PR. |
| `content type` | Genre or intent of the material. | Free text (e.g., `reference documentation`, `research journal`). | Use consistent phrases to aid filtering. |
| `notes` | Short description of relevance or quality. | Markdown-compatible sentence. | Mention authorship, scope, or caveats. |
| `value (low / med / high)` | Relative usefulness rating. | `low`, `med`, `high`. | Reflect confidence after reviewing the material. |

## `web-resource-index.csv`

| Column | Description | Allowed values / format | Notes |
| --- | --- | --- | --- |
| `title` | Human-readable name of the resource. | Plain text. | Keep aligned with the linked page title. |
| `link` | URL of the resource. | Full `https://` URL. | Verify accessibility before committing. |
| `description` | Summary of the page. | One or two sentences. | Replace `TBD` placeholders as you review each link. |

## `outputs.csv`

| Column | Description | Allowed values / format | Notes |
| --- | --- | --- | --- |
| `title` | Name of the output or tool. | Plain text. | Often matches a user object or script name. |
| `description` | What the asset delivers. | One-sentence summary. | Keep under 120 characters when possible. |
| `code` | Filename of the backing script. | Relative path (e.g., `cell creator.py`). | Use `n/a` if the output is purely procedural. |
| `bugs` | Known issues. | `none` or comma-separated list. | Escalate critical bugs by opening an issue. |
| `fixes` | Proposed fixes in progress. | `none` or comma-separated list. | Link to issues or PRs when available. |
| `feature requests` | Enhancements that would improve the asset. | `none` or comma-separated list. | Promote items to issues when work begins. |
| `additional notes` | Context that does not fit elsewhere. | Optional sentence. | Capture validation status, dependencies, or TODOs. |

## Maintenance checklist

- Validate CSV formatting (UTF-8, header row, no trailing commas) before committing.
- Update this dictionary alongside any schema change so downstream scripts stay in sync.
- Mention notable updates in the [release notes](../docs/release-notes.md) and link to the
  relevant dataset entry from issues or PRs.
