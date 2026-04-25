using AphroditeAncient.AphroditeAncientCode.Extensions;
using AphroditeAncient.AphroditeAncientCode.Relics;
using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Models;

namespace AphroditeAncient.AphroditeAncientCode.Ancients;

[Pool(typeof(AncientEventModel))]
public class AphroditeAncient : CustomAncientModel
{
    public override string CustomScenePath => "aphrodite.tscn".AncientImagePath();
    public override string CustomMapIconPath => "map_icon.png".AncientImagePath();
    public override string CustomMapIconOutlinePath => "map_icon_outline.png".AncientImagePath();
    public override string CustomRunHistoryIconPath => "run_history_icon.png".AncientImagePath();
    public override string CustomRunHistoryIconOutlinePath => "run_history_icon_outline.png".AncientImagePath();

    protected override OptionPools MakeOptionPools
    {
        get
        {
            List<AncientOption> debuffRelicsPool =
            [
                AncientOption<BrokenResolve>(),
                AncientOption<GlamourGain>(),
                AncientOption<NervousWreck>(),
                AncientOption<SweetSurrender>()
            ];

            List<AncientOption> otherRelicsPool =
            [
                AncientOption<DifferentLeague>(),
                AncientOption<FlutterFlourish>(),
                AncientOption<HealthyRebound>(),
                AncientOption<HeartbreakStrike>(),
                AncientOption<ShamelessAttitude>(),
                AncientOption<SisyphusAid>(),
                AncientOption<SpiritualAffirmation>(),
                AncientOption<SweetNectar>()
            ];

            return new OptionPools(MakePool(otherRelicsPool.ToArray()), MakePool(debuffRelicsPool.ToArray()));
        }
    }

    public override bool IsValidForAct(ActModel act)
    {
        return act.ActNumber() == 3;
    }
}