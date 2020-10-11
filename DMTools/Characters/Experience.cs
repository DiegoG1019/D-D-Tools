using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.Other;
using DiegoG.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public sealed class Experience : CharacterTrait<Experience>, IHistoried<float>
    {
        public float Multiplier { get; set; }
        private float _current;
        public float Required { get; set; }
        public int Level { get; set; }

        public List<float> History { get; set; }
        public float Current
        {
            get
            {
                return _current;
            }
            set
            {
                Add(value - _current);
            }
        }
        public int BaseExpGrant { get; set; }
        public int ExtraGrant { get; set; }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Grant => Level * (Level - 1) * 500 + (BaseExpGrant * Level) + ExtraGrant;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int HistoryEntries => History.Count;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public float Left => Required - Current;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public Percentage Progress => new Percentage((Current / Required) * 100f);

        public void Add(float v)
        {
            _current += v;
            History.Add(v);
        }

        public void Sub(float v)
        {
            if (v > _current)
            {
                _current = 0;
                return;
            }
            _current -= v;
            History.Add(-v);
        }

        public void Gain(float v)
        {
            Add(v * Multiplier);
        }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public bool DidLevel => Current >= Required;
        public void LevelUp()
        {
            Current = 0;
            Level++;
        }

        public void SetRequired()
        {
            Required = (Level + 1) * (Level) * 500;
        }
    }
}
