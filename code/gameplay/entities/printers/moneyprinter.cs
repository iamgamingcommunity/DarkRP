using Sandbox;
using System;


	public partial class MoneyPrinter: BaseEntity
	{
		//Future Money Printer Var?
        // [Property, Feature("Money Printer Info")]
		// public int CurrentMoneyStackAmount { get; set; }
        [Property, Feature("Money Printer Info")]
		public int MoneyPrinterPrintAmount { get; set; }
		
		[Property, Feature("Money Printer Info")]
		public int MoneyPrinterPrintTime { get; set; }

		[Property, Feature("Money Printer Info")]
		public bool IsPrinting { get; set; } = true;

		[Property, Feature("Money Printer Info")]
		public PrefabFile MoneyEntity { get; set; }


		

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
		// Called each frame while the use key is held down.
		public bool Pressing(Component.IPressable.Event pressEvent) => true;

		// Called when the use key is released.
		public void Release(Component.IPressable.Event pressEvent) { }

		protected override void OnUpdate()
		{

		}
	}