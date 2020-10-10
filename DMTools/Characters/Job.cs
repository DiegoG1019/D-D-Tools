using DiegoG.DnDTDesktop.Other;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public sealed class Job : CharacterTrait<Job>, INoted
    {
        [Serializable]
        public struct JobGrowth
        {

            public List<List<byte>> BaseAttack { get; set; }
            public List<List<byte>> Saving { get; set; } //Throws
            public List<Ability> Abilities { get; set; }
            public List<List<byte>> DailySpells { get; set; }

        }
        public string Name { get; set; }
        public byte Level { get; set; }
        public List<string> Competence { get; set; } = new List<string>();
        public Dice HPDice { get; set; } = default;
        public int SkillPoints { get; set; }
        public JobGrowth Growth { get; set; } = default;
        public NoteList Notes { get; set; }
    }
}

