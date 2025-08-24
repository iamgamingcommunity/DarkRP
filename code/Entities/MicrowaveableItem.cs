using Sandbox;

public sealed class SudoEntityTeacup : Component
{
	protected override void OnUpdate()
	{

	}

	    
    [Property, Title("MicrowaveTime")]
    public int MicrowaveTime { get; set; }
}
