using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTools.Base.Characters
{
    [Serializable]
    public class Experience : CharacterTrait<Experience>, IHistoried
    {
        public float Multiplier { get => MultiplierField; set { MultiplierField = value; NotifyPropertyChanged(); } }
        private float MultiplierField;
        public int Required { get => RequiredField; set { RequiredField = value; NotifyPropertyChanged(); } }
        private int RequiredField;
        public int Level { get => LevelField; set { LevelField = value; NotifyPropertyChanged(); } }
        private int LevelField;
        public int BaseExpGrant { get => BaseExpGrantField; set { BaseExpGrantField = value; NotifyPropertyChanged(); } }
        private int BaseExpGrantField;
        public int ExtraGrant { get => ExtraGrantField; set { ExtraGrantField = value; NotifyPropertyChanged(); } }
        private int ExtraGrantField;

        public ObservableCollection<int> History { get; set; } = new ObservableCollection<int>();
        public int Current
        {
            get => CurrentField;
            set => Add(value - CurrentField);
        }
        private int CurrentField;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int UnspentLevels => Level - Parent.Jobs.AllLevels;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Grant => Level * (Level - 1) * 500 + (BaseExpGrant * Level) + ExtraGrant;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Left => Required - Current;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public Percentage Progress => new Percentage((Current / Required) * 100f);

        public void Add(int v)
        {
            CurrentField += v;
            History.Add(v);
            NotifyPropertyChanged(nameof(Current));
        }

        public void Sub(int v)
        {
            if (v > CurrentField)
            {
                CurrentField = 0;
                return;
            }
            CurrentField -= v;
            History.Add(-v);
            NotifyPropertyChanged(nameof(Current));
        }

        public void Gain(int v) => Add((int)(v * Multiplier));
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public bool DidLevel => Current >= Required;
        public void LevelUp()
        {
            Current = 0;
            Level++;
            NotifyPropertyChanged(nameof(Level));
        }

        /// <summary>
        /// Calculate the required experience amount following the Game's rules
        /// </summary>
        public void SetRequired() => Required = (Level + 1) * (Level) * 500;
    }
}
