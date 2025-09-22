using Sandbox;
using System;
using System.Collections.Generic;

namespace DarkRP.ActionGraphs
{
    public class PickupableEntityRuntimeData
    {
        public Dictionary<string, bool> Bools = new();
        public Dictionary<string, int> Ints = new();
        public Dictionary<string, float> Floats = new();
        public Dictionary<string, string> Strings = new();

        public bool GetBool(string key) => Bools.TryGetValue(key, out var val) ? val : false;
        public void SetBool(string key, bool value) => Bools[key] = value;

        public int GetInt(string key) => Ints.TryGetValue(key, out var val) ? val : 0;
        public void SetInt(string key, int value) => Ints[key] = value;

        public float GetFloat(string key) => Floats.TryGetValue(key, out var val) ? val : 0f;
        public void SetFloat(string key, float value) => Floats[key] = value;

        public string GetString(string key) => Strings.TryGetValue(key, out var val) ? val : "";
        public void SetString(string key, string value) => Strings[key] = value;
    }
}