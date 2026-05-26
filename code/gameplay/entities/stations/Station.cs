using System.Diagnostics.CodeAnalysis;
using Sandbox;

[Description("A Station is a thing where a person can go to receive a 'Resource'. This 'Resource' can be Health, Armor, etc.")]
public sealed class Station : BaseEntity
{
	
	[Property, Group("Station"), Feature("Station")] public SoundEvent StationSFX {get; set;}
	[Property, Group("Station"), Feature("Station")] public SoundEvent StationNoResourceLeftSFX {get; set;}
	[Property, Group("Station"), Feature("Station")] public SoundEvent StationDeniedSFX {get; set;}
	[Property, Group("Station"), Feature("Station")] public SoundEvent StationStoredResourceReplienished {get; set;}
	[Property, Group("Station"), Feature("Station")] public float StationReplienishDelay {get; set;}
	[Property, Group("Station"), Feature("Station")] public float StationInteractionDelay {get; set;}
	[Property, Group("Station"), Feature("Station")] public int StationResourceAmountGiven {get; set;}
	[Property, Group("Station"), Feature("Station")] public int StationResourceGivenDelay {get; set;}
	[Property, Group("Station"), Feature("Station")] public int StationStoredResourceAmount {get; set;}
	[Property, Group("Station"), Feature("Station")] public int StationStoredMaxResourceAmount {get; set;}
	[Property, Group("Station"), Feature("Station")] public bool IsStationGivingResource {get; set;}
	[Property, Group("Station"), Feature("Station"), Description("Every x amount(StationReplienishDelay) should we refill the current 'Resource' Amount to the 'StationStoredMaxResourceAmount'?")] public bool IsReplenishAlways {get; set;}
	[Property, Group("Station"), Feature("Station")] public SoundHandle StationSoundHandle {get; set;}

	[Property, Group("Station"), Feature("Station"), Description("Will this Station Add or Subtract from the Player 'Resource'?")] public StationAction StationActionType {get; set;}
	[Property, Group("Station"), Feature("Station"), Description("What type of 'Resource' will this Station Add or Remove from the Player when they interact with the station?")] public StationResource StationResourceType {get; set;}



	public enum StationAction
	{
		Add,
		Subtract
	}

	public enum StationResource
	{
		Health,
		Armor,
		DarkRPMoney
	}



}
