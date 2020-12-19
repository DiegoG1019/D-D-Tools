using DiegoG.DnDTools.Base.Other;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Enumerations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    [Serializable]
    public sealed class Skill : CharacterTrait<Skill>, INotifyPropertyChanged
    {
        public bool TrainedOnly
        {
            get => TrainedOnlyField;
            set { TrainedOnlyField = value; NotifyPropertyChanged(); }
        }
        private bool TrainedOnlyField;
        public bool PenalizedByArmor
        {
            get => PenalizedByArmorField;
            set { PenalizedByArmorField = value; NotifyPropertyChanged(); }
        }
        private bool PenalizedByArmorField;
        public bool JobSkill
        {
            get => JobSkillField;
            set { JobSkillField = value; NotifyPropertyChanged(); }
        }
        private bool JobSkillField;

        public CharacterStatProperty ParentStats => Parent.Stats[KeyStat];

        public string Name { get => NameField; set {NameField = value;
                NotifyPropertyChanged();
            } }
        private string NameField;
        public Stats KeyStat { get => KeyStatField; set {KeyStatField = value;
                NotifyPropertyChanged();
            } }
        private Stats KeyStatField;
        public int Rank { get => RankField; set {RankField = value;
                NotifyPropertyChanged();
            } }
        private int RankField;
        public int MiscRanks { get => MiscRanksField; set {MiscRanksField = value;
                NotifyPropertyChanged();
            } }
        private int MiscRanksField;
        public int OtherRanks { get => OtherRanksField; set {OtherRanksField = value;
                NotifyPropertyChanged();
            } }
        private int OtherRanksField;

        public void Train(int l) => Rank += l;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Modifier
        {
            get
            {
                var val = ParentStats.Modifier + MiscRanks;
                if (TrainedOnly && Rank <= 0)
                    return ParentStats.Modifier + MiscRanks - 2;
                if (JobSkill)
                    return val + Rank;
                return val + (Rank / 2);
            }
        }
    }
}
