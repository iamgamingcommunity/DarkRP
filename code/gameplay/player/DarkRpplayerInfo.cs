using Sandbox;
using Sandbox.Utility;
using PlayerData = NetworkManager.NetworkManager.PlayerData;

[Description("All Info related to The DarkRP Player is here within this component. This is to be only used on Players and Bots.")]
public sealed class DarkrpPlayerInfo : Component
{


	//Steam Player Related Info
    [Property, ReadOnly, Feature("Basic DarkRP Info"), Group("Basic DarkRP Info")] public SteamId SteamId { get; private set; }
	[Property, ReadOnly, Feature("Basic DarkRP Info"), Group("Basic DarkRP Info")] public string SteamName { get; private set; }
	[Property, Feature("Basic DarkRP Info"), Group("Basic DarkRP Info")] public string DisplayName { get; set; }
	[Sync, Property, Feature("Basic DarkRP Info"), Group("Basic DarkRP Info")] public JobResource CurrentJob { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Basic DarkRP Info")] public int PlayerMoney { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodyFireAnimationParameterName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodyclimbingAnimationParameterName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodyDeployAnimationParameterName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodyFirstPersonAnimationParameterName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodyGroundedAnimationParameterName { get; set; }	
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodyJumpAnimationParameterName { get; set; }	
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodyLongIdleAnimationParameterName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodyNoclipAnimationParameterName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodyReloadAnimationParameterName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodyReloadingAnimationParameterName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodyReloadingInsertAnimationParameterName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodySwimAnimationParameterName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodyWeaponLowerAnimationParameterName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public string BodySitAnimationParameterName { get; set; }
	[Property, Feature("Basic DarkRP Info"), Group("Base Body Pos Info")] public int BodySitAnimationParameterValue { get; set; }

	// Not Needed??[Property] public string PlayerMoney { get; private set; }




	// //Player HotBars Vars Old
	// [Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot0 { get; set; }
	// [Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot1 { get; set; }
	// [Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot2 { get; set; }
	// [Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot3 { get; set; }	
	// [Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot4 { get; set; }
	// [Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot5 { get; set; }
	// [Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot6 { get; set; }
	// [Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot7 { get; set; }		
	// [Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot8 { get; set; }
	// [Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public HotbarSlot Slot9 { get; set; }	
	// [Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public int MaxSlots { get; set; } = 9;
	[Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public List<HotbarSlot> HotBarSlots { get; set; } = new();
	
	[Property, Feature("Player Hotbar Info"), Group("Player Hotbar Info")] public List<HotbarSlot> TempJailHotBarSlots { get; set; } = new();
	// Keep track of the currently active slot index for the Inventory
   public int ActiveSlot { get; set; } = 0;

	public struct HotbarSlot
	{
	[KeyProperty, Group("Player Hotbar Info")] public HotbarSlotInfo HotBarSlotInfo { get; set; }
		[Property, Description("This is the current slot A.K.A Swep you have active in the specific weapon catagory. THIS IS NEEDED!")] public int HotBarSlotCurrent { get; set; }
	}

	public struct HotbarSlotInfo
	{
	[KeyProperty] public List<PickupableEntityHotbarStructure> PickupableEntityHotbarStructure { get; set; }
	}



	public struct PickupableEntityHotbarStructure
	{
	[Description("This is used for keeping the sweps with the player after they are unarrested. The Lists it checks for are 'Starting Equipment' & 'Legalized Equipment'.")]public bool KeepSwep { get; set; }
	[KeyProperty] public PickupableEntity HotBarSlotHolder { get; set; }
	}




    [Button, Property, Feature("Debug"), Group("PD"), Title("Arrest Player")]
	public void DebugArrestPlayer()
	{
		ArrestedLogic?.Invoke();
	}


    [Button, Property, Feature("Debug"), Group("PD"), Title("Unarrest Player")]
	public void DebugUnArrestPlayer()
	{
		UnArrestLogic?.Invoke();
	}

	[Rpc.Host]
	public void RequestBecomeJob(JobResource job)
	{
	#if SERVER
		if (job == null) return;

		// server logic: assign job
		JobManager.Instance.TryAssignJob(this, job);
	#endif
	}

		// public static DarkrpPlayerInfo Local =>
		// 	Game.LocalClient?.Pawn?.Components.Get<DarkrpPlayerInfo>();


	//Extra DarkRP Info
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info"), ] public string Usergroup { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public bool IsBot { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public int PlayerDoorInt{ get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public PlayerData PlayerListData { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public GameObject F2MenuUIPanel { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public GameObject SecondaryInteractionTraceHitVar { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public bool IsInUIMenu { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public bool IsHasWeaponLicense { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public bool IsArrested { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public int PlayerCurrentJobTempTime { get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public bool DropPlayerMoneyOnDeath { get; set; }
	[Property, ShowIf ( nameof( DropPlayerMoneyOnDeath ), true), Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public bool PlayerDeathMoneyDropAll{ get; set; }
	[Property, ShowIf ( nameof( DropPlayerMoneyOnDeath ), true), Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public int PlayerDeathMoneyDropAmount{ get; set; }
	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public GameObject PlayerCameraRef { get; set; }

	[Property, Feature("Extra DarkRP Info"), Group("Extra DarkRP Info")] public List<GameObject> TempGameObjectList { get; set; }

	//Action Graphs
	public delegate void ActionGraphOpenChatLogic();
	[Property, Feature("Action Graphs"), Group("Action Graphs"), Title("Open Chat Logic")]
	public ActionGraphOpenChatLogic OpenChatLogic { get; set; }

	public delegate void ActionGraphArrested();
	[Property, Feature("Action Graphs"), Group("Action Graphs"), Title("Arrested Logic")]
	public ActionGraphArrested ArrestedLogic { get; set; }

	public delegate void ActionGraphUnArrest();
	[Property, Feature("Action Graphs"), Group("Action Graphs"), Title("Unarrest Logic")]
	public ActionGraphUnArrest UnArrestLogic { get; set; }









	public void ArrestPlayer()
	{
		ArrestedLogic?.Invoke();
	}

	public void UnArrestPlayer()
	{
		UnArrestLogic?.Invoke();
	}






	protected override void OnStart()
	{
		if (!IsBot)
		{
			//Gets and sets SteamID to Be the Players SteamID for Using Later
			DisplayName = Steam.PersonaName;
			SteamId = Steam.SteamId;
			Log.Info($"Local Player Name: {DisplayName}");
			Log.Info($"Local Player Name: {SteamId}");
		}
	}

	// protected override void OnUpdate()
	// {
	// }
}
