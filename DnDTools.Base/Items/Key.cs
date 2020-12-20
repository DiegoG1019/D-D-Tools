using DiegoG.DnDTools.Base.Other;

namespace DiegoG.DnDTools.Base.Items
{
    public class Key : Item
    {
        public string Pins { get => PinsField; set { PinsField = value; NotifyPropertyChanged(); } }
        private string PinsField;
        public bool Compare(Key other) => Pins == other.Pins;
        public Key() { }
        public Key(NameDesc nameDesc) : base(nameDesc) { }
    }
}