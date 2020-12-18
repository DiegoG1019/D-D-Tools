using System;
using DiegoG.Utilities;
using DiegoG.DnDTools.Base.Other;
using System.Xml.Serialization;
using System.Collections.Generic;
using DiegoG.DnDTools.Base.Items.Info;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using DiegoG.Utilities.Measures;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Items
{
    public class Liquid : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public NoteList Notes { get; set; } = new();

        /// <summary>
        /// Value of current amount
        /// </summary>
        public PriceTag Value
        {
            get => new((int)(LiterValue.NumericalValue * Amount.Liter));
            set => LiterValue = new((int)(Amount.NotZero ? value.NumericalValue / Amount.Liter : throw new InvalidOperationException("Can't assign a current amount value to no amount")));
        }

        /// <summary>
        /// Value of 1Lt
        /// </summary>
        public PriceTag LiterValue { get; set; }
        public List<Effect> Effects { get; set; } = new List<Effect>();
        /// <summary>
        /// Defaults to 0, ignorable
        /// </summary>
        public Density Density { get; set; } = new(0);
        public Volume Amount { get; set; }
        public Liquid() { }
        public Liquid(NameDesc nameDesc) : this()
        {
            Name = nameDesc.Name;
            Description = nameDesc.Description;
            Notes = nameDesc.Notes;
        }
    }
}
