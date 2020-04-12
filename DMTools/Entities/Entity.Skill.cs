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
		public sealed class Skill : IFlagged<Skill.FlagList>
		{

			public enum FlagList
			{
				trainedOnly, penalizedByArmor, JobSkill
			};

			public string Name { get; set; }
			public Stats KeyStat { get; set; }
			public uint Level { get; set; }
			public uint MiscLevels { get; set; }

			[IgnoreDataMember]
			public Entity parent;

			public Skill(Skill other) :
				this(null, other.Name, other.KeyStat, other.MiscLevels, other.Level, other.Flags)
			{ }
			public Skill() :
				this(Entity._NULL)
			{ }
			public Skill(Entity p) :
				this(p, String.Empty)
			{ }
			public Skill(Entity p, string name) :
				this(p, name, Stats.charisma)
			{ }
			public Skill(Entity p, string name, Stats keyStat) :
				this(p, name, keyStat, 0)
			{ }
			public Skill(Entity p, string name, Stats keyStat, uint miscLevels) :
				this(p, name, keyStat, miscLevels, 0)
			{ }
			public Skill(Entity p, string name, Stats keyStat, uint miscLevels, uint level) :
				this(p, name, keyStat, miscLevels, 0, new FlagsArray<FlagList>())
			{ }
			public Skill(Entity p, string name, Stats keyStat, uint miscLevels, uint level, FlagsArray<FlagList> flg)
			{
				this.parent = p;
				this.Name = name;
				this.KeyStat = keyStat;
				this.MiscLevels = miscLevels;
				this.Level = level;
				Flags = flg;
			}

			public FlagsArray<FlagList> Flags { get; set; }

			public void Train(uint l)
			{
				this.Level += l;
			}
			public long Mod
			{
				get
				{
					int val = (int)(this.parent.GetMod(this.KeyStat) + this.MiscLevels);
					if (Flags[FlagList.JobSkill])
					{
						return val + this.Level;
					}
					else
					{
						return val + (this.Level / 2);
					}
				}
			}

		}

	}
}
