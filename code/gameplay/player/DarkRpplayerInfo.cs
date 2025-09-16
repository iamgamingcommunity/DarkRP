using Sandbox;
using Sandbox.Utility;
using PlayerData = NetworkManager.NetworkManager.PlayerData;

public sealed class DarkrpPlayerInfo : Component
{


	//Steam Player Related Info
    [Property, ReadOnly, Feature("Basic DarkRP Info"), Group("Basic DarkRP Info")] public SteamId SteamId { get; private set; }
	[Property, ReadOnly, Feature("Basic DarkRP Info"), Group("Basic DarkRP Info")] public string SteamName { get; private set; }
	[Property, Feature("Basic DarkRP Info"), Group("Basic DarkRP Info")] public string DisplayName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Basic DarkRP Info")] public JobResource CurrentJob { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Basic DarkRP Info")] public int PlayerMoney { get; set; }

	// Not Needed??[Property] public string PlayerMoney { get; private set; }




	//Player HotBars Vars
	[Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot0 { get; set; }
	[Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot1 { get; set; }
	[Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot2 { get; set; }
	[Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot3 { get; set; }	
	[Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot4 { get; set; }
	[Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot5 { get; set; }
	[Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot6 { get; set; }
	[Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot7 { get; set; }		
	[Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot8 { get; set; }
	[Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot9 { get; set; }	


	public struct HotbarSlot
	{
	[KeyProperty] public List<PickupableEntity> HotBarSlotHolder { get; set; }
	[KeyProperty] public int HotBarSlotCurrent { get; set; }
	}


	//Extra DarkRP Info
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public bool IsBot { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public int PlayerDoorInt{ get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public PlayerData PlayerListData { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public GameObject F2MenuUIPanel { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public GameObject SecondaryInteractionTraceHitVar { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public bool IsInUIMenu { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public int PlayerCurrentJobTempTime { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public bool DropPlayerMoneyOnDeath { get; set; }
	[Property, ShowIf ( nameof( DropPlayerMoneyOnDeath ), true), Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public bool PlayerDeathMoneyDropAll{ get; set; }
	[Property, ShowIf ( nameof( DropPlayerMoneyOnDeath ), true), Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public int PlayerDeathMoneyDropAmount{ get; set; }





















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
