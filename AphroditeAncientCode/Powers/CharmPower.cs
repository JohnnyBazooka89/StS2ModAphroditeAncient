using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;

namespace AphroditeAncient.AphroditeAncientCode.Powers;

public class CharmPower : AphroditeAncientPower
{
    private const string StacksToStunKey = "StacksToStun";

    public override PowerType Type => PowerType.Debuff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public override int DisplayAmount => GetInternalData<Data>().StacksApplied;

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new(StacksToStunKey, 6M)
    ];

    protected override object InitInternalData() => new Data();

    public override async Task AfterPowerAmountChanged(
        PlayerChoiceContext choiceContext,
        PowerModel power,
        Decimal amount,
        Creature? applier,
        CardModel? cardSource)
    {
        if (amount <= 0M || power != this)
            return;

        Data data = GetInternalData<Data>();
        data.StacksApplied += (int)amount;
        if (data.StacksApplied >= DynamicVars[StacksToStunKey].IntValue)
        {
            Flash();
            await CreatureCmd.Stun(power.Owner);

            data.StacksApplied %= DynamicVars[StacksToStunKey].IntValue;
            if (data.StacksApplied == 0)
            {
                await PowerCmd.Remove(this);
            }
        }

        InvokeDisplayAmountChanged();
    }

    private class Data
    {
        public int StacksApplied;
    }
}