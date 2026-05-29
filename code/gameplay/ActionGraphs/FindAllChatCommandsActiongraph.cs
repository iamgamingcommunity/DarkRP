using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;

public static class ChatCommandActionGraphNodes
{
      // Returns a specific chat command resource by name
   [ActionGraphNode("ChatCommands/Get Command By Name")]
[Group("DarkRP Action Graphs")]
[Description("Gets a Chat Command by name.")]
public static ChatCommandResource GetChatCommandByName( string name )
{
    if ( string.IsNullOrWhiteSpace( name ) )
    {
        Log.Info("Command name was null or empty");
        return null;
    }

    name = name.Trim();

    Log.Info($"Searching for command: {name}");
    Log.Info($"Total Resources: {ChatCommandResource.All.Count}");

    foreach ( var resource in ChatCommandResource.All )
    {
        if ( resource == null )
        {
            Log.Info("Resource was null");
            continue;
        }

        if ( resource.ChatCommands.ChatCommandName == null )
        {
            Log.Info($"Command list null on resource: {resource.ResourceName}");
            continue;
        }

        Log.Info($"Checking Resource: {resource.ResourceName}");

        foreach ( var commandName in resource.ChatCommands.ChatCommandName )
        {
            Log.Info($"Found Alias: {commandName}");

            if ( string.Equals(
                commandName?.Trim(),
                name,
                StringComparison.OrdinalIgnoreCase ) )
            {
                Log.Info($"MATCHED COMMAND: {commandName}");

                return resource;
            }
        }
    }

    Log.Info("NO COMMAND MATCH FOUND");

    return null;
}

    // Returns all chat command resources
    [ActionGraphNode("ChatCommands/Get All Commands")]
    [Group("DarkRP Action Graphs")]
    public static List<ChatCommandResource> GetAllChatCommands()
    {
        return ChatCommandResource.All.ToList();
    }

    // Optional: return the ActionGraphReference for a given command name
    // Useful if you want to feed the graph reference into a "Run Graph" node inside Action Graph.
    // [ActionGraphNode("ChatCommands/Get Command Graph")]
    // [Group("DarkRP Action Graphs")]
    // public static ActionGraphReference GetChatCommandGraph(string name)
    // {
    //     var cmd = GetChatCommandByName(name);
    //     return cmd != null ? cmd.ChatCommands.GraphChatCommand : null;
    // }
}