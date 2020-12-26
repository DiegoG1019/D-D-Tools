using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.DnDTools.Base.Items;
using DiegoG.Utilities.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Cache.GlobalCache;
using static DiegoG.DnDTools.Base.Enumerations;
using Version = DiegoG.Utilities.Version;

namespace DiegoG.DnDTools.Base.Characters
{
    [Serializable]
    public class Character
    {
        public const string FileNameStandard = "Character_{0}";

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

        [JsonPropertyName("Character Stats"), XmlElement(ElementName = "Character Stats", IsNullable = false)]
        public CharacterStat<Stats, CharacterStatProperty> Stats { get; init; }
        //public CharacterStat<Stats, CharacterStatProperty> Stats { get => StatsField; init { StatsField = ConstructingSetTest(value); } }
        //private CharacterStat<Stats, CharacterStatProperty> StatsField;

        [JsonPropertyName("Character Saving Throws"), XmlElement(ElementName = "Character Saving Throws", IsNullable = false)]
        public CharacterStat<SavingThrow, CharacterSavingThrowProperty> SavingThrows { get => SavingThrowsField; set { SavingThrowsField = ConstructingSetTest(value); } }
        private CharacterStat<SavingThrow, CharacterSavingThrowProperty> SavingThrowsField;

        [JsonPropertyName("Other Character Stats"), XmlElement(ElementName = "Other Character Stats", IsNullable = false)]
        public SecondaryCharacterStats SecondaryStats { get => SecondaryStatsField; set { SecondaryStatsField = ConstructingSetTest(value); } }
        private SecondaryCharacterStats SecondaryStatsField;

        [JsonPropertyName("Character Experience"), XmlElement(ElementName = "Character Experience", IsNullable = false)]
        public Experience Experience { get => ExperienceField; set { ExperienceField = ConstructingSetTest(value); } }
        private Experience ExperienceField;

        [JsonPropertyName("Character Armor Class"), XmlElement(ElementName = "Character Armor Class", IsNullable = false)]
        public ArmorClass ArmorClass { get => ArmorClassField; set { ArmorClassField = ConstructingSetTest(value); } }
        private ArmorClass ArmorClassField;

        [JsonPropertyName("Character Description"), XmlElement(ElementName = "Character Description", IsNullable = false)]
        public Description Description { get => DescriptionField; set { DescriptionField = ConstructingSetTest(value); } }
        private Description DescriptionField;

        [JsonPropertyName("Character Health"), XmlElement(ElementName = "Character Health", IsNullable = false)]
        public Health Health { get => HealthField; set { HealthField = ConstructingSetTest(value); } }
        private Health HealthField;

        [JsonPropertyName("Character Classes"), XmlElement(ElementName = "Character Classes", IsNullable = false)]
        public JobList Jobs { get => JobsField; set { JobsField = ConstructingSetTest(value); } }
        private JobList JobsField;

        [JsonPropertyName("Character Abilities"), XmlElement(ElementName = "Character Abilities", IsNullable = false)]
        public ObservableCollection<Ability> Abilities { get => AbilitiesField; set { AbilitiesField = ConstructingSetTest(value); } }
        private ObservableCollection<Ability> AbilitiesField = new();

        [JsonPropertyName("Character Feats"), XmlElement(ElementName = "Character Feats", IsNullable = false)]
        public ObservableCollection<Ability> Feats { get => FeatsField; set { FeatsField = ConstructingSetTest(value); } }
        private ObservableCollection<Ability> FeatsField = new();
        [JsonPropertyName("Character Skills"), XmlElement(ElementName = "Character Skills", IsNullable = false)]
        public SkillList Skills { get => SkillsField; set { SkillsField = ConstructingSetTest(value); } }
        private SkillList SkillsField;

        [JsonPropertyName("Character Bags"), XmlElement(ElementName = "Character Bags", IsNullable = false)]
        public ObservableCollection<Inventory> Bags { get => BagsField; set { BagsField = ConstructingSetTest(value); } }
        private ObservableCollection<Inventory> BagsField = new();

        [JsonPropertyName("Character Equipped Items"), XmlElement(ElementName = "Character Equipped Items", IsNullable = false)]
        public Inventory Equipped { get => EquippedField; set { EquippedField = ConstructingSetTest(value); } }
        private Inventory EquippedField = new() { Description = "Equipped Items", Name = "Equipped" };

