using Sandbox;
using System.Collections.Generic;
using System.Dynamic;

public sealed class JobManager : Component
{

    [Property] JobResource SelectedJob;

    [Property] JobResource OldSelectedJob;
    [Property] JobResource SelectedJobForIndex;


    [Property] public GameObject Player { get; set; } 

    [Sync] [Property] public NetList<JobSlotInfo> JobSlots { get; set; } = new();
    public class JobSlotInfo
    {
        public string JobCommandName {get; set;}
        public int JobSlotAmount {get; set;}
        public bool IsHidden {get; set;}
    }






  //Action Graph For Becoming Job
    public delegate void ActionGraphBecomeJob(JobResource SelectedJob, GameObject PlayerInfo, JobResource OldSelectedJob);
	[Property, Feature("Player Hud Info")]
	public ActionGraphBecomeJob GraphBecomeJob { get; set; }
  
  //Action Graph For Selecting Job Index
    public delegate void ActionGraphSetJobIndex(JobResource SelectedJob, GameObject PlayerInfo, JobResource OldSelectedJob);
	[Property, Feature("Player Hud Info")]
	public ActionGraphSetJobIndex GraphSetJobIndex { get; set; }

















    public void BecomeJob(GameObject PlayerInfo, JobResource OldSelectedJob)
    {
  

     

        Player = PlayerInfo;
        var DarkRPInfo = PlayerInfo.GetComponent<DarkrpPlayerInfo>();
         OldSelectedJob = DarkRPInfo.CurrentJob;
         

        SelectedJobForIndex = SelectedJob;
        GraphBecomeJob?.Invoke(SelectedJob, Player, OldSelectedJob);
        if (DarkRPInfo.CurrentJob == OldSelectedJob)
        {

        }
        SetJobSlot(SelectedJob, OldSelectedJob );
    }


    public void SelectJob(JobResource job, CategoryResource.JobCategoryInfoStructMain jobInfo)
    {


 

        SelectedJob = job;



    }




 [Rpc.Broadcast]
    void SetJobSlot(JobResource SelectedJobForIndex, JobResource OldSelectedJob )
    {


    
      
        GraphSetJobIndex?.Invoke(SelectedJobForIndex, Player, OldSelectedJob);
    }

public int GetSlotAmount( string jobCommand )
{
    for ( int i = 0; i < JobSlots.Count; i++ )
    {
        if ( JobSlots[i].JobCommandName == jobCommand )
            return JobSlots[i].JobSlotAmount;
    }

    return 0;
}


public void SetJobSlotAmount( string jobName, int amount )
{
    if ( !Networking.IsHost )
        return;

    int foundIndex = -1;

    // Manually search the NetList
    for ( int i = 0; i < JobSlots.Count; i++ )
    {
        if ( JobSlots[i].JobCommandName == jobName )
        {
            foundIndex = i;
            break;
        }
    }

    // Create if missing
    if ( foundIndex == -1 )
    {
        JobSlots.Add( new JobSlotInfo
        {
            JobCommandName = jobName,
            JobSlotAmount = amount
        } );

        Log.Info( $"Created {jobName} with {amount}" );
        return;
    }

    // Update existing
    var slot = JobSlots[foundIndex];
    slot.JobSlotAmount = amount;

    // IMPORTANT:
    // Reassign struct back into NetList
    JobSlots[foundIndex] = slot;

    Log.Info( $"Updated {jobName} to {amount}" );
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


    protected override void OnStart()
    {
 foreach ( var category in CategoryResource.All )
    {
        // Skip non-job categories
        if ( !category.IsJobCategory )
            continue;

        // Safety
        if ( category.JobCategoryInfo == null )
            continue;

        foreach ( var jobInfo in category.JobCategoryInfo )
        {
            // Safety
            if ( jobInfo == null )
                continue;

            var job = jobInfo.JobsInCategory;

            // Safety
            if ( job == null )
                continue;

            // Prevent duplicates
            bool alreadyExists = JobSlots.Any(
                x => x.JobCommandName == job.JobCommandName
            );

            if ( alreadyExists )
                continue;

            JobSlots.Add( new JobSlotInfo
            {
                JobCommandName = job.JobCommandName,
            } );

            Log.Info( $"Added Job Slot: {job.JobCommandName}" );
        }
    }

    Log.Info( $"Built {JobSlots.Count} job slots." );
}
    }
