using DiegoG.DnDNetCore.Characters.Complements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDNetCore.Enumerations;

namespace DiegoG.DnDNetCore.Characters
{
    [Serializable]
    public class SkillList : CharacterTrait<SkillList>, IList<Skill>
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
        public int IndexOf(Skill item) => SkillListCollection.IndexOf(item);
        public void Insert(int index, Skill item) => SkillListCollection.Insert(index, item);
        public void RemoveAt(int index) => SkillListCollection.RemoveAt(index);
        public void Clear() => SkillListCollection.Clear();
        public bool Contains(Skill item) => SkillListCollection.Contains(item);
        public void CopyTo(Skill[] array, int arrayIndex) => SkillListCollection.CopyTo(array, arrayIndex);
        bool ICollection<Skill>.Remove(Skill item) => SkillListCollection.Remove(item);

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Count => SkillListCollection.Count;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int[] JobBaseSkillPoints => (from val in Parent.Jobs select val.SkillPoints).ToArray();
        public int ExtraBaseSkillPoints { get; set; } = 0;
        public int AbilityBaseSkillPoints { get; set; } = 0;
        public int ExtraAbilitySkillPoints { get; set; } = 0;
        public int ExtraSkillPoints { get; set; } = 0;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int JobSkillPoints => (from val in Parent.Jobs select calcSP(val)).Sum();
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int SpentSkillPoints => (from val in this where val.JobSkillFlag select val.Rank).Sum();
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int RemainingSkillPoints => TotalSkillPoints - SpentSkillPoints;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int TotalSkillPoints => ((JobSkillPoints + ExtraBaseSkillPoints + AbilityBaseSkillPoints) * Parent.Jobs.AllLevels) + ExtraSkillPoints + ExtraAbilitySkillPoints;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int AvailableSkillPoints => TotalSkillPoints - SpentSkillPoints;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int MaxJobSkillRank => Parent.Jobs.AllLevels + 4;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int MaxOtherSkillRank => MaxJobSkillRank / 2;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public bool IsReadOnly => false;
    }
}
