using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.DnDTools.Base.Other;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTools.Base.Characters
{
    [Serializable]
    public sealed class Ability : CharacterTrait<Ability>, INoted
    {
        public struct AbilityTag
        {
            public string Name { get; set; }
            public string ShortenedName { get; set; }
            public string Description { get; set; }

            public static AbilityTag Extraordinary { get; } = new AbilityTag()
            {
                Name = "Extraordinary Ability",
                ShortenedName = "Ex.",
                Description = "Extraordinary abilities are nonmagical, though they may break the laws of physics. They are not something that just anyone can do or even learn to do without extensive training."
            };
            public static AbilityTag SpellLike { get; } = new AbilityTag()
            {
                Name = "Spell-Like Ability",
                ShortenedName = "Sp",
                Description = "Usually, a spell-like ability works just like the spell of that name. A few spell-like abilities are unique; these are explained in the text where they are described."
            };
            public static AbilityTag Supernatural { get; } = new AbilityTag()
            {
                Name = "Supernatural Ability",
                ShortenedName = "Su",
                Description = "Supernatural abilities are magical and go away in an antimagic field but are not subject to spell resistance, counterspells, or to being dispelled by dispel magic."
            };
        }

        public string Name { get => NameField; set { NameField = value; NotifyPropertyChanged(); } }
        private string NameField;
        public string Requirements { get => RequirementsField; set { RequirementsField = value; NotifyPropertyChanged(); } }
        private string RequirementsField;
        public string Description { get => DescriptionField; set { DescriptionField = value; NotifyPropertyChanged(); } }
        private string DescriptionField;
        /// <summary>
        /// Not always applicable
        /// </summary>
        public int Level { get => LevelField; set { LevelField = value; NotifyPropertyChanged(); } }
        private int LevelField;
        public NoteList Notes { get => NotesField; set { NotesField = value; NotifyPropertyChanged(); } }
        private NoteList NotesField = new NoteList();
        public int[] Buffs { get => BuffsField; set { BuffsField = value; NotifyPropertyChanged(); } }
        private int[] BuffsField = new int[Enumerations.StatCount];
        public ObservableCollection<AbilityTag> Tags { get => TagsField; set { TagsField.CollectionChanged -= TagsFieldChanged; TagsField = value; TagsField.CollectionChanged += TagsFieldChanged; NotifyPropertyChanged(); } }

        private void TagsFieldChanged(object sender, NotifyCollectionChangedEventArgs e)
            => NotifyPropertyChanged(nameof(Tags));

        private ObservableCollection<AbilityTag> TagsField = new ObservableCollection<AbilityTag>();

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public string FullName
        {
            get
            {
                string str = Name + (Level > 0 ? $"+{Level}" : "");
                foreach (AbilityTag tag in Tags)
                    str += $" ({tag.ShortenedName})";
                return str;
            }
        }

    }
}
