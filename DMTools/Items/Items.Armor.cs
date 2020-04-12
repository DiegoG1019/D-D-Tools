namespace DnDTDesktop
{
    public partial class Item
	{
		public class Armor : Item
		{
			public int Bonif { get; set; }
			public ushort MaximumDeterity { get; set; }
			public int Penalty { get; set; }
			public Percentage SpellFailure { get; set; } //Percentage
			public int SpeedPenalty { get; set; }

			public Armor(Armor other) :
				this(other.Bonif, other.MaximumDeterity, other.Penalty, other.SpellFailure, other.SpeedPenalty, other)
			{ }
			public Armor() :
				this(0)
			{ }
			public Armor(int bonif) :
				this(bonif, ushort.MaxValue)
			{ }
			public Armor(int bonif, ushort maxdex) :
				this(bonif, maxdex, 0)
			{ }
			public Armor(int bonif, ushort maxdex, int penalty) :
				this(bonif, maxdex, penalty, 0)
			{ }
			public Armor(int bonif, ushort maxdex, int penalty, float spellfail) :
				this(bonif, maxdex, penalty, spellfail, 0)
			{ }
			public Armor(int bonif, ushort maxdex, int penalty, float spellfail, int speedpenalty) :
				this(bonif, maxdex, penalty, spellfail, speedpenalty, new Item())
			{ }
			public Armor(int bonif, ushort maxdex, int penalty, float spellfail, int speedpenalty, Item obj) :
				this(bonif, maxdex, penalty, new Percentage(spellfail), speedpenalty, obj)
			{ }
			public Armor(int bonif, ushort maxdex, int penalty, Percentage spellfail, int speedpenalty, Item obj) :
				base(obj)
			{
				Bonif = bonif;
				MaximumDeterity = maxdex;
				Penalty = penalty;
				SpellFailure = spellfail;
				SpeedPenalty = speedpenalty;
			}
		}

	}
}
