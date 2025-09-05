using Sandbox;
using System.Collections.Generic;
using System.Linq;

public sealed class Jobscore : Component
{

	// Outputs a specific job resource into AG
    [ActionGraphNode("Jobs/Get Job By Name")]
    public static JobResource GetJobByName(string name)
    {
        return JobResource.All.FirstOrDefault(j => j.Title == name);
    }

    // Outputs all jobs as a list
    [ActionGraphNode("Jobs/Get All Jobs")]
    public static List<JobResource> GetAllJobs()
    {
        return JobResource.All.ToList();
    }





	// protected override void OnUpdate()
	// {
    //     // Wait until jobs are loaded
    //     if (!jobsLogged && JobResource.All.Count > 0)
    //     {
    //         foreach (var job in JobResource.All)
    //             Log.Info($"Job Loaded: {job.Title}");

    //         jobsLogged = true; // Only run this once
    //     }
	// }
}
