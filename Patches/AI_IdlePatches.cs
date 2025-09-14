using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace ExperienceMultiplier.Patches;

public class AI_IdlePatches
{
    [HarmonyTranspiler]
    [HarmonyPatch(typeof(AI_Idle), nameof(AI_Idle.Run), MethodType.Enumerator)]
    public static IEnumerable<CodeInstruction> AI_IdleRun_Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        return new CodeMatcher(instructions)
            .MatchForward(false,
                new CodeMatch(OpCodes.Ldloc_S),
                new CodeMatch(OpCodes.Ldfld),
                new CodeMatch(OpCodes.Ldc_I4, 900))
            .Advance(2)
            .RemoveInstruction()
            .Insert(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(AI_IdlePatches), nameof(GetMaxPotential))))
            .InstructionEnumeration();
    }

    public static int GetMaxPotential()
    {
        return Mathf.Clamp(PluginSettings.MaxPotential.Value - 100, 0, PluginSettings.MaxPotential.Value - 100);
    }
}
