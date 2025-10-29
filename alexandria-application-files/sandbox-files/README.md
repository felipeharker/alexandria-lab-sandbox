# Sandbox index

This directory houses working Grasshopper (`.gh`) and Rhino (`.3dm`) files that demonstrate
Alexandria components in context. Duplicate files before experimenting so the canonical
examples remain intact for other collaborators.

## Available studies

| File | Highlights | Dependencies | Notes |
| --- | --- | --- | --- |
| `trial-gh-graph_mapping.gh` | Graph Mapper-driven modulation of Alexandria pattern components. | Alexandria user objects, native Grasshopper | Foundation for the [hello world tour](../../docs/hello-world-tour.md). Save derivatives outside the repository. |
| `trial-gh-nurbs_curve.gh` | NURBS curve exploration showcasing curve evaluation, tangents, and attractor logic. | Native Grasshopper, Alexandria Attractor tools | Useful when testing curve-based façade studies. |
| `trial-ghpython-library.gh` | Demonstrates calling the Alexandria Python scripts from a Grasshopper definition. | `alexandria-application-files/scripts/`, Rhino Python | Keep script paths synchronized when moving the file. |
| `trial-ghpython-library.3dm` | Rhino scene paired with `trial-ghpython-library.gh` for viewport captures. | Rhino 7+ | Open alongside the Grasshopper definition for consistent camera views. |

## Adding new examples

1. Store `.gh` and supporting `.3dm` files in this folder. Use descriptive, hyphenated names.
2. Include a short bullet under *Available studies* describing the learning goal and
   dependencies.
3. Commit screenshots or renders to a local `media/` subdirectory if they aid discovery.
4. Mention the addition in the [release notes](../../docs/release-notes.md) so users know a
   new example is available.
