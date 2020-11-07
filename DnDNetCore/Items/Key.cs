using System;
using System.Collections.Generic;

namespace DiegoG.DnDNetCore.Items
{
    public class Key : Item
    {
        public string Pins { get; set; }
        public bool Compare(Key other) => Pins == other.Pins;
    }
}