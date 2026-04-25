using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.RelicPools;

namespace AphroditeAncient.AphroditeAncientCode.Relics;

[Pool(typeof(EventRelicPool))]
public class NervousWreck : AphroditeAncientRelic
{
    public override RelicRarity Rarity => RelicRarity.Ancient;

    public override Decimal ModifyPowerAmountGiven(
        PowerModel power,
        Creature giver,
        Decimal amount,
        Creature? target,
        CardModel? cardSource)
    {
        return power.Type != PowerType.Debuff || !Owner.Creature.CombatState.Enemies.Contains(target) ||
               giver != Owner.Creature
            ? amount
            : 2 * amount;
    }

    public override Task AfterModifyingPowerAmountGiven(PowerModel power)
    {
        Flash();
        return Task.CompletedTask;
    }
}