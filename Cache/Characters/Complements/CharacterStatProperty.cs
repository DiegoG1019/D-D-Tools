﻿using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDNetCore.Characters.Complements
{
    [Serializable]
    public class CharacterStatProperty : CharacterTrait<CharacterStatProperty>, ICharacterProperty
    {
        public int BasePoints { get; set; }
        public int Bonus { get; set; }

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int EffectPoints { get; set; }
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int BaseTotal => BasePoints + Bonus;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int BaseModifier => (BaseTotal / 2) - 5;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Total => BaseTotal + EffectPoints;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Modifier => (Total / 2) - 5;
    }
}