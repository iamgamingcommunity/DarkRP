using Sandbox;

public sealed class ElevatorCallPanel : BaseEntity 
{
	[Property, Feature("ElevatorCallPanel Info")]
	public int FloorLevel { get; set; }

	protected override void OnUpdate()
	{

	}
}