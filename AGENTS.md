# Agent Instructions — Unity Compositor Layers

A Unity sample project demonstrating the OVROverlay / Compositor Layers API across five scenes (Intro, Performance, Independence, LayerShapes, Filtering) selectable via an in-headset menu.

## Source-of-truth files (read these first, do not duplicate their contents in this file)

For setup, build steps, SDK versions, and project layout, read:

- `README.md` — official setup, scene-by-scene description
- `ProjectSettings/ProjectVersion.txt` — Unity editor version
- `Packages/manifest.json` and `Packages/packages-lock.json` — Unity package versions
- `Assets/Scenes/` — the five demo scenes (Intro is the entry point)
- `LICENSE` — license terms

## Quest / Horizon-specific notes

- Open the Intro scene first — the in-app menu (☰ button) is what drives navigation between the five demo scenes, not the build settings.
- The Performance scene exists specifically to stress-test compositor layer cost. Per-frame compositor work happens at the OS layer and won't show up in normal Unity profilers — use OVR Metrics or platform tools rather than Unity's CPU/GPU timeline alone.
- Compositor layers only render a predefined set of mesh shapes (see `LayerShapes` scene). Refactors must stay within that set — arbitrary geometry is not supported.
- Git LFS is used by this repo — run `git lfs install` before cloning or assets will be pointer files.

# Meta Quest tooling

This is a Meta Quest / Horizon OS sample. The bespoke intro above is the source of truth for what this project is and how it's built — use it (and the files it points at) instead of restating facts from memory.

When the user asks anything about Quest device behavior, build / deploy / debug / capture flows, on-device performance, or Horizon OS APIs, reach for these tools instead of generic Unity answers:

- **`hzdb`** — Quest-aware ADB wrapper (device list, install / launch / stop, logs, screenshots, Perfetto traces, on-device docs search). Already wired up as an MCP server via `.mcp.json`, `.vscode/mcp.json`, and `.cursor/mcp.json`. Also runnable directly: `npx -y @meta-quest/hzdb <subcommand>`.
- **Meta Quest Agentic Tools** — the full skill set, including Unity-specific skills: <https://github.com/meta-quest/agentic-tools>. Install per your client (Claude Code: `/plugin install meta-vr@meta-quest`; Gemini CLI: `gemini extensions install https://github.com/meta-quest/agentic-tools`; Cursor / VS Code: install the **Meta Horizon** extension from the Marketplace).

A few behavior expectations:

- **Read this repo's files first.** Before answering anything project-specific, read `README.md` and whichever source-of-truth files the intro above points at. Don't restate their contents in chat — quote or link instead.
- **Use `hzdb` for device-side work.** Anything that touches an attached Quest (install, launch, logs, screenshot, capture, manifest inspection) goes through `hzdb`, not raw `adb`.
- **Check live Horizon OS docs before answering API questions.** `hzdb docs search "..."` queries the live docs; training data on Horizon OS APIs goes stale fast.
- **Don't fabricate SDK / engine versions.** If a version isn't visible in this repo's files, say so rather than guessing.
