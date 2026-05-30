using Sandbox;


[Title("Check System"), Description("'Check' or 'Cheque' is a component for the base DarkRP Framework Money Check System.")]
public class Check : BaseEntity
{

	//Base'Check' or 'Cheque' Vars
        [Property, Feature("Money Info")]
		public int MoneyStackAmount { get; set; }


		[Property, Feature("Money Info")]
		public string PlayerRecipientName { get; set; }

		
		[Property, Feature("Money Info")]
		public string PlayerRecipientSteamID { get; set; }

		[Property, Feature("Money Info")]
		public string PlayerSenderName { get; set; }

		[Property, Feature("Money Info")]
		public string PlayerSenderSteamID { get; set; }


		



}