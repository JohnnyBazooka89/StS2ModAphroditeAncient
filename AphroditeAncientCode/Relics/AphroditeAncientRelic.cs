using BaseLib.Abstracts;
using BaseLib.Extensions;
using AphroditeAncient.AphroditeAncientCode.Extensions;

namespace AphroditeAncient.AphroditeAncientCode.Relics;

public abstract class AphroditeAncientRelic : CustomRelicModel
{
    //AphroditeAncient/images/relics
    public override string PackedIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".RelicImagePath();
    protected override string PackedIconOutlinePath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".RelicOutlineImagePath();
    protected override string BigIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigRelicImagePath();
}