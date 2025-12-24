using Sandbox;

namespace DarkRPGamemode
{
public partial class DarkRPGamemode : GameModeBase
{
	//DarkRP Basic Info
	// Maybe put this on the Respawn Component? [Property, Feature("DarkRP Gamemode Info")] public float SpawnProtection { get; set; }
	[Property, Feature("Basic Info")] public bool DisableDefualtF2MenuUI { get; set; }
	[Property, Feature("Basic Info")] public bool DisableDefualtF4MenuUI { get; set; }	
	[Property, Feature("Basic Info")] public bool DisableDefualtScoreboardUI { get; set; }	
	[Property, Feature("Basic Info")] public bool DisableDefualtModerationSystem { get; set; }	
	[Property, Feature("Basic Info")] public bool DisableDefualtSpawnProtectionSystem { get; set; }	
	[Property, Feature("Basic Info")] public int SalaryPaymentSystemCycleTime { get; set; }
	[Property, Feature("Basic Info")] public int SalaryPaymentMultiplier { get; set; }
	[Property, Feature("Basic Info")] public int EntityPriceMultiplier { get; set; }
	[Property, Feature("Basic Info")] public PickupableEntityBase[] StartingEquipment { get; set; }
	[Property, Feature("Basic Info")] public PrefabFile MoneyEntity { get; set; }
	[Property, Feature("Basic Info")] public int MaxPropSpawnedAmount { get; set; }
	[Property, Feature("Basic Info"), Description("If True a Job has ")] public int TempPlayTimeTotalCycleAmount { get; set; }

	//DarkRP Law System Info
	[Property, Feature("Law Info")] public GameObject[] JailPos { get; set; }
	[Property, Feature("Law Info")] public int JailTime { get; set; }
	[Property, Feature("Law Info")] public Model LawBoardModel { get; set; }
	[Property, Feature("Law Info")] public int MaxLawsOnBoard { get; set; }
	[Property, Feature("Law Info"), Title("Lottery System")] public bool ToggleLottery { get; set; }
	[Property, Feature("Law Info")] public int MinLotteryPrice { get; set; }
	[Property, Feature("Law Info")] public int MaxLotteryPrice { get; set; }
	[Property, Feature("Law Info")] public SoundEvent LockDownStartSFX { get; set; }
	[Property, Feature("Law Info")] public SoundEvent LockDownOnGoingSFX { get; set; }
	[Property, Feature("Law Info")] public SoundEvent AlarmSound { get; set; }
	[Property, Feature("Law Info")] public SoundEvent ArrestedSFX { get; set; }
	[Property, Feature("Law Info")] public SoundEvent UnArrestedSFX { get; set; }
	[Property, Feature("Law Info")] public PickupableEntityBase[] PDStartingEquipment { get; set; }
	[Property, Feature("Law Info")] public PickupableEntityBase[] LicensedEquipment { get; set; }

	
	//DarkRP Vote System Info
	[Property, Feature("Vote Info")] public int DefualtVoteDuration { get; set; }
	[Property, Feature("Vote Info")] public int DefualtMinimumVoteRequired { get; set; }
	[Property, Feature("Vote Info")] public float DefualtRequiredYesPercentage { get; set; }
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