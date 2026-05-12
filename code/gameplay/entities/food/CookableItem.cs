using Sandbox;

//[Library("Food", Title = "Food")]
public partial class CookableItem : Food
{
	[Property, FeatureEnabled("Cooking")]
	public bool Cooking { get; set; } = false;

	[Property, Feature("Cooking")]
    public int ItemCookTime { get; set; }

	[Property, Feature("Cooking")]
    public SoundEvent IngredientMixingSound { get; set; }

	[Property, Feature("Cooking")]
	public IngredientData[] Ingredients { get; set; }
	
	//Structure for Cooking Data
	public struct IngredientData
{
	[KeyProperty] public string IngredientName { get; set; }
	[KeyProperty] public int IngredientAmount { get; set; }
	[KeyProperty] public bool IngredientDone { get; set; }
}



	protected override void OnUpdate()
	{

	}   

}
