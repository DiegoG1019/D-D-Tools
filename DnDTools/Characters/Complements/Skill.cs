using DiegoG.DnDNetCore.Other;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDNetCore.Enumerations;

namespace DiegoG.DnDNetCore.Characters.Complements
{
    [Serializable]
    public sealed class Skill : CharacterTrait<Skill>, IFlagged<Skill.FlagList>
    {
        public enum FlagList
        {
            TrainedOnly, PenalizedByArmor, JobSkill
        };

        public bool TrainedOnlyFlag
        {
            get => Flags[FlagList.TrainedOnly];
            set => Flags[FlagList.TrainedOnly] = value;
        }
        public bool PenalizedByArmorFlag
        {
            get => Flags[FlagList.PenalizedByArmor];
            set => Flags[FlagList.PenalizedByArmor] = value;
        }
        public bool JobSkillFlag
        {
            get => Flags[FlagList.JobSkill];
            set => Flags[FlagList.JobSkill] = value;
        }

        public CharacterStatProperty ParentStats => Parent.Stats[KeyStat];

        public string Name { get; set; }
        public Stats KeyStat { get; set; }
        public int Rank { get; set; }
        public int MiscRanks { get; set; }
        public int OtherRanks { get; set; }

        public FlagsArray<FlagList> Flags { get; set; }

        public void Train(int l) => Rank += l;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Modifier
        {
            get
            {
                var val = ParentStats.Modifier + MiscRanks;
                if (TrainedOnlyFlag && Rank <= 0)
                    return ParentStats.Modifier + MiscRanks - 2;
                if (JobSkillFlag)
                    return val + Rank;
                return val + (Rank / 2);
            }
        }
    }
}
