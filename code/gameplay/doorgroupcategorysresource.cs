using Sandbox;
using System;
using System.Collections.Generic;

[GameResource("DoorGC", "doorgc", "Defines a DarkRP Door Group.")]
public class DoorGroupCategoryResource : GameResource
{
    [Property] public string Title { get; set; }
    [Property, TextArea] public string Description { get; set; }
    [Property] public Color Color { get; set; }

    public List<JobResource> DoorGroupJobs { get; set; }














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
}