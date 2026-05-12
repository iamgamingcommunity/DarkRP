using Sandbox;

public sealed class RespawnSystem : Component
{

	[Property] public bool IsDarkRPPlayer { get; set; }
	[Property] public int RespawnTime { get; set; }
	[Property] public bool RespawnTimeVaried { get; set; }
	[Property, ShowIf ( nameof( RespawnTimeVaried ), true)] public int RespawnMixTime { get; set; }
	[Property, ShowIf ( nameof( RespawnTimeVaried ), true)] public int RespawnMaxTime { get; set; }


	//Action Graph Vars
	public delegate void ActionGraphRespawnLogic();
	[Property]
	public ActionGraphRespawnLogic RespawnLogic { get; set; }




	void RespawnLogicSystem()
	{
		RespawnLogic?.Invoke();
	}







	protected override void OnUpdate()
	{

	}
}
