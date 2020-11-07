using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.Other;
using DiegoG.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public class Experience : CharacterTrait<Experience>, IHistoried
    {
        public float Multiplier { get; set; }
        private int _current;
        public int Required { get; set; }
        public int Level { get; set; }

        public ObservableCollection<int> History { get; set; } = new ObservableCollection<int>();
        public int Current
        {
            get => _current;
            set => Add(value - _current);
        }
        public int BaseExpGrant { get; set; }
        public int ExtraGrant { get; set; }

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
            _current += v;
            History.Add(v);
        }

        public void Sub(int v)
        {
            if (v > _current)
            {
                _current = 0;
                return;
            }
            _current -= v;
            History.Add(-v);
        }

        public void Gain(int v) => Add((int)(v * Multiplier));
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public bool DidLevel => Current >= Required;
        public void LevelUp()
        {
            Current = 0;
            Level++;
        }

        /// <summary>
        /// Calculate the required experience amount following the Game's rules
        /// </summary>
        public void SetRequired() => Required = (Level + 1) * (Level) * 500;
    }
}
