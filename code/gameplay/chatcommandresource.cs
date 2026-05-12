using Sandbox;
using System;
using System.Collections.Generic;

[GameResource("ChatCommand", "chatc", "Defines a DarkRP Chat Command.", Category = "DarkRP")]
public class ChatCommandResource : GameResource
{


    [Property, Group("Chat Command Info")] public ChatCommand ChatCommands { get; set; }




    public struct ChatCommand
	{
        [KeyProperty, Group("Chat Command Info")] public string ChatCommandName { get; set; }
        //Action Graph
		public delegate void ActionGraphChatCommand();
	    [KeyProperty, Feature("Action Graphs"), Group("Action Graphs"), Title("Chat Command")]
	    public ActionGraphChatCommand GraphChatCommand { get; set; }
	}



	public void ChatCommandLogic ()
	{
		ChatCommands.GraphChatCommand?.Invoke();
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
        // Normalize the path (for different OS separators)
        var path = ResourcePath.ToLower();

        // Only allow commands from these folders
        return path.StartsWith("assets/gameplay/addons/") ||
               path.StartsWith("assets/gameplay/chatcommands/");
    }

    // Optional helper for quick lookup by command name
    public static ChatCommandResource GetByCommand(string cmd)
    {
        return _all.FirstOrDefault(x => 
    x.ChatCommands.ChatCommandName.Equals(cmd, StringComparison.OrdinalIgnoreCase));
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
    [Property]
    public PrefabFile Prefab { get; set; }


	public override Bitmap RenderThumbnail( ThumbnailOptions options )
	{
		// No prefab - can't make a thumbnail
		if ( Prefab is null ) return default;

		var bitmap = new Bitmap( options.Width, options.Height );
		bitmap.Clear( Color.Transparent );

		SceneUtility.RenderGameObjectToBitmap( Prefab.GetScene(), bitmap );

		return bitmap;
	}

	protected override Bitmap CreateAssetTypeIcon( int width, int height )
	{
		return CreateSimpleAssetTypeIcon( "💬", width, height, "#8bcece" );
	}
}