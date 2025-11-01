using Sandbox;

public sealed class PermaGameObjectsSystem : Component
{



 [Property, Feature("Map Info"), Group("Map Saved GameObjects Info")] public List<MapSaveFileResource> MapSaveFile { get; set; }






}
