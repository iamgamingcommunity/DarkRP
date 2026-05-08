using Sandbox;
using System.Collections.Generic;
using System.Dynamic;

public sealed class JobManager : Component
{
    public static JobManager Instance { get; private set; }

    [Sync] public NetDictionary<string, int> JobSlotsTaken { get; set; } = new();

    [Property] public NetList<CategoryResource> JobSlots { get; set; } = new();

	public delegate void ActionTest();
	[Property, Feature("Action Graphs"), Group("Action Graphs"), Title("Unarrest Logic")]
	public ActionTest GraTest { get; set; }


    protected override void OnAwake()
    {
        Instance = this;
    }



    public void FireChange()
    {
    // if ( !Networking.IsHost )
    //     return;

        GraTest?.Invoke();
        // JobSlots.Add(new List<CategoryResource>
        // {
        //     JobCommandName = "Citizen",
        //     JobSlotAmount = 1
        // });
    // var citizen = JobSlots.FirstOrDefault(x => x.JobCommandName == "Citizen");

    // Log.Info($"Citizen Slots: {citizen.JobSlotAmount}");
    }


    public void FireDebug(int Number)
    {
    Log.Info($"IsProxy: {IsProxy}");
    Log.Info($"NetworkMode: {GameObject.NetworkMode}");
    Log.Info($"Owner: {Network.OwnerId}");
    Log.Info($"Number: {Number}");

    // var citizen = JobSlots.FirstOrDefault(x => x.JobCommandName == "Citizen");

    // if ( citizen == null )
    // {
    //     Log.Info("Citizen entry not found!");
    //     return;
    // }
    //  Log.Info($"Citizen Slots: {citizen.JobSlotAmount}");
    }



    public class JobSlotInfo
    {
        public string JobCommandName {get; set;}
        public int JobSlotAmount {get; set;}
    }







// protected override void OnStart()
// {
// #if SERVER
//     foreach ( var category in JobCategoryInfo )
//     {
//         var job = category.JobsInCategory;
//         if ( job == null ) continue;

//         JobRuntimeState.Instance.JobSlotsTaken.TryAdd(
//             job.ResourcePath,
//             0
//         );
//     }
// #endif
// }


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













// public void TryAssignJob( DarkrpPlayerInfo player, JobResource job )
// {
// #if SERVER
//     if ( job == null )
//         return;

//     AssignJob( player, job );
// #endif
// }



}