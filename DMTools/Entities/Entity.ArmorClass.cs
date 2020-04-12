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
		public sealed class ArmorClass : IFlagged<ArmorClass.FlagList>
		{

			public enum FlagList
			{
				featDex
			}

			public int Baseac { get; set; } //base armor class
			public int Armor { get; set; }
			public int Size { get; set; }
			public int Natural { get; set; }
			public int Deflex { get; set; }
			public int Temporary { get; set; }
			public int Misc { get; set; }
			public FlagsArray<Entity.ArmorClass.FlagList> Flags { get; set; }

			[IgnoreDataMember]
			public Entity parent;

			public ArmorClass(ArmorClass Other) :
				this(Other.Armor, Other.Size, Other.Natural, Other.Deflex, Other.Temporary, Other.Misc, Other.Baseac, new FlagsArray<FlagList>(Other.Flags))
			{ }
			///-----------    armor,  size, natural, deflex, temporary,     misc, baseac
			public ArmorClass(int a, int s, int n, int d, int temp, int misc, int b, FlagsArray<FlagList> fl)
			{
				Armor = a;
				Size = s;
				Natural = n;
				Deflex = d;
				Temporary = temp;
				Misc = misc;
				Baseac = b;
				Flags = fl;
			}
			public ArmorClass(Entity parent, int a, int s, int n, int d, int temp, int misc, int b) : this(a, s, n, d, temp, misc, b, new FlagsArray<FlagList>())
			{
				this.parent = parent;
			}
			public ArmorClass()
			{
				Flags = new FlagsArray<Entity.ArmorClass.FlagList>();
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public uint AC
			{
				get
				{
					int a = (this.Baseac + this.Armor + this.Size + this.Natural + this.Deflex + this.Temporary + this.Misc + this.parent.GetMod(Stats.dexterity));
					if (a > 0)
					{
						return (uint)a;
					}
					else
					{
						return 0u;
					}
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public uint TouchAC
			{
				get
				{
					int a = (this.Baseac + this.Size + this.Misc + this.Deflex + this.parent.GetMod(Stats.dexterity));
					if (a > 0)
					{
						return (uint)a;
					}
					else
					{
						return 0u;
					}
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public uint UnawareAC
			{
				get
				{
					int a = (this.Baseac + this.Armor + this.Size + this.Natural + this.Misc);
					if (Flags[FlagList.featDex])
					{
						a += parent.GetMod(Stats.dexterity);
					}
					if (a > 0)
					{
						return (uint)a;
					}
					else
					{
						return 0u;
					}
				}
			}

		}

	}
}
