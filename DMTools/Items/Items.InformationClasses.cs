using System;

namespace DnDTDesktop
{
	public partial class Item
	{
		public class ItemDamage
		{
			private Dice[] die;
			public Dice this[Sizes ind]
			{
				get
				{
					return die[(int)ind];
				}
				set
				{
					die[(int)ind] = value;
				}
			}

			public ItemDamage(ItemDamage other) :
				this(other.die)
			{ }
			public ItemDamage()
			{
				die = new Dice[App.SizeCount];
				for (int i = 0; i < App.SizeCount; i++)
				{
					die[i] = new Dice();
				}
			}
			public ItemDamage(Dice[] die)
			{
				this.die = die;
			}
		}

		public struct ItemAttackThrow
		{
			public Stats KeyStat { get; set; }
			public Stats? SecondaryStat { get; set; }

			public ItemAttackThrow(Stats s) :
				this(s, null)
			{ }
			public ItemAttackThrow(Stats s1, Stats? s2) :
				this()
			{
				KeyStat = s1;
				SecondaryStat = s2;
			}
		}

		public class ItemCriticalHit
		{
			public byte Minimum { get; set; }
			public byte Maximum { get; set; }
			public float Multiplier { get; set; }
			public string Value
			{
				get
				{
					if (Maximum != Minimum)
					{
						return String.Format("{0}-{1}; x{2}", Minimum, Maximum, Multiplier);
					}
					return String.Format("{0}; x{1}", Minimum, Multiplier);
				}
			}

			public ItemCriticalHit(ItemCriticalHit other) :
				this(other.Minimum, other.Multiplier, other.Maximum)
			{ }
			public ItemCriticalHit() :
				this(20)
			{ }
			public ItemCriticalHit(byte Min) :
				this(Min, 1F)
			{ }
			public ItemCriticalHit(byte Min, float Mult) :
				this(Min, Mult, Min)
			{ }
			public ItemCriticalHit(byte Min, float Mult, byte Max)
			{
				Minimum = Min;
				Maximum = Max;
				Multiplier = Mult;
			}
		}

	}
}
