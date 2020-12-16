using System;
using System.Collections.Generic;
using System.Text;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Items.Info
{
    public class Effect
    {
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public int[] Bonus { get; set; } = new int[StatCount];
        public int this[Stats index]
        {
            get => Bonus[(int)index];
            set => Bonus[(int)index] = value;
        }
    }
}
