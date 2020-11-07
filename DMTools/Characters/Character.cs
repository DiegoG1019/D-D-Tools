using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.Items;
using DiegoG.Utilities.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Version = DiegoG.Utilities.Version;
using static DiegoG.DnDTDesktop.Enumerations;
using DiegoG.DnDTDesktop.Other;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public class Character
    {
        /// <summary>
        /// Represents the Character Version that the program expects
        /// A.B.C.D
        /// A - Completely incompatible with previous versions
        /// B - Previous versions will need to be imported
        /// C - Small changes in names and other minor things
        /// D - Small changes in character construction
        /// </summary>
#warning Remember to update this
        public static Version Working_Version { get; } = new Version($"{Program.AuthorSignature}{Program.ShortAppName}", 1, 0, 0, 0);
        /// <summary>
        /// Represents the character's version, as defined by the program 
        /// </summary>
        [JsonPropertyName("Character Version"), XmlElement(ElementName = "Character Version", IsNullable = false, Order = 1)]
        public Version Version { get; set; }

        /// <summary>
        /// Represents the Version of the Program that serialized the object
        /// </summary>
        [JsonPropertyName("Generator Version"), XmlElement(ElementName = "Generator Version", IsNullable = false, Order = 2)]
        public Version Program_Version => Program.Version;

        private bool constructing = true;
        private string _CFN;
        [JsonPropertyName("Character File Name"), XmlElement(ElementName = "Character File Name", IsNullable = false, Order = 3)]
        public string CharacterFileName
        {
            get => _CFN;
            set
            {
                if (!constructing)
                    Program.Characters.ChangeCharacterRegistrationKey(_CFN, value);
                _CFN = value;
            }
        }
        [JsonPropertyName("Character Stats"), XmlElement(ElementName = "Character Stats", IsNullable = false)]
        public CharacterStat<Stats, CharacterStatProperty> Stats { get; set; }

        [JsonPropertyName("Character Saving Throws"), XmlElement(ElementName = "Character Saving Throws", IsNullable = false)]
        public CharacterStat<SavingThrow, CharacterSavingThrowProperty> SavingThrows { get; set; }

        [JsonPropertyName("Other Character Stats"), XmlElement(ElementName = "Other Character Stats", IsNullable = false)]
        public SecondaryCharacterStats SecondaryStats { get; set; }

        [JsonPropertyName("Character Experience"), XmlElement(ElementName = "Character Experience", IsNullable = false)]
        public Experience Experience { get; set; }

        [JsonPropertyName("Character Armor Class"), XmlElement(ElementName = "Character Armor Class", IsNullable = false)]
        public ArmorClass ArmorClass { get; set; }

        [JsonPropertyName("Character Description"), XmlElement(ElementName = "Character Description", IsNullable = false)]
        public Description Description { get; set; }

        [JsonPropertyName("Character Health"), XmlElement(ElementName = "Character Health", IsNullable = false)]
        public Health Health { get; set; }

        [JsonPropertyName("Character Classes"), XmlElement(ElementName = "Character Classes", IsNullable = false)]
        public JobList Jobs { get; set; }

        [JsonPropertyName("Character Abilities"), XmlElement(ElementName = "Character Abilities", IsNullable = false)]
        public List<Ability> Abilities { get; set; } = new List<Ability>();

        [JsonPropertyName("Character Feats"), XmlElement(ElementName = "Character Feats", IsNullable = false)]
        public List<Ability> Feats { get; set; } = new List<Ability>();

        [JsonPropertyName("Character Skills"), XmlElement(ElementName = "Character Skills", IsNullable = false)]
        public SkillList Skills { get; set; } = new SkillList();

        [JsonPropertyName("Character Bags"), XmlElement(ElementName = "Character Bags", IsNullable = false)]
        public List<Inventory> Bags { get; set; } = new List<Inventory>();

        [JsonPropertyName("Character Equipped Items"), XmlElement(ElementName = "Character Equipped Items", IsNullable = false)]
        public Inventory Equipped { get; set; } = new Inventory();

        [JsonPropertyName("Character Initiative"), XmlElement(ElementName = "Character Initiative", IsNullable = false)]
        public CharacterSavingThrowProperty Initiative { get; set; } = new CharacterSavingThrowProperty() { BaseStat = Enumerations.Stats.Dexterity };

        /// <summary>
        /// Don't use this one, this is for serialization, and WILL result in bugs if not initialized properly. (The serializer is supposed to take care of that)
        /// </summary>
        public Character() { }
        public Character(string characterFileName)
        {
            CharacterFileName = characterFileName;

            Experience = new Experience() { ParentName = CharacterFileName };
            ArmorClass = new ArmorClass() { ParentName = CharacterFileName };
            Description = new Description() { ParentName = CharacterFileName };
            Health = new Health() { ParentName = CharacterFileName };
            Jobs = new JobList() { ParentName = CharacterFileName };
            Stats = new CharacterStat<Stats, CharacterStatProperty>(CharacterFileName);
            SavingThrows = new CharacterStat<SavingThrow, CharacterSavingThrowProperty>(CharacterFileName);

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
                    ScriptData = new Scripting.CharacterPropertyScript(Program.Directories.Scripts, "SpeedProperty.cs")
                }
            );

            constructing = false;
            Program.Characters.Register(this);
        }

        public async Task SerializeAsync() => await Serialization.Serialize.JsonAsync(this, Program.Directories.Characters, CharacterFileName);
        public async static Task<Character> DeserializeAndReplaceAsync(Character chara)
        {
            Program.Characters.Unregister(chara);
            //Before serialization the object is initialized to its default state, the default state of 'constructing' is true
            chara = await Serialization.Deserialize<Character>.JsonAsync(Program.Directories.Characters, chara.CharacterFileName);
            Program.Characters.Register(chara);
            chara.constructing = false;
            return chara;
        }   
        public static async Task<Character> DeserializeAndRegisterAsync(string characterFileName)
        {
            var chara = await Serialization.Deserialize<Character>.JsonAsync(Program.Directories.Characters, characterFileName);
            Program.Characters.Register(chara);
            chara.constructing = false;
            return chara;
        }
    }
}
