using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;

public class StorageMapSave : Component
{

	[Property, Feature("Extra"), Group("Extra")] public GameObject TestGameOjbect { get; set; }

	[Property, Feature("Extra"), Group("Extra")] public string IdTest { get; set; }



[Button("New Save")]
    public void SaveMapDirectly(GameObject TestGameOjbect)
    {
        var saveEntry = Storage.CreateEntry("save");
        saveEntry.Files.WriteAllText("player.json", "playerJson");
		saveEntry.SetMeta("level", TestGameOjbect);              // what level they are at
		saveEntry.SetMeta("playtime", 3600);        // how long they’ve been playing
        Log.Info($"Map saved! Entry ID: {saveEntry.Id}");
   }

	[Button("Delete All Saves")]
    public void DeleteAllSaves()
    {
        // Get all save entries of type "save"
        var allSaves = Storage.GetAll("save");
        // Loop through all saves
        foreach (var save in allSaves)
        {
			save.Delete();
			Log.Info($"Deleted ID: {save.Id}");
   		}
   }





    // Load all saves
    public void LoadAllSaves()
    {
        // Get all save entries of type "save"
        var allSaves = Storage.GetAll("save");


        // Loop through all saves
        foreach (var save in allSaves)
        {
            Log.Info($"Save ID: {save.Id}");
            Log.Info($"Created: {save.Created}");

            // Metadata
            var playerName = save.GetMeta<string>("playerName");
            var level = save.GetMeta<int>("level");
            Log.Info($"Player: {playerName}, Level: {level}");

            // Files
            if (save.Files.FileExists("player.json"))
            {
                var playerJson = save.Files.ReadAllText("player.json");
                Log.Info($"player.json content: {playerJson}");
            }
   		}


}







   
}