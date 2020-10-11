using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.Other;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public sealed class Skill : CharacterTrait<Skill>, IFlagged<Skill.FlagList>
    {
        public enum FlagList
        {
            TrainedOnly, PenalizedByArmor, JobSkill
        };

        public string Name { get; set; }
        public Stats KeyStat { get; set; }
        public int Level { get; set; }
        public int MiscLevels { get; set; }

        public Skill(string name, Stats keyStat, int miscLevels, int level, FlagsArray<FlagList> flg)
        {
            Name = name;
            KeyStat = keyStat;
            MiscLevels = miscLevels;
            Level = level;
            Flags = flg;
        }

        public FlagsArray<FlagList> Flags { get; set; }

        public void Train(int l)
        {
            Level += l;
        }

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Modifier
        {
            get
            {
                var val = Parent.Stats.Modifier[KeyStat] + MiscLevels;
                if (Flags[FlagList.TrainedOnly] && Level <= 0)
                {
                    return Parent.Stats.Modifier[KeyStat] + MiscLevels - 2;
                }

                if (Flags[FlagList.JobSkill])
                {
                    return val + Level;
                }

                return val + (Level / 2);
            }
        }

    }
}
