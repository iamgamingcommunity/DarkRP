using Sandbox;
using System;

//namespace GameSystems.BaseEntity;
//namespace TeaAddon;
[Library("ammo", Title = "Ammo")]
public partial class Ammo : BaseEntity
{

    [Property, Feature("Basic Ammo Info"), Group("Basic Ammo Info")] public AmmoResource AmmoResourceFile { get; set; }


     protected override void OnStart()
    {
        // var entity = GameObject.GetComponent<BaseEntity>();

        // if ( entity != null )
        // {
        //     // Example override behavior
        //     Log.Info($"DID IT!!");
        // }
    }








    // // Called every frame while the player is looking at this object. Note:
    // public bool Look(Ray ray) => false;

    // // Called once when the player starts looking at this object.
    // public void Hover() { }

    // // Called once when the player stops looking at this object.
    // public void Blur() { }

    // // Determine if pressing is currently allowed (always true here).
    // public bool CanPress() => false;


    // Called when the use key is released.
    public void Release(Component.IPressable.Event pressEvent) { }

}
