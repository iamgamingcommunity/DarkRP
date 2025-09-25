using Sandbox;
using System;

//namespace GameSystems.BaseEntity;
//namespace TeaAddon;
[Library("swepdroppedentity", Title = "SwepDroppedEntity", Description = "")]
public partial class SwepDroppedEntity : BaseEntity
{

	[Property, Feature("Swep Dropped Entity"), Group("Swep Dropped Entity")] 
	public PickupableEntity SwepDataFile { get; set; }







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