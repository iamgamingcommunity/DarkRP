using Sandbox;
[Description("This holds Infomation/Logic related to Jail Positions.")]
public sealed class JailPosition : Component
{

	
	[Property, Feature("Jail Position"), Description("Holds the cloths you want the debug visuals to have when you turn them on after it's turned off. (This is so the model isn't naked when you turn the visuals back on.)"), Group("Jail Position Action Graph")]
	public List<ClothingContainer.ClothingEntry> JailClothes { get; set; } = new();
	
	
	public delegate void ActionGraphJailPosVisualDebug();
	[Property, Feature("Jail Position"), Group("Jail Position Action Graph"), Title("Jail Pos Visual Debug")]
	public ActionGraphJailPosVisualDebug JailPosVisualDebug { get; set; }







    [Button, Property, Feature("Jail Position"), Group("Jail Position Action Graph"), Title("Turn On/Off Jail Pos Visuals")]
	public void JailPosVisualDebugLogic()
	{
		JailPosVisualDebug?.Invoke();
	}


}
