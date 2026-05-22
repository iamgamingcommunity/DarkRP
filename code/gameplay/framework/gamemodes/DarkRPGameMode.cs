using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sandbox;

namespace DarkRPGamemode
{
[Description("This is the main Component that houses most variables throughout everything related to DarkRP.")]
public partial class DarkRPGamemode : GameModeBase
{
	//DarkRP Basic Info
	// Maybe put this on the Respawn Component? [Property, Feature("DarkRP Gamemode Info")] public float SpawnProtection { get; set; }
	[Property, Feature("Basic Info"), Group("Disable Default Settings"), Description("Disable Default F2MenuUI")] public bool IsDisableDefaultF2MenuUI { get; set; }
	[Property, Feature("Basic Info"), Group("Disable Default Settings"), Description("Disable Default F4MenuUI")] public bool IsDisableDefaultF4MenuUI { get; set; }	
	[Property, Feature("Basic Info"), Group("Disable Default Settings"), Description("Disable Default ScoreboardUI")] public bool IsDisableDefaultScoreboardUI { get; set; }	
	[Property, Feature("Basic Info"), Group("Disable Default Settings"), Description("Disable Default Moderation System")] public bool IsDisableDefaultModerationSystem { get; set; }	
	[Property, Feature("Basic Info"), Group("Disable Default Settings"), Description("Disable Default Spawn Protection?")] public bool IsDisableDefaultSpawnProtectionSystem { get; set; }	
	[Property, Feature("Basic Info"), Group("Disable Default Settings"), Description("After Respawning Do You Want To Disable Spawning after to have a forced cooldown?")] public bool IsDisableRespawningAfterBecomingJob { get; set; }	
	[Property, Feature("Basic Info"), Group("Disable Default Settings"), Description("Disable Jobs from changing the base S&Box Player Clothing when they switch jobs.")] public bool IsDisableJobClothing { get; set; }	

    [Property, Feature("Basic Info"), Group("Restrictions To Job"), Description("Whenever triggered, This forces Users to Switch right after they become the job.")] public bool IsEnableJobAutoSwitch { get; set; }
	[Property, Feature("Basic Info"), Group("Restrictions To Job"), Description("Can Any Users Listed in 'UserGroupList' skip any job Whitelist?")] public bool IsUserGroupListSkipWhitelists  { get; set; }
	[Property, Feature("Basic Info"), Group("Restrictions To Job"), Description("Can Any Users Listed in 'UserGroupList' skip any job Blacklist?")] public bool IsUserGroupListSkipBlacklists  { get; set; }
	[Property, Feature("Basic Info"), Group("Restrictions To Job"), Description("Show un joinable jobs in the Job Menu?")] public bool IsShowUnJoinableJobs  { get; set; }
	[Property, Feature("Basic Info"), Group("Restrictions To Job"), Description("Show Whitelist/Blacklist System in Context Menu?")] public bool IsShowContextMenu  { get; set; }

	[Property, Feature("Basic Info"), Group("Hunger Mod"), Description("Enabled Hunger mod that will enabled the Hunger/Thirst System?")] public bool IsHungerModEnabled  { get; set; }
	[Property, Feature("Basic Info"), Group("Hunger Mod"), Description("Disable the Hunger?")] public bool IsHungerDisabled  { get; set; }
	[Property, Feature("Basic Info"), Group("Hunger Mod"), Description("Disable the Thirst?")] public bool IsThirstDisabled  { get; set; }
	[Property, Feature("Basic Info"), Group("Hunger Mod"), Description("Disable the Damage the player recieves when they are less than or equal to 0?")] public bool IsHungerDamageDisabled  { get; set; }
	[Property, Feature("Basic Info"), Group("Hunger Mod"), Description("Amount of damage to recieve when no hunger or thirst.")] public int HungerDamage  { get; set; }
	[Property, Feature("Basic Info"), Group("Hunger Mod"), Description("Amount of damage to recieve when no hunger or thirst.")] public int ThirstDamage  { get; set; }

