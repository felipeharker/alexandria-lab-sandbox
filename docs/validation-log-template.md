# Validation log template

Use this template to capture manual or automated testing steps for Alexandria updates. Copy
it into a new Markdown file (for example, `project-documentation/validation-logs/2025-02-14.md`)
or append it to an issue when documenting QA.

```
# Validation log – YYYY-MM-DD

## Context
- Related issue or pull request: <link>
- Author: <name>
- Assets touched: <components, datasets, documentation>

## Test matrix
| Scenario | Steps | Expected result | Status |
| --- | --- | --- | --- |
| Example – Load Cell Creator sandbox | Open `trial-gh-graph_mapping.gh` and enable preview. | Alexandria components load without dependency warnings. | ✅ |
|  |  |  |  |

## Screenshots or captures
- <link to `media/` asset>

## Notes
- Observations, follow-up tasks, or blockers.
```

Store completed logs alongside the feature branch or link them in the PR description so
reviewers can retrace the validation path.
