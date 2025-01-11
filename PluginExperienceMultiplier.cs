using BepInEx;
using BepInEx.Logging;
using ExperienceMultiplier.Patches;
using HarmonyLib;

namespace ExperienceMultiplier;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class PluginExperienceMultiplier : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    private void Awake()
    {
        Logger = base.Logger;

        Logger.LogInfo("Initializing configuration for [ Experience Multiplier ] plugin...");
        PluginSettings.InitializeConfiguration(Config);
        Logger.LogInfo("Successfully initialized configuration for [ Experience Multiplier ] plugin.");

        Logger.LogInfo("Applying patches for [ Experience Multiplier ] plugin.");
        Harmony.CreateAndPatchAll(typeof(ElementContainerPatches));
        Harmony.CreateAndPatchAll(typeof(AI_IdlePatches));
        Logger.LogInfo("Successfully applied patches for [ Experience Multiplier ] plugin.");

        Logger.LogInfo("Plugin [ Experience Multiplier ] is loaded!");
    }
}
