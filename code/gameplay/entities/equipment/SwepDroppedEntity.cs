using Sandbox;
using System;

//namespace GameSystems.BaseEntity;
//namespace TeaAddon;
[Library("swepdroppedentity", Title = "SwepDroppedEntity", Description = "")]
public partial class SwepDroppedEntity : BaseEntity
{

	[Property, Feature("Swep Dropped Entity"), Group("Swep Dropped Entity")] 
	public PickupableEntity SwepDataFile { get; set; }
	
    [Property, Feature("Swep Dropped Entity"), Group("Swep Dropped Entity")] 
	public GameObject SwepMuzzle { get; set; }

    [Property, Feature("Swep Dropped Entity"), Group("Swep Dropped Entity")] 
	public GameObject SwepBulletEjectionPort { get; set; }

    [Property, Feature("Swep Dropped Entity"), Group("Swep Dropped Entity"), Description("WARNING: ONLY ENABLE WHEN THIS COMPONENT IS ON THE swep world model.")] 
	public bool SwepComponentOnModel { get; set; }

    [Property, ShowIf ( nameof( SwepComponentOnModel ), true), Feature("Swep Dropped Entity"), Group("Swep Dropped Entity"), Description("WARNING: DON'T FILL THIS VAR WHEN THIS COMPONENT IS ON THE 'model'!!! ONLY FILL THIS VAR WHEN IT'S ON THE world model sweps.")] 
	public GameObject SwepModel { get; set; }

    [Property, Feature("Swep Dropped Entity"), Group("Swep Dropped Entity")] 
	public GameObject DebugBullet { get; set; }






     protected override void OnStart()
    {
        // var entity = GameObject.GetComponent<BaseEntity>();

        // if ( entity != null )
        // {
        //     // Example override behavior
        //     Log.Info($"DID IT!!");
        // }
    }

}
///
///		if Renderer.Parameters.GetBool("IsOpen?", true)
///			{
///				Log.Info("SweatyDebugInfo: Renderer Paraneter Fired! False");
///				Renderer.Parameters.Set("IsOpen?", false);
///				return true; 
///			}
///		else
///			Log.Info("SweatyDebugInfo: Renderer Paraneter Fired! True");
///		Renderer.Parameters.Set("IsOpen?", true);
///        return true; 
///    }