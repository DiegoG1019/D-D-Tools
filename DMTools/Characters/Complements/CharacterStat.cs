using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    [Serializable]
    public class CharacterStat<TStat> where TStat : Enum
    {
        public CharacterStatProperty<TStat> Natural { get; set; }
        public CharacterStatProperty<TStat> Bonus { get; set; }
        public CharacterStatProperty<TStat> TemporaryPoints { get; set; }

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public CharacterStatProperty<TStat> NaturalSum => Natural + Bonus;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public CharacterStatProperty<TStat> NaturalModifier => (NaturalSum / 2) - 5;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public CharacterStatProperty<TStat> Sum => NaturalSum + TemporaryPoints;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public CharacterStatProperty<TStat> Modifier => (Sum / 2) - 5;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public CharacterStatProperty<TStat>[] Basic => new CharacterStatProperty<TStat>[] { Natural, Bonus, TemporaryPoints };
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public CharacterStatProperty<TStat>[] Compound => new CharacterStatProperty<TStat>[] { NaturalModifier, NaturalSum, Sum, Modifier };
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public CharacterStatProperty<TStat>[] All => new CharacterStatProperty<TStat>[] { Natural, Bonus, TemporaryPoints, NaturalModifier, NaturalSum, Sum, Modifier };

        /// <summary>
        /// Don't use this one
        /// </summary>
        public CharacterStat() : this(1) { }
        public CharacterStat(int count)
        {
            for (int i = 0; i < Basic.Length; i++)
            {
                Basic[i] = new CharacterStatProperty<TStat>(count);
            }
        }
    }
}
