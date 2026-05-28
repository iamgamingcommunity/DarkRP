using Sandbox;
using System;


	public partial class Money: BaseEntity
	{
        [Property, Feature("Money Info")]
		public int MoneyStackAmount { get; set; }

	
	}

    