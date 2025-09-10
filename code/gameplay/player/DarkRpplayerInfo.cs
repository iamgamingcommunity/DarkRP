using Sandbox;
using Sandbox.Utility;
using PlayerData = NetworkManager.NetworkManager.PlayerData;

public sealed class DarkrpPlayerInfo : Component
{


	//Steam Player Related Info
    [Property, ReadOnly] public SteamId SteamId { get; private set; }
	[Property, ReadOnly] public string SteamName { get; private set; }
	[Property] public string DisplayName { get; set; }


	[Property] public GameObject F2MenuUIPanel { get; set; }

	[Property] public GameObject SecondaryInteractionTraceHitVar { get; set; }

	[Property] public PlayerData PlayerListData { get; set; }

	[Property]
    public JobResource CurrentJob { get; set; }
	
	[Property] public int PlayerMoney { get; set; }
	[Property] public bool DropPlayerMoneyOnDeath { get; set; }
	[Property, ShowIf ( nameof( DropPlayerMoneyOnDeath ), true)] public bool PlayerDeathMoneyDropAll{ get; set; }
	[Property, ShowIf ( nameof( DropPlayerMoneyOnDeath ), true)] public int PlayerDeathMoneyDropAmount{ get; set; }

	[Property]
	public int PlayerDoorInt{ get; set; }
	//[Property] public string PlayerMoney { get; private set; }

	[Property] public bool IsInUIMenu { get; set; }

	[Property] public bool IsBot { get; set; }


	






	protected override void OnStart()
	{
		if ( !IsBot )
		{
		//Gets and sets SteamID to Be the Players SteamID for Using Later
		DisplayName = Steam.PersonaName;
		SteamId = Steam.SteamId;
		Log.Info( $"Local Player Name: {DisplayName}" );
		Log.Info($"Local Player Name: {SteamId}");
		 }
	}

	// protected override void OnUpdate()
	// {
	// }
}
