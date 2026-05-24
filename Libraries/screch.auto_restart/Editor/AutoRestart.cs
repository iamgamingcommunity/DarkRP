using System.Collections.Generic;
using System.Linq;
using Editor;
using Sandbox;

namespace AutoRestart;

/// <summary>
/// Auto Restart - one-click editor restart with proper unsaved-changes handling.
///
/// Adds:
///   Editor > Auto Restart > Restart Editor                (handles unsaved scenes)
///   Editor > Auto Restart > Restart Editor (Force)        (discards unsaved scenes)
///   Editor > Auto Restart > About
///
/// Triggers a clean process restart and re-launches sbox-dev.exe with the same
/// command-line arguments + the current project, so the editor reopens straight
/// back into the project you're working on - no launcher detour.
///
/// Why this exists separately from the engine's <c>EditorUtility.RestartEditor()</c>:
/// the engine call kicks off <c>Process.Start("sbox-dev.exe", ...)</c> immediately after
/// <c>EditorWindow.Close()</c>. The close call is non-blocking, and if there are
/// unsaved scenes the engine's own popup is also non-blocking, so a second editor
/// process spawns while the old one is still showing the save dialog. We handle
/// the save prompt ourselves and only call <c>RestartEditor()</c> once the user
/// has decided what to do with unsaved work.
/// </summary>
public static class AutoRestartMenu
{
	// ── Public entry points ────────────────────────────────────────────────

	[Menu( "Editor", "Auto Restart/Restart Editor", "restart_alt" )]
	public static void Restart()
	{
		var unsaved = GetUnsavedSessions();

		if ( unsaved.Count == 0 )
		{
			Dialog.AskConfirm(
				DoRestartNow,
				"Restart the s&box editor now? It will relaunch straight back into this project.",
				"Auto Restart",
				"Restart",
				"Cancel" );
			return;
		}

		ShowUnsavedDialog( unsaved );
	}

	[Menu( "Editor", "Auto Restart/Restart Editor (Force)", "bolt" )]
	public static void RestartForce()
	{
		var unsaved = GetUnsavedSessions();
		if ( unsaved.Count > 0 )
		{
			Log.Warning( $"[Auto Restart] Forcing restart - discarding unsaved changes in {unsaved.Count} scene(s)." );
			DiscardUnsaved( unsaved );
		}
		DoRestartNow();
	}

	[Menu( "Editor", "Auto Restart/About", "info" )]
	public static void About()
	{
		Dialog.AskConfirm(
			() => { },
			"Auto Restart\n\n" +
			"One-click editor restart for s&box.\n\n" +
			"Menu: Editor > Auto Restart\n\n" +
			"Performs a clean process restart: prompts for unsaved changes, then " +
			"re-launches sbox-dev.exe with the same command-line arguments and the " +
			"current project so the editor automatically reopens back into the " +
			"project you're working on.",
			"Auto Restart",
			"OK" );
	}

	// ── Save-dialog flow ───────────────────────────────────────────────────

	private static void ShowUnsavedDialog( List<SceneEditorSession> unsaved )
	{
		var popup = new PopupDialogWidget( "💾" );
		popup.WindowTitle = "Auto Restart - Unsaved Changes";
		popup.FixedWidth = 520;
		popup.MessageLabel.Text =
			$"You have unsaved changes in {unsaved.Count} scene{(unsaved.Count == 1 ? "" : "s")}:\n\n" +
			"  • " + string.Join( "\n  • ", unsaved.Select( s => s.Scene?.Name ?? "<unnamed>" ) ) +
			"\n\nWhat would you like to do before restarting?";

		popup.ButtonLayout.Spacing = 4;
		popup.ButtonLayout.AddStretchCell();

		popup.ButtonLayout.Add( new Button.Primary( "Save and Restart" )
		{
			Clicked = () =>
			{
				foreach ( var s in unsaved )
				{
					try { s.Save( false ); }
					catch ( System.Exception ex ) { Log.Error( $"[Auto Restart] Failed to save '{s.Scene?.Name}': {ex.Message}" ); }
				}
				popup.Destroy();
				DoRestartNow();
			}
		} );

		popup.ButtonLayout.Add( new Button( "Restart Without Saving" )
		{
			Clicked = () =>
			{
				DiscardUnsaved( unsaved );
				popup.Destroy();
				DoRestartNow();
			}
		} );

		popup.ButtonLayout.Add( new Button( "Cancel" )
		{
			Clicked = popup.Destroy
		} );

		popup.SetModal( true, true );
		popup.Hide();
		popup.Show();
	}

	// ── Helpers ────────────────────────────────────────────────────────────

	private static List<SceneEditorSession> GetUnsavedSessions()
	{
		return SceneEditorSession.All
			.Where( s => s != null && s.HasUnsavedChanges )
			.ToList();
	}

	/// <summary>
	/// Mark sessions clean so the engine's own OnClose check returns true and we
	/// don't race the engine's non-blocking save popup against Process.Start.
	/// </summary>
	private static void DiscardUnsaved( List<SceneEditorSession> sessions )
	{
		foreach ( var s in sessions )
		{
			try { s.HasUnsavedChanges = false; } catch { }
		}
	}

	private static void DoRestartNow()
	{
		EditorUtility.RestartEditor();
	}
}
