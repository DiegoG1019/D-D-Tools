using DiegoG.DnDTDesktop.Items.Weapons;
using DiegoG.DnDTDesktop.Other;
using DiegoG.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Items
{
    public class Inventory : Item
    {
        public event Action InventoryChanged;
        public class Bag<T> : List<T> where T : Item
        {
            public new void Add(T item)
            {
                if (Contains(item))
                {
                    int i = IndexOf(item);
                    if (!this[i].Flags[FlagList.QuantityCap])
                    {
                        this[IndexOf(item)].Quantity += item.Quantity;
                        return;
                    }
                }
                base.Add(item);
            }
            public new bool Remove(T item)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (this[i].Name == item.Name)
                    {
                        if (this[i].Quantity > item.Quantity)
                        {
                            this[i].Quantity -= item.Quantity;
                            return true;
                        }
                        else
                        {
                            RemoveAt(i);
                            return true;
                        }
                    }
                }
                return false;
            }
            protected bool Baseremove(T item)
            {
                return base.Remove(item);
            }

            public Bag() : base() { }
            public Bag(Bag<T> other) :
                base(other)
            { }
        }

        public class Slot<T> : Bag<T> where T : Item
        {
            public new void Add(T item)
            {
                item.LockQuantity();
                base.Add(item);
            }
            public new bool Remove(T item) => Baseremove(item);
        }

        public enum WeaponIndex
        {
            Melee, Ranged, Ammo
        }

        public new int Quantity => 1;

        public Bag<Armor> Armors { get; set; } = new Bag<Armor>();
        public Bag<Item> Other { get; set; } = new Bag<Item>();
        public Bag<Key> Keychain { get; set; } = new Bag<Key>();
        public Bag<Melee> MeleeWeapons { get; set; } = new Bag<Melee>();
        public Bag<Ranged> RangedWeapons { get; set; } = new Bag<Ranged>();
        public Bag<Ammo> Ammunitions { get; set; } = new Bag<Ammo>();
        public Slot<Potion> Potions { get; set; } = new Slot<Potion>();

        public Mass MaximumWeight { get; set; } = new Mass(20, Mass.Units.Kilogram);

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public bool IsOverFilled => Weight > MaximumWeight;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public Mass FullWeight { get; private set; }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public PriceTag FullValue { get; private set; }

        public Inventory()
        {
            InventoryChanged += Inventory_InventoryChanged;
            InventoryChanged();
        }

        private async void Inventory_InventoryChanged()
        {
            await Task.Run(delegate
            {
                decimal weight = 0;
                int value = 0;
                foreach (Item item in Armors)
                {
                    weight += item.Weight.Kilogram;
                    value += item.Value.NumericalValue;
                }
                foreach (Item item in Other)
                {
                    weight += item.Weight.Kilogram;
                    value += item.Value.NumericalValue;
                }
                foreach (Item item in Keychain)
                {
                    weight += item.Weight.Kilogram;
                    value += item.Value.NumericalValue;
                }
                foreach (Item item in MeleeWeapons)
                {
                    weight += item.Weight.Kilogram;
                    value += item.Value.NumericalValue;
                }
                foreach (Item item in RangedWeapons)
                {
                    weight += item.Weight.Kilogram;
                    value += item.Value.NumericalValue;
                }
                foreach (Item item in Ammunitions)
                {
                    weight += item.Weight.Kilogram;
                    value += item.Value.NumericalValue;
                }
                foreach (Item item in Potions)
                {
                    weight += item.Weight.Kilogram;
                    value += item.Value.NumericalValue;
                }
            });
        }
    }
}

