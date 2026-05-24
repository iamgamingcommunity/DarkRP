# Auto Restart

One-click editor restart for [s&box](https://sbox.game). Trigger a restart from the menu and the editor automatically relaunches straight back into the project you're working on - no launcher detour, no manual reopen. Properly prompts for any unsaved scenes first.

---

## Quick start

1. **Install the library** — clone this repo into your s&box project's `Libraries/` folder, or pull as a published package. Editor picks it up on next launch.
2. **Open any project in the editor** — the `Editor → Auto Restart` menu appears in the menu bar.
3. **Trigger a restart** via the menu.
4. The editor closes, a fresh `sbox-dev.exe` spawns with the same command-line arguments and `-project <currentproject>`, and you're back in your project a moment later.

---

## Menu

| Item | Behavior |
|---|---|
| **Editor → Auto Restart → Restart Editor** | Safe restart. Checks for unsaved scenes first. If clean, simple "Restart now?" confirm. If dirty, three-button dialog: **Save and Restart** / **Restart Without Saving** / **Cancel**. |
| **Editor → Auto Restart → Restart Editor (Force)** | Skips the dialog and restarts immediately. If any scenes are dirty their changes are discarded and a warning is logged listing every discarded scene. |
| **Editor → Auto Restart → About** | Version and usage info. |

---

## What problem does this solve?

The s&box engine ships a public `EditorUtility.RestartEditor()` but doesn't expose it anywhere in the default UI. There's no menu item, no shortcut, no toolbar button - the API just sits there unused. Auto Restart wires it up.

It also fixes a subtle bug in the engine's own implementation: `EditorUtility.RestartEditor()` calls `EditorWindow.Close()` (which is non-blocking, and if there are unsaved scenes triggers a non-blocking save popup) and then *immediately* runs `Process.Start("sbox-dev.exe", …)`. If you have unsaved scenes you can end up with two editor processes — one showing the save dialog, one freshly booting. Auto Restart handles the save prompt itself first, then only fires the restart once unsaved sessions are either saved or explicitly discarded, so the engine's `OnClose()` returns `true` cleanly and exactly one new editor process is launched.

---

## When to use it

Use Auto Restart when:

- You changed a mounted package or native asset that the hotloader can't pick up.
- Hotload fails with an "unsupported change" error and asks you to restart.
- You want a guaranteed clean slate for testing.
- You're iterating on editor code (this library, the MCP server, custom inspectors, etc.) and want a quick refresh.

For pure C# gameplay changes the engine's `HotloadManager` usually handles things without a full restart — you don't need this for every code change.

---

## How it works

```csharp
[Menu( "Editor", "Auto Restart/Restart Editor", "restart_alt" )]
public static void Restart()
{
    var unsaved = SceneEditorSession.All.Where( s => s.HasUnsavedChanges ).ToList();
    if ( unsaved.Count == 0 ) /* simple confirm → restart */
    else                      /* save/discard/cancel dialog → restart */
}

private static void DoRestartNow() => EditorUtility.RestartEditor();
```

`EditorUtility.RestartEditor()` (from `Sandbox.Tools`) handles the actual process spawn — it preserves `Environment.CommandLine` and adds `-project "<Project.Current.ConfigFilePath>"`, which is what makes the new editor reopen straight into the same project.

---

## Layout

```
Editor/
  AutoRestart.cs              Menu items + save-dialog flow
auto_restart.sbproj           Library manifest (Org: screch, Ident: auto_restart)
.version                      Date-versioned package version
README.md
```

---

## License

MIT (or whatever you like — feel free to vendor and modify).
