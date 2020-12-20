using DiegoG.DnDTools.Base.Items.Weapons;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using DiegoG.Utilities.Measures;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTools.Base.Items
{
    public class Inventory : IItem
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public class Bag<T> : ICollection<T>, INotifyPropertyChanged where T : Item
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            private readonly List<T> ts = new();

            public int Count => ts.Count;

            [JsonIgnore, IgnoreDataMember, XmlIgnore]
            public bool IsReadOnly => false;

            /// <summary>
            /// Use of Set accesor is not recommended. It exists because I really don't want to build a ConverterFactory
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            [JsonIgnore, IgnoreDataMember, XmlIgnore]
            public T this[int index]
            {
                get => ts[index];
                set => Add(ts[index]);
            }
            [JsonIgnore, IgnoreDataMember, XmlIgnore]
            public int this[T item] => ts.IndexOf(item);

            public void Add(T item)
            {
                if (ts.Contains(item))
                {
                    int i = ts.IndexOf(item);
                    if (!this[i].EnableQuantityCap)
                    {
                        this[i].Quantity += item.Quantity;
                        return;
                    }
                }
                ts.Add(item);
                NotifyPropertyChanged();
            }
            public bool Remove(T item)
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
                        ts.RemoveAt(i);
                        NotifyPropertyChanged();
                        return true;
                    }
                }
                NotifyPropertyChanged();
                return false;
            }

            public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)ts).GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)ts).GetEnumerator();

            public void Clear() => ts.Clear();

            public bool Contains(T item) => ts.Contains(item);
            public void CopyTo(T[] array, int arrayIndex) => ts.CopyTo(array, arrayIndex);

            public Bag() { }
        }

        public class Slot<T> : Bag<T> where T : Item
        {
            public new void Add(T item)
            {
                item.LockQuantity();
                base.Add(item);
            }
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

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public enum WeaponIndex { Melee, Ranged, Ammo }

        public Bag<Armor> Armors
        {
            get => ArmorsField;
            set
            {
                ArmorsField.PropertyChanged -= ArmorsField_PropertyChanged;
                ArmorsField = value;
                ArmorsField.PropertyChanged += ArmorsField_PropertyChanged;
                NotifyPropertyChanged();
            }
        }
        private Bag<Armor> ArmorsField = new Bag<Armor>();
        public Bag<Item> Other
        {
            get => OtherField;
            set
            {
                OtherField.PropertyChanged -= OtherField_PropertyChanged;
                OtherField = value;
                OtherField.PropertyChanged += OtherField_PropertyChanged;
                NotifyPropertyChanged();
            }
        }
        private Bag<Item> OtherField = new Bag<Item>();
        public Bag<Key> Keychain
        {
            get => KeychainField;
            set
            {
                KeychainField.PropertyChanged -= KeychainField_PropertyChanged;
                KeychainField = value;
                KeychainField.PropertyChanged += KeychainField_PropertyChanged;
                NotifyPropertyChanged();
            }
        }
        private Bag<Key> KeychainField = new Bag<Key>();
        public Bag<Melee> MeleeWeapons
        {
            get => MeleeWeaponsField;
            set
            {
                MeleeWeaponsField.PropertyChanged -= MeleeWeaponsField_PropertyChanged;
                MeleeWeaponsField = value;
                MeleeWeaponsField.PropertyChanged += MeleeWeaponsField_PropertyChanged;
                NotifyPropertyChanged();
            }
        }
        private Bag<Melee> MeleeWeaponsField = new Bag<Melee>();
        public Bag<Ranged> RangedWeapons
        {
            get => RangedWeaponsField;
            set
            {
                RangedWeaponsField.PropertyChanged -= RangedWeaponsField_PropertyChanged;
                RangedWeaponsField = value;
                RangedWeaponsField.PropertyChanged += RangedWeaponsField_PropertyChanged;
                NotifyPropertyChanged();
            }
        }
        private Bag<Ranged> RangedWeaponsField = new Bag<Ranged>();
        public Bag<Ammo> Ammunitions
        {
            get => AmmunitionsField;
            set
            {
                AmmunitionsField.PropertyChanged -= AmmunitionsField_PropertyChanged;
                AmmunitionsField = value;
                AmmunitionsField.PropertyChanged += AmmunitionsField_PropertyChanged;
                NotifyPropertyChanged();
            }
        }
        private Bag<Ammo> AmmunitionsField = new Bag<Ammo>();
        public Slot<Bottle> Bottles
        {
            get => BottlesField;
            set
            {
                BottlesField.PropertyChanged -= BottlesField_PropertyChanged;
                BottlesField = value;
                BottlesField.PropertyChanged += BottlesField_PropertyChanged;
                NotifyPropertyChanged();
            }
        }
        private Slot<Bottle> BottlesField = new Slot<Bottle>();
        public Wallet Wallet
        {
            get => WalletField;
            set
            {
                WalletField.PropertyChanged -= WalletField_PropertyChanged;
                WalletField = value;
                WalletField.PropertyChanged += WalletField_PropertyChanged;
                NotifyPropertyChanged();
            }
        }
        private void ArmorsField_PropertyChanged(object sender, PropertyChangedEventArgs e)
            => NotifyPropertyChanged(nameof(Armors));
        private void OtherField_PropertyChanged(object sender, PropertyChangedEventArgs e)
            => NotifyPropertyChanged(nameof(Other));
        private void KeychainField_PropertyChanged(object sender, PropertyChangedEventArgs e)
            => NotifyPropertyChanged(nameof(Keychain));
        private void MeleeWeaponsField_PropertyChanged(object sender, PropertyChangedEventArgs e)
           => NotifyPropertyChanged(nameof(MeleeWeapons));
        private void RangedWeaponsField_PropertyChanged(object sender, PropertyChangedEventArgs e)
           => NotifyPropertyChanged(nameof(RangedWeapons));
        private void AmmunitionsField_PropertyChanged(object sender, PropertyChangedEventArgs e)
           => NotifyPropertyChanged(nameof(Ammunitions));
        private void BottlesField_PropertyChanged(object sender, PropertyChangedEventArgs e)
            => NotifyPropertyChanged(nameof(Bottles));
        private void WalletField_PropertyChanged(object sender, PropertyChangedEventArgs e)
            => NotifyPropertyChanged(nameof(Wallet));

        private Wallet WalletField = new Wallet();

        public Mass Weight { get => WeightField; set { WeightField = value; NotifyPropertyChanged(); } }
        private Mass WeightField = new Mass(0, Mass.Units.Kilogram);
        public Mass MaximumWeight { get => MaximumWeightField; set { MaximumWeightField = value; NotifyPropertyChanged(); } }
        private Mass MaximumWeightField = new Mass(20, Mass.Units.Kilogram);

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

        public string Name { get => NameField; set { NameField = value; NotifyPropertyChanged(); } }
        private string NameField;
        public string Description { get => DescriptionField; set { DescriptionField = value; NotifyPropertyChanged(); } }
        private string DescriptionField;
        public PriceTag Value { get => ValueField; set { ValueField = value; NotifyPropertyChanged(); } }
        private PriceTag ValueField;
        public NoteList Notes { get => NotesField; set { NotesField = value; NotifyPropertyChanged(); } }
        private NoteList NotesField = new();

        private void Inventory_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                var taskMan = new AsyncTaskManager<(decimal weight, int value)>();
                taskMan.Run(() =>
                {
                    var v = Armors.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.Run(() =>
                {
                    var v = Other.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.Run(() =>
                {
                    var v = Keychain.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.Run(() =>
                {
                    var v = MeleeWeapons.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.Run(() =>
                {
                    var v = RangedWeapons.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.Run(() =>
                {
                    var v = Ammunitions.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.Run(() =>
                {
                    var v = Bottles.Select(i => new { i.Weight.Kilogram, i.Value.NumericalValue });
                    return (v.Sum(i => i.Kilogram), v.Sum(i => i.NumericalValue));
                });
                taskMan.WaitAll();
                FullWeight = new Mass(taskMan.AllResults.Sum(i => i.weight), Mass.Units.Kilogram);
                FullValue = new PriceTag(taskMan.AllResults.Sum(i => i.value));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex}");
            }
        }

        public Inventory()
        {
            PropertyChanged += Inventory_PropertyChanged;
            WalletField.PropertyChanged += WalletField_PropertyChanged;
            BottlesField.PropertyChanged += BottlesField_PropertyChanged;
            AmmunitionsField.PropertyChanged += AmmunitionsField_PropertyChanged;
            RangedWeaponsField.PropertyChanged += RangedWeaponsField_PropertyChanged;
            MeleeWeaponsField.PropertyChanged += MeleeWeaponsField_PropertyChanged;
            KeychainField.PropertyChanged += KeychainField_PropertyChanged;
            OtherField.PropertyChanged += OtherField_PropertyChanged;
            ArmorsField.PropertyChanged += ArmorsField_PropertyChanged;
        }

        public Inventory(NameDesc nameDesc) : this()
        {
            Name = nameDesc.Name;
            Description = nameDesc.Description;
            Notes = nameDesc.Notes;
        }
    }
}