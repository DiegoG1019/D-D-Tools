using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Serilog;

namespace DnDTDesktop
{
	public partial class Entity
	{
		public sealed class Health
		{
			public sealed class Hurt : IHistoried<int>
			{
				private uint dmg;
				public uint Damage
				{
					get
					{
						return dmg;
					}
					set
					{
						if (this.dmg > value)
						{
							this.Harm((int)(this.dmg - value));
						}
						else
						{
							if (this.dmg < value) //I don't want it to be added to the History if they were the same
							{
								this.Heal((int)(value - this.dmg));
							}
						}
					}
				}

				public List<int> History { get; set; }

				public Hurt(Hurt other) :
					this(other.dmg, other.History)
				{ }
				public Hurt() :
					this(0)
				{ }
				public Hurt(uint dmg) :
					this(dmg, new List<int>())
				{ }
				public Hurt(uint dmg, List<int> Hst)
				{
					this.dmg = dmg;
					this.History = Hst;
				}


				[IgnoreDataMember]
				[JsonIgnore]
				public int HistoryEntries
				{
					get
					{
						return this.History.Count;
					}
				}

				public void Harm(int d)
				{
					if ((d < 0) && (Math.Abs(d) > this.Damage))
					{
						this.dmg = 0u;
					}
					else
					{
						this.dmg = (uint)(this.dmg + d);
					}
					this.History.Add(d);
				}

				public void Heal(int h)
				{
					if (h > this.Damage)
					{
						this.dmg = 0u;
					}
					else
					{
						this.dmg = (uint)(this.dmg - h);
					}
					this.History.Add(-h);
				}

			}

			private uint BaseHP { get; set; }

			public Hurt LethalDamage { get; set; }
			public Hurt NonlethalDamage { get; set; }

			public List<uint> HpThrows { get; set; } //This is a List, as opposed to a simple Array, because while usually levels cap out at 20, this is D&D we're talking about. I want the user to be able to expand it as necessary.
													 //This list will have to be displayed and handled with this in mind.

			[IgnoreDataMember]
			public Entity parent;

			public Health(Health Other) :
				this(Other.BaseHP, Other.LethalDamage, Other.NonlethalDamage, Other.HpThrows)
			{ }
			public Health(Entity p) :
				this()
			{
				parent = p;
			}
			public Health() :
				this(1)
			{ }
			public Health(uint bhp) :
				this(bhp, new Hurt(), new Hurt())
			{ }
			public Health(uint bhp, Hurt ld, Hurt nld) :
				this(bhp, ld, nld, new List<uint>(new uint[30]))
			{ }
			public Health(uint bhp, Hurt ld, Hurt nld, List<uint> hpt)
			{
				BaseHP = bhp;
				LethalDamage = ld;
				NonlethalDamage = nld;
				HpThrows = hpt;
			}

			public void SetBaseHP()
			{
				for (byte i = 0; i <= this.parent.Level; i++)
				{
					int n = (int)(this.HpThrows[i] + this.parent.GetMod(Stats.constitution));
					if (n > 1)
					{
						this.BaseHP = (uint)(this.BaseHP + n);
					}
					else
					{
						this.BaseHP++;
					}
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public int HP
			{
				get
				{
					return (int)(this.BaseHP - (this.LethalDamage.Damage + this.NonlethalDamage.Damage));
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public int NlHP
			{
				get
				{
					return (int)(this.BaseHP - this.LethalDamage.Damage);
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public bool Dead
			{
				get
				{
					return this.HP <= App.Cf.Options.EntityValues["dead"];
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public bool BleedingOut
			{
				get
				{
					return this.HP <= App.Cf.Options.EntityValues["bleedingOut"];
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public bool Down
			{
				get
				{
					return this.HP <= App.Cf.Options.EntityValues["down"];
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public string State
			{
				get
				{
					if (this.Dead)
					{
						return "Dead";
					}
					else
					{
						if (this.BleedingOut)
						{
							return "Bleeding out";
						}
						else
						{
							if (this.Down)
							{
								return "Down";
							}
						}
					}
					return "Fine";
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public string OmaeWaMou
			{
				get
				{
					if (this.Dead)
					{
						return "Shindeiru";
					}
					else
					{
						return "";
					}
				}
			}

		}

	}
}
