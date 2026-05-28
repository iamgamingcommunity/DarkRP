using Sandbox;


[Title("Check System"), Description("'Check' or 'Cheque' is a component for the base DarkRP Framework Money Check System.")]
public class Check : BaseEntity
{

	//Base'Check' or 'Cheque' Vars
        [Property, Feature("Money Info")]
		public int MoneyStackAmount { get; set; }


		[Property, Feature("Money Info")]
		public string PlayerName { get; set; }



}