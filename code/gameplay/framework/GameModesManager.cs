using Sandbox;
using System;
public sealed class GameModesManager : Component
{


	//SFX Vars
	[Property, Feature("SFX Info"), Group("Player SFX Info")] public SoundEvent PlayerRespawnSound { get; set; }

	[Property] public GameObject[] GameModes { get; set; }

	[Property] public Action RespawnPointListLogic { get; set; }

	[Property] public List<GameObject> RespawnPointList { get; set; }

	[Property] public List<GameObject> TempRespawnPointList { get; set; }

	[Property] public bool IsPreventRespawnDataWipe { get; set; }

	public void ReFireRespawnPointLogic()
	{
		RespawnPointListLogic?.Invoke();
	}




	protected override void OnUpdate()
	{

	}
}
