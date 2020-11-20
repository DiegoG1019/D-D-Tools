using DiegoG.DnDTDesktop.Characters;
using DiegoG.DnDTDesktop;
using DiegoG.DnDTDesktop.Properties;
using DiegoG.DnDTDesktop.Characters.Complements;
using static DiegoG.DnDTDesktop.Enumerations;

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