using System;
using System.Collections.Generic;

namespace DnDTDesktop
{
	public partial class Item : INoted, IFlagged<Item.FlagList>
	{

		public enum FlagList
		{
			QuantityLocked
		}

		private uint quant = 0;

		public string Name { get; set; }
		public string Description { get; set; }
		public PriceTag Value { get; set; }
		public Mass Weight { get; set; }
		public List<string> Notes { get; set; }
		public Length RangeIncrement { get; set; }
		public uint Quantity
		{
			get
			{
				return quant;
			}
			set
			{
				if (Flags[FlagList.QuantityLocked])
				{
					if (value.GetType() == true.GetType()) //If it's a boolean
					{
						quant = value;
						return;
					}
					quant = (value > 0U) ? 1U : 0U;
				}
				else
				{
					quant = value;
				}
			}
		}

		public string AllNotes
		{
			get
			{
				const string a = "-{0}\n";
				string c = "";
				foreach (string b in Notes)
				{
					c += String.Format(a, b);
				}
				if (c.Length > 0)
				{
					return c.Substring(0, c.Length - 1);
				}
				else
				{
					return c;
				}
			}
		}

		public Item(Item other) :
			this(other.Name, other.Description, other.Weight, other.Value, other.Quantity, other.Notes, other.RangeIncrement, other.Flags)
		{ }
		public Item() :
			this(String.Empty)
		{ }
		public Item(string name) :
			this(name, String.Empty)
		{ }
		public Item(string name, string description) :
			this(name, description, new Mass(1M, Mass.Units.Pound))
		{ }
		public Item(string name, string description, Mass weight) :
			this(name, description, weight, 1)
		{ }
		public Item(string name, string description, Mass weight, ulong value) :
			this(name, description, weight, value, 1)
		{ }
		public Item(string name, string description, Mass weight, ulong value, uint quantity) :
			this(name, description, weight, value, quantity, new List<string>())
		{ }
		public Item(string name, string description, Mass weight, ulong value, uint quantity, List<string> notes) :
			this(name, description, weight, value, quantity, notes, new Length(1M, Length.Units.Foot))
		{ }
		public Item(string name, string description, Mass weight, ulong value, uint quantity, List<string> notes, Length rangeincrement) :
			this(name, description, weight, value, quantity, notes, rangeincrement, new FlagsArray<FlagList>())
		{ }
		public Item(string name, string description, Mass weight, ulong value, uint quantity, List<string> notes, Length rangeincrement, FlagsArray<FlagList> flg) :
			this(name, description, weight, new PriceTag(value), quantity, notes, rangeincrement, flg)
		{ }
		public Item(string name, string description, Mass weight, PriceTag value, uint quantity, List<string> notes, Length rangeincrement, FlagsArray<FlagList> flg)
		 {
			Name = name;
			Description = description;
			Weight = weight;
			Value = value;
			Notes = notes;
			RangeIncrement = rangeincrement;
			Flags = flg;
			Quantity = quantity;
		 }

		public FlagsArray<FlagList> Flags { get; set; }

		public void LockQuantity()
		{
			Flags[FlagList.QuantityLocked] = true;
			Quantity = 1;
		}
		public void LockQuantity(uint q)
		{
			Flags[FlagList.QuantityLocked] = true;
			Quantity = q;
		}

		public void UnlockQuantity()
		{

		}

	}

}
