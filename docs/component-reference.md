# Component reference

This catalog summarizes the Alexandria Grasshopper user objects and scripted utilities that
ship with the sandbox. Use it to discover available tools, review inputs and outputs, and
locate supporting documentation before wiring components into a definition.

## How to read this guide

- **File name** corresponds to the asset stored in `alexandria-application-files/UserObjects/`
  or `alexandria-application-files/scripts/`.
- **Inputs/Outputs** list the primary parameters exposed on the component. Refer to the
  component Help bubble in Grasshopper for exact port names.
- **Dependencies** call out third-party libraries or Alexandria assets that must be present.
- When you update a component, append your changes to the relevant table and link supporting
  sandbox examples.

## Grid and array generators

| Component | File name | Inputs | Outputs | Dependencies | Notes |
| --- | --- | --- | --- | --- | --- |
| Cell Creator | `Cell Creator.ghuser` / `cell creator.py` | Grid dimensions, cell size, origin point | Structured grid of cells for downstream patterning | Alexandria Python runtime | Establishes consistent cell ordering for pattern tools. Documented more fully in `outputs.csv`. |
| Construct Geometry Array | `Construct Geometry Array.ghuser` | Base geometry, X/Y counts, spacing | Arrayed geometry instances | Native Grasshopper | Ideal for populating facades or modular assemblies. |
| Construct Point | `Construct Point_2.ghuser` | X, Y, Z coordinates | Point geometry | Native Grasshopper | Convenience wrapper that exposes Alexandria defaults (units, tolerance). |

## Pattern and tiling tools

| Component | File name | Inputs | Outputs | Dependencies | Notes |
| --- | --- | --- | --- | --- | --- |
| Cell Patternizer | `Cell Patternizer.ghuser` / `cell patternizer.py` | Cell grid, pattern selector, modifiers | Patterned panels, curves, or meshes | Alexandria Python runtime | Use alongside Cell Creator for compatible grid indices. Document enhancements in `outputs.csv`. |
| Attractor Curve | `Attractor Curve_1.ghuser` | Curve reference, geometry to influence, falloff distance | Weighted values or transformed geometry | Native Grasshopper | Adjusts behavior across a curve. Pair with Attractor Point for hybrid effects. |
| Attractor Point | `Attractor Point_1.ghuser` | Point reference, geometry to influence, falloff distance | Weighted values or transformed geometry | Native Grasshopper | Ideal for radial gradients or localized deformations. |
| Color Picker | `Color Picker.ghuser` | Palette list, interpolation factor | ARGB color swatch | Native Grasshopper | Useful for tinting pattern outputs or visualizing analysis results. |

## Image and data-driven utilities

| Component | File name | Inputs | Outputs | Dependencies | Notes |
| --- | --- | --- | --- | --- | --- |
| Image Sampler | `image sampler.py` | Image path, sample grid, mapping mode | Numeric matrix controlling geometry | Rhino Python, PIL (optional) | Drives heightfields or density grids based on tonal values. |
| Graph Mapping Sandbox | `trial-gh-graph_mapping.gh` | Graph Mapper control points | Pattern modulation preview | Alexandria user objects | Featured in the [hello world tour](hello-world-tour.md). |

## Maintenance and support tools

| Component | File name | Inputs | Outputs | Dependencies | Notes |
| --- | --- | --- | --- | --- | --- |
| Cluster Unlocker | `cluster unlocker.cs` | Grasshopper cluster path, optional password | Unlocked cluster definition | RhinoCommon, .NET 4.8 | Use sparingly and document any unlocked clusters in PR notes. |
| Library Inspector | *(Add new row when asset is published)* | | | | |

## Updating this reference

1. Confirm the component metadata (name, description, version) inside Grasshopper matches the
   details in this table.
2. List new sandbox examples in the [sandbox index](../alexandria-application-files/sandbox-files/README.md).
3. Update the [data dictionary](../artificial-intelligence-dataset/data-dictionary.md) if you
   add supporting CSV entries.
4. Add a short note to the [release notes](release-notes.md) when you introduce a new
   component or adjust behavior that affects existing definitions.
