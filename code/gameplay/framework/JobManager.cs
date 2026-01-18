using Sandbox;
using System.Collections.Generic;

public partial class JobManager : Entity
{
    public static JobManager Instance { get; private set; }

    [Net] private IDictionary<string, int> JobSlots { get; set; }

    public override void Spawn()
    {
        if (!Game.IsServer)
            return;

        Instance = this;
        JobSlots = new Dictionary<string, int>();
    }

    public bool TryTakeJob(JobResource job)
    {
        var id = job.ResourceId;

        JobSlots.TryGetValue(id, out var current);

        if (current >= job.MaxPlayersAllowedOnJob)
            return false;

        JobSlots[id] = current + 1;
        return true;
    }

    public void ReleaseJob(JobResource job)
    {
        var id = job.ResourceId;

        if (!JobSlots.ContainsKey(id))
            return;

        JobSlots[id] = System.Math.Max(0, JobSlots[id] - 1);
    }

    public int GetJobSlots(JobResource job)
    {
        JobSlots.TryGetValue(job.ResourceId, out var count);
        return count;
    }
}