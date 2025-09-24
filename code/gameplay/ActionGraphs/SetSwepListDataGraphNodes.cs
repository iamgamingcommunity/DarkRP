// using Sandbox;
// using System;
// using System.Linq;
// using System.Collections.Generic;
// using DarkRP.ActionGraphs;

// namespace DarkRP.ActionGraphs
// {
//     public static class RuntimeExtraDataNodes
//     {
//         // Helper to get a runtime bool by name
//         private static PickupableEntity.SwepExtraBools? FindBool(PickupableEntityBase swp, string key)
//         {
//             return swp.RunTimeExtraBools.FirstOrDefault(x => x.BoolName == key);
//         }

//         [ActionGraphNode("Runtime/Extra Bools/Get Bool")]
//         public static bool GetRuntimeBool(PickupableEntityBase swp, string key)
//         {
//             return FindBool(swp, key)?.ExtraBools ?? false;
//         }

//     [ActionGraphNode("Runtime/Extra Bools/Set Bool")]
//     public static void SetRuntimeBool(PickupableEntityBase swp, string key, bool value)
//     {
//         int index = swp.RunTimeExtraBools.FindIndex(x => x.BoolName == key);

//         if (index >= 0)
//         {
//             var temp = swp.RunTimeExtraBools[index];
//             temp.ExtraBools = value;  // modify the copy
//             swp.RunTimeExtraBools[index] = temp; // write it back to the list
//         }
//         else
//         {
//             swp.RunTimeExtraBools.Add(new PickupableEntity.SwepExtraBools { BoolName = key, ExtraBools = value });
//         }
//     }

//     // Get runtime int
//     public static int GetRuntimeInt(PickupableEntityBase swp, string key)
//     {
//         var found = swp.RunTimeExtraInt.FirstOrDefault(x => x.BoolName == key);
//         return found.BoolName == key ? found.ExtraInt : 0;
//     }

//     [ActionGraphNode("Runtime/Extra Ints/Set Int")]
//     public static void SetRuntimeInt(PickupableEntityBase swp, string key, int value)
//     {
//         int index = swp.RunTimeExtraInt.FindIndex(x => x.BoolName == key);

//         if (index >= 0)
//         {
//             var temp = swp.RunTimeExtraInt[index];
//             temp.ExtraInt = value;
//             swp.RunTimeExtraInt[index] = temp;
//         }
//         else
//         {
//             swp.RunTimeExtraInt.Add(new PickupableEntity.SwepExtraInt { BoolName = key, ExtraInt = value });
//         }
//     }

//     // Get runtime float
//     public static float GetRuntimeFloat(PickupableEntityBase swp, string key)
//     {
//         var found = swp.RunTimeExtraFloat.FirstOrDefault(x => x.BoolName == key);
//         return found.BoolName == key ? found.ExtraFloat : 0f;
//     }

//     [ActionGraphNode("Runtime/Extra Floats/Set Float")]
//     public static void SetRuntimeFloat(PickupableEntityBase swp, string key, float value)
//     {
//         int index = swp.RunTimeExtraFloat.FindIndex(x => x.BoolName == key);

//         if (index >= 0)
//         {
//             var temp = swp.RunTimeExtraFloat[index];
//             temp.ExtraFloat = value;
//             swp.RunTimeExtraFloat[index] = temp;
//         }
//         else
//         {
//             swp.RunTimeExtraFloat.Add(new PickupableEntity.SwepExtraFloat { BoolName = key, ExtraFloat = value });
//         }
//     }

//         [ActionGraphNode("Runtime/Extra Strings/Get String")]
//         public static string GetRuntimeString(PickupableEntityBase swp, string key)
//         {
//             return swp.RunTimeExtraStrings.FirstOrDefault(x => x == key) ?? "";
//         }


//     }
// }