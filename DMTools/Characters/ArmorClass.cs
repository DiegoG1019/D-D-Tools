using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.Other;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public sealed class ArmorClass : CharacterTrait<ArmorClass>, IFlagged<ArmorClass.FlagList>
    {
        public enum FlagList
        {
            FeatDex
        }

        public int BaseAC { get; set; } = 0;
        public int Armor { get; set; } = 0;
        public int Size { get; set; } = 0;
        public int Natural { get; set; } = 0;
        public int Deflex { get; set; } = 0;
        public int Bonus { get; set; } = 0;
        public int Effect { get; set; } = 0;
        public FlagsArray<FlagList> Flags { get; set; } = new FlagsArray<FlagList>();

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int AC => BaseAC + Armor + Size + Natural + Deflex + Bonus + Effect + Parent.Stats[Stats.Dexterity].Modifier;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int TouchAC => BaseAC + Size + Effect + Deflex + Parent.Stats[Stats.Dexterity].Modifier;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int UnawareAC => BaseAC + Armor + Size + Natural + Effect + (Flags[FlagList.FeatDex] ? Parent.Stats[Stats.Dexterity].Modifier : 0);

    }
}
