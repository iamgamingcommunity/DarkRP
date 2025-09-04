using Sandbox;

public sealed class ElevatorButtons : BaseEntity
{
	[Property, Feature("Elevator Info")]
	public int ElevatorFloorNumber { get; set; }

	protected override void OnUpdate()
	{

	}
}