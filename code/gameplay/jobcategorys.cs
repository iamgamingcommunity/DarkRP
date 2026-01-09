using Sandbox;
using System;
using System.Collections.Generic;
using System.Drawing;
using DarkRPGamemode;
using System.Diagnostics.CodeAnalysis;

[GameResource("Category", "category", "Defines a DarkRP style category for Jobs, Entity's, Ammo. Etc.")]
public class CategoryResource : GameResource
{
    [Property] public string Name { get; set; }

    [Property] public Color Color { get; set; } = Color.White; // optional color for UI

    [Property] 
    public DarkRPGamemode.TypeOfCategorys TypeOfCategorys { get; set; }




        [Property, ShowIf ( nameof( TypeOfCategorys ), DarkRPGamemode.TypeOfCategorys.Jobs), Feature("Jobs"), Group("JobCatagory")] public List<JobResource> JobsInCatagory { get; set; }

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
}
