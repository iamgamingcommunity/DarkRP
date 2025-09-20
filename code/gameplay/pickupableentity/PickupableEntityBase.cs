using Sandbox;



public class PickupableEntityBase : Component
{

	//PickupableEntity Info
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public string EquipmentName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info"), TextArea] public string EquipmentDescription { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public Model viewmodel { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public Model worldmodel { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public float EquipmentFireSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public float EquipmentAimSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public float EquipmentReloadSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public PickupableEntity SwepDataFile { get; set; }



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
	
	//Actions Graphs
	[Property, Feature("Action Graphs"), Group("Action Graphs")] public PickupableEntity.ActionGraphFireEquipment GraphFireEquipment { get; set; }
	[Property, Feature("Action Graphs"), Group("Action Graphs")] public PickupableEntity.ActionGraphAimEquipment GraphAimEquipment { get; set; }
	[Property, Feature("Action Graphs"), Group("Action Graphs")] public PickupableEntity.ActionGraphReloadEquipment GraphReloadEquipment { get; set; }
	
	//Extra Swep Vars
	[Property, Feature("Extra"), Group("Extra")] public GameObject PlayerControllerRef { get; set; }
	[Property, Feature("Extra"), Group("Extra")] public List<PickupableEntity.SwepExtraBools> ExtraBools { get; set; }
	[Property, Feature("Extra"), Group("Extra")] public List<PickupableEntity.SwepExtraInt> ExtraInt { get; set; }
	[Property, Feature("Extra"), Group("Extra")] public List<PickupableEntity.SwepExtraFloat> ExtraFloat { get; set; }
	[Property, Feature("Extra"), Group("Extra")] public List<PickupableEntity.SwepExtraFloat> RunTimeExtraFloat { get; set; } = new();
	[Property, Feature("Extra"), Group("Extra")] public List<string> ExtraStrings{ get; set; }




	// //Action Graphs
	public delegate void ActionGraphSetHotBarSwepInfo(PickupableEntity CurrentHotBarSwep);
	[Property, Feature("Action Graphs")]
	public ActionGraphSetHotBarSwepInfo GraphSetHotBarSwepInfo { get; set; }

	// public delegate void ActionGraphAimEquipment();
	// [Property, Feature("Action Graphs")]
	// public ActionGraphAimEquipment GraphAimEquipment { get; set; }
	
	// public delegate void ActionGraphReloadEquipment();
	// [Property, Feature("Action Graphs")]
	// public ActionGraphReloadEquipment GraphReloadEquipment { get; set; }


public struct PlayerKeyAction
{
    [Property] public string ActionName { get; set; } // e.g. "jump", "attack1", "use"
	[Property, Feature("Action Graphs")]
	public PickupableEntity.ActionGraphFireEquipment ExtraKeyBindings { get; set; }
}



	public void FireEquipment ()
	{
		GraphFireEquipment?.Invoke();
	}


	public void AimEquipment ()
	{
		GraphAimEquipment?.Invoke();
	}


	public void ReloadEquipment ()
	{
		GraphReloadEquipment?.Invoke();
	}


	public void SetHotBarSwepInfo(PickupableEntity CurrentHotBarSwep)
    {
		Log.Info("Worked");
		GraphSetHotBarSwepInfo?.Invoke(CurrentHotBarSwep);
    }

	//DarkRP Player Hotbar Action Graph Trigger Functions
	// public void TriggerSlot0()
    // {
	// 	 F2Menu?.Invoke();
    // }

	// public void TriggerSlot1()
    // {
	// 	 F2Menu?.Invoke();
    // }

	// public void TriggerSlot2()
    // {
	// 	 F2Menu?.Invoke();
    // }

	// public void TriggerSlot3()
    // {
	// 	 TabMenu?.Invoke();
    // }

	// public void TriggerSlot4()
    // {
	// 	 F2Menu?.Invoke();
    // }

	// public void TriggerSlot5()
    // {
	// 	 F2Menu?.Invoke();
    // }

	// public void TriggerSlot6()
    // {
	// 	 F2Menu?.Invoke();
    // }

	// public void TriggerSlot7()
    // {
	// 	 TabMenu?.Invoke();
    // }


	// public void TriggerSlot8()
    // {
	// 	 F2Menu?.Invoke();
    // }

	// public void TriggerSlot9()
    // {
	// 	 TabMenu?.Invoke();
    // }



  [Property, Feature("Action Graphs"), Group("Extra Action Graphs")] public List<PickupableEntity.SwepExtraActionGraphs> SwepExtraActionGraphs { get; set; } = new();






    // Not needed?? [Property, Feature("Action Graphs"), Group("Action Graphs")] public List<PlayerKeyAction> Bindings { get; set; } = new();

    protected override void OnUpdate()
    {
        foreach (var binding in SwepExtraActionGraphs)
        {
            if (Input.Pressed(binding.ActionName)) // check the bind name
            {
                Log.Info($"Triggered action: {binding.ActionName}");

                binding.GraphOtherKeybinds?.Invoke(); // execute the Action Graph
            }
        }
    }
}
