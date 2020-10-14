﻿using DiegoG.DnDTDesktop.Characters.Complements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public class SkillList : CharacterTrait<SkillList>, IEnumerable<Skill>
    {
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public List<Skill> SkillListCollection { get; private set; } = new List<Skill>();
        public Skill this[int index]
        {
            get => SkillListCollection[index];
            set => SkillListCollection[index] = value;
        }
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public Skill this[string skillName] => (from skill in SkillListCollection where skill.Name == skillName select skill).First();
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int this[Skill skill] => SkillListCollection.IndexOf(skill);

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Count => SkillListCollection.Count;

        public void Add(Skill item) => SkillListCollection.Add(item);
        public IEnumerator<Skill> GetEnumerator() => SkillListCollection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int[] JobBaseSkillPoints => (from val in Parent.Jobs select val.SkillPoints).ToArray();
        public int MiscSkillPoints { get; set; } = 0;
        public int AbilitySkillPoints { get; set; } = 0;
        public int ExtraAbilitySkillPoints { get; set; } = 0;
        public int ExtraSkillPoints { get; set; } = 0;
        public int JobSkillPoints => (from val in Parent.Jobs select val.SkillPoints * val.Level).Sum();
        public int SpentSkillPoints => (from val in this where val.JobSkillFlag select val.Rank).Sum();
        public int TotalSkillPoints => JobSkillPoints + ((MiscSkillPoints + AbilitySkillPoints) * Parent.Jobs.AllLevels) + ExtraSkillPoints + ExtraAbilitySkillPoints;
        public int AvailableSkillPoints => TotalSkillPoints - SpentSkillPoints;
        public int MaxJobSkillRank => Parent.Jobs.AllLevels + 4;
        public int MaxOtherSkillRank => MaxJobSkillRank / 2;
    }
}
