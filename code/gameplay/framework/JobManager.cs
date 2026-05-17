using Sandbox;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;

public sealed class JobManager : Component
{

    [Property] JobResource SelectedJob;

    [Property] JobResource OldSelectedJob;
    [Property] JobResource SelectedJobForIndex;

    [Property] public bool IsStopBlacklistSearch { get; set; } 

    [Property] public bool IsPlayerBlacklisted { get; set; } 

    [Property] public int WhitelistSystemSwitchInt { get; set; } 
    [Property] public GameObject Player { get; set; } 
    [Sync] [Property] public NetList<JobSlotInfo> JobSlots { get; set; } = new();
    public class JobSlotInfo
    {
        public string JobCommandName {get; set;}
        public int JobSlotAmount {get; set;}
        public bool IsHidden {get; set;}
    }





	// [Property, Group("Restrictions To Job"), ShowIf ( nameof( JobWhitelistBlacklist ), true)] public WhitelistBlacklist SelectedWhitelistBlacklist { get; set; }

   [Sync] [Property] public NetList<JobWhitelistBlacklistInfo> SyncedJobList {get; set;} = new();




    public class JobWhitelist
    {
        public string Type {get; set; }
        public string Value {get; set; }
        public string PlayerName {get; set; }
        public string AddedByName {get; set; }
    } 

        public class JobBlacklist
    {
        public string Type {get; set; }
        public string Value {get; set; }
        public string PlayerName {get; set; }
        public string AddedByName {get; set; }
    } 

        public class JobBannedList
    {
        public string Type {get; set; }
        public string Value {get; set; }
        public string PlayerName {get; set; }
        public string PlayerUserGroup {get; set; }
        public string AddedByName {get; set; }
    } 


        public class JobWhitelistBlacklistInfo
    {
    
    [Property, Group("Basic Job Info"), Description("The Job Command name is the command you use to become the job via chat. This is also used to check for the job. So NEVER have a duplicate job command name.")]public string JobCommandName {get; set;}

    [Property, Group("Basic Job Info"), Description("Enable Job Whitelist & Blacklist System? This will enable the filling of the list of Jobs the player has Whitelisted/Blacklisted.")] public bool IsJobWhitelistEnabled { get; set; }	
    [Property, Group("Basic Job Info")]public int JobSlotAmount {get; set;}
    [Property, Group("Basic Job Info")] public bool IsHidden {get; set;}

    [Property, Group("Basic Job Info")] public int Salary { get; set; }



    //Job Whitelist/Blacklist Restriction System Vars

	[Property, Group("Whitelist Blacklist Restrictions To Job")] public bool IsWhitelistEnabled { get; set; }
    [Property, Group("Whitelist Blacklist Restrictions To Job")] public bool IsBlacklistEnabled { get; set; }
	[Property, Group("Whitelist Blacklist Restrictions To Job")] public bool IsWhitelistToByDefault { get; set; }
    [Property, Group("Whitelist Blacklist Restrictions To Job")] public bool IsBlacklistFromByDefault { get; set; }
    [Property, Group("Whitelist Blacklist Restrictions To Job")] public bool IsDisableAutoSwitch { get; set; }

    [Property, Group("Whitelist Blacklist Restrictions To Job")] public List<JobWhitelist> Whitelist { get; set; }
    [Property, Group("Whitelist Blacklist Restrictions To Job")] public List<JobBlacklist> Blacklist { get; set; }
    [Property, Group("Whitelist Blacklist Restrictions To Job")] public List<JobBannedList> BannedList { get; set; }


    //UserGroups
    [Property, Group("UserGroups Restrictions To Job")] public bool IsForUserGroups { get; set; }
    [Property, Group("UserGroups Restrictions To Job"), ShowIf ( nameof( IsForUserGroups ), true), Description("If True, Only the Usergroups listed will be allowed to get onto the job. If False, every usergroup can use the job.")] public List<string> UserGroupThatCanUseJob{ get; set; }
    [Property, Group("UserGroups Restrictions To Job"), ShowIf ( nameof( IsForUserGroups ), true), Description("If True, Non Assaigned user groups will have x amount of time to play on the job until the 'TempPlayTimeTotalCycleAmount' resets the time back to the total amount you want the player to be on the job.")] public bool HasTempPlayTime { get; set; }
    [Property, Group("UserGroups Restrictions To Job"), ShowIf ( nameof( IsForUserGroups ), true), Description("0 = Nothing, 60 = 1 minute. So set the total time here to be the total amount of time you want the player to play on the job.")] public int TempPlayTimeTotalAmount { get; set; }
    
    //SteamID
    [Property, Group("SteamID Restrictions To Job")] public bool IsForSteamUsers { get; set; }
    [Property, Group("SteamID Restrictions To Job"), ShowIf ( nameof( IsForSteamUsers ), true), Description("If True, Only the Usergroups listed will be allowed to get onto the job. If False, every usergroup can use the job.")] public List<string> SteamIDsThatCanUseJob{ get; set; }


    } 


    /// <summary>
    /// <Whitelist
    /// Type
    /// Value
    /// Player Name
    /// Added By
    /// <Blacklist
    /// Type
    /// Value
    /// Player Name
    /// Added By
    /// <BannedList
    /// Type
    /// Value
    /// Player Name
    /// UserGroup
    /// Added By   
    /// </summary>


	public enum WhitelistBlacklist 
	{
		Whitelist,
		Blacklist,
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
        SetJobSlot(SelectedJob, OldSelectedJob, PlayerInfo );
    }


    public void SelectJob(JobResource job, CategoryResource.JobCategoryInfoStructMain jobInfo)
    {


 

        SelectedJob = job;



    }




 [Rpc.Broadcast]
    void SetJobSlot(JobResource SelectedJobForIndex, JobResource OldSelectedJob, GameObject PlayerInfo)
    {
      Player = PlayerInfo;
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
    
    
    




    public void LoadJobSlots()
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
    

public void SyncedJobInfo()
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
            bool alreadyExists = SyncedJobList.Any(
                x => x.JobCommandName == job.JobCommandName
            );

            if ( alreadyExists )
                continue;

            SyncedJobList.Add( new JobWhitelistBlacklistInfo
            {
                // Basic Info
                JobCommandName = job.JobCommandName,
                JobSlotAmount = 0,
                IsHidden = false,
                Salary = job.Salary,

                // Whitelist / Blacklist
                IsJobWhitelistEnabled = job.IsJobWhitelistEnabled,
                IsWhitelistEnabled = false,
                IsBlacklistEnabled = false,
                IsWhitelistToByDefault = false,
                IsBlacklistFromByDefault = false,
                IsDisableAutoSwitch = false,

                Whitelist = new List<JobWhitelist>(),
                Blacklist = new List<JobBlacklist>(),
                BannedList = new List<JobBannedList>(),

                // Usergroups
                IsForUserGroups = job.IsForUserGroups,
                UserGroupThatCanUseJob = job.UserGroupThatCanUseJob,
                HasTempPlayTime = job.HasTempPlayTime,
                TempPlayTimeTotalAmount = job.TempPlayTimeTotalAmount,

                // SteamID
                IsForSteamUsers = job.IsForSteamUsers,
                SteamIDsThatCanUseJob = job.SteamIDsThatCanUseJob
            } );

            Log.Info( $"Added Job Whitelist/Blacklist Info: {job.JobCommandName}" );
        }
    }

    Log.Info( $"Built {SyncedJobList.Count} JobWhitelistBlacklist entries." );
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
    LoadJobSlots();
    SyncedJobInfo();
    }
    }
