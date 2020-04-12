using System;
using System.Collections.Generic;

namespace DnDTDesktop
{
    public partial class Item
	{
		public class Key : Item
		{
			public List<char> Pins { get; set; }
			public string Code
			{
				get
				{
					return String.Join("", Pins);
				}
				set
				{
					Pins = new List<char>(value.ToCharArray());
				}
			}

			public Key(Key other) :
				this(other.Code, other)
			{ }
			public Key() :
				this(String.Empty)
			{ }
			public Key(string c) :
				this(c, new Item())
			{ }
			public Key(string c, Item obj) :
				base(obj)
			{
				Code = c;
			}

			public bool IsSame(Key other)
			{
				return (this.Code == other.Code);
			}

		}
	}
}
