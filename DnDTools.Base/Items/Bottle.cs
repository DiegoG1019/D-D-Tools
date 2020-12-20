using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using DiegoG.Utilities.Measures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DiegoG.DnDTools.Base.Items
{
    [Serializable]
    public class Bottle : Item, IEnumerable<(Liquid Liquid, Percentage Fill)>
    {
        public Volume BottleSize { get => BottleSizeField; set { BottleSizeField = value; NotifyPropertyChanged(); } }
        private Volume BottleSizeField = new(10, Volume.Units.Ounce);
        public Mass BottleWeight { get => BottleWeightField; set { BottleWeightField = value; NotifyPropertyChanged(); } }
        private Mass BottleWeightField = new(300, Mass.Units.Gram);
        public override Mass Weight => base.Weight;

        public (Liquid Liquid, Percentage Fill) this[int index]
        {
            get => (Liquids[index], Fills[index]);
            set => Replace(value.Liquid, value.Fill);
        }

        private readonly List<Liquid> Liquids = new();
        private readonly List<Percentage> Fills = new();

        public bool IsFull => DiegoGMath.TolerantCompare(Fill.Value, 100d, 1 / 1000d) == 0;
        public bool IsOverFilled => DiegoGMath.TolerantCompare(Fill.Value, 100d, 1 / 1000d) == 1;
        public Percentage Fill
        {
            get
            {
                if (RecalcFill)
                {
                    double a = 0;
                    foreach (var l in Fills)
                        a += l.Value;
                    FillCache = new(Fills.Sum(d => d.Value));
                    RecalcFill = false;
                }
                return FillCache;
            }
        }
        private Percentage FillCache;
        private bool RecalcFill = true;

        public int Count => Liquids.Count;

        private void Liquids_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            => NotifyPropertyChanged(nameof(Liquids));

        public void Add(Liquid item, Percentage fill)
        {
            if (Contains(item))
                Fills[Liquids.IndexOf(item)] += fill;
            Liquids.Add(item);
            Fills.Add(fill);
            NotifyPropertyChanged(nameof(Fill));
        }

        public void Clear()
        {
            Liquids.Clear();
            Fills.Clear();
            NotifyPropertyChanged(nameof(Fill));
        }

        public bool Contains(Liquid item)
            => Liquids.Contains(item);

        public bool Remove(Liquid item)
        {
            if (!Contains(item))
                return false;

            var ind = Liquids.IndexOf(item);
            Liquids.RemoveAt(ind);
            Fills.RemoveAt(ind);
            NotifyPropertyChanged(nameof(Fill));
            return true;
        }

        /// <summary>
        /// If true, it replaced an existing item. If false, it simply added it
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fill"></param>
        /// <returns></returns>
        public bool Replace(Liquid item, Percentage fill)
        {
            if (Contains(item))
            {
                Fills[IndexOf(item)] = fill;
                NotifyPropertyChanged(nameof(Fill));
                return true;
            }
            Add(item, fill);
            return false;
        }
        /// <summary>
        /// If true, it replaced an existing item. If false, it simply added it
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fill"></param>
        /// <returns></returns>
        public bool Replace(int itemIndex, Percentage fill)
            => Replace(Liquids[itemIndex], fill);

        public int IndexOf(Liquid item) => Liquids.IndexOf(item);

        public IEnumerator<(Liquid, Percentage)> GetEnumerator()
        {
            for (int i = 0; i < Liquids.Count; i++)
                yield return (Liquids[i], Fills[i]);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Bottle() : base() { PropertyChanged += Bottle_PropertyChanged; }
        public Bottle(NameDesc nameDesc) : base(nameDesc) { }
        private void Bottle_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            => RecalcFill = true;
    }
}
