using MegaCrit.Sts2.Core.Models;

namespace AphroditeAncient.AphroditeAncientCode.Patches;

using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.Events;
using System.Runtime.CompilerServices;

[HarmonyPatch(typeof(NAncientEventLayout), "SetDialogueLineAndAnimate")]
public static class NAncientEventLayout_SetDialogueLineAndAnimate_Patch
{
    private const float XOffset = 150f;

    private static readonly ConditionalWeakTable<NAncientEventLayout, Box> State = new();

    private sealed class Box
    {
        public float BaseContentX;
        public float BaseContainerWidth;

        public Box(float baseContentX, float baseContainerWidth)
        {
            BaseContentX = baseContentX;
            BaseContainerWidth = baseContainerWidth;
        }
    }

    static void Prefix(NAncientEventLayout __instance)
    {
        var t = Traverse.Create(__instance);

        var ancientEvent = t.Field("_ancientEvent").GetValue<AncientEventModel>();

        if (ancientEvent.Id != ModelDb.GetId<Ancients.AphroditeAncient>())
            return;
        
        var content = t.Field("_content").GetValue<VBoxContainer>();
        var contentContainer = t.Field("_contentContainer").GetValue<Control>();

        if (content == null || contentContainer == null)
            return;

        if (!State.TryGetValue(__instance, out var state))
        {
            state = new Box(content.Position.X, contentContainer.Size.X);
            State.Add(__instance, state);
        }

        content.Position = new Vector2(
            state.BaseContentX + XOffset,
            content.Position.Y
        );

        // Prevent right-side clipping.
        contentContainer.Size = new Vector2(
            state.BaseContainerWidth + Mathf.Abs(XOffset),
            contentContainer.Size.Y
        );
    }
}