using Sandbox;

public sealed class PlayerHud : Component
{
	public delegate void ActionGraphF2Menu();
	[Property, Feature("Player Hud Info")]
	public ActionGraphF2Menu F2Menu { get; set; }

	public delegate void ActionGraphF3Menu();
	[Property, Feature("Player Hud Info")]
	public ActionGraphF3Menu F3Menu { get; set; }

	public delegate void ActionGraphF4Menu();
	[Property, Feature("Player Hud Info")]
	public ActionGraphF4Menu F4Menu { get; set; }

	public delegate void ActionGraphTab();
	[Property, Feature("Player Hud Info")]
	public ActionGraphTab TabMenu { get; set; }

	//Actions Graphs For Default DarkRP Chat
	public delegate void ActionGraphOpenChatLogic();
	[Property, Feature("Player Hud Info")]
	public ActionGraphOpenChatLogic GraphOpenChatLogic { get; set; }


	public bool StopF4MenuOpenCheck {get; set;}

	public void TriggerF2Menu()
    {
		 F2Menu?.Invoke();
    }

	public void TriggerF3Menu()
    {
		 F3Menu?.Invoke();
    }

	// [Rpc.Owner]

	public void TriggerF4Menu()
    {
		if ( IsProxy ) return;
		 F4Menu?.Invoke();
    }

	public void TriggerTabMenu()
    {
		 TabMenu?.Invoke();
    }

	public void OpenChatLogic()
	{
		GraphOpenChatLogic?.Invoke();
	}

	// void OnTextChanged( string newValue )
    // {
    //     DoorCustomTitle = newValue;
    //     Log.Info( $"Live text: {DoorCustomTitle}" );
    // }
	
	// public void LineTraceCustom()
    // {
	// SceneTraceResult tr = Scene.Trace.Ray( startPos, endPos ).Run();

	// if ( tr.Hit )
	// {
	// 	Log.Info( $"Hit: {tr.GameObject} at {tr.EndPosition}" );
	// }
	// }


	protected override void OnUpdate()
	{

	}
}
