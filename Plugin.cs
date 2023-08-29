using System;
using System.Collections;

// From BepInEx.core.dll in BepInEx/core folder
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;

//from 0Harmony.dll in BepInEx/core folder
using HarmonyLib;

using UnityEngine;

namespace HS2_PluginTemplate;

[BepInProcess("HoneySelect2")]
[BepInPlugin(GUID, NAME, VERSION)]
public class Plugin : BaseUnityPlugin
{
    /// <summary>
        /// Human-readable name of the plugin. In general, it should be short and concise.
        /// This is the name that is shown to the users who run BepInEx and to modders that inspect BepInEx logs. 
        /// </summary>
        public const string NAME = "HoneySelect2:PluginTemplate";
        /// <summary>
        /// Unique ID of the plugin. Will be used as the default config file name.
        /// This must be a unique string that contains only characters a-z, 0-9 underscores (_) and dots (.)
        /// When creating Harmony patches or any persisting data, it's best to use this ID for easier identification.
        /// </summary>
        public const string GUID = "com.wad8989.HS2.Template";

        /// <summary>
        /// Version of the plugin. Must be in form <major>.<minor>.<build>.<revision>.
        /// Major and minor versions are mandatory, but build and revision can be left unspecified.
        /// </summary>
        public const string VERSION = "0.0.1";

        private ConfigEntry<bool> _configEntry;

        public GameObject WadCoreManager;

    private void Awake()
    {
        // Plugin startup logic
        Logger.LogInfo($"Plugin {GUID} is loaded!");

        _configEntry = Config.Bind("General", "Enable this plugin", true, "If false, this plugin will do nothing");

        if (_configEntry.Value)
        {
            Harmony.CreateAndPatchAll(typeof(Hooks), GUID);
        }
    }

    private static class Hooks
    {
        // [HarmonyPrefix]
        // [HarmonyPatch(typeof(SomeClass), nameof(SomeClass.SomeInstanceMethod))]
        // private static void SomeMethodPrefix(SomeClass __instance, int someParameter, ref int __result)
        // {
        //     ...
        // }
    }
}
