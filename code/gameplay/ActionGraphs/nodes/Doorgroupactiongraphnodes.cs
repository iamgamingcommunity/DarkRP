using Sandbox;
using System.Collections.Generic;
using System.Linq;

[Library("DoorGroupAG", Title = "Door Group Nodes")]
public sealed class DoorGroupActionGraphNodes : Component
{

	// Outputs a specific job resource into AG
    [ActionGraphNode("DoorGroup/Get Door Group By Name"), Group("DarkRP Action Graphs")]
    public static DoorGroupCategoryResource GetDoorGroupByName(string name)
    {
        return DoorGroupCategoryResource.All.FirstOrDefault(j => j.Title == name);
    }

    // Outputs all jobs as a list
    [ActionGraphNode("DoorGroup/Get All Door Groups"), Group("DarkRP Action Graphs")]
    public static List<DoorGroupCategoryResource> GetAllDoorGroups()
    {
        return DoorGroupCategoryResource.All.ToList();
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
