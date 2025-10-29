# Hello world tour

This guided exercise walks through a complete Alexandria Grasshopper workflow. You will
duplicate a sandbox definition, wire up its scripted components, and produce a quick render
that proves your environment is configured correctly.

## Before you start

- Install the Alexandria plugin bundle by following the [user guide](user-guide.md#install-the-alexandria-plugin-bundle).
- Confirm you can open `trial-gh-graph_mapping.gh` from `alexandria-application-files/sandbox-files/`.
- Prepare a folder where you can save working copies and screenshots. Keeping artifacts
  outside the repository prevents accidental commits of large binary files.

## Step 1 – Duplicate the sandbox file

1. Copy `trial-gh-graph_mapping.gh` into your personal workspace. Rename it to
   `hello-world-tour.gh`.
2. Launch Rhino, open Grasshopper, and load your copy. The Alexandria tabs should appear in
   the component ribbon without dependency warnings.

## Step 2 – Inspect the graph mapper rig

1. Hover over the *Graph Mapper* component. The Alexandria version includes presets for
   easing curves. Right-click to switch the mapper to **Bezier** mode.
2. Drag a few control points to exaggerate the curve. Watch how the preview geometry reacts
   in the viewport—this confirms Rhino is responding to Grasshopper changes.

## Step 3 – Wire Alexandria components

1. Locate the **Cell Creator** and **Cell Patternizer** user objects.
2. Connect the Graph Mapper output to the Cell Creator’s modifier input. If you do not see
   the expected ports, open the component’s Help bubble to review the parameter names listed
   in the [component reference](component-reference.md#pattern-and-tiling-tools).
3. Feed the Cell Creator grid output into the Cell Patternizer. Toggle a few pattern
   options until you see a repeating motif emerge.

## Step 4 – Add color and exports

1. Drop the **Color Picker** user object onto the canvas. Supply a gradient or manual color
   to tint the pattern output. You can link a Rhino material for advanced shading.
2. When you are satisfied, bake the geometry into a new Rhino layer. Use `-ViewCaptureToFile`
   (or the viewport capture toolbar) to save an image into your working folder.
3. Optionally, note your steps in a new dated entry inside
   `artificial-intelligence-dataset/working-notes.md` so collaborators can reproduce the
   results.

## Step 5 – Capture documentation assets

- Take a screenshot of the Grasshopper canvas showing the key connections.
- Capture the Rhino viewport or render that illustrates the final output.
- Store images inside a local `media/` folder next to your working copy. Screenshots can be
  attached to issues or pull requests when you share findings.

## Troubleshooting tips

| Symptom | Suggested fix |
| --- | --- |
| Components appear orange or red | Ensure you copied every file from `alexandria-application-files/Libraries/` and unblocked the DLLs. |
| Graph Mapper does not influence geometry | Verify its output is wired into the Cell Creator (or another Alexandria component) and that Preview is enabled. |
| Patternizer output looks distorted | Reset the component or switch to a simpler pattern mode before retuning the Graph Mapper. |

Document notable discoveries in the [release notes](release-notes.md) so future updates can
highlight new workflows or compatibility changes.
