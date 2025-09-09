using Sandbox;
using System;
using System.Collections.Generic;

[GameResource("JobDef", "job", "Defines a DarkRP style job")]
public class JobResource : GameResource
{
    [Property] public string Title { get; set; }
    [Property, TextArea] public string Description { get; set; }
    [Property] public int Salary { get; set; }
    [Property] public Color Color { get; set; }
    [Property] public string JobCategory { get; set; }
    [Property] public float JobHealth { get; set; }
    [Property] public float JobHealthMax { get; set; }
    [Property] public float JobArmor { get; set; }
    [Property] public float JobArmorMax { get; set; }



    public List<PickupableEntity> StartingEquipment { get; set; }

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