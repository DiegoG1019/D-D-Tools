using DiegoG.DnDNetCore.Items.Weapons;
using DiegoG.DnDNetCore.Other;
using DiegoG.Utilities;
using DiegoG.Utilities.Collections;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DiegoG.DnDNetCore.Items
{
    public class Inventory
    {
        public event Action InventoryChanged;
        public class Bag<T> : List<T> where T : Item
        {
            public new void Add(T item)
            {
                if (Contains(item))
                {
                    int i = IndexOf(item);
                    if (!this[i].Flags[Item.FlagList.QuantityCap])
                    {
                        this[i].Quantity += item.Quantity;
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
                        RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }
            protected bool Baseremove(T item) => base.Remove(item);
            public Bag() : base() { }
            public Bag(Bag<T> other) : base(other) { }
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

        private class AllItemLists : IEnumerable<Item>
        {
            public List<IList> Bags { get; set; }
            public IEnumerator<Item> GetEnumerator()
            {
                foreach (var l in Bags)
                    foreach (var i in l)
                        yield return (Item)i;
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public enum WeaponIndex { Melee, Ranged, Ammo }

        public Bag<Armor> Armors { get; set; } = new Bag<Armor>();
        public Bag<Item> Other { get; set; } = new Bag<Item>();
        public Bag<Key> Keychain { get; set; } = new Bag<Key>();
        public Bag<Melee> MeleeWeapons { get; set; } = new Bag<Melee>();
        public Bag<Ranged> RangedWeapons { get; set; } = new Bag<Ranged>();
        public Bag<Ammo> Ammunitions { get; set; } = new Bag<Ammo>();
        public Slot<Potion> Potions { get; set; } = new Slot<Potion>();
        public Wallet Wallet { get; set; } = new Wallet();

        private AllItemLists AllItemsList { get; set; } = new AllItemLists();
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public IEnumerable<Item> AllItems => AllItemsList;

        public Mass Weight { get; set; } = new Mass(0, Mass.Units.Kilogram);
        public Mass MaximumWeight { get; set; } = new Mass(20, Mass.Units.Kilogram);

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public bool IsOverFilled => Weight > MaximumWeight;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public Mass Overfill => IsOverFilled ? new Mass(0, Mass.Units.Kilogram) : Weight - MaximumWeight;

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public Mass FullWeight { get; private set; }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public PriceTag FullValue { get; private set; }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int ArmorAC => Armors.Count > 0 ? (from item in Armors select item.Protection).Sum() : 0;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int ArmorPenalty => Armors.Count > 0 ? (from item in Armors select item.Penalty).Max() : 0;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int ArmorSpeedPenalty => Armors.Count > 0 ? (from item in Armors select item.SpeedPenalty).Max() : 0;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int ArmorMaximumDexterity => Armors.Count > 0 ? (from item in Armors select item.MaximumDeterity).Max() : 0;

        public Inventory()
        {
            AllItemsList.Bags = new List<IList>()
            { Armors, Other, Keychain, MeleeWeapons, RangedWeapons, Ammunitions, Potions };
            InventoryChanged += Inventory_InventoryChanged;
            InventoryChanged();
        }

        private async void Inventory_InventoryChanged()
        {
            try
            {
                var taskMan = new AsyncTaskManager<(decimal weight, int value)>();
                taskMan.Run(() => {
                    var v = Armors.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.Run(() => {
                    var v = Other.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.Run(() => {
                    var v = Keychain.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.Run(() => {
                    var v = MeleeWeapons.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.Run(() => {
                    var v = RangedWeapons.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.Run(() => {
                    var v = Ammunitions.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.Run(() => {
                    var v = Potions.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                await taskMan.WhenAll;
                FullWeight = new Mass(taskMan.AllResults.Sum(i => i.weight), Mass.Units.Kilogram);
                FullValue = new PriceTag(taskMan.AllResults.Sum(i => i.value));
            }
            catch (Exception e)
            {
                Log.Error($"{e}");
            }
        }
    }
}