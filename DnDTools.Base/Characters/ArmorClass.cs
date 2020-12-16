using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.DnDTools.Base.Other;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Characters
{
    [Serializable]
    public sealed class ArmorClass : CharacterTrait<ArmorClass>, IFlagged<ArmorClass.FlagList>
    {
        public enum FlagList
        {
            FeatDex
        }

        public int BaseAC { get; set; } = 0;
        public int Size { get; set; } = 0;
        public int Natural { get; set; } = 0;
        public int Deflection { get; set; } = 0;
        public int Bonus { get; set; } = 0;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Effect { get; set; } = 0;
        public FlagsArray<FlagList> Flags { get; set; } = new FlagsArray<FlagList>();
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Armor => Parent.Equipped.ArmorAC;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int AC => BaseAC + Armor + Size + Natural + Deflection + Bonus + Effect + Parent.Stats[Stats.Dexterity].Modifier;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int TouchAC => BaseAC + Size + Effect + Deflection + Parent.Stats[Stats.Dexterity].Modifier;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int UnawareAC => BaseAC + Armor + Size + Natural + Effect + (Flags[FlagList.FeatDex] ? Parent.Stats[Stats.Dexterity].Modifier : 0);

    }
}
