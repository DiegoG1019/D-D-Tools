using System;
using System.Collections.Generic;

namespace DiegoG.DnDTDesktop.Items
{
    public class Key : Item
    {
        public List<char> Pins { get; set; } = new List<char>();
        public string Code
        {
            get => String.Join("", Pins);
            set => Pins = new List<char>(value.ToCharArray());
        }
        public bool Compare(Key other) => Code == other.Code;
    }
}