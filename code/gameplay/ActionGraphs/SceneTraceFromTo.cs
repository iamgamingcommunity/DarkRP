using Sandbox;
using System.Threading.Tasks;

public static class DarkRPActionGraphs
{
    [ActionGraphNode( "Scene Trace With Beam" )]
    [Group( "DarkRP Action Graphs" )]
    public static SceneTraceResult TraceWithBeam(
        GameObject source,
        Vector3 from,
        Vector3 to,
        bool showDebugLog
    )
    {
        if ( source == null || source.Scene == null )
            return default;

        var tr = source.Scene.Trace
            .Ray( from, to )
            .Run();

        if ( showDebugLog )
        {
            Log.Info( $"Trace: {from} → {to} | Hit: {tr.Hit}" );
        }

        var hitPos = tr.Hit ? tr.HitPosition : to;

        SpawnDebugLine( source.Scene, from, hitPos, tr.Hit );

        return tr;
    }

    private static async void SpawnDebugLine(
        Scene scene,
        Vector3 from,
        Vector3 to,
        bool hit
    )
    {
        var dir = to - from;
        var dist = dir.Length;

        if ( dist <= 0.001f )
            return;

        dir = dir.Normal;

        var go = new GameObject( scene );

        // midpoint positioning
        go.WorldPosition = from + dir * (dist * 0.5f);

        // rotate toward target
        go.WorldRotation = Rotation.LookAt( dir );

        var model = go.Components.Create<ModelRenderer>();

        model.Model = Model.Load( "models/dev/box.vmdl" );

        // IMPORTANT: stretch on X axis
        go.WorldScale = new Vector3( dist, 0.1f, 0.1f );

        model.Tint = hit
            ? Color.Green
            : Color.Red;

        await Task.Delay( 100 );

        if ( go.IsValid() )
            go.Destroy();
    }
}