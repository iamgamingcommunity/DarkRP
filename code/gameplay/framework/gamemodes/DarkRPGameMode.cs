using Sandbox;

namespace DarkRPGamemode
{
[Description("This is the main Component that houses most variables throughout everything related to DarkRP.")]
public partial class DarkRPGamemode : GameModeBase
{
	//DarkRP Basic Info
	// Maybe put this on the Respawn Component? [Property, Feature("DarkRP Gamemode Info")] public float SpawnProtection { get; set; }
	[Property, Feature("Basic Info")] public bool DisableDefaultF2MenuUI { get; set; }
	[Property, Feature("Basic Info")] public bool DisableDefaultF4MenuUI { get; set; }	
	[Property, Feature("Basic Info")] public bool DisableDefaultScoreboardUI { get; set; }	
	[Property, Feature("Basic Info")] public bool DisableDefaultModerationSystem { get; set; }	
	[Property, Feature("Basic Info")] public bool DisableDefaultSpawnProtectionSystem { get; set; }	
	[Property, Feature("Basic Info")] public int SalaryPaymentSystemCycleTime { get; set; }
	[Property, Feature("Basic Info")] public int SalaryPaymentMultiplier { get; set; }
	[Property, Feature("Basic Info")] public int EntityPriceMultiplier { get; set; }
	[Property, Feature("Basic Info")] public List<PickupableEntity> StartingEquipment { get; set; }
	[Property, Feature("Basic Info")] public PrefabFile MoneyEntity { get; set; }
	[Property, Feature("Basic Info")] public int MaxPropSpawnedAmount { get; set; }
	[Property, Feature("Basic Info"), Description("If True a Job has ")] public int TempPlayTimeTotalCycleAmount { get; set; }

	//DarkRP Law System Info
	[Property, Feature("Law Info")] public List<GameObject> JailPos { get; set; }
	[Property, Feature("Law Info")] public int JailTime { get; set; }
	[Property, Feature("Law Info")] public Model LawBoardModel { get; set; }
	[Property, Feature("Law Info")] public int MaxLawsOnBoard { get; set; }
	[Property, Feature("Law Info"), Description("Should Players when they are unarrested get their Illegal Sweps back? True=Yes False=No")] public bool GiveIllegalSwepsBackOnUnarrest { get; set; }
	[Property, Feature("Law Info"), Title("Lottery System")] public bool ToggleLottery { get; set; }
	[Property, Feature("Law Info")] public int MinLotteryPrice { get; set; }
	[Property, Feature("Law Info")] public int MaxLotteryPrice { get; set; }
	[Property, Feature("Law Info")] public SoundEvent LockDownStartSFX { get; set; }
	[Property, Feature("Law Info")] public SoundEvent LockDownOnGoingSFX { get; set; }
	[Property, Feature("Law Info")] public SoundEvent AlarmSound { get; set; }
	[Property, Feature("Law Info")] public SoundEvent ArrestedSFX { get; set; }
	[Property, Feature("Law Info")] public SoundEvent UnArrestedSFX { get; set; }
	[Property, Feature("Law Info")] public List<PickupableEntity> PDStartingEquipment { get; set; }
	[Property, Feature("Law Info")] public List<PickupableEntity> LicensedEquipment { get; set; }

	
	//DarkRP Vote System Info
	[Property, Feature("Vote Info")] public int DefaultVoteDuration { get; set; }
	[Property, Feature("Vote Info")] public int DefaultMinimumVoteRequired { get; set; }
	[Property, Feature("Vote Info")] public float DefaultRequiredYesPercentage { get; set; }
	[Property, Feature("Vote Info")] public SoundEvent VoteStartSFX { get; set; }




	//Notify SFX Vars
	[Property, Feature("Notify SFX Info")] public SoundEvent NotifyGenericSound { get; set; }
	[Property, Feature("Notify SFX Info")] public SoundEvent NotifyErrorSound { get; set; }
	[Property, Feature("Notify SFX Info")] public SoundEvent NotifySuccessSound { get; set; }
	[Property, Feature("Notify SFX Info")] public SoundEvent NotifyWarningSound { get; set; }


	//Chat Related Vars
	[Property, Feature("Chat Info")] public List<ChatCommandResource> AllChatCommands { get; set; }

	//Chat Related Vars
	[Property, Feature("Hitman Info")] public int MinHitPrice { get; set; }
	[Property, Feature("Hitman Info")] public int MaxHitPrice { get; set; }



	//Debug Related Vars

	[Property, Feature("Debug"), Group("Debug Settings")] public bool JailPositionDebug { get; set; }



 	// public struct SwepLists
	// {
	// [KeyProperty] public List<PickupableEntity> Swep { get; set; }
	// public int SwepPosIndex { get; set; }

	// }





}
 public enum TypeOfCategorys
 {
	Jobs,
	Entities,
	Weapons,
	Shipments,
	Ammo,
	Vehicles,

 }
}