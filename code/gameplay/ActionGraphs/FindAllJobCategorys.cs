using Sandbox;
using System.Collections.Generic;
using System.Linq;

public static class CategoryActionGraphNodes
{
    [ActionGraphNode("Categories/Get Job Categories")]
    [Group("DarkRP Action Graphs")]
    [Description("Returns only job-related CategoryResource assets.")]
    public static List<CategoryResource> GetJobCategories()
    {
        return CategoryResource.All
            .Where(c => c.IsJobCategory)
            .ToList();
    }
}