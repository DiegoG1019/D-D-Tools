using DiegoG.Utilities.IO;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    [Serializable]
    public abstract class CharacterTrait<T> : INotifyPropertyChanged where T : class
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string ParentName { get => ParentNameField; set {ParentNameField = value;
                NotifyPropertyChanged();
            } }
        private string ParentNameField;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public Character Parent => DnDManager.Characters[ParentName];
        public virtual T Copy() => (T)Serialization.CopyByBinarySerialization(this);
    }
}
