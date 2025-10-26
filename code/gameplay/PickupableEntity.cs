using Sandbox;
using System;
using System.Collections.Generic;

[GameResource("Swep", "swep", "Swep(A.K.A Special Weapon) Defines anything that is a PickupableEntity that can be held in the DarkRP Player Hands.")]
public class PickupableEntity : GameResource
{
	//PickupableEntity Info
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public string EquipmentName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info"), TextArea] public string EquipmentDescription { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public PrefabFile viewmodel { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public PrefabFile worldmodel { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public Texture SpawnMenuIcon { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public PrefabFile MuzzleFlash { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public PrefabFile BulletEjection { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info")] public Vector3 SwepHandPosition { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info"), Description("This uses a string but the swep model NEEDS have a int or enum with a index of 1 to fire off the aiming logic. If not this won't work.")] public string SwepAimAnimationParameterName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info")] public string SwepFireAnimationParameterName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info")] public string SwepDryFireAnimationParameterName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info")] public string SwepDeploySkipAnimationParameterName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info")] public string SwepEmptyAnimationParameterName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info")] public string SwepGrabAnimationParameterName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info")] public string SwepHolsterAnimationParameterName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info")] public string SwepLowerWeaponAnimationParameterName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info")] public string SwepReloadAnimationParameterName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info")] public string SwepEquipAnimationParameterName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info")] public string SwepHoldTypeAnimationParameterName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info"), Description("We Use Default S&Box Character that has hold types. The Hold Types are: 0=None, 1=Pistol, 2=Rifle, 3=Shotgun, 4=HoldItem, 5=MeleePunch, 6=MeleeWeapons, 7=RPG, 8=Physgun")] public int SwepHoldTypeParameter { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info")] public string SwepHoldTypeHandednessAnimationParameterName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Swep Pos Info"), Description("We Use Default S&Box Character that has hold types. The Hold Types are: 0=2H, 1=RH, 2=LH")] public int SwepHoldTypeHandednessParameter { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info"), Description("Default DarkRP Ballistic System Firemodes Index Goes as Listed: 0=Safety, 1=Manual Single Bolt, 2=Single bolt, 3=Semi, 4=Burst, 5=Auto, 6=Shotgun, 7=Gatling.")] public List<int> EquipmentFireMode { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info"), Description("This places the weapon the in the catagory you set in the spawn menus.")] public string SpawnMenuCatagory{ get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public bool NeedWeaponLicense { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public bool NoStripSwep { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public bool DisallowDrop { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info"), Description("If the weapon can be spawned.")] public bool Spawnable { get; set; } = true;
	[Property, Feature("Equipment Base Info"), Group("Base Info"), Description("If the weapon can be ONLY spawned via admin rank.")] public bool AdminSpawnable { get; set; } = true;
	[Property, Feature("Equipment Base Info"), Group("Base Info"), Description("Which hotbar you want the swep to be added to.")] public int HotbarSlot { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public float EquipmentRecoil { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public float EquipmentCone { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public float EquipmentFireSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public float EquipmentAimSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public float EquipmentReloadSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public float EquipmentBulletSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public PrefabFile EquipmentBulletDecal { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Base Info")] public bool EquipmentUsePresetWeaponSystem { get; set; }


	//PickupableEntity Damage Info

	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Ammo Info"), Title("Explosive Damage?")] public bool EquipmentExplosiveDamage { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Ammo Info"), Title("Explosive Damage Amount"), Description("Explosive Damage Amount delt to the player in the radius. Note: If you want to heal the player put a negative amount here instead."), ShowIf ( nameof( EquipmentExplosiveDamage ), true)] public int EquipmentExplosiveDamageAmount { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Ammo Info"), Title("Explosive Damage Radius"), Description("Explosive Damage radius where the bullet impacts."), ShowIf ( nameof( EquipmentExplosiveDamage ), true)] public float EquipmentExplosiveRadius { get; set; }	
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Ammo Info"), Title("Unlimited Ammo")] public bool EquipmentUnlimitedAmmo { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Ammo Info"), Title("Current Ammo")] public int EquipmentCurrentAmmo { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Ammo Info"), Title("Stored Ammo")] public int EquipmentMaxAmmo { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Ammo Info"), Title("Max Stored Ammo")] public int EquipmentMaxStoredAmmo { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Ammo Info"), Title("Mag Size")] public int EquipmentAmountOfRoundsToReload { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Ammo Info"), Title("Swep Bullet Projectile Fire Speed"), Description("IF you are using a Shotgun that has burst fire, you MUST use this to adjust the rounds fired out of the barrel speed. Don't Confuse this with Fire Speed on Shotgun burst, Fire Speed on Shotgun burst is the speed of which you use the next round in your mag.")] public float EquipmentShotgunBurstBulletSpeed { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Ammo Info"), Title("Reload Time")] public int EquipmentReloadTimeDelay { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Ammo Info"), Title("Amount of Projectiles Fired"), Description("Amount of Rounds sends X amount of Projectiles out of the barrel. So if you want to make a Shotgun buckshot you use this, or if you're using Burst Fire. This will be the amount of burst rounds that are fired. If Burst you MUST have more than 1 round fired or it won't work.")] public int EquipmentAmountOfRoundsFired { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Ammo Info"), Title("Swep Ammo Type")] public List<AmmoResource> EquipmentAmmoType { get; set; }


	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Damage"), Title("Base Damage")] public float EquipmentBaseDamage { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Damage"), Title("Damage Min")] public float EquipmentDamageMin { get; set; } = 1f;
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Damage"), Title("Damage Max")] public float EquipmentDamageMax { get; set; } = 1f;
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Damage"), Title("Headshot Damage Multiplier")] public float EquipmentHeadshotDamageMultiplier { get; set; } = 1f;
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Swep Damage")] public Curve DamageOverDistanceCurve { get; set; }
	
	//PickupableEntity SFX Info
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent FireEquipmentSFX { get; set; }
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent DryFireEquipmentSFX { get; set; }
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent AimEquipmentSFX { get; set; }
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent ReloadEquipmentSFX { get; set; }
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent BulletDecalSFX { get; set; }
    [Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public List<SoundEvent> ExtraSFX { get; set; }

	[Property, Feature("Extra"), Group("Extra")] public GameObject PlayerControllerRef { get; set; }

		//Action Graphs
	public delegate void ActionGraphFireEquipment(GameObject PlayerControllerRef);
	[Property, Feature("Action Graphs"), Group("Action Graphs"), Title("Custom Fire Swep")]
	public ActionGraphFireEquipment GraphFireEquipment { get; set; }

	public delegate void ActionGraphAimEquipment(GameObject PlayerControllerRef);
	[Property, Feature("Action Graphs"), Group("Action Graphs"), Title("Custom Aim Swep")]
	public ActionGraphAimEquipment GraphAimEquipment { get; set; }
	
	public delegate void ActionGraphReloadEquipment(GameObject PlayerControllerRef);
	[Property, Feature("Action Graphs"), Group("Action Graphs"), Title("Custom Reload Swep")]
	public ActionGraphReloadEquipment GraphReloadEquipment { get; set; }

	public delegate void ActionGraphFireModeEquipment(GameObject PlayerControllerRef);
	[Property, Feature("Action Graphs"), Group("Action Graphs"), Title("Custom FireMode Swep")]
	public ActionGraphFireModeEquipment GraphFireModeEquipment { get; set; }


	public struct SwepExtraActionGraphs
	{
		[Property] public string ActionName { get; set; } // e.g. "jump", "attack1", "use"
		[Property]
		public PickupableEntity.ActionGraphFireEquipment GraphOtherKeybinds { get; set; }
	}

 	[Property, Feature("Action Graphs"), Group("Action Graphs")] public List<SwepExtraActionGraphs> ExtraKeyBindings { get; set; } = new();

	//Extra Variables for using in Actions graphs
	[Property, Feature("Extra"), Group("Extra")] public List<SwepExtraBools> ExtraBools { get; set; }
	[Property, Feature("Extra"), Group("Extra")] public List<SwepExtraInt> ExtraInts { get; set; }
	[Property, Feature("Extra"), Group("Extra")] public List<SwepExtraFloat> ExtraFloats { get; set; }
	[Property, Feature("Extra"), Group("Extra")] public List<string> ExtraStrings { get; set; }

	// Not Needed??
	// public enum EquipmentFireModesList
	// {
	// 	Safe,
	// 	Manual,
	// 	SingleBolt,
	// 	Semi,
	// 	Burst,
	// 	Auto,
	// 	Shotgun,
	// 	Gatling
	// }


	public struct SwepExtraBools
	{
		[Property, Feature("Extra"), Group("Extra")] public string BoolName { get; set; }
		[Property, Feature("Extra"), Group("Extra")] public bool ExtraBools { get; set; }
	}

	public struct SwepExtraInt
	{
		[Property, Feature("Extra"), Group("Extra")] public string BoolName { get; set; }
		[Property, Feature("Extra"), Group("Extra")] public int ExtraInt { get; set; }
	}

		public struct SwepExtraFloat
	{
		[Property, Feature("Extra"), Group("Extra")] public string BoolName { get; set; } 
		[Property, Feature("Extra"), Group("Extra")] public float ExtraFloat { get; set; }
	}




    public static IReadOnlyList<PickupableEntity> All => _all;
    internal static List<PickupableEntity> _all = new();

    // Event for when all job assets are loaded
    public static event Action OnPickupableEntityLoaded;

    protected override void PostLoad()
    {
        base.PostLoad();

        if (!_all.Contains(this))
            _all.Add(this);

        // Fire the event once (after the first job is loaded)
        // For multiple jobs, it’s fine — subscribers can check PickupableEntity.All.Count
        OnPickupableEntityLoaded?.Invoke();
    }
}