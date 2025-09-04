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

	public void TriggerF2Menu()
    {
		 F2Menu?.Invoke();
    }

	public void TriggerF3Menu()
    {
		 F2Menu?.Invoke();
    }

	public void TriggerF4Menu()
    {
		 F2Menu?.Invoke();
    }

	public void TriggerTabMenu()
    {
		 TabMenu?.Invoke();
    }
	
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
