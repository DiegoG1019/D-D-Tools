using DiegoG.DnDTDesktop.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    [Serializable]
    public sealed class Job : INoted
    {
        [Serializable]
        public class JobGrowth
        {
            public List<List<int>> BaseAttack { get; set; } = new List<List<int>>();
            public List<List<int>> SavingThrows { get; set; } = new List<List<int>>();
            public List<Ability> Abilities { get; set; } = new List<Ability>();
            public List<List<int>> DailySpells { get; set; } = new List<List<int>>();
        }
        public string Name { get; set; }
        public int Level { get; set; }
        public ObservableCollection<string> Competence { get; set; } = new ObservableCollection<string>();
        public Dice HPDice { get; set; } = default;
        public int SkillPoints { get; set; }
        public JobGrowth Growth { get; set; } = default;
        public NoteList Notes { get; set; } = default;
        public Job()
        {
            Competence.CollectionChanged += Competence_CollectionChanged;
        }
        public event Action CompetenceChanged;

        private void Competence_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CompetenceChanged();
        }
    }
}