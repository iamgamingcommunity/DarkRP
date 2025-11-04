using Sandbox;

public sealed class PermaGameObjectsSystem : Component
{



 [Property, Feature("Map Info"), Group("Map Saved GameObjects Info")] public List<MapSaveFileResource> MapSaveFile { get; set; }

 [Property, Feature("Save Buttons"), Group("Save Buttons")] public MapSaveFileResource SaveMapSaveFile { get; set; }

 [Property, Feature("Save Buttons"), Group("Save Buttons")] public MapSaveFileResource.GameObjectsInfoStruct InfoStruct { get; set; }

 [Property, Feature("Save Buttons"), Group("Save Buttons")] public List<GameObject> TempGameObjects { get; set; }

    public struct GameObjectsInfoStruct
	{
		[Property] public GameObject GameObject { get; set; }
    	[Property] public Vector3 GameObjectPosition { get; set; }
    	[Property] public Rotation GameObjectRotation { get; set; }	
    	[Property] public Vector3 GameObjectScale { get; set; }	
	}

    //Action Graphs
	public delegate void ActionGraphSaveAllDoors();
	[Property, Feature("Save Buttons"), Group("Action Graphs"), Title("Save All Doors Logic")]
	public ActionGraphSaveAllDoors GraphSaveAllDoors { get; set; }






    [Button, Property, Feature("Save Buttons"), Group("Save Buttons"), Title("Save All Doors")]
	public void SaveAllDoors()
	{
		GraphSaveAllDoors?.Invoke();
	}


}
