using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using DiegoG.Utilities.IO;
using DiegoG.Utilities.Measures;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Items
{
    public interface IItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PriceTag Value { get; }
        public NoteList Notes { get; set; }
    }
    [Serializable]
    public class Item : IItem, INoted, INotifyPropertyChanged
    {
        private int quant = 0;
        private int qc = 0;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool EnableQuantityCap { get => EnableQuantityCapField; set { EnableQuantityCapField = value; NotifyPropertyChanged(); } }
        private bool EnableQuantityCapField;
        public string Name { get => NameField; set { NameField = value; NotifyPropertyChanged(); } }
        private string NameField;
        public string Description { get => DescriptionField; set { DescriptionField = value; NotifyPropertyChanged(); } }
        private string DescriptionField;
        public PriceTag Value { get => ValueField; set { ValueField = value; NotifyPropertyChanged(); } }
        private PriceTag ValueField = default;
        public NoteList Notes { get => NotesField; set { NotesField = value; NotifyPropertyChanged(); } }
        private NoteList NotesField = new NoteList();
        public Length ThrownRangeIncrement { get => ThrownRangeIncrementField; set { ThrownRangeIncrementField = value; NotifyPropertyChanged(); } }
        private Length ThrownRangeIncrementField = new Length(1, Length.Units.Meter);
        public ItemEncumbrance Encumbrance { get => EncumbranceField; set { EncumbranceField = value; NotifyPropertyChanged(); } }
        private ItemEncumbrance EncumbranceField = ItemEncumbrance.Light;
        public virtual Mass Weight { get => WeightField; set { WeightField = value; NotifyPropertyChanged(); } }
        private Mass WeightField = new Mass(0, Mass.Units.Kilogram);
        public int QuantityCap
        {
            get => qc;
            set
            {
                if (value == 0)
                {
                    EnableQuantityCap = false;
                    qc = 0;
                    return;
                }
                qc = value;
            }
        }
        public int Quantity
        {
            get => quant;
            set
            {
                if (EnableQuantityCap && value >= QuantityCap)
                    throw new InvalidOperationException($"Attempted to stack items beyond the cap. Item: {Name}, Value: {value}, Cap: {QuantityCap}");
                quant = value;
                NotifyPropertyChanged();
            }
        }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public Mass StackWeight => new Mass(Weight.Kilogram * Quantity, Mass.Units.Kilogram);
        public virtual void LockQuantity()
        {
            EnableQuantityCap = true;
            QuantityCap = 1;
            Quantity = Quantity;
        }
        public virtual void LockQuantity(int q)
        {
            EnableQuantityCap = true;
            QuantityCap = q;
            Quantity = Quantity;
        }

        public virtual void UnlockQuantity()
        {
            EnableQuantityCap = false;
            QuantityCap = 0;
        }

        public Item() { }
        public Item(NameDesc nameDesc)
        {
            Name = nameDesc.Name;
            Description = nameDesc.Description;
            Notes = nameDesc.Notes;
        }

        public virtual Item Copy() => (Item)Serialization.CopyByBinarySerialization(this);
    }

}
