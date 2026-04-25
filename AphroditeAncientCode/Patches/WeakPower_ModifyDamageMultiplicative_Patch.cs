using AphroditeAncient.AphroditeAncientCode.Relics;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace AphroditeAncient.AphroditeAncientCode.Patches;

[HarmonyPatch(typeof(WeakPower), nameof(WeakPower.ModifyDamageMultiplicative))]
public static class WeakPower_ModifyDamageMultiplicative_Patch
{
    public static void Postfix(
        WeakPower __instance,
        Creature? target,
        decimal amount,
        ValueProp props,
        Creature? dealer,
        CardModel? cardSource,
        ref decimal __result)
    {
        BrokenResolve? stickyHand = target?.Player?.GetRelic<BrokenResolve>();
        if (stickyHand == null)
        {
            return;
        }
        
        decimal newValue =
            dealer != __instance.Owner || !props.IsPoweredAttack()
                ? __result
                : __result - (1M - __result);

        __result = Math.Max(0.5M, newValue);
    }
}