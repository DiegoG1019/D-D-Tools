using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.DnDTools.Base.Items;
using DiegoG.Utilities.IO;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Cache.GlobalCache;
using static DiegoG.DnDTools.Base.Enumerations;
using Version = DiegoG.Utilities.Version;

namespace DiegoG.DnDTools.Base.Characters
{
    [Serializable]
    public class Character : INotifyPropertyChanged
    {
        /// <summary>
        /// Represents the Character Version that the program expects
        /// A.B.C.D
        /// A - Completely incompatible with previous versions
        /// B - Previous versions will need to be imported
        /// C - Small changes in names and other minor things
        /// D - Small changes in character construction
        /// </summary>
        public static Version Working_Version { get; } = new Version($"{ShortAppName} Character", 1, 0, 0, 0);
        /// <summary>
        /// Represents the character's version, as defined by the program 
        /// </summary>
        [JsonPropertyName("Character Version"), XmlElement(ElementName = "Character Version", IsNullable = false, Order = 1)]
        public Version Version { get; set; }

        private bool constructing = true;
        private string _CFN;
        [JsonPropertyName("Character File Name"), XmlElement(ElementName = "Character File Name", IsNullable = false, Order = 3)]
        public string CharacterFileName
        {
            get => _CFN;
            set
            {
                if (!constructing)
                    DnDManager.Characters.ChangeCharacterRegistrationKey(_CFN, value);
                _CFN = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        [JsonPropertyName("Character Stats"), XmlElement(ElementName = "Character Stats", IsNullable = false)]
        public CharacterStat<Stats, CharacterStatProperty> Stats { get => StatsField; set { StatsField = value; NotifyPropertyChanged(); } }
        private CharacterStat<Stats, CharacterStatProperty> StatsField;

        [JsonPropertyName("Character Saving Throws"), XmlElement(ElementName = "Character Saving Throws", IsNullable = false)]
        public CharacterStat<SavingThrow, CharacterSavingThrowProperty> SavingThrows { get => SavingThrowsField; set { SavingThrowsField = value; NotifyPropertyChanged(); } }
        private CharacterStat<SavingThrow, CharacterSavingThrowProperty> SavingThrowsField;

        [JsonPropertyName("Other Character Stats"), XmlElement(ElementName = "Other Character Stats", IsNullable = false)]
        public SecondaryCharacterStats SecondaryStats { get => SecondaryStatsField; set { SecondaryStatsField = value; NotifyPropertyChanged(); } }
        private SecondaryCharacterStats SecondaryStatsField;

        [JsonPropertyName("Character Experience"), XmlElement(ElementName = "Character Experience", IsNullable = false)]
        public Experience Experience { get => ExperienceField; set { ExperienceField = value; NotifyPropertyChanged(); } }
        private Experience ExperienceField;

        [JsonPropertyName("Character Armor Class"), XmlElement(ElementName = "Character Armor Class", IsNullable = false)]
        public ArmorClass ArmorClass { get => ArmorClassField; set { ArmorClassField = value; NotifyPropertyChanged(); } }
        private ArmorClass ArmorClassField;

        [JsonPropertyName("Character Description"), XmlElement(ElementName = "Character Description", IsNullable = false)]
        public Description Description { get => DescriptionField; set { DescriptionField = value; NotifyPropertyChanged(); } }
        private Description DescriptionField;

        [JsonPropertyName("Character Health"), XmlElement(ElementName = "Character Health", IsNullable = false)]
        public Health Health { get => HealthField; set { HealthField = value; NotifyPropertyChanged(); } }
        private Health HealthField;

        [JsonPropertyName("Character Classes"), XmlElement(ElementName = "Character Classes", IsNullable = false)]
        public JobList Jobs { get => JobsField; set { JobsField = value; NotifyPropertyChanged(); } }
        private JobList JobsField;

        [JsonPropertyName("Character Abilities"), XmlElement(ElementName = "Character Abilities", IsNullable = false)]
        public ObservableCollection<Ability> Abilities
        {
            get => AbilitiesField;
            set
            {
                AbilitiesField = value;
                NotifyPropertyChanged();
            }
        }
        private ObservableCollection<Ability> AbilitiesField = new();

        [JsonPropertyName("Character Feats"), XmlElement(ElementName = "Character Feats", IsNullable = false)]
        public ObservableCollection<Ability> Feats
        {
            get => FeatsField;
            set { FeatsField = value; NotifyPropertyChanged(); }
        }
        private ObservableCollection<Ability> FeatsField = new();
        [JsonPropertyName("Character Skills"), XmlElement(ElementName = "Character Skills", IsNullable = false)]
        public SkillList Skills { get => SkillsField; set { SkillsField = value; NotifyPropertyChanged(); } }
        private SkillList SkillsField;

        [JsonPropertyName("Character Bags"), XmlElement(ElementName = "Character Bags", IsNullable = false)]
        public ObservableCollection<Inventory> Bags
        {
            get => BagsField;
            set
            {
                BagsField = value;
                NotifyPropertyChanged();
            }
        }
        private ObservableCollection<Inventory> BagsField = new();

        [JsonPropertyName("Character Equipped Items"), XmlElement(ElementName = "Character Equipped Items", IsNullable = false)]
        public Inventory Equipped { get => EquippedField; set { EquippedField = value; NotifyPropertyChanged(); } }
        private Inventory EquippedField = new() { Description = "Equipped Items", Name = "Equipped" };

        [JsonPropertyName("Character Initiative"), XmlElement(ElementName = "Character Initiative", IsNullable = false)]
        public CharacterSavingThrowProperty Initiative { get => InitiativeField; set { InitiativeField = value; NotifyPropertyChanged(); } }
        private CharacterSavingThrowProperty InitiativeField;

        /// <summary>
        /// Don't use this one, this is for serialization, and WILL result in bugs if not initialized properly. (The serializer is supposed to take care of that)
        /// </summary>
        public Character() { }
        public Character(string characterFileName) : this()
        {
            CharacterFileName = characterFileName;

            Experience = new Experience() { ParentName = CharacterFileName };
            ArmorClass = new ArmorClass() { ParentName = CharacterFileName };
            Description = new Description() { ParentName = CharacterFileName };
            Health = new Health() { ParentName = CharacterFileName };
            Jobs = new JobList() { ParentName = CharacterFileName };
            Stats = new CharacterStat<Stats, CharacterStatProperty>(CharacterFileName);
            SavingThrows = new CharacterStat<SavingThrow, CharacterSavingThrowProperty>(CharacterFileName);
            Initiative = new CharacterSavingThrowProperty() { BaseStat = Enumerations.Stats.Dexterity, ParentName = CharacterFileName };
            Skills = new() { ParentName = CharacterFileName };

            SavingThrows[SavingThrow.Fortitude].BaseStat = Enumerations.Stats.Constitution;
            SavingThrows[SavingThrow.Reflexes].BaseStat = Enumerations.Stats.Dexterity;
            SavingThrows[SavingThrow.Willpower].BaseStat = Enumerations.Stats.Wisdom;

            Version = Working_Version;

            SecondaryStats = new SecondaryCharacterStats() { ParentName = CharacterFileName, };
            SecondaryStats.Add(
                "speed",
                new SecondaryCharacterStatProperty()
                {
                    ParentName = CharacterFileName,
                    ScriptData = new Scripting.CharacterPropertyScript(Directories.Scripts, "SpeedPropertyDefault.cs")
                }
            );

            constructing = false;
            DnDManager.Characters.Register(this);
        }

        public async Task SerializeAsync() => await Serialization.Serialize.JsonAsync(this, Directories.Characters, CharacterFileName);
        public async static Task<Character> DeserializeAndReplaceAsync(Character chara)
        {
            DnDManager.Characters.Unregister(chara);
            return await DeserializeAndRegisterAsync(chara.CharacterFileName);
        }
        public static async Task<Character> DeserializeAndRegisterAsync(string characterFileName)
        {
            //Before deserialization the object is initialized to its default state, the default state of 'constructing' is true
            var chara = await Serialization.Deserialize<Character>.JsonAsync(Directories.Characters, characterFileName);
            DnDManager.Characters.Register(chara);
            chara.constructing = false;
            return chara;
        }
    }
}
