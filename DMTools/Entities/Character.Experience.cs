using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Serilog;

namespace DnDTDesktop
{
	public partial class Character : Entity
	{
		public sealed class Experience : IHistoried<long>
		{
			public float Multiplier { get; set; }
			public long current;
			public long Required { get; set; }
			public List<long> History { get; set; }
			public long Current
			{
				get
				{
					return current;
				}
				set
				{
					if (this.parent != null)
					{
						this.Gain(Math.Abs(this.current - value));
					}
					else
					{
						Add(value);
						this.History.Add(value);
					}
				}
			}


			[IgnoreDataMember]
			public Character parent;

			public Experience(Experience other) :
				this(other.Multiplier, other.Current, other.Required, other.History)
			{ }
			public Experience(Character parent) :
				this()
			{
				this.parent = parent;
			}
			public Experience() :
				this(1F)
			{ }
			public Experience(float mult) :
				this(mult, 0)
			{ }
			public Experience(float mult, long current) :
				this(mult, current, 10)
			{ }
			public Experience(float mult, long current, long required) :
				this(mult, current, required, new List<long>())
			{ }
			public Experience(float mult, long current, long required, List<long> history)
			{
				Multiplier = mult;
				this.current = current;
				Required = required;
				History = history;
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

			[IgnoreDataMember]
			[JsonIgnore]
			public int Left
			{
				get
				{
					return (int)(this.Required - this.Current);
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public int Progress
			{
				get
				{
					return (int)(((float)(this.Current) / (float)(this.Required)) * 100f);
				}
			}

			public void Add(long v)
			{
				this.current += v;
			}

			public void Sub(long v)
			{
				if (v > this.current)
				{
					this.current = 0;
				}
				else
				{
					this.current -= v;
				}
			}

			///<summary><c>SetFreeLevel</c> This method picks between the four available free level choices to set the multiplier. The range is 0-3.
			[IgnoreDataMember]
			[JsonIgnore]
			public float FreeLevelmultiplier
			{
				get
				{
					switch (this.parent.FreeLevels)
					{
						case 0:
							return 1F;
						case 1:
							return 0.75F;
						case 2:
							return 0.5F;
						case 3:
							return 0.25F;
						default:
							throw new TooManyFreeLevels(String.Format("The entity \"{0}\" of ID \"{1}\" has too many free levels", this.parent.Desc.Name, this.parent.Id));
					}
				}
			}

			public void Gain(long v)
			{
				this.Add((int)(v * (Multiplier * FreeLevelmultiplier)));
				this.History.Add(v);
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public bool DidLevel
			{
				get
				{
					return this.Current >= this.Required;
				}
			}

			//More stuff happens when an entity levels up, but that requires the Job and Job.Growth classes
			public void LevelUp()
			{
				if (this.DidLevel)
				{
					this.Current -= this.Required;
					this.parent.Level++;
				}
				else
				{
					throw new CantLevelUpYet(String.Format("The entity \"{0}\" of ID \"{1}\" attempted to level up without a right to", this.parent.Desc.Name, parent.Id));
				}
			}

			public void SetRequired()
			{
				byte l = this.parent.Level;
				this.Required = (l + 1) * (l) * 500;
			}

		}
	}
}
