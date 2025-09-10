using Sandbox;

public partial class GameModeBase : Component
{

	



	//Notify SFX Vars
	[Property, Feature("Notify SFX Info")] public SoundEvent NotifyGenericSound { get; set; }
	[Property, Feature("Notify SFX Info")] public SoundEvent NotifyErrorSound { get; set; }
	[Property, Feature("Notify SFX Info")] public SoundEvent NotifySuccessSound { get; set; }
	[Property, Feature("Notify SFX Info")] public SoundEvent NotifyWarningSound { get; set; }





	protected override void OnUpdate()
	{

	}
}
