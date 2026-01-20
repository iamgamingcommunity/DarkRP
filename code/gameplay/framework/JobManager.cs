using Sandbox;
using System.Collections.Generic;

public sealed class JobManager : Component
{
    public static JobManager Instance { get; private set; }

    [Sync] public NetDictionary<string, int> JobSlotsTaken { get; set; } = new();

    protected override void OnAwake()
    {
        Instance = this;
    }


protected override void OnStart()
{
#if SERVER
    foreach ( var category in JobCategoryInfo )
    {
        var job = category.JobsInCategory;
        if ( job == null ) continue;

        JobRuntimeState.Instance.JobSlotsTaken.TryAdd(
            job.ResourcePath,
            0
        );
    }
#endif
}


//Become Job Button Logic for DarkRP F4 Job Menu
void BecomeJob_Server( Connection conn, JobResource job )
{
    var jobId = job.ResourcePath;
    var runtime = JobManager.Instance;

    int taken = runtime.JobSlotsTaken.GetValueOrDefault( jobId );

    if ( taken >= job.MaxPlayersAllowedOnJob )
        return;

    runtime.JobSlotsTaken[jobId] = taken + 1;
}

public void TryAssignJob( DarkrpPlayerInfo player, JobResource job )
{
#if SERVER
    if ( job == null )
        return;

    AssignJob( player, job );
#endif
}



}