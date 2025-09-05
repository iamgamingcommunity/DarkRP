using Sandbox;
using System;


	public partial class door : BaseEntity
	{
		
		//Door Base Related Vars
		[Property, Feature("Door Info")]
		public bool IsDoorPurchasable { get; set; }
		
		[Property, Feature("Door Info")]
		public bool IsDoorOwnable { get; set; } = true;

		[Property, Feature("Door Info")]
		public bool IsDoorLocked { get; set; }
		
	


		//Door Purchase Infomation Vars
		[Property, Feature( "Door Info" ), ShowIf ( nameof( IsDoorPurchasable ), true)]
		public int DoorBuyAmount { get; set; }


		[Property, Feature( "Door Info" ), ShowIf ( nameof( IsDoorPurchasable ), true)]
		public string PlayerDisplayName { get; set; }

		[Property, Feature( "Door Info" ), ShowIf ( nameof( IsDoorPurchasable ), true)]
		public string PlayerSteamIDWhoOwnsDoor { get; set; }

		[Property, Feature("Door Info"), ShowIf ( nameof( IsDoorPurchasable ), true)]
		public string[] PlayerFriendsSteamIDWhoOwnsDoor { get; set; }
		
		[Property, Feature( "Door Info" )]
		public string[] WhitelistedJobDoorGroups { get; set; }
		
		[Property, Feature("Door Info")]
		public string[] BlacklistedJobDoorGroups { get; set; }


		//Needed Vars for having dooring open/close correctly in the right directions
		public bool DoorInt0OpeningBool { get; set; }

		public bool DoorInt0ClosingBool { get; set; }

		public bool DoorInt1OpeningBool { get; set; }

		public bool DoorInt1ClosingBool { get; set; }

		public Rotation DoorLocalRotation { get; set; }

		public bool IsDoorOpen { get; set; }


		// Called every frame while the player is looking at this object.
		public bool Look( Ray ray ) => true;

		// Called once when the player starts looking at this object.
		public void Hover() { }

		// Called once when the player stops looking at this object.
		public void Blur() { }

		// Determine if pressing is currently allowed (always true here).
		public bool CanPress() => true;


		[ActionGraphNode( "On Pressed" )]
		public void FirePressed()
		{
			// This node becomes available in the Action Graph
		}

	// Called when the player presses the use key on this object.
	// public bool Press(Component.IPressable.Event pressEvent)
	// {

	// }

		// Called each frame while the use key is held down.
		public bool Pressing(Component.IPressable.Event pressEvent) => true;

		// Called when the use key is released.
		public void Release(Component.IPressable.Event pressEvent) { }

		protected override void OnUpdate()
		{

		}
	}