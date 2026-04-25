using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.RelicPools;

namespace AphroditeAncient.AphroditeAncientCode.Relics;

[Pool(typeof(EventRelicPool))]
public class SisyphusAid : AphroditeAncientRelic
{
    public override RelicRarity Rarity => RelicRarity.Ancient;

    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromCard<RollingBoulder>()
    ];

    public override async Task AfterAutoPrePlayPhaseEntered(
        PlayerChoiceContext choiceContext,
        Player player)
    {
        if (player != Owner || player.Creature.CombatState.RoundNumber > 1)
        {
            return;
        }

        CardModel rollingBoulderCard = player.Creature.CombatState.CreateCard<RollingBoulder>(Owner);

        await CardCmd.AutoPlay(choiceContext, rollingBoulderCard, null);
    }
}