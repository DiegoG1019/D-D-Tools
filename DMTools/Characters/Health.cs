﻿using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.Other;
using DiegoG.DnDTDesktop.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public sealed class Hurt : IHistoried
        {
            private int dmg;
            public int Damage
            {
                get => dmg;
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

            public ObservableCollection<int> History { get; set; } = new ObservableCollection<int>();

            [JsonIgnore, IgnoreDataMember, XmlIgnore]
            public int HistoryEntries => History.Count;

            public void Harm(int d)
            {
                History.Add(d);
                if ((d < 0) && (Math.Abs(d) > Damage))
                {
                    dmg = 0;
                    return;
                }
                dmg += d;
            }

            public void Heal(int h)
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

        public int EffectHP { get; set; }
        public int BaseHP { get; set; }
        public Hurt LethalDamage { get; set; } = new Hurt();
        public Hurt NonlethalDamage { get; set; } = new Hurt();

        public List<int> HpThrows { get; set; } = new List<int>();
        public void SetBaseHP()
        {
            for (byte i = 0; i <= Parent.Experience.Level; i++)
            {
                var n = HpThrows[i] + Parent.Stats[Stats.Constitution].Modifier;
                if (n > 1)
                {
                    BaseHP += n;
                    return;
                }
                BaseHP++;
            }
        }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int RemainingHP => EffectHP + BaseHP - (LethalDamage.Damage + NonlethalDamage.Damage);

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int NonLethalHP => EffectHP + BaseHP - NonlethalDamage.Damage;

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
                if (RemainingHP <= Settings.Default.DeceasedHP)
                {
                    return CombatState.Deceased;
                }
                if (RemainingHP <= Settings.Default.BleedingOutHP)
                {
                    return CombatState.BleedingOut;
                }
                if (RemainingHP <= Settings.Default.IncapacitatedHP)
                {
                    return CombatState.Incapacitated;
                }
                return CombatState.Active;
            }
        }
    }
}
