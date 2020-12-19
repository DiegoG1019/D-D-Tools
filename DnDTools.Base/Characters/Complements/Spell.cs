using DiegoG.DnDTools.Base.Other;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    public class Spell : INoted, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string Name { get => NameField; set { NameField = value; NotifyPropertyChanged(); } }
        private string NameField;
        public string Description { get => DescriptionField; set { DescriptionField = value; NotifyPropertyChanged(); } }
        private string DescriptionField;
        public CombatAction Action { get => ActionField; set { ActionField = value; NotifyPropertyChanged(); } }
        private CombatAction ActionField;
        public MagicSchool School { get => SchoolField; set { SchoolField = value; NotifyPropertyChanged(); } }
        private MagicSchool SchoolField;
        public int Level { get => LevelField; set { LevelField = value; NotifyPropertyChanged(); } }
        private int LevelField;
        public NoteList Notes { get => NotesField; set { NotesField = value; NotifyPropertyChanged(); } }
        private NoteList NotesField;
        /// <summary>
        /// Not applicable to all classes and spells; for most scenarios 
        /// </summary>
        public bool IsPrepared { get => IsPreparedField; set { IsPreparedField = value; NotifyPropertyChanged(); } }
        private bool IsPreparedField;
    }
}
