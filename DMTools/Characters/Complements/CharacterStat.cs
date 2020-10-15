using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    [Serializable]
    public class CharacterStat<TStat> where TStat : Enum
    {
        public CharacterStatProperty<TStat> BasePoints { get; } = new CharacterStatProperty<TStat>();
        public CharacterStatProperty<TStat> Bonus { get; } = new CharacterStatProperty<TStat>();
        public CharacterStatProperty<TStat> EffectPoints { get; } = new CharacterStatProperty<TStat>();

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public CharacterStatProperty<TStat> BaseTotal => BasePoints + Bonus;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public CharacterStatProperty<TStat> BaseModifier => (BaseTotal / 2) - 5;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public CharacterStatProperty<TStat> Total => BaseTotal + EffectPoints;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public CharacterStatProperty<TStat> Modifier => (Total / 2) - 5;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        private CharacterStatProperty<TStat>[] Collection => new CharacterStatProperty<TStat>[] { BasePoints, Bonus, EffectPoints };
        /// <summary>
        /// Don't use this one
        /// </summary>
        public CharacterStat() : this(1) { }
        public CharacterStat(int count)
        {
            for (int i = 0; i < Collection.Length; i++)
                Collection[i] = new CharacterStatProperty<TStat>(count);
        }
    }
}
