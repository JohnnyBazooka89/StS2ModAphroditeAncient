using BaseLib.Abstracts;
using BaseLib.Extensions;
using AphroditeAncient.AphroditeAncientCode.Extensions;

namespace AphroditeAncient.AphroditeAncientCode.Powers;

public abstract class AphroditeAncientPower : CustomPowerModel
{
    //Loads from AphroditeAncient/images/powers/your_power.png
    public override string CustomPackedIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PowerImagePath();
    public override string CustomBigIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigPowerImagePath();
}