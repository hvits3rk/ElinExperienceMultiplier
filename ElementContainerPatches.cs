using HarmonyLib;
using UnityEngine;

namespace ExperienceMultiplier;

public class ElementContainerPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ElementContainer), nameof(ElementContainer.ModExp))]
    public static void ElementContainerModExp_Prefix(ref ElementContainer __instance, int ele, ref int a, bool chain)
    {
        var chara = __instance.Chara;

        if (chara == null || !chara.isChara || chara.isDead) return;

        var multipliedExp = Mathf.RoundToInt(a * PluginSettings.ExperienceMultiplier.Value);

        if (PluginSettings.MainCharacter.Value)
        {
            if (chara.IsPC) a = multipliedExp;
        }
        if (PluginSettings.Faction.Value)
        {
            if (chara.IsPCFaction && !chara.IsPC && !chara.IsPCParty) a = multipliedExp;
        }
        if (PluginSettings.Party.Value)
        {
            if (chara.IsPCParty && !chara.IsPC) a = multipliedExp;
        }
        if (PluginSettings.PlayerMinion.Value)
        {
            if (IsPCMinion(chara)) a = multipliedExp;
        }
        if (PluginSettings.FactionMinion.Value)
        {
            if (chara.IsPCFactionMinion && !IsPCMinion(chara) && !chara.IsPCPartyMinion) a = multipliedExp;
        }
        if (PluginSettings.PartyMinion.Value)
        {
            if (chara.IsPCPartyMinion && !IsPCMinion(chara)) a = multipliedExp;
        }
    }

    private static bool IsPCMinion(Chara chara)
    {
        return chara.master != null && chara.master == EClass.pc;
    }
}