using DiegoG.DnDNetCore.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiegoG.DnDNetCore.Enumerations;

namespace DiegoG.DnDNetCore.Characters.Complements
{
    public class Spell : INoted
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CombatAction Action { get; set; }
        public MagicSchool School { get; set; }
        public int Level { get; set; }
        public NoteList Notes { get; set; }
        /// <summary>
        /// Not applicable to all classes and spells; for most scenarios 
        /// </summary>
        public bool IsPrepared { get; set; } = false;
    }
}
