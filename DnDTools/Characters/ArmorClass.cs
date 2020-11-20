using DiegoG.DnDNetCore.Characters.Complements;
using DiegoG.DnDNetCore.Other;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDNetCore.Enumerations;

namespace DiegoG.DnDNetCore.Characters
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
        public int Deflex { get; set; } = 0;
        public int Bonus { get; set; } = 0;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Effect { get; set; } = 0;
        public FlagsArray<FlagList> Flags { get; set; } = new FlagsArray<FlagList>();
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Armor => Parent.Equipped.ArmorAC;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int AC => BaseAC + Armor + Size + Natural + Deflex + Bonus + Effect + Parent.Stats[Stats.Dexterity].Modifier;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int TouchAC => BaseAC + Size + Effect + Deflex + Parent.Stats[Stats.Dexterity].Modifier;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int UnawareAC => BaseAC + Armor + Size + Natural + Effect + (Flags[FlagList.FeatDex] ? Parent.Stats[Stats.Dexterity].Modifier : 0);

    }
}
