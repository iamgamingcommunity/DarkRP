using Sandbox;
using System;
using System.Collections.Generic;
using System.Drawing;

[GameResource("Job Category", "jobcategory", "Defines a DarkRP style job category")]
public class JobCategoryResource : GameResource
{
    [Property] public string Name { get; set; }

    [Property] public Color Color { get; set; } = Color.White; // optional color for UI

    [Property, ResourceType("vmdl")] public string Icon { get; set; } // optional model/icon

    // Keep track of all categories
    public static IReadOnlyList<JobCategoryResource> All => _all;
    internal static List<JobCategoryResource> _all = new();

    public static event Action OnCategoriesLoaded;

    protected override void PostLoad()
    {
        base.PostLoad();

        if (!_all.Contains(this))
            _all.Add(this);

        OnCategoriesLoaded?.Invoke();
    }
}
