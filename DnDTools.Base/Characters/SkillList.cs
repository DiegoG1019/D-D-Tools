using DiegoG.DnDTools.Base.Characters.Complements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Characters
{
    [Serializable]
    public class SkillList : CharacterTrait<SkillList>, ICollection<Skill>
    {
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public ObservableCollection<Skill> SkillListCollection { get; private set; } = new ObservableCollection<Skill>();
        public Skill this[int index]
        {
            get => SkillListCollection[index];
            set
            {
                value.PropertyChanged -= Item_PropertyChanged;
                SkillListCollection[index] = value;
                value.PropertyChanged += Item_PropertyChanged;
                NotifyPropertyChanged(nameof(SkillListCollection));
            }
        }
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public Skill this[string skillName] => (from skill in SkillListCollection where skill.Name == skillName select skill).First();
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int this[Skill skill] => SkillListCollection.IndexOf(skill);

        private int CalcSP(Job val)
        {
            int P = val.SkillPoints, I = Parent.Stats[Stats.Intelligence].BaseModifier, L = val.Level;
            int r = ((P + I + 1) * 4) + ((P + I + 1) * (L - 1));
            return Math.Max(r, val.Level);
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            => NotifyPropertyChanged(nameof(SkillListCollection));

        public void Add(Skill item)
        {
            SkillListCollection.Add(item);
            item.PropertyChanged += Item_PropertyChanged;
            NotifyPropertyChanged(nameof(SkillListCollection));
        }

        public void Remove(Skill item)
        {
            SkillListCollection.Remove(item);
            item.PropertyChanged -= Item_PropertyChanged;
            NotifyPropertyChanged(nameof(SkillListCollection));
        }
        public void Remove(string skillname) => Remove(this[skillname]);
        bool ICollection<Skill>.Remove(Skill item)
        {
            if (Contains(item))
            { Remove(item); return true; }
            return false;
        }
        public IEnumerator<Skill> GetEnumerator() => SkillListCollection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int IndexOf(Skill item) => SkillListCollection.IndexOf(item);
        public void Clear()
        {
            foreach (var s in this)
                Remove(s);
        }
        public bool Contains(Skill item) => SkillListCollection.Contains(item);
        public void CopyTo(Skill[] array, int arrayIndex) => SkillListCollection.CopyTo(array, arrayIndex);

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Count => SkillListCollection.Count;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int[] JobBaseSkillPoints => (from val in Parent.Jobs select val.SkillPoints).ToArray();
        public int ExtraBaseSkillPoints { get => ExtraBaseSkillPointsField; set { ExtraBaseSkillPointsField = value; NotifyPropertyChanged(); } }
        private int ExtraBaseSkillPointsField;
        public int AbilityBaseSkillPoints { get => AbilityBaseSkillPointsField; set { AbilityBaseSkillPointsField = value; NotifyPropertyChanged(); } }
        private int AbilityBaseSkillPointsField;
        public int ExtraAbilitySkillPoints { get => ExtraAbilitySkillPointsField; set { ExtraAbilitySkillPointsField = value; NotifyPropertyChanged(); } }
        private int ExtraAbilitySkillPointsField;
        public int ExtraSkillPoints { get => ExtraSkillPointsField; set { ExtraSkillPointsField = value; NotifyPropertyChanged(); } }
        private int ExtraSkillPointsField;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int JobSkillPoints => (from val in Parent.Jobs select CalcSP(val)).Sum();
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int SpentSkillPoints => (from val in this where val.JobSkill select val.Rank).Sum();
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
