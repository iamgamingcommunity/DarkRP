using Sandbox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

[GameResource("ChatCommand", "chatc", "Defines a DarkRP Chat Command.", Category = "DarkRP")]
public class ChatCommandResource : GameResource
{


    [Property, Group("Chat Command Info")] public ChatCommand ChatCommands { get; set; }
    [Property, Description("When need to spawn something in, use this prefab file var."), Group("Chat Command Info")] public PrefabFile Prefab { get; set; }



	[Property, Feature("Action Graphs"), Group("Action Graphs")] public List<SwepExtraActionGraphs> ExtraKeyBindings { get; set; } = new();

	//Extra Variables for using in Actions graphs
	[Property, Feature("Extra"), Group("Extra")] public List<SwepExtraBools> ExtraBools { get; set; }
	[Property, Feature("Extra"), Group("Extra")] public List<SwepExtraInt> ExtraInts { get; set; }
	[Property, Feature("Extra"), Group("Extra")] public List<SwepExtraFloat> ExtraFloats { get; set; }
	[Property, Feature("Extra"), Group("Extra")] public List<string> ExtraStrings { get; set; }

	public struct SwepExtraActionGraphs
	{
		[Property] public string ActionName { get; set; } // e.g. "jump", "attack1", "use"
		[Property]
		public SwepEntity.ActionGraphFireEquipment GraphOtherKeybinds { get; set; }
	}

	public struct SwepExtraBools
	{
		[Property, Feature("Extra"), Group("Extra")] public string BoolName { get; set; }
		[Property, Feature("Extra"), Group("Extra")] public bool ExtraBools { get; set; }
	}

	public struct SwepExtraInt
	{
		[Property, Feature("Extra"), Group("Extra")] public string BoolName { get; set; }
		[Property, Feature("Extra"), Group("Extra")] public int ExtraInt { get; set; }
	}

		public struct SwepExtraFloat
	{
		[Property, Feature("Extra"), Group("Extra")] public string BoolName { get; set; } 
		[Property, Feature("Extra"), Group("Extra")] public float ExtraFloat { get; set; }
	}







    public struct ChatCommand
	{
        [KeyProperty, Group("Chat Command Info")] public List<string> ChatCommandName { get; set; }
        //Action Graph
		public delegate void ActionGraphChatCommand(GameObject Player);
	    [KeyProperty, Feature("Action Graphs"), Group("Action Graphs"), Title("Chat Command")]
	    public ActionGraphChatCommand GraphChatCommand { get; set; }
	}



	public void ChatCommandLogic(GameObject Player)
	{
		ChatCommands.GraphChatCommand?.Invoke(Player);
	}



    public static IReadOnlyList<ChatCommandResource> All => _all;
    internal static List<ChatCommandResource> _all = new();

    // Event for when all job assets are loaded
    public static event Action OnChatCommandLoaded;

    protected override void PostLoad()
    {
        base.PostLoad();

        if (!_all.Contains(this))
            _all.Add(this);

        // Fire the event once (after the first job is loaded)
        // For multiple jobs, it’s fine — subscribers can check JobResource.All.Count
        OnChatCommandLoaded?.Invoke();
    }








private bool IsInValidPath()
{
    // Normalize path
    var path = ResourcePath
        .Replace("\\", "/")
        .ToLowerInvariant();

    // Allow anything inside these folders + subfolders
    return path.StartsWith("assets/gameplay/addons/") ||
           path.StartsWith("assets/gameplay/chatcommands/");
}

    // Optional helper for quick lookup by command name
public static ChatCommandResource GetByCommand( string cmd )
{
    if ( string.IsNullOrWhiteSpace( cmd ) )
        return null;

    return _all.FirstOrDefault( x =>
        x.ChatCommands.ChatCommandName != null &&
        x.ChatCommands.ChatCommandName.Any( name =>
            string.Equals(
                name,
                cmd,
                StringComparison.OrdinalIgnoreCase
            )
        )
    );
}
    // Reload all chat commands manually (optional)
    public static void Reload()
    {
        _all.Clear();
        var resources = ResourceLibrary.GetAll<ChatCommandResource>();
        foreach (var res in resources)
        {
            if (res.IsInValidPath())
                _all.Add(res);
        }

        OnChatCommandLoaded?.Invoke();
    }


        //Create Custom File Icon
    [Description("!!WARNING!!: DO NOT FILL/USE/GET/ANYTHING of THIS PREFAB VAR! IT'S ONLY USED FOR THE RESOURCE FILE UI!!!")]public PrefabFile PrefabFileIcon { get; set; }


	public override Bitmap RenderThumbnail( ThumbnailOptions options )
	{
		// No prefab - can't make a thumbnail
		if ( PrefabFileIcon is null ) return default;

		var bitmap = new Bitmap( options.Width, options.Height );
		bitmap.Clear( Color.Transparent );

		SceneUtility.RenderGameObjectToBitmap( PrefabFileIcon.GetScene(), bitmap );

		return bitmap;
	}

	protected override Bitmap CreateAssetTypeIcon( int width, int height )
	{
		return CreateSimpleAssetTypeIcon( "💬", width, height, "#8bcece" );
	}
}