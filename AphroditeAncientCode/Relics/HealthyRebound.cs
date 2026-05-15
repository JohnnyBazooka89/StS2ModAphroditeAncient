using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.RelicPools;
using MegaCrit.Sts2.Core.Rooms;

namespace AphroditeAncient.AphroditeAncientCode.Relics;

[Pool(typeof(EventRelicPool))]
public class HealthyRebound : AphroditeAncientRelic
{
    private const string NormalCombatHealKey = "NormalCombatHeal";
    private const string EliteCombatHealKey = "EliteCombatHeal";
    private const string BossCombatHealKey = "BossCombatHeal";

    public override RelicRarity Rarity => RelicRarity.Ancient;

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new(NormalCombatHealKey, 5M),
        new(EliteCombatHealKey, 15M),
        new(BossCombatHealKey, 25M)
    ];

    public override async Task AfterRoomEntered(AbstractRoom room)
    {
        if (room is not CombatRoom || Owner.Creature.IsDead)
        {
            return;
        }

        int amountToHeal;
        if (room.RoomType == RoomType.Boss)
        {
            amountToHeal = DynamicVars[BossCombatHealKey].IntValue;
        }
        else if (room.RoomType == RoomType.Elite)
        {
            amountToHeal = DynamicVars[EliteCombatHealKey].IntValue;
        }
        else
        {
            amountToHeal = DynamicVars[NormalCombatHealKey].IntValue;
        }

        Flash();
        await CreatureCmd.Heal(Owner.Creature, amountToHeal);
    }
}