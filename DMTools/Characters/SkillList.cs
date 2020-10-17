﻿using DiegoG.DnDTDesktop.Characters.Complements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTDesktop.Enums;

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

        private int calcSP(Job val)
        {
            int P = val.SkillPoints, I = Parent.Stats[Stats.Intelligence].BaseModifier, L = val.Level;
            int r = ((P + I + 1) * 4) + ((P + I + 1) * (L - 1));
            return Math.Max(r, val.Level);
        }

        public void Add(Skill item) => SkillListCollection.Add(item);
        public void Remove(Skill item) => SkillListCollection.Remove(item);
        public void Remove(string skillname) => SkillListCollection.Remove(this[skillname]);
        public void Remove(int skillindex) => SkillListCollection.RemoveAt(skillindex);
        public IEnumerator<Skill> GetEnumerator() => SkillListCollection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Count => SkillListCollection.Count;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int[] JobBaseSkillPoints => (from val in Parent.Jobs select val.SkillPoints).ToArray();
        public int MiscSkillPoints { get; set; } = 0;
        public int AbilitySkillPoints { get; set; } = 0;
        public int ExtraAbilitySkillPoints { get; set; } = 0;
        public int ExtraSkillPoints { get; set; } = 0;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int JobSkillPoints => (from val in Parent.Jobs select calcSP(val)).Sum();
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int SpentSkillPoints => (from val in this where val.JobSkillFlag select val.Rank).Sum();
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int TotalSkillPoints => JobSkillPoints + ((MiscSkillPoints + AbilitySkillPoints) * Parent.Jobs.AllLevels) + ExtraSkillPoints + ExtraAbilitySkillPoints;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int AvailableSkillPoints => TotalSkillPoints - SpentSkillPoints;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int MaxJobSkillRank => Parent.Jobs.AllLevels + 4;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int MaxOtherSkillRank => MaxJobSkillRank / 2;
    }
}
