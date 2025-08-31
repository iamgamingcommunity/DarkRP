using Sandbox;

public sealed class HealthComponent : Component
{
	//Health Feature Tab
	[Property, Feature("Health Info")]
	public float Health { get; set; }

	[Property, Feature("Health Info")]
	public float MaxHealth { get; set; }
	
	[Property, Feature("Health Info")]
	public bool IsGodMode { get; set; }


	//Armor Feature Tab
	[Property, FeatureEnabled("Armor Info")]
	public bool ArmorInfo { get; set; } = false;

	[Property, Feature("Armor Info")]
	public float Armor { get; set; }

	[Property, Feature("Armor Info")]
	public float MaxArmor { get; set; }

	//Hunger System Feature Tab
	[Property, FeatureEnabled("Hunger System")]
	public bool HungerSystem { get; set; } = false;

	[Property, Feature("Hunger System")]
	public float PlayerThirst { get; set; } = 80;

	[Property, Feature("Hunger System")]
	public float PlayerThirstMax { get; set; } = 100;

	[Property, Feature("Hunger System")]
	public float PlayerHunger { get; set; } = 80;

	[Property, Feature("Hunger System")]
	public float PlayerHungerMax { get; set; } = 100;

	[Property, Feature("Hunger System")]
	public bool IsThirstEnabled { get; set; } = false;

	[Property, Feature("Hunger System")]
	public bool IsHungerEnabled { get; set; } = false;

	

	
	protected override void OnUpdate()
	{

	}
}
