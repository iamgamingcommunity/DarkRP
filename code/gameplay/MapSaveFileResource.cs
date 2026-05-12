using Sandbox;
using System;
using System.Collections.Generic;

[GameResource("MapSaveFile", "maps", "A File that holds all Game Objects Related to the map.", Category = "DarkRP")]
public class MapSaveFileResource : GameResource
{


    [Property, Group("Map Saved GameObjects Info")] public PermaGameObjectsStruct MapSaveFile { get; set; }




	public struct PermaGameObjectsStruct
	{
		[KeyProperty] public string MapInstanceName { get; set; }
        [KeyProperty] public GameObjectsStruct SaveGameObjects { get; set; }

	}

	public struct GameObjectsStruct
	{
		[Property] public List<GameObjectsInfoStruct> SpawnPoints { get; set; }
        [Property] public List<GameObjectsInfoStruct> JailPositions { get; set; }
        [Property] public List<GameObjectsInfoStruct> DoorPositions { get; set; }
        [Property] public List<GameObjectsInfoStruct> WindowPositions { get; set; }
        [Property] public List<GameObjectsInfoStruct> ElevatorPositions { get; set; }		
        [Property] public List<GameObjectsInfoStruct> Extra { get; set; }	
	}

    public struct GameObjectsInfoStruct
	{
		[Property] public GameObject GameObject { get; set; }
    	[Property] public Vector3 GameObjectPosition { get; set; }
    	[Property] public Rotation GameObjectRotation { get; set; }	
    	[Property] public Vector3 GameObjectScale { get; set; }	
	}

    public static IReadOnlyList<MapSaveFileResource> All => _all;
    internal static List<MapSaveFileResource> _all = new();

    // Event for when all job assets are loaded
    public static event Action MapSaveFileResourceLoaded;

    protected override void PostLoad()
    {
        base.PostLoad();

        if (!_all.Contains(this))
            _all.Add(this);

        // Fire the event once (after the first job is loaded)
        // For multiple jobs, it’s fine — subscribers can check JobResource.All.Count
        MapSaveFileResourceLoaded?.Invoke();
    }




      private bool IsInValidPath()
    {
        // Normalize the path (for different OS separators)
        var path = ResourcePath.ToLower();

        // Only allow commands from these folders
        return path.StartsWith("assets/gameplay/addons/") ||
               path.StartsWith("assets/gameplay/world/mapssavefiles");
    }

}