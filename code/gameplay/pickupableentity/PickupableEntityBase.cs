using Sandbox;

public sealed class PickupableEntityBase : Component
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


public struct PlayerKeyAction
{
    [Property] public string ActionName { get; set; } // e.g. "jump", "attack1", "use"
    public delegate void ActionGraphOtherKeybinds();
	[Property, Feature("Action Graphs")]
	public ActionGraphOtherKeybinds GraphOtherKeybinds { get; set; }
}



	// void FireEquipment ()
	// {
	// 	GraphFireEquipment?.Invoke();
	// }


	// void AimEquipment ()
	// {
	// 	GraphAimEquipment?.Invoke();
	// }


	// void ReloadEquipment ()
	// {
	// 	GraphReloadEquipment?.Invoke();
	// }















    [Property] public List<PlayerKeyAction> Bindings { get; set; } = new();

    protected override void OnUpdate()
    {
        foreach (var binding in Bindings)
        {
            if (Input.Pressed(binding.ActionName)) // check the bind name
            {
                Log.Info($"Triggered action: {binding.ActionName}");

                binding.GraphOtherKeybinds?.Invoke(); // execute the Action Graph
            }
        }
    }
}
