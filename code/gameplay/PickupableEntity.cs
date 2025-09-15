using Sandbox;
using System;
using System.Collections.Generic;

[GameResource("Equipment", "equip", "Defines a PickupableEntity")]
public class PickupableEntity : GameResource
{
	//PickupableEntity Info
	[Property, Feature("Equipment Base Info")] public string EquipmentName { get; set; }
	[Property, Feature("Equipment Base Info")] public Model viewmodel { get; set; }
	[Property, Feature("Equipment Base Info")] public Model worldmodel { get; set; }
	[Property, Feature("Equipment Base Info")] public float EquipmentFireSpeed { get; set; }
	[Property, Feature("Equipment Base Info")] public float EquipmentAimSpeed { get; set; }
	[Property, Feature("Equipment Base Info")] public float EquipmentReloadSpeed { get; set; }


	//PickupableEntity Damage Info
	[Property, Feature("Equipment Damage Info")] public int EquipmentCurrentAmmo { get; set; }
	[Property, Feature("Equipment Damage Info")] public int EquipmentMaxAmmo { get; set; }
    [Property, Feature("Equipment Damage Info")] public bool EquipmentUnlimitedAmmo { get; set; }
	[Property, Feature("Equipment Damage Info")] public int EquipmentAmountOfRoundsFired { get; set; }
	[Property, Feature("Equipment Damage Info")] public bool IsEnableMinMaxDamage { get; set; }
	[Property, Feature("Equipment Damage Info"), ShowIf ( nameof( IsEnableMinMaxDamage ), false)] public float EquipmentBaseDamage { get; set; }
	[Property, Feature("Equipment Damage Info"), ShowIf ( nameof( IsEnableMinMaxDamage ), true)] public float EquipmentDamageMin { get; set; }
	[Property, Feature("Equipment Damage Info"), ShowIf ( nameof( IsEnableMinMaxDamage ), true)] public float EquipmentDamageMax { get; set; }
	
	//PickupableEntity SFX Info
	[Property, Feature("Equipment SFX Info")] public SoundEvent FireEquipmentSFX { get; set; }
	[Property, Feature("Equipment SFX Info")] public SoundEvent AimEquipmentSFX { get; set; }
	[Property, Feature("Equipment SFX Info")] public SoundEvent ReloadEquipmentSFX { get; set; }
    [Property, Feature("Equipment SFX Info")] public SoundEvent[] ExtraSFX { get; set; }

		//Action Graphs
	public delegate void ActionGraphFireEquipment();
	[Property, Feature("Action Graphs")]
	public ActionGraphFireEquipment GraphFireEquipment { get; set; }

	public delegate void ActionGraphAimEquipment();
	[Property, Feature("Action Graphs")]
	public ActionGraphAimEquipment GraphAimEquipment { get; set; }
	
	public delegate void ActionGraphReloadEquipment();
	[Property, Feature("Action Graphs")]
	public ActionGraphReloadEquipment GraphReloadEquipment { get; set; }


	

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