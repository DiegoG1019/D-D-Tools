using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.Utilities.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Characters
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

        public int TotalBaseAttack => JobsCollection.Select((j) => j.BaseAttack).Sum();
        public ReadOnlyIndexedProperty<int, int> TotalDailySpells { get; private set; }

        public IEnumerable<Ability> GetGainedAbilities()
        {
            List<Pair<Task, IEnumerable<Ability>>> PairList = new List<Pair<Task, IEnumerable<Ability>>>();
            foreach (var j in JobsCollection)
            {
                var pair = new Pair<Task, IEnumerable<Ability>>();
                pair.ObjectA = Task.Run(() => { pair.ObjectB = j.GetAbilities(); });
            }
            Task.WaitAll((from i in PairList select i.ObjectA).ToArray());
            var newlist = new List<Ability>();
            foreach (var p in PairList)
                newlist.AddRange(p.ObjectB);
            return newlist;
        }

        public SavingThrowBase GetCurrentSavingThrows()
        {
            var pl = new List<Pair<Task, SavingThrowBase>>();
            foreach (Job job in this)
            {
                var pair = new Pair<Task, SavingThrowBase>();
                pair.ObjectA = Task.Run(
                    () =>
                    {
                        pair.ObjectB = new SavingThrowBase();
                        pair.ObjectB.Add(job.GetSavingThrows());
                    }
                );
            }
            var (AllTasks, AllSavingThrows) = Pair<Task, SavingThrowBase>.SeparateEnumerable(pl);
            Task.WaitAll(AllTasks.ToArray());
            var stb = new SavingThrowBase();
            foreach (var i in AllSavingThrows)
                stb.Add(i);
            return stb;
        }

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