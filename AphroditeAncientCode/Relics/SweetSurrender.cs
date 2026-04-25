using AphroditeAncient.AphroditeAncientCode.Powers;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Models.RelicPools;

namespace AphroditeAncient.AphroditeAncientCode.Relics;

[Pool(typeof(EventRelicPool))]
public class SweetSurrender : AphroditeAncientRelic
{
    public override RelicRarity Rarity => RelicRarity.Ancient;

    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromPower<WeakPower>(),
        HoverTipFactory.FromPower<VulnerablePower>(),
        HoverTipFactory.FromPower<CharmPower>(),
    ];

    public override async Task AfterPowerAmountChanged(
        PlayerChoiceContext choiceContext,
        PowerModel power,
        Decimal amount,
        Creature? applier,
        CardModel? cardSource)
    {
        if (amount <= 0M || applier != Owner.Creature || !Owner.Creature.CombatState.Enemies.Contains(power.Owner) ||
            power.Id != ModelDb.GetId<WeakPower>())
        {
            return;
        }

        Flash();
        await PowerCmd.Apply<VulnerablePower>(new ThrowingPlayerChoiceContext(), power.Owner, amount, null, null);
        await PowerCmd.Apply<CharmPower>(new ThrowingPlayerChoiceContext(), power.Owner, amount, null, null);
    }
}