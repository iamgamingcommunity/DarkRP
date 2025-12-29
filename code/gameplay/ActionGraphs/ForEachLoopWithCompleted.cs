using Sandbox;
using System.Collections.Generic;

public static class ForEachLoopWithCompleted
{
    /// <summary>
    /// UE5-style ForEach helper node.
    /// Returns the item at Index and whether the loop has reached the last element.
    /// </summary>
    [ActionGraphNode( "logic.foreach" )]
    [Title( "For Each (UE Style)" )]
    [Group( "Logic" )]
    [Icon( "repeat" )]
    public static void ForEach<T>(
        IReadOnlyList<T> list,
        int index,
        out T item,
        out int outIndex,
        out bool completed
    )
    {
        item = default;
        outIndex = index;
        completed = true;

        if ( list == null )
            return;

        if ( index < 0 || index >= list.Count )
            return;

        item = list[index];
        outIndex = index;
        completed = index == list.Count - 1;
    }
}