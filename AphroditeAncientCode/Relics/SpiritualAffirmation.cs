using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.RelicPools;

namespace AphroditeAncient.AphroditeAncientCode.Relics;

[Pool(typeof(EventRelicPool))]
public class SpiritualAffirmation : AphroditeAncientRelic
{
    public override RelicRarity Rarity => RelicRarity.Ancient;

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new MaxHpVar(16),
        new GoldVar(499)
    ];

    public override async Task AfterObtained()
    {
        await CreatureCmd.GainMaxHp(Owner.Creature, DynamicVars.MaxHp.BaseValue);
        await PlayerCmd.GainGold(DynamicVars.Gold.BaseValue, Owner);
    }
}