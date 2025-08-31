using Sandbox;
using System;

//namespace GameSystems.BaseEntity;
//namespace TeaAddon;
[Library("microwave", Title = "Microwave")]
public partial class Microwave : BaseEntity
{

    [Property, Feature("Microwave")]
    public SkinnedModelRenderer Renderer { get; set; }

    [Property, Feature("Microwave")]
    public GameObject TargetObject { get; set; }

    [Property, Feature("Microwave")]
    public GameObject ObjectRef { get; set; }

    [Property, Feature("Microwave")]
    public bool IsCooking { get; set; }
    
    [Property, Feature("Microwave")]
    public SoundEvent MicrowaveItemSound { get; set; }

    [Property, Feature("Microwave")]
    public SoundEvent MicrowaveDoneSound { get; set; }



     protected override void OnStart()
    {
        // var entity = GameObject.GetComponent<BaseEntity>();

        // if ( entity != null )
        // {
        //     // Example override behavior
        //     Log.Info($"DID IT!!");
        // }
    }








    // Called every frame while the player is looking at this object. Note:
    public bool Look(Ray ray) => false;

    // Called once when the player starts looking at this object.
    public void Hover() { }

    // Called once when the player stops looking at this object.
    public void Blur() { }

    // Determine if pressing is currently allowed (always true here).
    public bool CanPress() => false;

    // Called when the player presses the use key on this object.
    // public bool Press(Component.IPressable.Event pressEvent)
    // {
    //     if (!IsCooking)
    //     {
    //         // Get current state (defaults to false if not set yet)
    //         bool isOpen = Renderer.Parameters.GetBool("IsOpen?");

    //         // Toggle it
    //         isOpen = !isOpen;
    //         Renderer.Parameters.Set("IsOpen?", isOpen);

    //         Log.Info($"SweatyDebugInfo: Renderer Parameter toggled! Now: {isOpen}");

    //         return true;
    //     }
    //     return false;
    // }

    // Called each frame while the use key is held down.
    // public bool Pressing(Component.IPressable.Event pressEvent) { }


    // Called when the use key is released.
    public void Release(Component.IPressable.Event pressEvent) { }

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