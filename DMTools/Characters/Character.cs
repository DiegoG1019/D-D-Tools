using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.Items;
using DiegoG.Utilities.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Version = DiegoG.Utilities.Version;
using static DiegoG.DnDTDesktop.Enumerations;
using DiegoG.DnDTDesktop.Other;

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
        public static Version Working_Version { get; } = new Version($"{Program.AuthorSignature}{Program.ShortAppName}", 1, 1, 0, 0);
        /// <summary>
        /// Represents the character's version, as defined by the program 
        /// </summary>
        public Version Version { get; set; }

        /// <summary>
        /// Represents the Version of the Program that serialized the object
        /// </summary>
        public Version Program_Version => Program.Version;

        private bool constructing = true;
        private string _CFN;
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
        public CharacterStat<Stats, CharacterStatProperty> Stats { get; set; }
        public CharacterStat<SavingThrowsInitiative, CharacterSavingThrowProperty> SavingThrowsInitiative { get; set; }
        public SecondaryCharacterStats SecondaryStats { get; set; }
        public Experience Experience { get; set; }
        public ArmorClass ArmorClass { get; set; }
        public Description Description { get; set; }
        public Health Health { get; set; }
        public JobList Jobs { get; set; }
        public List<Ability> Abilities { get; set; } = new List<Ability>();
        public List<Ability> Feats { get; set; } = new List<Ability>();
        public SkillList Skills { get; set; } = new SkillList();
        public List<Inventory> Bags { get; set; } = new List<Inventory>();
        public Inventory Equipped { get; set; } = new Inventory();

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
            SavingThrowsInitiative = new CharacterStat<SavingThrowsInitiative, CharacterSavingThrowProperty>(CharacterFileName);

            SavingThrowsInitiative[Enumerations.SavingThrowsInitiative.Fortitude].BaseStat = Enumerations.Stats.Constitution;
            SavingThrowsInitiative[Enumerations.SavingThrowsInitiative.Reflexes].BaseStat = Enumerations.Stats.Dexterity;
            SavingThrowsInitiative[Enumerations.SavingThrowsInitiative.Willpower].BaseStat = Enumerations.Stats.Wisdom;
            SavingThrowsInitiative[Enumerations.SavingThrowsInitiative.Initiative].BaseStat = Enumerations.Stats.Dexterity;

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
            //Before serialization the object is initialized to its default state, the default state of 'constructing' is false
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
