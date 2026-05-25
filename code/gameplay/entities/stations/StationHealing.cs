using System.Diagnostics.CodeAnalysis;
using Sandbox;

public sealed class StationHealing : BaseEntity
{
	
	[Property, Group("Healing Station"), Feature("Healing Station")] public SoundEvent HealingStationSFX {get; set;}
	[Property, Group("Healing Station"), Feature("Healing Station")] public int HealingStationHealAmount {get; set;}
	[Property, Group("Healing Station"), Feature("Healing Station")] public int HealingStationDelay {get; set;}
	[Property, Group("Healing Station"), Feature("Healing Station")] public bool IsHealingStationHealing {get; set;}
	[Property, Group("Healing Station"), Feature("Healing Station")] public SoundHandle HealingStationSoundHandle {get; set;}



}
