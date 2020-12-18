using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities.Collections;
using static DiegoG.DnDTools.Base.Enumerations;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    [Serializable]
    public sealed class Job : CharacterTrait<Job>, INoted
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public ObservableCollection<string> Competence { get; set; } = new ObservableCollection<string>();
        public Dice HPDice { get; set; } = default;
        public int SkillPoints { get; set; }
        public NoteList Notes { get; set; } = new NoteList();

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int BaseAttack => AllBaseAttackBonuses.UpToIndex(Level).Sum();
        public SavingThrowBase GetSavingThrows()
        {
            var arr = AllSavingThrows.UpToIndex(Level);
            var stb = new SavingThrowBase();
            foreach (var i in arr)
                stb.Add(i);
            return stb;
        }

        public IEnumerable<Ability> GetAbilities()
        {
            List<Ability> r = new List<Ability>();
            var arr = AllAbilities.UpToIndex(Level);
            foreach (var i in arr)
                r.AddRange(i);
            return r;
        }

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public SafeIndexList<int> DailySpells => AllDailySpells[Level];

        public SafeIndexList<int> AllBaseAttackBonuses { get; set; } = new SafeIndexList<int>(20);
        public SafeIndexList<SavingThrowBase> AllSavingThrows { get; set; } = new SafeIndexList<SavingThrowBase>(20);
        public SafeIndexList<SafeIndexList<Ability>> AllAbilities { get; set; } = new SafeIndexList<SafeIndexList<Ability>>(20);
        public SafeIndexList<SafeIndexList<int>> AllDailySpells { get; set; } = new SafeIndexList<SafeIndexList<int>>(20);
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