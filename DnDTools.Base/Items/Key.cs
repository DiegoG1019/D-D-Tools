﻿using DiegoG.DnDTools.Base.Other;
using System;
using System.Collections.Generic;

namespace DiegoG.DnDTools.Base.Items
{
    public class Key : Item
    {
        public string Pins { get; set; }
        public bool Compare(Key other) => Pins == other.Pins;
        public Key() { }
        public Key(NameDesc nameDesc) : base(nameDesc) { }
    }
}