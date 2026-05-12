using Sandbox;
using System;
using System.Collections.Generic;
using System.Drawing;
using DarkRPGamemode;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

[GameResource("Category", "category", "Defines a DarkRP style category for Jobs, Entity's, Ammo. Etc.", Category = "DarkRP")]
public class CategoryResource : GameResource
{
    [Property] public string Name { get; set; }

    [Property] public Color Color { get; set; } = Color.White; // optional color for UI

    [Property] 
    public DarkRPGamemode.TypeOfCategorys TypeOfCategorys { get; set; }


public class JobCategoryInfoStructMain
{
    public JobResource JobsInCategory { get; set; }
    // Not Needed? [Description("Only Allow Certain Usergroup to Use The jobs.")]public List<string> Whitelist { get; set; }

}

public struct MiscCategoryInfoStructMain
{
    public PrefabFile MiscEntitiesInCategory { get; set; }
    public int MiscCurrentItemsBought { get; set; }

    public bool HideUI { get; set; }
    [Description("Only Allow Certain Usergroup to Buy The Misc Items.")]public List<string> Whitelist { get; set; }
}



        [Property, ShowIf ( nameof( TypeOfCategorys ), DarkRPGamemode.TypeOfCategorys.Jobs), Feature("Jobs"), Group("JobCategory")] public List<JobCategoryInfoStructMain> JobCategoryInfo { get; set; } 
        [Property, ShowIf ( nameof( TypeOfCategorys ), DarkRPGamemode.TypeOfCategorys.Miscellaneous), Feature("Misc"), Group("MiscCategory")] public List<MiscCategoryInfoStructMain> MiscEntitiesInCategory { get; set; }
        public bool IsJobCategory =>
        TypeOfCategorys == DarkRPGamemode.TypeOfCategorys.Jobs;

        public bool IsEntityCategory =>
        TypeOfCategorys == DarkRPGamemode.TypeOfCategorys.Entities;

        public bool IsWeaponsCategory =>
        TypeOfCategorys == DarkRPGamemode.TypeOfCategorys.Weapons;

        public bool IsShipmentsCategory =>
        TypeOfCategorys == DarkRPGamemode.TypeOfCategorys.Shipments;

        public bool IsAmmoCategory =>
        TypeOfCategorys == DarkRPGamemode.TypeOfCategorys.Ammo;

        public bool IsVehiclesCategory =>
        TypeOfCategorys == DarkRPGamemode.TypeOfCategorys.Vehicles;

        public bool IsMiscellaneousCategory =>
        TypeOfCategorys == DarkRPGamemode.TypeOfCategorys.Miscellaneous;









    // Keep track of all categories
    public static IReadOnlyList<CategoryResource> All => _all;
    internal static List<CategoryResource> _all = new();

    public static event Action OnCategoriesLoaded;

    protected override void PostLoad()
    {
        base.PostLoad();

        if (!_all.Contains(this))
            _all.Add(this);

        OnCategoriesLoaded?.Invoke();
    }






    //Create Custom File Icon
    private PrefabFile CustomFileIconPrefab { get; set; }


	public override Bitmap RenderThumbnail( ThumbnailOptions options )
	{
		// No prefab - can't make a thumbnail
		if ( CustomFileIconPrefab is null ) return default;

		var bitmap = new Bitmap( options.Width, options.Height );
		bitmap.Clear( Color.Transparent );

		SceneUtility.RenderGameObjectToBitmap( CustomFileIconPrefab.GetScene(), bitmap );

		return bitmap;
	}

	protected override Bitmap CreateAssetTypeIcon( int width, int height )
	{
		return CreateSimpleAssetTypeIcon( "📊", width, height, "#2daadb" );
	}

}
