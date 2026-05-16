using Sandbox;
using System;
using System.Collections.Generic;

[GameResource("JobDef", "job", "Defines a DarkRP style job", Category = "DarkRP")]
public class JobResource : GameResource
{

    //Basic Job Info
    [Property, Group("Basic Job Info")] public string Title { get; set; }
    [Property, Group("Basic Job Info")] public Texture JobImage { get; set; }
    [Property, Group("Basic Job Info")] public string JobCommandName { get; set; }
    [Property, TextArea, Group("Basic Job Info")] public string Description { get; set; }
    [Property, Group("Basic Job Info")] public int Salary { get; set; }
    [Property, Group("Basic Job Info")] public Color Color { get; set; }
    [Property, Group("Basic Job Info")] public List<Clothing> JobClothes { get; set; }
    [Property, Group("Basic Job Info")] public CategoryResource JobCategory { get; set; }
    [Property, Group("Basic Job Info")] public int MaxPlayersAllowedOnJob { get; set; }
    [Property, Group("Basic Job Info")] public bool IsInfiniteJobSlots { get; set; }
    [Property, Group("Basic Job Info")] public int SortingLevel { get; set; }

    //Job Health Info
    [Property, Group("Job Health Info")] public float JobHealth { get; set; }
    [Property, Group("Job Health Info")] public float JobHealthMax { get; set; }
    [Property, Group("Job Health Info")] public float JobArmor { get; set; }
    [Property, Group("Job Health Info")] public float JobArmorMax { get; set; }

    
    //Extra Job Info
    [Property, Group("Extra Job Info")] public bool IsPD { get; set; }
    [Property, Group("Extra Job Info")] public bool IsMayor { get; set; }
    [Property, Group("Extra Job Info")] public bool IsUsingDefaultJobEquipment { get; set; }
    [Property, Group("Extra Job Info")] public List<SwepEntity> StartingEquipment { get; set; }

    //Restrictions To Job Info
    [Property, Group("Restrictions To Job")] public bool IsVoteNeeded { get; set; }
    [Property, Group("Restrictions To Job")] public int PlayTimeNeededToPlay { get; set; }


   
    [Property, Group("Restrictions To Job"), Description("Enable Job Whitelist & Blacklist System? This will enable the filling of the list of Jobs the player has Whitelisted/Blacklisted.")] public bool IsJobWhitelistEnabled { get; set; }	

    //UserGroups
    [Property, Group("Restrictions To Job")] public bool IsForUserGroups { get; set; }
    [Property, Group("Restrictions To Job"), ShowIf ( nameof( IsForUserGroups ), true), Description("If True, Only the Usergroups listed will be allowed to get onto the job. If False, every usergroup can use the job.")] public List<string> UserGroupThatCanUseJob{ get; set; }
    [Property, Group("Restrictions To Job"), ShowIf ( nameof( IsForUserGroups ), true), Description("If True, Non Assaigned user groups will have x amount of time to play on the job until the 'TempPlayTimeTotalCycleAmount' resets the time back to the total amount you want the player to be on the job.")] public bool HasTempPlayTime { get; set; }
    [Property, Group("Restrictions To Job"), ShowIf ( nameof( IsForUserGroups ), true), Description("0 = Nothing, 60 = 1 minute. So set the total time here to be the total amount of time you want the player to play on the job.")] public int TempPlayTimeTotalAmount { get; set; }
    
    //SteamID
    [Property, Group("Restrictions To Job")] public bool IsForSteamUsers { get; set; }
    [Property, Group("Restrictions To Job"), ShowIf ( nameof( IsForSteamUsers ), true), Description("If True, Only the Usergroups listed will be allowed to get onto the job. If False, every usergroup can use the job.")] public List<string> SteamIDsThatCanUseJob{ get; set; }






    public static IReadOnlyList<JobResource> All => _all;
    internal static List<JobResource> _all = new();

    // Event for when all job assets are loaded
    public static event Action OnJobsLoaded;

    protected override void PostLoad()
    {
        base.PostLoad();

        if (!_all.Contains(this))
            _all.Add(this);

        // Fire the event once (after the first job is loaded)
        // For multiple jobs, it’s fine — subscribers can check JobResource.All.Count
        OnJobsLoaded?.Invoke();
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
		return CreateSimpleAssetTypeIcon( "👤", width, height, "#3ae934" );
	}

}