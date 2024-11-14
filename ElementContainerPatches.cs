using System.Collections.Generic;
using System.Reflection.Emit;
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
        
        a = MultiplierValue(chara, a, PluginSettings.ExperienceMultiplier.Value);
    }

    [HarmonyTranspiler]
    [HarmonyPatch(typeof(ElementContainer), nameof(ElementContainer.ModExp))]
    public static IEnumerable<CodeInstruction> ElementContainerModExp_Transpiler(
        IEnumerable<CodeInstruction> instructions)
    {
        return new CodeMatcher(instructions)
            .MatchForward(false,
                new CodeMatch(OpCodes.Ldarg_2),
                new CodeMatch(OpCodes.Ldloc_1),
                new CodeMatch(OpCodes.Ldc_I4_S),
                new CodeMatch(OpCodes.Ldc_I4),
                new CodeMatch(OpCodes.Call, AccessTools.Method(typeof(Mathf), "Clamp", [typeof(int), typeof(int), typeof(int)])))
            .Advance(3)
            .SetOperandAndAdvance(PluginSettings.MaxPotential.Value)
            .InstructionEnumeration();
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(ElementContainer), nameof(ElementContainer.ModPotential))]
    public static void ElementContainerModPotential_Prefix(ref ElementContainer __instance, int ele, ref int v)
    {
        var chara = __instance.Chara;

        if (chara == null || !chara.isChara || chara.isDead) return;
        
        v = MultiplierValue(chara, v, PluginSettings.PotentialMultiplier.Value);
    }

    [HarmonyTranspiler]
    [HarmonyPatch(typeof(ElementContainer), nameof(ElementContainer.ModPotential))]
    public static IEnumerable<CodeInstruction> ElementContainerModPotential_Transpiler(
        IEnumerable<CodeInstruction> instructions)
    {
        return new CodeMatcher(instructions)
            .MatchForward(true,
                new CodeMatch(OpCodes.Ldloc_0),
                new CodeMatch(OpCodes.Ldfld),
                new CodeMatch(OpCodes.Ldc_I4))
            .SetOperandAndAdvance(PluginSettings.MaxPotential.Value)
            .MatchForward(true,
                new CodeMatch(OpCodes.Ldloc_0),
                new CodeMatch(OpCodes.Ldc_I4))
            .SetOperandAndAdvance(PluginSettings.MaxPotential.Value)
            .InstructionEnumeration();
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(ElementContainer), nameof(ElementContainer.ModTempPotential))]
    public static void ElementContainerModTempPotential_Prefix(ref ElementContainer __instance, int ele, ref int v, int threshMsg = 0)
    {
        var chara = __instance.Chara;

        if (chara == null || !chara.isChara || chara.isDead) return;
        
        v = MultiplierValue(chara, v, PluginSettings.PotentialMultiplier.Value);
    }

    [HarmonyTranspiler]
    [HarmonyPatch(typeof(ElementContainer), nameof(ElementContainer.ModTempPotential))]
    public static IEnumerable<CodeInstruction> ElementContainerModTempPotential_Transpiler(
        IEnumerable<CodeInstruction> instructions)
    {
        return new CodeMatcher(instructions)
            .MatchForward(true,
                new CodeMatch(OpCodes.Ldloc_0),
                new CodeMatch(OpCodes.Ldfld),
                new CodeMatch(OpCodes.Ldc_I4))
            .SetOperandAndAdvance(PluginSettings.MaxPotential.Value)
            .MatchForward(true,
                new CodeMatch(OpCodes.Ldloc_0),
                new CodeMatch(OpCodes.Ldc_I4))
            .SetOperandAndAdvance(PluginSettings.MaxPotential.Value)
            .InstructionEnumeration();
    }

    private static int MultiplierValue(Chara chara, int value, float multiplier)
    {
        var multipliedValue = Mathf.RoundToInt(value * multiplier);
        var resultValue = value;

        if (PluginSettings.MainCharacter.Value)
        {
            if (chara.IsPC)
                resultValue = multipliedValue;
        }

        if (PluginSettings.Faction.Value)
        {
            if (chara.IsPCFaction && !chara.IsPC && !chara.IsPCParty)
                resultValue = multipliedValue;
        }

        if (PluginSettings.Party.Value)
        {
            if (chara.IsPCParty && !chara.IsPC)
                resultValue = multipliedValue;
        }

        if (PluginSettings.PlayerMinion.Value)
        {
            if (IsPCMinion(chara))
                resultValue = multipliedValue;
        }

        if (PluginSettings.FactionMinion.Value)
        {
            if (chara.IsPCFactionMinion && !IsPCMinion(chara) && !chara.IsPCPartyMinion)
                resultValue = multipliedValue;
        }

        if (PluginSettings.PartyMinion.Value)
        {
            if (chara.IsPCPartyMinion && !IsPCMinion(chara))
                resultValue = multipliedValue;
        }

        return resultValue;
    }

    private static bool IsPCMinion(Chara chara)
    {
        return chara.master != null && chara.master == EClass.pc;
    }
}