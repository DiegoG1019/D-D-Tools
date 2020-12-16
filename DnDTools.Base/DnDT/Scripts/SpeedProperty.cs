using DiegoG.DnDTools.Base.Characters;
using DiegoG.DnDTools.Base;
using DiegoG.DnDTools.Base.Properties;
using DiegoG.DnDTools.Base.Characters.Complements;
using static DiegoG.DnDTools.Base.Enumerations;

public class SpeedProperty
{
    public bool ReceiveInput = false;
    public bool RespondToStatChanges = false;
    public int GetDependentValue(Character chara, SecondaryCharacterStatProperty stat)
    {
        return chara.Stats[Stats.Dexterity].Modifier;
    }
    public int GetOtherValue(Character chara, SecondaryCharacterStatProperty stat)
    {
        return GetDependentValue(chara, stat) / Settings.Default.SquareSize;
    }
}