	[Property, Feature("Basic Info"), Group("Hunger Mod"), ShowIf ( nameof( IsHungerModEnabled ), true), Description("What is the Default Hunger.")] public float DefaultHungerAmount  { get; set; }
	[Property, Feature("Basic Info"), Group("Hunger Mod"), ShowIf ( nameof( IsHungerModEnabled ), true), Description("What is the Default Thirst?")] public float DefaultThirstAmount  { get; set; }
	[Property, Feature("Basic Info"), Group("Hunger Mod"), ShowIf ( nameof( IsHungerModEnabled ), true), Description("What is the Max Hunger.")] public float MaxHungerAmount  { get; set; }
	[Property, Feature("Basic Info"), Group("Hunger Mod"), ShowIf ( nameof( IsHungerModEnabled ), true), Description("What is the Max Thirst?")] public float MaxThirstAmount  { get; set; }
		[Property, Feature("Basic Info"), Group("Hunger Mod"), ShowIf ( nameof( IsHungerModEnabled ), true), Description("What is the Default Hunger Reduction amount? This is how much Hunger is taken away from player when Hunger Reduction Triggered.")] public float HungerDefaultReductionAmount  { get; set; }
	[Property, Feature("Basic Info"), Group("Hunger Mod"), ShowIf ( nameof( IsHungerModEnabled ), true), Description("What is the Default Thirst Reduction amount? This is how much Thirst is taken away from player when Thirst Reduction Triggered.")] public float ThirstDefaultReductionAmount  { get; set; }
	[Property, Feature("Basic Info"), Group("Hunger Mod"), ShowIf ( nameof( IsHungerModEnabled ), true), Description("What is the Default Hunger Reduction Speed? 0.1 = 0.1 second, 1 = 1 second.")] public float HungerDefaultReductionSpeed  { get; set; }
	[Property, Feature("Basic Info"), Group("Hunger Mod"), ShowIf ( nameof( IsHungerModEnabled ), true), Description("What is the Default Thirst Reduction Speed? 0.1 = 0.1 second, 1 = 1 second.")] public float ThirstDefaultReductionSpeed  { get; set; }

	[Property, Feature("Basic Info"), Group("Hunger Mod"), ShowIf ( nameof( IsHungerModEnabled ), true), Description("What is the Max Hunger Reduction Speed?")] public float HungerMaxReductionSpeed  { get; set; }
	[Property, Feature("Basic Info"), Group("Hunger Mod"), ShowIf ( nameof( IsHungerModEnabled ), true), Description("What is the Max Thirst Reduction Speed?")] public float ThirstMaxReductionSpeed  { get; set; }

	[Property, Feature("Basic Info")] public JobResource DefaultDarkRPCivilianJob { get; set; }
	[Property, Feature("Basic Info")] public int SalaryPaymentSystemCycleTime { get; set; }
	[Property, Feature("Basic Info")] public int SalaryPaymentMultiplier { get; set; }
	[Property, Feature("Basic Info")] public int EntityPriceMultiplier { get; set; }
	[Property, Feature("Basic Info")] public List<SwepEntity> StartingEquipment { get; set; }
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
	[Property, Feature("Law Info")] public List<SwepEntity> PDStartingEquipment { get; set; }
	[Property, Feature("Law Info")] public List<SwepEntity> LicensedEquipment { get; set; }


	//DarkRP Admin System Info
	[Property, Feature("Admin Info"), Description("'Staff Sweps' is the sweps that any staff member will spawn and respawn with.")] public List<SwepEntity> StaffSweps { get; set; }
	
	//DarkRP Vote System Info
	[Property, Feature("Vote Info")] public int DefaultVoteDuration { get; set; }
	[Property, Feature("Vote Info")] public int DefaultMinimumVoteRequired { get; set; }
	[Property, Feature("Vote Info")] public float DefaultRequiredYesPercentage { get; set; }
	[Property, Feature("Vote Info")] public SoundEvent VoteStartSFX { get; set; }

	//SFX Vars


	//Notify SFX Vars
	[Property, Feature("SFX Info"), Group("Notify SFX Info")] public SoundEvent NotifyGenericSound { get; set; }
	[Property, Feature("SFX Info"), Group("Notify SFX Info")] public SoundEvent NotifyErrorSound { get; set; }
	[Property, Feature("SFX Info"), Group("Notify SFX Info")] public SoundEvent NotifySuccessSound { get; set; }
	[Property, Feature("SFX Info"), Group("Notify SFX Info")] public SoundEvent NotifyWarningSound { get; set; }


	//Chat Related Vars
	[Property, Feature("Chat Info")] public List<ChatCommandResource> AllChatCommands { get; set; }

	//Chat Related Vars
	[Property, Feature("Hitman Info")] public int MinHitPrice { get; set; }
	[Property, Feature("Hitman Info")] public int MaxHitPrice { get; set; }



	//Debug Related Vars

	[Property, Feature("Debug"), Group("Debug Settings")] public bool JailPositionDebug { get; set; }



 	// public struct SwepLists
	// {
	// [KeyProperty] public List<SwepEntity> Swep { get; set; }
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
	Miscellaneous,

 }
}