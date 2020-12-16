using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using DiegoG.Utilities.IO;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Items
{
    public interface IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PriceTag Value { get; }
        public NoteList Notes { get; set; }
    }
    [Serializable]
    public class Item : IItem, INoted, IFlagged<Item.FlagList>
    {
        private int quant = 0;
        private int qc = 0;
        
        public enum FlagList { QuantityCap }
        public string Name { get; set; }
        public string Description { get; set; }
        public PriceTag Value { get; set; } = default;
        public NoteList Notes { get; set; } = new NoteList();
        public Length ThrownRangeIncrement { get; set; } = new Length(1, Length.Units.Meter);
        public ItemEncumbrance Encumbrance { get; set; } = ItemEncumbrance.Light;
        public FlagsArray<FlagList> Flags { get; set; } = new FlagsArray<FlagList>();
        public virtual Mass Weight { get; set; } = new Mass(0, Mass.Units.Kilogram);
        public int QuantityCap
        {
            get => qc;
            set
            {
                if (value == 0)
                {
                    Flags[FlagList.QuantityCap] = false;
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
                if (Flags[FlagList.QuantityCap] && value >= QuantityCap)
                    throw new InvalidOperationException($"Attempted to stack items beyond the cap. Item: {Name}, Value: {value}, Cap: {QuantityCap}");
                quant = value;
            }
        }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public Mass StackWeight => new Mass(Weight.Kilogram * Quantity, Mass.Units.Kilogram);
        public virtual void LockQuantity()
        {
            Flags[FlagList.QuantityCap] = true;
            QuantityCap = 1;
            Quantity = Quantity;
        }
        public virtual void LockQuantity(int q)
        {
            Flags[FlagList.QuantityCap] = true;
            QuantityCap = q;
            Quantity = Quantity;
        }

        public virtual void UnlockQuantity()
        {
            Flags[FlagList.QuantityCap] = false;
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
