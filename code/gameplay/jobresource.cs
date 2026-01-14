using Sandbox;
using System;
using System.Collections.Generic;

[GameResource("JobDef", "job", "Defines a DarkRP style job")]
public class JobResource : GameResource
{
    [Property, Group("Basic Job Info")] public string Title { get; set; }
    [Property, Group("Basic Job Info")] public Texture JobImage { get; set; }
    [Property, Group("Basic Job Info")] public string JobCommandName { get; set; }
    [Property, TextArea, Group("Basic Job Info")] public string Description { get; set; }
    [Property, Group("Basic Job Info")] public int Salary { get; set; }
    [Property, Group("Basic Job Info")] public Color Color { get; set; }
    [Property, Group("Basic Job Info")] public List<Clothing> JobClothes { get; set; }
    [Property, Group("Basic Job Info")] public CategoryResource JobCategory { get; set; }
    [Property, Group("Basic Job Info")] public int MaxPlayersAllowedOnJob { get; set; }
    [Property, Group("Basic Job Info")] public int SortingLevel { get; set; }
    [Property, Group("Job Health Info")] public float JobHealth { get; set; }
    [Property, Group("Job Health Info")] public float JobHealthMax { get; set; }
    [Property, Group("Job Health Info")] public float JobArmor { get; set; }
    [Property, Group("Job Health Info")] public float JobArmorMax { get; set; }
    [Property, Group("Extra Job Info")] public bool IsPD { get; set; }
    [Property, Group("Extra Job Info")] public bool IsMayor { get; set; }
    [Property, Group("Extra Job Info")] public bool IsUsingDefaultJobEquipment { get; set; }
    [Property, Group("Extra Job Info")] public List<PickupableEntity> StartingEquipment { get; set; }

    [Property, Group("Restrictions To Job")] public bool IsVoteNeeded { get; set; }
    [Property, Group("Restrictions To Job")] public int PlayTimeNeededToPlay { get; set; }
    
    [Property, Group("Restrictions To Job")] public bool IsOnlyForUserGroups { get; set; }
    [Property, Group("Restrictions To Job"), ShowIf ( nameof( IsOnlyForUserGroups ), true), Description("If True, Only the Usergroups listed will be allowed to get onto the job. If False, every usergroup can use the job.")] public List<string> UserGroupThatCanOnlyUseJob{ get; set; }
    [Property, Group("Restrictions To Job"), ShowIf ( nameof( IsOnlyForUserGroups ), true), Description("If True, Non Assaigned user groups will have x amount of time to play on the job until the 'TempPlayTimeTotalCycleAmount' resets the time back to the total amount you want the player to be on the job.")] public bool HasTempPlayTime { get; set; }
    [Property, Group("Restrictions To Job"), ShowIf ( nameof( IsOnlyForUserGroups ), true), Description("0 = Nothing, 60 = 1 minute. So set the total time here to be the total amount of time you want the player to play on the job.")] public int TempPlayTimeTotalAmount { get; set; }

    





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
}