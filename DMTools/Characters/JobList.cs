using DiegoG.DnDTDesktop.Characters.Complements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Characters
{
    public class JobList : CharacterTrait<JobList>, IList<Job>
    {
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public List<Job> JobsCollection { get; set; } = new List<Job>();
        public event Action ListChanged;
        public void Add(Job item)
        {
            if (JobsCollection.Contains(item))
                throw new InvalidOperationException($"JobList collection already contains this Job {item.Name}");

            item.CompetenceChanged += JobList_ListChanged;
            JobsCollection.Add(item);
            ListChanged();
        }
        public void Remove(Job item)
        {
            item.CompetenceChanged -= JobList_ListChanged;
            JobsCollection.Remove(item);
            ListChanged();
        }

        public IEnumerator<Job> GetEnumerator()
        {
            foreach (var item in JobsCollection)
                yield return item;
        }

        public Job this[int index]
        {
            get => JobsCollection[index];
            set => JobsCollection[index] = value;
        }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public Job this[string JobName] => (from job in JobsCollection where job.Name == JobName select job).First();
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int this[Job job] => JobsCollection.IndexOf(job);
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Count => JobsCollection.Count;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public JobList()
        {
            foreach (var item in JobsCollection)
                item.CompetenceChanged += JobList_ListChanged;

            ListChanged += JobList_ListChanged;
            ListChanged();
        }

        private void JobList_ListChanged()
        {
            AllCompetences.Clear();
            foreach (var job in this)
                AllCompetences.Concat(job.Competence);
        }

        public int IndexOf(Job item) => JobsCollection.IndexOf(item);
        public void Insert(int index, Job item) => JobsCollection.Insert(index, item);
        public void RemoveAt(int index) => JobsCollection.RemoveAt(index);
        public void Clear() => JobsCollection.Clear();
        public bool Contains(Job item) => JobsCollection.Contains(item);
        public void CopyTo(Job[] array, int arrayIndex) => JobsCollection.CopyTo(array, arrayIndex);
        bool ICollection<Job>.Remove(Job item) => JobsCollection.Remove(item);

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public List<string> AllCompetences { get; private set; } = new List<string>();
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int AllLevels => (from item in JobsCollection select item.Level).Sum();
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int TotalSkillPoints => Parent.Skills.JobSkillPoints;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public bool IsReadOnly => false;
    }
}