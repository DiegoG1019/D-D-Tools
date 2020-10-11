using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.Other;
using DiegoG.DnDTDesktop.Properties;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public sealed class Health : CharacterTrait<Health>
    {
        [Serializable]
        public sealed class Hurt : IHistoried<float>
        {
            private float dmg;
            public float Damage
            {
                get
                {
                    return dmg;
                }
                set
                {
                    if (dmg > value)
                    {
                        Harm(dmg - value);
                        return;
                    }
                    if (dmg < value) //I don't want it to be added to the History if they were the same
                    {
                        Heal(value - dmg);
                    }
                }
            }

            public List<float> History { get; set; } = new List<float>();

            [JsonIgnore, IgnoreDataMember, XmlIgnore]
            public int HistoryEntries => History.Count;

            public void Harm(float d)
            {
                History.Add(d);
                if ((d < 0) && (Math.Abs(d) > Damage))
                {
                    dmg = 0;
                    return;
                }
                dmg += d;
            }

            public void Heal(float h)
            {
                History.Add(-h);
                if (h > Damage)
                {
                    dmg = 0;
                    return;
                }
                dmg -= h;
            }

        }

        private float BaseHP { get; set; }

        public Hurt LethalDamage { get; set; } = new Hurt();
        public Hurt NonlethalDamage { get; set; } = new Hurt();

        public List<float> HpThrows { get; set; } = new List<float>();
        public void SetBaseHP()
        {
            for (byte i = 0; i <= Parent.Experience.Level; i++)
            {
                var n = HpThrows[i] + Parent.Stats.Modifier[Stats.Constitution];
                if (n > 1)
                {
                    BaseHP += n;
                    return;
                }
                BaseHP++;
            }
        }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public float HP => BaseHP - (LethalDamage.Damage + NonlethalDamage.Damage);

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public float NlHP => BaseHP - NonlethalDamage.Damage;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public bool IsDeceased => State == CombatState.Deceased;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public bool IsBleedingOut => State == CombatState.BleedingOut;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public bool IsIncapacitated => State == CombatState.Incapacitated;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public CombatState State
        {
            get
            {
                if (HP <= Settings.Default.DeceasedHP)
                {
                    return CombatState.Deceased;
                }

                if (HP <= Settings.Default.BleedingOutHP)
                {
                    return CombatState.BleedingOut;
                }

                if (HP <= Settings.Default.IncapacitatedHP)
                {
                    return CombatState.Incapacitated;
                }

                return CombatState.Active;
            }
        }
    }
}
