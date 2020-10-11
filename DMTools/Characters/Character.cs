using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public class Character
    {
        public string CharacterFileName { get; set; }
        public CharacterStat<Stats> Stats { get; set; } = new CharacterStat<Stats>(StatCount);
        public CharacterStat<SavingThrows> SavingThrows { get; set; } = new CharacterStat<SavingThrows>(SavingThrowCount);
        public Experience Experience { get; set; }
        public ArmorClass ArmorClass { get; set; }
        public Description Description { get; set; }
        public Health Health { get; set; }
        public JobList Jobs { get; set; }
        public List<Ability> Abilities { get; set; } = new List<Ability>();
        public List<Ability> Feats { get; set; } = new List<Ability>();
        public List<Skill> Skills { get; set; } = new List<Skill>();

        /// <summary>
        /// Don't use this one
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
        }

        public async Task SerializeAsync() => await Serialization.Serialize.JsonAsync(this, Program.Directories.Characters, CharacterFileName);
        public static Character Deserialize(string characterFileName) => Serialization.Deserialize<Character>.Json(Program.Directories.Characters, characterFileName);
        public static async Task<Character> DeserializeAndRegisterAsync(string characterFileName)
        {
            var chara = await Serialization.Deserialize<Character>.JsonAsync(Program.Directories.Characters, characterFileName);
            Program.Characters.Register(chara);
            return chara;
        }
    }
}
