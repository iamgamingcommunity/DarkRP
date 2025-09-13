using Sandbox;
using System;
using System.Collections.Generic;
using System.Drawing;
using DarkRPGamemode;

[GameResource("Category", "category", "Defines a DarkRP style category for Jobs, Entity's, Ammo. Etc.")]
public class CategoryResource : GameResource
{
    [Property] public string Name { get; set; }

    [Property] public Color Color { get; set; } = Color.White; // optional color for UI

    [Property] 
    public DarkRPGamemode.TypeOfCategorys TypeOfCategorys { get; set; }

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
}
