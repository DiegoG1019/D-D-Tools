using System;
using System.Collections.Generic;

namespace DnDTDesktop
{
    public partial class Item
    {
		public class Potion : Item
		{
			public class Effect
			{
				public string Description { get; set; }
				public int Duration { get; set; }  //Seconds
				public int[] Bonus { get; set; }
				public int this[Stats index]
				{
					get
					{
						return Bonus[(int)index];
					}
					set
					{
						Bonus[(int)index] = value;
					}
				}

				public Effect(Effect other) :
					this(other.Description, other.Duration, other.Bonus)
				{ }
				public Effect() :
					this(String.Empty)
				{ }
				public Effect(string d) :
					this(d, 0)
				{ }
				public Effect(string d, int dur) :
					this(d, dur, new int[App.StatCount])
				{ }
				public Effect(string d, int dur, int[] b)
				{
					Bonus = b;
					Description = d;
					Duration = dur;
				}
			}

			public List<Effect> Effects { get; set; }
			public Percentage Fill { get; set; }
			public Percentage Solvent { get; set; }

			public Potion(Potion other) :
				this(new List<Effect>(other.Effects), other.Fill, other.Solvent, other)
			{ }
			public Potion() :
				this(new List<Effect>())
			{ }
			public Potion(List<Effect> Fx) :
				this(Fx, 100f)
			{ }
			public Potion(List<Effect> Fx, float fill) :
				this(Fx, fill, 0f)
			{ }
			public Potion(List<Effect> Fx, float fill, float solvent) :
				this(Fx, fill, solvent, new Item("", "", new Mass(1M, Mass.Units.Pound)))
			{ }
			public Potion(List<Effect> Fx, float fill, float solvent, ulong v) :
				this(Fx, fill, solvent, new Item("", "", new Mass(1M, Mass.Units.Pound), v))
			{ }
			public Potion(List<Effect> Fx, float fill, float solvent, Item obj) :
				this(Fx, new Percentage(fill), new Percentage(solvent), obj)
			{ }
			public Potion(List<Effect> Fx, Percentage fill, Percentage solvent, Item obj) : base(obj)
			{
				LockQuantity();
				Effects = Fx;
				Fill = fill;
				Solvent = solvent;
			}

			private int[] AdjustBonus(Percentage OtherFill, int[] OtherBonus)
			{
				for (int i = 0; i < OtherBonus.Length; i++)
				{
					OtherBonus[i] = (int)(OtherBonus[i] * OtherFill.Percent);
				}
				return OtherBonus;
			}

			private int AdjustDuration(Percentage OtherFill, int Duration)
			{
				return (int)(Duration * OtherFill.Percent);
			}

			private ulong AdjustValue(Percentage OtherFill, ulong value)
			{
				return (ulong)(value * OtherFill.Percent);
			}

			public Potion Separate(Percentage OtherFill)
			{

				if (OtherFill.Value > Fill.Value)
				{
					throw new InvalidOperationException("Cannot separate a potion by taking more than what it currently holds");
				}
				else
				{
					if (OtherFill.Value == Fill.Value)
					{
						throw new InvalidOperationException("Cannot separate a potion by taking the same amount that it currently holds. (Just take the potion itself.)");
					}
				}

				Fill = new Percentage(Fill.Value - OtherFill.Value);

				List<Effect> fx = new List<Effect>();
				List<Effect> tfx = new List<Effect>();
				foreach (Effect e in this.Effects)
				{
					fx.Add(new Effect(e.Description, AdjustDuration(OtherFill, e.Duration), AdjustBonus(OtherFill, e.Bonus)));
					tfx.Add(new Effect(e.Description, AdjustDuration(Fill, e.Duration), AdjustBonus(Fill, e.Bonus)));
				}

				Effects = tfx;
				Value = new PriceTag(AdjustValue(Fill, Value.basevalue.v));

				return new Potion(fx, OtherFill.Value, AdjustValue(OtherFill, Value.basevalue.v));

			}

			public void Dilute(Percentage newfill)
			{
				Solvent = new Percentage(Solvent.Value + newfill.Value);
				Value = new PriceTag((ulong)(Value.basevalue.v * (Fill.Percent - Solvent.Percent)));
				Fill = new Percentage(Fill.Value + newfill.Value);
			}

		}
	}
}
