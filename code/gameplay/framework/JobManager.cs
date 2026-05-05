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



// private void BecomeJob_Server(string jobId)
// {


//     var job = ResourceLibrary.Get<JobResource>(jobId);
//     if (job == null)
//         return;

//     int taken = JobCounts.TryGetValue(jobId, out var count) ? count : 0;

//     if (taken >= job.MaxPlayersAllowedOnJob)
//     {
//         Log.Info($"Job {job.Title} is full ({taken}/{job.MaxPlayersAllowedOnJob})");
//         return;
//     }

//     JobCounts[jobId] = taken + 1;

//     Log.Info($"Player took job {job.Title} ({JobCounts[jobId]}/{job.MaxPlayersAllowedOnJob})");

// }


//     public void SelectJobServer(JobResource job)
//     {
//         if (JobCounts >= job.MaxPlayersAllowedOnJob)
//         {
//             Log.Info($"Job {job.Title} is full ({JobCounts}/{job.MaxPlayersAllowedOnJob})");
//             return;
//         }

//         Playhudmain.SelectedJob = job;



//         Log.Info($"Selected job: {job.Title}, {JobCounts}/{job.MaxPlayersAllowedOnJob}");
//     }





// [Sync]
// public Dictionary<string, int> JobCounts { get; set; } = new();


// [Rpc.Owner]
// public void RequestBecomeJob(string jobId)
// {
//     BecomeJob_Server(jobId);
// }



// 	public static bool CanJoin( DarkrpPlayerInfo player, JobResource job, out string reason )
// 	{
// 		reason = null;

// 		if ( player is null || definition is null )
// 		{
// 			reason = "Invalid job selection.";
// 			return false;
// 		}

// 		if ( string.Equals( player.JobDefinitionPath, definition.ResourcePath, StringComparison.OrdinalIgnoreCase ) )
// 			return true;

// 		if ( definition.MaxPlayers > 0 && CountPlayers( definition ) >= definition.MaxPlayers )
// 		{
// 			reason = "This job is full.";
// 			return false;
// 		}

// 		return true;
// 	}













public void TryAssignJob( DarkrpPlayerInfo player, JobResource job )
{
#if SERVER
    if ( job == null )
        return;

    AssignJob( player, job );
#endif
}



}