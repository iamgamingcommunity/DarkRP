using Sandbox;
using System;


	public partial class BaseEntity : Component, Component.IPressable
	{
	
		[Property, Feature("Entity Info"), Group("Entity Info")]
		public bool IsInteractable { get; set; } = true;

		[Property, Feature("Entity Info"), Group("Entity Info"), Title("Able To Put in Pocket System?")]
		public bool IsPocketable { get; set; }

		[Property, Feature("Entity Info"), Group("Entity Info"), Title("Able To Put in Inventory System?")]
		public bool IsInventoriable { get; set; }

		[Property, Feature("Entity Info"), Group("Entity Info")]
		public SoundEvent InteractionSFX { get; set; }
		
		public delegate void PressedActionDelegate( PlayerController LastInteractingPlayer );
		[Property]
		public PressedActionDelegate Interacted { get; set; }

		public delegate void OnReleaseActionDelegate( PlayerController LastInteractingPlayer );
		[Property]
		public OnReleaseActionDelegate OnRelease { get; set; }

		public PlayerController LastInteractingPlayer { get; set; } 
		

		// Called every frame while the player is looking at this object.
		public bool Look(Ray ray) => true;

		// Called once when the player starts looking at this object.
		public void Hover() { }

		// Called once when the player stops looking at this object.
		public void Blur() { }

		// Determine if pressing is currently allowed (always true here).
		public bool CanPress() => true;


	// [ActionGraphNode( "Interacted" )]
    // public void FireInteracted ()
    // {
    //     // This node becomes available in the Action Graph
    // }


	// Called when the player presses the use key on this object.
	public bool Press(Component.IPressable.Event pressEvent)
	{
		if (Interacted != null)
		{
			LastInteractingPlayer = pressEvent.Source as PlayerController;// this is the "presser"
			Interacted.Invoke(LastInteractingPlayer);
		}
		Log.Info($"Interacted With {this}");
		return true;
	}

	// public bool OnStopInteraction(Component.IPressable.Event releaseEvent)
	// {
	// 	if (Interacted != null)
	// 	{
	// 		LastInteractingPlayer = releaseEvent.Source as PlayerController;// this is the "presser"
	// 		OnRelease.Invoke(LastInteractingPlayer);
	// 	}
	// 	Log.Info($"STOPPED Interacted With {this}");
	// 	return true;
	// }

		// Called each frame while the use key is held down.
		public bool Pressing(Component.IPressable.Event pressEvent) => true;

		// Called when the use key is released.
    // RELEASE
    public void Release( Component.IPressable.Event releaseEvent )
    {
        LastInteractingPlayer = releaseEvent.Source as PlayerController;

        OnRelease?.Invoke( LastInteractingPlayer );

        Log.Info( $"STOPPED Interacted With {this}" );
    }

		protected override void OnUpdate()
		{

		}
	}