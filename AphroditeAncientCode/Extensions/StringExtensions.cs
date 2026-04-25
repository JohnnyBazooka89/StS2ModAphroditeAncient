using Godot;

namespace AphroditeAncient.AphroditeAncientCode.Extensions;

//Mostly utilities to get asset paths.
public static class StringExtensions
{
    public static string ImagePath(this string path)
    {
        return Path.Join(AphroditeAncientMainFile.ResPath, "images", path);
    }

    public static string CardImagePath(this string path)
    {
        path = Path.Join(AphroditeAncientMainFile.ResPath, "images", "card_portraits", path);
        if (ResourceLoader.Exists(path)) return path;

        AphroditeAncientMainFile.Logger.Info("Could not find card image path: " + path);
        return Path.Join(AphroditeAncientMainFile.ResPath, "images", "card_portraits", "card.png");
    }

    public static string BigCardImagePath(this string path)
    {
        path = Path.Join(AphroditeAncientMainFile.ResPath, "images", "card_portraits", "big", path);
        if (ResourceLoader.Exists(path)) return path;

        AphroditeAncientMainFile.Logger.Info("Could not find big card image path: " + path);
        return Path.Join(AphroditeAncientMainFile.ResPath, "images", "card_portraits", "big", "card.png");
    }

    public static string PowerImagePath(this string path)
    {
        path = Path.Join(AphroditeAncientMainFile.ResPath, "images", "powers", path);
        if (ResourceLoader.Exists(path)) return path;

        AphroditeAncientMainFile.Logger.Info("Could not find power image path: " + path);
        return Path.Join(AphroditeAncientMainFile.ResPath, "images", "powers", "power.png");
    }

    public static string BigPowerImagePath(this string path)
    {
        path = Path.Join(AphroditeAncientMainFile.ResPath, "images", "powers", "big", path);
        if (ResourceLoader.Exists(path)) return path;

        AphroditeAncientMainFile.Logger.Info("Could not find big power image path: " + path);
        return Path.Join(AphroditeAncientMainFile.ResPath, "images", "powers", "big", "power.png");
    }

    public static string RelicImagePath(this string path)
    {
        path = Path.Join(AphroditeAncientMainFile.ResPath, "images", "relics", path);
        if (ResourceLoader.Exists(path)) return path;

        AphroditeAncientMainFile.Logger.Info("Could not find relic image path: " + path);
        return Path.Join(AphroditeAncientMainFile.ResPath, "images", "relics", "relic.png");
    }
    
    public static string RelicOutlineImagePath(this string path)
    {
        path = Path.Join(AphroditeAncientMainFile.ResPath, "images", "relics", "outline", path);
        if (ResourceLoader.Exists(path)) return path;

        AphroditeAncientMainFile.Logger.Info("Could not find relic image path: " + path);
        return Path.Join(AphroditeAncientMainFile.ResPath, "images", "relics", "outline", "relic.png");
    }

    public static string BigRelicImagePath(this string path)
    {
        path = Path.Join(AphroditeAncientMainFile.ResPath, "images", "relics", "big", path);
        if (ResourceLoader.Exists(path)) return path;

        AphroditeAncientMainFile.Logger.Info("Could not find big relic image path: " + path);
        return Path.Join(AphroditeAncientMainFile.ResPath, "images", "relics", "big", "relic.png");
    }

    public static string CharacterUiPath(this string path)
    {
        return Path.Join(AphroditeAncientMainFile.ResPath, "images", "charui", path);
    }
    
    public static string AncientImagePath(this string path)
    {
        return Path.Join(AphroditeAncientMainFile.ResPath, "images", "ancients", path);
    }
}