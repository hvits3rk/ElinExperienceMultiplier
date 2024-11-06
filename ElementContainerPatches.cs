using HarmonyLib;
using UnityEngine;

namespace ExperienceMultiplier;

public class ElementContainerPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ElementContainer), nameof(ElementContainer.ModExp))]
    public static void LianDanPanel_StartLianDan_Prefix(ref ElementContainer __instance, int ele, ref int a, bool chain)
    {
        if (__instance is { Chara.IsPC: true })
        {
            a = Mathf.RoundToInt(a * PluginSettings.ExperienceMultiplier.Value);
        }
    }
}
