using Sandbox;

public sealed class ElevatorCallPanel : BaseEntity 
{
	[Property, Feature("ElevatorCallPanel Info")]
	public int FloorLevel { get; set; }

	[Property, Feature("ElevatorCallPanel Info")]
	public GameObject ElevatorObject { get; set; }

	protected override void OnUpdate()
	{

	}
}