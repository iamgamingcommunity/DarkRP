using Sandbox;

public sealed class Elevator : BaseEntity
{

	[Property, Feature("Elevator Info")]
	public bool ElevatorStopMovement { get; set; }

	[Property, Feature("Elevator Info")]
	public bool ElevatorMoving { get; set; }

	[Property, Feature("Elevator Info")]
	public int ElevatorFloorToGoTo { get; set; }

	[Property, Feature("Elevator Info")]
	public ElevatorData[] ElevatorFloorData { get; set; }

	public struct ElevatorData
	{
	[KeyProperty] public string FloorName { get; set; }
	[KeyProperty] public Vector3 FloorPos { get; set; }
	}




	protected override void OnUpdate()
	{

	}
}