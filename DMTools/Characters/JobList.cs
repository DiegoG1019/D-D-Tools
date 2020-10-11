using DiegoG.DnDTDesktop.Characters.Complements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DiegoG.DnDTDesktop.Characters
{
    public class JobList : CharacterTrait<JobList>, IEnumerable<Job>
    {
        private List<Job> Jobs { get; set; } = new List<Job>();
        public event Action ListChanged;
        public void Add(Job item)
        {
            if (Jobs.Contains(item))
            {
                throw new InvalidOperationException($"JobList collection already contains this Job {item.Name}");
            }

            item.CompetenceChanged += JobList_ListChanged;
            Jobs.Add(item);
            ListChanged();
        }
        public void Remove(Job item)
        {
            item.CompetenceChanged -= JobList_ListChanged;
            Jobs.Remove(item);
            ListChanged();
        }

        public IEnumerator<Job> GetEnumerator()
        {
            foreach (var item in Jobs)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public JobList()
        {
            foreach (var item in Jobs)
            {
                item.CompetenceChanged += JobList_ListChanged;
            }

            ListChanged += JobList_ListChanged;
            ListChanged();
        }

        private void JobList_ListChanged()
        {
            AllCompetences.Clear();
            foreach (var job in this)
            {
                AllCompetences.Concat(job.Competence);
            }
        }

        public List<string> AllCompetences { get; private set; } = new List<string>();
        public int AllLevels => (from item in Jobs select item.Level).Sum();
        public int TotalSkillPoints => (from item in Jobs select item.Level * item.SkillPoints).Sum();
        public Job this[string name] => (from item in Jobs where item.Name == name select item).First();
    }
}