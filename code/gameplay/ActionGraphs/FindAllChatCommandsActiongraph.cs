using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;

public static class ChatCommandActionGraphNodes
{
    // Returns a specific chat command resource by name
    [ActionGraphNode("ChatCommands/Get Command By Name")]
    [Group("DarkRP Action Graphs")]
    [Description("Gets a Chat Command by name by searching through all the possible commands in /addons and /chatcommands.")]
    public static ChatCommandResource GetChatCommandByName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        // Match using the struct's ChatCommandName property (case-insensitive)
        return ChatCommandResource.All
            .FirstOrDefault(c => c.ChatCommands.ChatCommandName.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    // Returns all chat command resources as a list
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