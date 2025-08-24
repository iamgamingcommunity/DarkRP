using Sandbox;
using System;
namespace TeaAddon;
public sealed class MicrowaveInteraction : Component, Component.IPressable
{
	[Property, Title("Skinned Model Renderer")]
	public SkinnedModelRenderer Renderer { get; set; }
	
	[Property, Title("Target Object")]
    public GameObject TargetObject { get; set; }

    [Property, Title("GameObjectRef")]
    public GameObject GameObjectRef { get; set; }
    
    [Property, Title("IsCooking?")]
    public bool IsCooking { get; set; }

    [Property, Title("Prefab")]
    public PrefabFile Prefab { get; set; }

    [Property, Title("MicrowaveLogicActionGraph")]
    public Action Graph { get; set; }

    [Property, Title("MicrowaveItemSound")]
    public SoundEvent MicrowaveItemSound { get; set; }

    [Property, Title("MicrowaveDoneSound")]
    public SoundEvent MicrowaveDoneSound { get; set; }


    // Called every frame while the player is looking at this object.
    public bool Look(Ray ray) => true;

    // Called once when the player starts looking at this object.
    public void Hover() {}

    // Called once when the player stops looking at this object.
    public void Blur() {}

    // Determine if pressing is currently allowed (always true here).
    public bool CanPress() => true;

    // Called when the player presses the use key on this object.
    public bool Press(Component.IPressable.Event pressEvent)
    {
        if (!IsCooking)
        {
            // Get current state (defaults to false if not set yet)
            bool isOpen = Renderer.Parameters.GetBool("IsOpen?");

            // Toggle it
            isOpen = !isOpen;
            Renderer.Parameters.Set("IsOpen?", isOpen);

            Log.Info($"SweatyDebugInfo: Renderer Parameter toggled! Now: {isOpen}");

            return true;
        }
        return false;
    }

    // Called each frame while the use key is held down.
    public bool Pressing(Component.IPressable.Event pressEvent) => true;

    // Called when the use key is released.
    public void Release(Component.IPressable.Event pressEvent) {} 

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