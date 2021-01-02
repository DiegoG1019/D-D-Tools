﻿using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using DiegoG.Utilities.Settings;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Characters
{
    [Serializable]
    public sealed class Health : CharacterTrait<Health>
    {
        [Serializable]
        public sealed class Hurt : IHistoried, INotifyPropertyChanged
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
                        Heal(value - dmg);
                    NotifyPropertyChanged();
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            public ObservableCollection<int> History { get; init; } = new ObservableCollection<int>();

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

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int EffectHP { get => EffectHPField; set { EffectHPField = value; NotifyPropertyChanged(); } }
        private int EffectHPField;
        public int BaseHP { get => BaseHPField; set { BaseHPField = value; NotifyPropertyChanged(); } }
        private int BaseHPField = 1;

        public Hurt LethalDamage
        {
            get => LethalDamageField;
            init
            {
                LethalDamageField.PropertyChanged -= LethalDamageField_PropertyChanged;
                LethalDamageField = value;
                LethalDamageField.PropertyChanged += LethalDamageField_PropertyChanged;
            }
        }
        private void LethalDamageField_PropertyChanged(object sender, PropertyChangedEventArgs e)
            => NotifyPropertyChanged(nameof(LethalDamage));
        private Hurt LethalDamageField = new Hurt();

        public Hurt NonlethalDamage
        {
            get => NonlethalDamageField;
            set
            {
                NonlethalDamageField.PropertyChanged -= NonlethalDamageField_PropertyChanged;
                NonlethalDamageField = value;
                NonlethalDamageField.PropertyChanged += NonlethalDamageField_PropertyChanged;
            }
        }
        private void NonlethalDamageField_PropertyChanged(object sender, PropertyChangedEventArgs e)
            => NotifyPropertyChanged(nameof(NonlethalDamage));
        private Hurt NonlethalDamageField = new Hurt();

        public ObservableCollection<int> HpThrows
        {
            get => HpThrowsField;
            set
            {
                HpThrowsField.CollectionChanged -= HpThrowsField_CollectionChanged;
                HpThrowsField = value;
                HpThrowsField.CollectionChanged += HpThrowsField_CollectionChanged;
            }
        }
        private void HpThrowsField_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            => NotifyPropertyChanged(nameof(HpThrows));
        private ObservableCollection<int> HpThrowsField = new ObservableCollection<int>();

        public void SetBaseHP()
        {
            BaseHP = 0;
            for (byte i = 0; i <= Parent.Experience.Level; i++)
            {
                if (HpThrows.Count <= i)
                    return;
                var n = HpThrows[i] + Parent.Stats[Stats.Constitution].Modifier;
                if (n > 1)
                { BaseHP += n; continue; }
                BaseHP++;
            }
        }

        public Health()
        {
            HpThrowsField.CollectionChanged += HpThrowsField_CollectionChanged;
            NonlethalDamageField.PropertyChanged += NonlethalDamageField_PropertyChanged;
            LethalDamageField.PropertyChanged += LethalDamageField_PropertyChanged;
            PropertyChanged += Health_PropertyChanged;
        }

        private void Health_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            HPRelation.BaseA = RemainingHP;
            HPRelation.BaseB = BaseHP + EffectHP;
        }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int RemainingHP => EffectHP + BaseHP - (LethalDamage.Damage + NonlethalDamage.Damage);

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public NumberRelation HPRelation { get; private set; } = new();

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
                if (RemainingHP <= Settings<DnDSettings>.Current.DeceasedHP)
                    return CombatState.Deceased;
                if (RemainingHP <= Settings<DnDSettings>.Current.BleedingOutHP)
                    return CombatState.BleedingOut;
                if (RemainingHP <= Settings<DnDSettings>.Current.IncapacitatedHP)
                    return CombatState.Incapacitated;
                return CombatState.Active;
            }
        }
    }
}