        [JsonPropertyName("Character Initiative"), XmlElement(ElementName = "Character Initiative", IsNullable = false)]
        public InitiativeProperty Initiative { get => InitiativeField; set { InitiativeField = ConstructingSetTest(value); } }
        private InitiativeProperty InitiativeField;


        [JsonPropertyName("Character Speed"), XmlElement(ElementName = "Character Speed", IsNullable = false)]
        public SpeedProperty Speed { get => SpeedField; set { SpeedField = ConstructingSetTest(value); } }
        private SpeedProperty SpeedField;

        /// <summary>
        /// Don't use this one, this is for serialization, and WILL result in bugs if not initialized properly. (The serializer is supposed to take care of that)
        /// </summary>
        public Character() { }
        public Character(string characterFileName) : this()
        {
            CharacterFileName = characterFileName;

            Experience = new Experience() { ParentName = CharacterFileName };
            ArmorClass = new ArmorClass()
            { 
                ParentName = CharacterFileName,
                BaseAC = 10,
            };
            Description = new Description() { ParentName = CharacterFileName };
            Health = new Health() { ParentName = CharacterFileName };
            Jobs = new JobList() { ParentName = CharacterFileName };
            Stats = new CharacterStat<Stats, CharacterStatProperty>(CharacterFileName);
            SavingThrows = new CharacterStat<SavingThrow, CharacterSavingThrowProperty>(CharacterFileName);
            Skills = new() { ParentName = CharacterFileName };
            Initiative = new InitiativeProperty() { ParentName = CharacterFileName };
            Speed = new() { ParentName = characterFileName };

            SavingThrows[SavingThrow.Fortitude].BaseStat = Enumerations.Stats.Constitution;
            SavingThrows[SavingThrow.Reflexes].BaseStat = Enumerations.Stats.Dexterity;
            SavingThrows[SavingThrow.Willpower].BaseStat = Enumerations.Stats.Wisdom;

            Version = Working_Version;

            //Commented out until I replace CSScript with a Lua Engine

            //SecondaryStats = new SecondaryCharacterStats() { ParentName = CharacterFileName, };
            //SecondaryStats.Add(
            //    "speed",
            //    new SecondaryCharacterStatProperty()
            //    {
            //        ParentName = CharacterFileName,
            //        ScriptData = new Scripting.CharacterPropertyScript(Directories.Scripts, "SpeedPropertyDefault.cs")
            //    }
            //);

            constructing = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A list of Character File Names that are available for loading</returns>
        public static async Task<IEnumerable<string>> CharacterFiles()
            => await Task.Run
            (
                () =>
                {
                    List<string> files = new();
                    var toremove = FileNameStandard.Replace("{0}", "");
                    foreach (string file in Directory.GetFiles(Directories.Characters))
                        if(file.Contains(toremove) && file.Contains(Serialization.JsonExtension))
                            files.Add(file.Split(Path.DirectorySeparatorChar)[^1].Replace(toremove, "").Replace(Serialization.JsonExtension, ""));
                    return files;
                }
            );

        public async Task SerializeAsync() => await Serialization.Serialize.JsonAsync(this, Directories.Characters, string.Format(FileNameStandard, CharacterFileName));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characterFileName"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCharacterException"></exception>
        public async static Task<Character> DeserializeAndReplaceAsync(Character chara)
        {
            DnDManager.Characters.Unregister(chara);
            return await DeserializeAndRegisterAsync(chara.CharacterFileName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="characterFileName"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCharacterException"></exception>
        public static async Task<Character> DeserializeAndRegisterAsync(string characterFileName)
        {
            //Before deserialization the object is initialized to its default state, the default state of 'constructing' is true
            Character chara;
            try
            {
                chara = await Serialization.Deserialize<Character>.JsonAsync(Directories.Characters, string.Format(FileNameStandard, characterFileName));
            }
            catch (JsonException e)
            {
                throw new InvalidCharacterException($"The file for {characterFileName} is invalid", e);
            }

            DnDManager.Characters.Register(chara);
            chara.constructing = false;
            return chara;
        }

        private T ConstructingSetTest<T>(T value, [CallerMemberName] string propertyName = "")
        {
            if (constructing)
                return value;
            throw new InvalidOperationException($"Cannot set property {propertyName} because the character is no longer being constructed");
        }
    }
}
