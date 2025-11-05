using Sandbox;
using System.Linq;

//
// 2) Save prefab metadata to UGC
//
[Category("IAG | UGC Storage")]
[Title("Save GameObject to UGC")]
public static class SavePrefabUGCNode
{
    public struct PrefabSaveData
    {
        public string Id { get; set; }       // Can be prefab ID or name
        public Vector3 Position { get; set; }
        public Rotation Rotation { get; set; }
    }

    [ActionGraphNode("UGC/Save GameObject")]
    [Input]
    public static void Save(GameObject obj, string saveName = "MyPrefab", string saveType = "prefabs")
    {
        if (obj == null)
        {
            Log.Warning("[UGC Save] No object provided.");
            return;
        }

        var saveComp = obj.Components.Get<SaveGameObject>();
        if (saveComp == null || saveComp.PrefabFile == null)
        {
            Log.Warning("[UGC Save] Object does not have a SaveGameObject component with a prefab.");
            return;
        }

        try
        {
            var entry = Storage.CreateEntry(saveType);

            var prefabData = new PrefabSaveData
            {
                Id = saveComp.PrefabFile.Id.ToString(), // or use Name if you prefer
                Position = obj.Transform.Position,
                Rotation = obj.Transform.Rotation
            };

            entry.Files.WriteJson("prefab.json", prefabData);
            entry.SetMeta("prefabName", saveName);
            entry.SetMeta("prefabId", saveComp.PrefabFile.Id.ToString());
            entry.SetMeta("savedAt", System.DateTime.UtcNow.ToString("o"));

            Log.Info($"[UGC Save] Saved '{saveName}' with prefab ID '{prefabData.Id}' into entry {entry.Id}");
        }
        catch (System.Exception ex)
        {
            Log.Error($"[UGC Save] Failed: {ex.Message}");
        }
    }

    //
    // Load function (create instance directly)
    //
    [ActionGraphNode("UGC/Load GameObject")]
    [Input]
    public static GameObject Load(string entryId)
    {
        try
        {
            var entry = Storage.GetAll("prefabs").FirstOrDefault(x => x.Id.ToString() == entryId);
            if (entry == null)
            {
                Log.Warning($"[UGC Load] No entry found with ID {entryId}");
                return null;
            }

            var prefabData = entry.Files.ReadJson<PrefabSaveData>("prefab.json");

            // Load the actual prefab
            var prefab = Prefab.Load(prefabData.Id);
            if (prefab == null)
            {
                Log.Warning($"[UGC Load] Could not load prefab with ID {prefabData.Id}");
                return null;
            }

            // Instantiate the object
            var obj = SceneUtility.Instantiate(prefab, prefabData.Position, prefabData.Rotation);
            Log.Info($"[UGC Load] Spawned prefab '{prefabData.Id}' at {prefabData.Position}");

            return obj;
        }
        catch (System.Exception ex)
        {
            Log.Error($"[UGC Load] Failed: {ex.Message}");
            return null;
        }
    }
}