using Sandbox;

public static class DarkRPActionGraphs
{
    [ActionGraphNode("Scene Trace With Beam")]
    [Group("DarkRP Action Graphs")]
    public static SceneTraceResult TraceWithBeam(
        GameObject source,
        Vector3 from,
        Vector3 to
    )
    {
        if ( source == null || source.Scene == null )
            return default;

        var tr = source.Scene.Trace
            .Ray( from, to )
            .Run();

        var beamGO = new GameObject();
        beamGO.WorldPosition = from;

        var beam = beamGO.Components.Create<BeamEffect>();

        beam.TargetPosition = tr.Hit ? tr.HitPosition : to;
        beam.Scale = 2f;
        beam.BeamLifetime = 0.1f;
        beam.BeamsPerSecond = 1;

        beam.BeamColor = tr.Hit ? Color.Green : Color.Red;

        // SAFE runtime destroy (works in all builds)
        _ = RunDestroyLater( beamGO, 1f );

        return tr;
    }

    private static async Task RunDestroyLater(GameObject obj, float seconds)
    {
        await Task.DelaySeconds(seconds);
        if ( obj.IsValid() )
            obj.Destroy();
    }
}