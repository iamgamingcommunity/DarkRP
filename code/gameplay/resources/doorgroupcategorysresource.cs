using Sandbox;
using System;
using System.Collections.Generic;

[GameResource("DoorGC", "doorgc", "Defines a DarkRP Door Group.", Category = "DarkRP")]
public class DoorGroupCategoryResource : GameResource
{
    [Property] public string Title { get; set; }
    [Property, TextArea] public string Description { get; set; }
    [Property] public Color Color { get; set; }

    public List<JobResource> DoorGroupJobs { get; set; } = new();











    public static IReadOnlyList<DoorGroupCategoryResource> All => _all;
    internal static List<DoorGroupCategoryResource> _all = new();

    // Event for when all job assets are loaded
    public static event Action OnDoorGroupCategoryResourceLoaded;

    protected override void PostLoad()
    {
        base.PostLoad();

        if (!_all.Contains(this))
            _all.Add(this);

        // Fire the event once (after the first job is loaded)
        // For multiple jobs, it’s fine — subscribers can check JobResource.All.Count
        OnDoorGroupCategoryResourceLoaded?.Invoke();
    }


    //Create Custom File Icon
    [Property]
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
		return CreateSimpleAssetTypeIcon( "🚪", width, height, "#a16238" );
	}




}