using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.Items;
using DiegoG.Utilities.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Version = DiegoG.Utilities.Version;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public class Character
    {
#warning Remember to update this
        /// <summary>
        /// Represents the Character Version that the program expects
        /// </summary>
        public static Version WorkingVersion { get; } = new Version($"{Program.AuthorSignature}{Program.ShortAppName}", 0, 0, 1, 0);
        /// <summary>
        /// Represents the character's version, as defined by the 
        /// </summary>
        public Version Version { get; set; }
        private bool constructing = true;
        private string _CFN;
        /// <summary>
        /// You usually should refrain from setting this.
        /// </summary>
        public string CharacterFileName
        {
            get => _CFN;
            set
            {
                if(!constructing)
                    Program.Characters.ChangeCharacterRegistrationKey(_CFN, value);
                _CFN = value;
            }
        }
        public CharacterStat<Stats, CharacterStatProperty> Stats { get; set; } = new CharacterStat<Stats, CharacterStatProperty>();
        public CharacterStat<SavingThrows, CharacterSavingThrowProperty> SavingThrows { get; set; }
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
            SavingThrows = new CharacterStat<SavingThrows, CharacterSavingThrowProperty>() { ParentName = CharacterFileName };
            Version = WorkingVersion;
            constructing = false;
        }

        public async Task SerializeAsync() => await Serialization.Serialize.JsonAsync(this, Program.Directories.Characters, CharacterFileName);
        public static Character Deserialize(string characterFileName)
        {
            var chara = Serialization.Deserialize<Character>.Json(Program.Directories.Characters, characterFileName);
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
