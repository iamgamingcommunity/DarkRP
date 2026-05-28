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
            return null;

        foreach ( var resource in ChatCommandResource.All )
        {
            if ( resource == null )
                continue;

            // Safety
            if ( resource.ChatCommands.ChatCommandName == null )
                continue;

            // Search through aliases/names
            bool found = resource.ChatCommands.ChatCommandName
                .Any( x => string.Equals(
                    x,
                    name,
                    StringComparison.OrdinalIgnoreCase ) );

            if ( found )
                return resource;
        }

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