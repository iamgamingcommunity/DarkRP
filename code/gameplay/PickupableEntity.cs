using Sandbox;
using System;
using System.Collections.Generic;

[GameResource("Swep", "swep", "Swep(A.K.A Special Weapon) Defines anything that is a PickupableEntity that can be held in the DarkRP Player Hands.")]
public class PickupableEntity : GameResource
{
	//PickupableEntity Info
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public string EquipmentName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info"), TextArea] public string EquipmentDescription { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public Model viewmodel { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public Model worldmodel { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public float EquipmentFireSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public float EquipmentAimSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public float EquipmentReloadSpeed { get; set; }


	//PickupableEntity Damage Info
	[Property, Feature("Equipment Damage Info"), ShowIf ( nameof( EquipmentUnlimitedAmmo ), false), Group("Equipment Damage Info")] public int EquipmentCurrentAmmo { get; set; }
	[Property, Feature("Equipment Damage Info"), ShowIf ( nameof( EquipmentUnlimitedAmmo ), false), Group("Equipment Damage Info")] public int EquipmentMaxAmmo { get; set; }
    [Property, Feature("Equipment Damage Info"), Group("Equipment Damage Info")] public bool EquipmentUnlimitedAmmo { get; set; }
	[Property, Feature("Equipment Damage Info"), Group("Equipment Damage Info")] public int EquipmentAmountOfRoundsFired { get; set; }
	[Property, Feature("Equipment Damage Info"), Group("Equipment Damage Info")] public bool IsEnableMinMaxDamage { get; set; }
	[Property, Feature("Equipment Damage Info"), ShowIf ( nameof( IsEnableMinMaxDamage ), false), Group("Equipment Damage Info")] public float EquipmentBaseDamage { get; set; }
	[Property, Feature("Equipment Damage Info"), ShowIf ( nameof( IsEnableMinMaxDamage ), true), Group("Equipment Damage Info")] public float EquipmentDamageMin { get; set; }
	[Property, Feature("Equipment Damage Info"), ShowIf ( nameof( IsEnableMinMaxDamage ), true), Group("Equipment Damage Info")] public float EquipmentDamageMax { get; set; }
	
	//PickupableEntity SFX Info
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent FireEquipmentSFX { get; set; }
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent AimEquipmentSFX { get; set; }
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent ReloadEquipmentSFX { get; set; }
    [Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent[] ExtraSFX { get; set; }

	[Property, Feature("Extra"), Group("Extra")] public GameObject PlayerControllerRef { get; set; }

		//Action Graphs
	public delegate void ActionGraphFireEquipment(GameObject PlayerControllerRef);
	[Property, Feature("Action Graphs"), Group("Action Graphs")]
	public ActionGraphFireEquipment GraphFireEquipment { get; set; }

	public delegate void ActionGraphAimEquipment();
	[Property, Feature("Action Graphs"), Group("Action Graphs")]
	public ActionGraphAimEquipment GraphAimEquipment { get; set; }
	
	public delegate void ActionGraphReloadEquipment();
	[Property, Feature("Action Graphs"), Group("Action Graphs")]
	public ActionGraphReloadEquipment GraphReloadEquipment { get; set; }


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