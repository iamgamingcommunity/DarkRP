using Sandbox;


[Library("swep", Title = "Swep", Description = "Swep(A.K.A Special Weapon) is a Classic DarkRP Term For Weapons that have special features. In this case, we use this for ANYTHING that can be held by the DarkRP Player.")]
public class PickupableEntityBase : Component
{

	//PickupableEntity Info
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public string EquipmentName { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info"), TextArea] public string EquipmentDescription { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public PrefabFile viewmodel { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public PrefabFile worldmodel { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public int EquipmentCurrentFireMode { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public int EquipmentFireModeTempLoopVar { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info"), Description("Default DarkRP Ballistic System Firemodes Index Goes as Listed: 0=Safety, 1=Manual Single Bolt, 2=Single bolt, 3=Semi, 4=Burst, 5=Auto, 6=Shotgun, 7=Gatling.")] public List<int> EquipmentFireMode { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public float EquipmentFireSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public float EquipmentAimSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public float EquipmentReloadSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public float EquipmentBulletSpeed { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public PrefabFile EquipmentBulletDecal { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public PickupableEntity SwepDataFile { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public bool EquipmentUsingDefaultWeaponSystem { get; set; }
	[Property, Feature("Equipment Base Info"), Group("Equipment Base Info")] public bool IsReloading { get; set; }



	//PickupableEntity Damage Info
	[Property, Feature("Equipment Damage/Ammo Info"), ShowIf ( nameof( EquipmentUnlimitedAmmo ), false), Group("Equipment Damage/Ammo Info")] public int EquipmentCurrentAmmo { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), ShowIf ( nameof( EquipmentUnlimitedAmmo ), false), Group("Equipment Damage/Ammo Info"), Title("Swep Stored Ammo")] public int EquipmentMaxAmmo { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), ShowIf ( nameof( EquipmentUnlimitedAmmo ), false), Group("Equipment Damage/Ammo Info")] public int EquipmentAmountOfRoundsToReload { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), ShowIf ( nameof( EquipmentUnlimitedAmmo ), false), Group("Equipment Damage/Ammo Info")] public int EquipmentReloadTimeDelay { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Equipment Damage/Ammo Info")] public bool EquipmentUnlimitedAmmo { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Equipment Damage/Ammo Info")] public int EquipmentAmountOfRoundsFired { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Equipment Damage/Ammo Info")] public bool IsEnableMinMaxDamage { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), Group("Equipment Damage/Ammo Info")] public Curve DamageOverDistanceCurve { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), ShowIf ( nameof( IsEnableMinMaxDamage ), false), Group("Equipment Damage/Ammo Info")] public float EquipmentBaseDamage { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), ShowIf ( nameof( IsEnableMinMaxDamage ), true), Group("Equipment Damage/Ammo Info")] public float EquipmentDamageMin { get; set; }
	[Property, Feature("Equipment Damage/Ammo Info"), ShowIf ( nameof( IsEnableMinMaxDamage ), true), Group("Equipment Damage/Ammo Info")] public float EquipmentDamageMax { get; set; }
	
	//PickupableEntity SFX Info
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent FireEquipmentSFX { get; set; }
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent DryFireEquipmentSFX { get; set; }
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent AimEquipmentSFX { get; set; }
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent ReloadEquipmentSFX { get; set; }
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public SoundEvent BulletDecalSFX { get; set; }
	[Property, Feature("Equipment SFX Info"), Group("Equipment SFX Info")] public List<SoundEvent> ExtraSFX { get; set; }
	
	//Actions Graphs
	[Property, Feature("Action Graphs"), Group("Action Graphs"), ShowIf ( nameof( EquipmentUsingDefaultWeaponSystem ), false), Title("Custom Fire Swep")] public PickupableEntity.ActionGraphFireEquipment CustomGraphFireEquipment { get; set; }
	[Property, Feature("Action Graphs"), Group("Action Graphs"), ShowIf ( nameof( EquipmentUsingDefaultWeaponSystem ), false), Title("Custom Aim Swep")] public PickupableEntity.ActionGraphAimEquipment CustomGraphAimEquipment { get; set; }
	[Property, Feature("Action Graphs"), Group("Action Graphs"), ShowIf ( nameof( EquipmentUsingDefaultWeaponSystem ), false), Title("Custom Reload Swep")] public PickupableEntity.ActionGraphReloadEquipment CustomGraphReloadEquipment { get; set; }
	[Property, Feature("Action Graphs"), Group("Action Graphs"), ShowIf ( nameof( EquipmentUsingDefaultWeaponSystem ), false), Title("Custom FireMode Swep")] public PickupableEntity.ActionGraphFireModeEquipment CustomGraphFireModeEquipment { get; set; }
	[Property, Feature("Action Graphs"), Group("Action Graphs"), ShowIf ( nameof( EquipmentUsingDefaultWeaponSystem ), true), Title("Default Fire Swep")] public PickupableEntity.ActionGraphFireEquipment GraphFireEquipment { get; set; }
	[Property, Feature("Action Graphs"), Group("Action Graphs"), ShowIf ( nameof( EquipmentUsingDefaultWeaponSystem ), true), Title("Default Aim Swep")] public PickupableEntity.ActionGraphAimEquipment GraphAimEquipment { get; set; }
	[Property, Feature("Action Graphs"), Group("Action Graphs"), ShowIf ( nameof( EquipmentUsingDefaultWeaponSystem ), true), Title("Default Reload Swep")] public PickupableEntity.ActionGraphReloadEquipment GraphReloadEquipment { get; set; }
	[Property, Feature("Action Graphs"), Group("Action Graphs"), ShowIf ( nameof( EquipmentUsingDefaultWeaponSystem ), true), Title("Default FireMode Swep")] public PickupableEntity.ActionGraphFireModeEquipment GraphFireModeEquipment { get; set; }

	//Extra Swep Vars
	[Property, Feature("Extra"), Group("Extra")] public GameObject PlayerControllerRef { get; set; } = new();
	[Property, Feature("Extra"), Group("Extra")] public List<PickupableEntity.SwepExtraBools> ExtraBools { get; set; } = new();
	[Property, Feature("Extra"), Group("Extra")] public List<PickupableEntity.SwepExtraBools> RunTimeExtraBools { get; set; } = new();
	[Property, Feature("Extra"), Group("Extra")] public List<PickupableEntity.SwepExtraInt> ExtraInt { get; set; } = new();
	[Property, Feature("Extra"), Group("Extra")] public List<PickupableEntity.SwepExtraInt> RunTimeExtraInt { get; set; } = new();
	[Property, Feature("Extra"), Group("Extra")] public List<PickupableEntity.SwepExtraFloat> ExtraFloat { get; set; } = new();
	[Property, Feature("Extra"), Group("Extra")] public List<PickupableEntity.SwepExtraFloat> RunTimeExtraFloat { get; set; } = new();
	[Property, Feature("Extra"), Group("Extra")] public List<string> ExtraStrings{ get; set; } = new();
	[Property, Feature("Extra"), Group("Extra")] public List<string> RunTimeExtraStrings{ get; set; } = new();




	// //Action Graphs
	public delegate void ActionGraphSetHotBarSwepInfo(PickupableEntity CurrentHotBarSwep);
	[Property, Feature("Action Graphs")]
	public ActionGraphSetHotBarSwepInfo GraphSetHotBarSwepInfo { get; set; }


	public delegate void ActionGraphSwepDefaultDRPDamageSystem(GameObject PlayerControllerRef, GameObject HitGameObjectRef, Vector3 TempNormal, Vector3 TempEndPos, float TempDistance);
	[Property, Feature("Action Graphs")]
	public ActionGraphSwepDefaultDRPDamageSystem GraphSwepDefaultDRPDamageSystem { get; set; }

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



	public void FireEquipment (GameObject PlayerControllerRef)
	{
		GraphFireEquipment?.Invoke(PlayerControllerRef);
	}


	public void AimEquipment (GameObject PlayerControllerRef)
	{
		GraphAimEquipment?.Invoke(PlayerControllerRef);
	}


	public void ReloadEquipment (GameObject PlayerControllerRef)
	{
		GraphReloadEquipment?.Invoke(PlayerControllerRef);
	}

	public void FireModeEquipment (GameObject PlayerControllerRef)
	{
		GraphFireModeEquipment?.Invoke(PlayerControllerRef);
	}



	public void SwepDefaultDRPDamageSystem (GameObject PlayerControllerRef, GameObject HitGameObjectRef, Vector3 TempNormal, Vector3 TempEndPos, float TempDistance)
	{
		GraphSwepDefaultDRPDamageSystem?.Invoke(PlayerControllerRef, HitGameObjectRef, TempNormal, TempEndPos, TempDistance);
	}





	public void CustomFireEquipment (GameObject PlayerControllerRef)
	{
		CustomGraphFireEquipment?.Invoke(PlayerControllerRef);
	}


	public void CustomAimEquipment (GameObject PlayerControllerRef)
	{
		CustomGraphAimEquipment?.Invoke(PlayerControllerRef);
	}


	public void CustomReloadEquipment (GameObject PlayerControllerRef)
	{
		CustomGraphReloadEquipment?.Invoke(PlayerControllerRef);
	}



	public void CustomFireModeEquipment (GameObject PlayerControllerRef)
	{
		CustomGraphFireModeEquipment?.Invoke(PlayerControllerRef);
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

                binding.GraphOtherKeybinds?.Invoke(PlayerControllerRef); // execute the Action Graph
            }
        }
    }
}
