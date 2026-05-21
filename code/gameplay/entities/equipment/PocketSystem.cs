using Sandbox;
using System.Collections.Generic;
using System.Text.Json.Nodes;

public sealed class PocketSystem : Component
{

    [Property]
    public List<GameObject> TestPocketItems { get; set; } = new();



    [Property]
    public List<PocketItemData> PocketItems { get; set; } = new();

    public class PocketItemData
    {
        public string PrefabPath { get; set; }
        public JsonObject SerializedData { get; set; }
        public string ItemName { get; set; }
        public string PocketType { get; set; }
    }

    public void PocketObject( GameObject obj )
    {
        if ( obj == null )
            return;

        PocketItems.Add( new PocketItemData
        {
            PrefabPath = obj.PrefabInstanceSource,
            SerializedData = obj.Serialize(),
            ItemName = obj.Name,
            PocketType = "Generic"
        } );

        Log.Info( $"Pocketed: {obj.Name}" );
        obj.Destroy();
    }

    public GameObject UnpocketObject( int index, Vector3 position )
    {
        if ( index < 0 || index >= PocketItems.Count )
            return null;

        var data = PocketItems[index];

        if ( string.IsNullOrWhiteSpace( data.PrefabPath ) )
        {
            Log.Info( "No prefab path stored for this pocket item." );
            return null;
        }

        var go = GameObject.Clone( data.PrefabPath, null );
        if ( go == null )
        {
            Log.Info( $"Failed to clone prefab: {data.PrefabPath}" );
            return null;
        }

        go.WorldPosition = position;
        go.Deserialize( data.SerializedData );

        PocketItems.RemoveAt( index );

        Log.Info( $"Unpocketed: {data.ItemName}" );
        return go;
    }

    public void SavePocket()
    {
        FileSystem.Data.WriteJson( "pocket_inventory.json", PocketItems );
        Log.Info( "Pocket inventory saved." );
    }

    public void LoadPocket()
    {
        if ( !FileSystem.Data.FileExists( "pocket_inventory.json" ) )
        {
            PocketItems = new();
            Log.Info( "No pocket save file found." );
            return;
        }

        PocketItems = FileSystem.Data.ReadJson( "pocket_inventory.json", new List<PocketItemData>() );
        Log.Info( $"Loaded {PocketItems.Count} pocket items." );
    }
}