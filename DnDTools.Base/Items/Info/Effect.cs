using System;
using System.Collections.ObjectModel;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Items.Info
{
    public record Effect
    {
        public string Description { get; init; }
        public TimeSpan Duration { get; init; }
        public ReadOnlyCollection<int> Bonus { get; private set; }
        public int[] BonusSet
        {
            init => Bonus = new(value);
        }
        public int this[Stats index] => Bonus[(int)index];
    }
}
