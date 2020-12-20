using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.Utilities.Collections;
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
    public class SpellBook : CharacterTrait<SpellBook>, ICollection<Spell>
    {
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public ObservableCollection<Spell> SpellCollection { get; set; } = new ObservableCollection<Spell>();
        public Spell this[int index]
        {
            get => SpellCollection[index];
            set
            {
                value.PropertyChanged -= Value_PropertyChanged;
                SpellCollection[index] = value;
                value.PropertyChanged += Value_PropertyChanged;
                NotifyPropertyChanged(nameof(SpellCollection));
            }
        }

        private void Value_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            => NotifyPropertyChanged(nameof(SpellCollection));

        public SpellBook()
        {
            //I think it's better to check both simultaneously rather than iterate twice, as would happen if I used prepared spells as a collection
            SpellsByLevel = new ReadOnlyIndexedProperty<int, IEnumerable<Spell>>
            ((i) => from spell in SpellCollection where spell.Level == i select spell);

            SpellsBySchool = new ReadOnlyIndexedProperty<MagicSchool, IEnumerable<Spell>>
            ((s) => from spell in SpellCollection where spell.School == s select spell);

            SpellsBySchoolAndLevel = new ReadOnlyIndexedProperty<MagicSchool, int, IEnumerable<Spell>>
            ((s, l) => from spell in SpellCollection where spell.School == s && spell.Level == l select spell);
        }

        public int Capacity { get; set; }

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public bool IsOverFilled => Count > Capacity;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public bool IsFull => Count >= Capacity;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Count => SpellCollection.Count;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public bool IsReadOnly => false;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public IEnumerable<Spell> AllSpells => this;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public SafeIndexList<Spell> PreparedSpells => (SafeIndexList<Spell>)FilterPreparedness(AllSpells).ToList();

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public ReadOnlyIndexedProperty<int, IEnumerable<Spell>> SpellsByLevel { get; private set; }

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public ReadOnlyIndexedProperty<MagicSchool, IEnumerable<Spell>> SpellsBySchool { get; private set; }

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public ReadOnlyIndexedProperty<MagicSchool, int, IEnumerable<Spell>> SpellsBySchoolAndLevel { get; private set; }

        public static IEnumerable<Spell> FilterPreparedness(IEnumerable<Spell> spells, bool isPrepared = true)
            => from spell in spells where spell.IsPrepared == isPrepared select spell;

        public void Add(Spell item)
        {
            SpellCollection.Add(item);
            item.PropertyChanged += Value_PropertyChanged;
            NotifyPropertyChanged(nameof(SpellCollection));
        }
        public bool Remove(Spell item)
        {
            if (!Contains(item))
                return false;
            SpellCollection.Remove(item);
            item.PropertyChanged -= Value_PropertyChanged;
            NotifyPropertyChanged(nameof(SpellCollection));
            return true;
        }
        public void Clear()
        {
            foreach (var v in this)
                Remove(v);
        }
        public bool Contains(Spell item) => SpellCollection.Contains(item);
        public void CopyTo(Spell[] array, int arrayIndex) => SpellCollection.CopyTo(array, arrayIndex);
        public int IndexOf(Spell item) => SpellCollection.IndexOf(item);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<Spell> GetEnumerator()
        {
            foreach (Spell s in SpellCollection)
                yield return s;
        }
    }
}
