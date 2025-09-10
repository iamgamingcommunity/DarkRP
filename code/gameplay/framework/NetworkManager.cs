using Sandbox;
using DarkRPGamemode;

namespace NetworkManager
{

public sealed class NetworkManager : Component
{







	[Property] public List<PlayerData> PlayerList { get; set; }


	public struct PlayerData
	{
	[KeyProperty] public string PlayerID { get; set; }
	[KeyProperty] public Component DarkRPPlayerInfo { get; set; }
	}


	protected override void OnUpdate()
	{

	}
	// 	protected override void OnStart()
	// {

	// }
}
}