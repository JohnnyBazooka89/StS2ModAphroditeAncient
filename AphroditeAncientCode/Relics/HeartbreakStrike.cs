using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Models.RelicPools;
using MegaCrit.Sts2.Core.Rooms;
using MegaCrit.Sts2.Core.ValueProps;

namespace AphroditeAncient.AphroditeAncientCode.Relics;

[Pool(typeof(EventRelicPool))]
public class HeartbreakStrike : AphroditeAncientRelic
{
    public override RelicRarity Rarity => RelicRarity.Ancient;

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<StrengthPower>(3M),
        new PowerVar<WeakPower>(1M)
    ];

    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromPower<StrengthPower>(),
        HoverTipFactory.FromPower<WeakPower>()
    ];

    public override async Task AfterRoomEntered(AbstractRoom room)
    {
        if (room is not CombatRoom)
            return;
        Flash();
        await PowerCmd.Apply<StrengthPower>(new ThrowingPlayerChoiceContext(), Owner.Creature,
            DynamicVars.Strength.BaseValue, Owner.Creature, null);
    }

    public override async Task AfterDamageGiven(
        PlayerChoiceContext choiceContext,
        Creature? dealer,
        DamageResult result,
        ValueProp props,
        Creature target,
        CardModel? cardSource)
    {
        if (dealer != Owner.Creature || !props.IsPoweredAttack())
            return;
        Flash();
        await PowerCmd.Apply<WeakPower>(choiceContext, target, DynamicVars.Weak.BaseValue,
            Owner.Creature, null);
    }
}