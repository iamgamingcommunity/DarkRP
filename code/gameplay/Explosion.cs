using Sandbox;

public sealed class Explosion : Component
{


	//Explosion Info
	[Property, Feature("Explosion Base Info"), Group("Explosion Base Info")] public float AmountOfExplosionDelt { get; set; }
	[Property, Feature("Explosion Base Info"), Group("Explosion Base Info")] public float AmountOfExplosionDeltMin { get; set; }
	[Property, Feature("Explosion Base Info"), Group("Explosion Base Info")] public float AmountOfExplosionDeltMax { get; set; }
	[Property, Feature("Explosion Base Info"), Group("Explosion Base Info"), Title("Explosive Damage Delay"), Description("The Delay when the explosive is not dealing damage anymore.")] public float EquipmentExplosiveDelay { get; set; }	



















}
