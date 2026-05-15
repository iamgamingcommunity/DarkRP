using Sandbox;
using System;
using System.Collections.Generic;

[GameResource("AmmoDef", "ammo", "Defines a DarkRP style Ammo for Sweps", Category = "DarkRP")]
public class AmmoResource : GameResource
{
    [Property, Group("Basic Ammo Info")] public string AmmoName { get; set; }
    [Property, Group("Basic Ammo Info")] public PrefabFile AmmoModel { get; set; }
    [Property, Group("Basic Ammo Info")] public int AmmoPrice { get; set; }
    [Property, Group("Basic Ammo Info")] public int AmmoAmountGiven { get; set; }
    [Property, Group("Basic Ammo Info")] public bool RestrictAmmoToJob { get; set; }
    [Property, Group("Basic Ammo Info"), ShowIf ( nameof( RestrictAmmoToJob ), true)] public List<JobResource> JobsThatCanUseTheAmmo { get; set; }


    public static IReadOnlyList<AmmoResource> All => _all;
    internal static List<AmmoResource> _all = new();

    // Event for when all job assets are loaded
    public static event Action OnAmmoLoaded;

    protected override void PostLoad()
    {
        base.PostLoad();

        if (!_all.Contains(this))
            _all.Add(this);

        // Fire the event once (after the first job is loaded)
        // For multiple Ammo, it’s fine — subscribers can check JobResource.All.Count
        OnAmmoLoaded?.Invoke();
    }

        //Create Custom File Icon
    public PrefabFile Prefab { get; set; }


	public override Bitmap RenderThumbnail( ThumbnailOptions options )
	{
		// No prefab - can't make a thumbnail
		if ( Prefab is null ) return default;

		var bitmap = new Bitmap( options.Width, options.Height );
		bitmap.Clear( Color.Transparent );

		SceneUtility.RenderGameObjectToBitmap( Prefab.GetScene(), bitmap );

		return bitmap;
	}

	protected override Bitmap CreateAssetTypeIcon( int width, int height )
	{
		return CreateSimpleAssetTypeIcon( "💥", width, height, "#9c5513" );
	}
}