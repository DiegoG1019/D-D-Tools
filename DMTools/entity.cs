using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Serilog;

namespace DnDTDesktop
{

	public class Entity
	{
		public static readonly Entity _NULL = null;
		/*-------------------------Sub Class Declaration-------------------------*/
		public struct ExperienceGrant
		{

			public uint Baseexp { get; set; }
			public uint Extra { get; set; }

			[IgnoreDataMember]
			public Entity parent;

			public ExperienceGrant(Entity parent)
			{
				this.parent = parent;
				this.Baseexp = 1;
				this.Extra = 0;
			}
			public ExperienceGrant(Entity parent, uint b)
			{
				this.parent = parent;
				this.Baseexp = b;
				this.Extra = 0;
			}
			public ExperienceGrant(Entity parent, uint b, uint e)
			{
				this.parent = parent;
				this.Baseexp = b;
				this.Extra = e;

			}

			[IgnoreDataMember]
			[JsonIgnore]
			public uint Grant
			{
				get
				{
					byte l = parent.Level;
					return (uint)(((l * (l - 1) * 500) + (this.Baseexp * l)) + this.Extra);
				}
			}

		}

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
			public ArmorClass(Entity parent, int a, int s, int n, int d, int temp, int misc, int b) : this(a,s,n,d,temp,misc,b, new FlagsArray<FlagList>())
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

				public Hurt(Hurt other):
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

			public Health(Health Other):
				this(Other.BaseHP, Other.LethalDamage, Other.NonlethalDamage, Other.HpThrows)
			{ }
			public Health(Entity p):
				this()
			{
				parent = p;
			}
			public Health():
				this(1)
			{ }
			public Health(uint bhp) :
				this(bhp, new Hurt(), new Hurt())
			{ }
			public Health(uint bhp, Hurt ld, Hurt nld):
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

		public sealed class Description : INoted
		{
			public string Name { get; set; }
			public string Fullname { get; set; }
			public string Race { get; set; }
			public string Alignment { get; set; }
			public string Deity { get; set; }
			public string BodyType { get; set; }
			public Sizes Size { get; set; }
			public string Bio { get; set; }
			public string Intro { get; set; }
			public string Personality { get; set; }
			public string Gender { get; set; }
			public List<string> Notes { get; set; }
			public ulong Age { get; set; }
			public Length Height { get; set; }
			public Mass Weight { get; set; }
			public Color Eyes { get; set; }
			public Color Hair { get; set; }
			public Color Skin { get; set; }
			public Color Bgcolor { get; set; }
			public Color BannerColor { get; set; }
			public Bitmap Mugshot { get; set; }
			public Bitmap FullBody { get; set; }
			public List<Bitmap> ArcaneMarks { get; set; }

			public Description(Description other) :
				this(other.Name, other.Fullname, other.Race, other.Alignment, other.Deity, other.BodyType, other.Size, other.Bio, other.Intro, other.Personality, other.Gender, other.Notes, other.Age, other.Height, other.Weight, other.Eyes, other.Hair, other.Skin, other.Bgcolor, other.BannerColor, other.Mugshot, other.FullBody, other.ArcaneMarks)
			{ }
			public Description() :
				this(String.Empty)
			{ }
			public Description(string name) :
				this(name, String.Empty)
			{ }
			public Description(string name, string fullname) :
				this(name, fullname, String.Empty)
			{ }
			public Description(string name, string fullname, string race) :
				this(name, fullname, race, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment) :
				this(name, fullname, race, alignment, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity) :
				this(name, fullname, race, alignment, deity, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype) :
				this(name, fullname, race, alignment, deity, bodytype, Sizes.Medium)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size) :
				this(name, fullname, race, alignment, deity, bodytype, size, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, new List<string>())
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, 0)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, new Length(1M, Length.Units.Meter))
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, new Mass(1M, Mass.Units.Kilogram))
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, hair, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair, Color? skin) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, hair, skin, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair, Color? skin, Color? bgcolor) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, hair, skin, bgcolor, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair, Color? skin, Color? bgcolor, Color? bannercolor) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, hair, skin, bgcolor, bannercolor, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair, Color? skin, Color? bgcolor, Color? bannercolor, Bitmap mugshot) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, hair, skin, bgcolor, bannercolor, mugshot, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair, Color? skin, Color? bgcolor, Color? bannercolor, Bitmap mugshot, Bitmap fullbody):
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, hair, skin, bgcolor, bannercolor, mugshot, fullbody, new List<Bitmap>())
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair, Color? skin, Color? bgcolor, Color? bannercolor, Bitmap mugshot, Bitmap fullbody, List<Bitmap> arcanemarks)
			{
				Name = name;
				Fullname = fullname;
				Race = race;
				Alignment = alignment;
				Deity = deity;
				BodyType = bodytype;
				Size = size;
				Bio = bio;
				Intro = intro;
				Personality = personality;
				Gender = gender;
				Notes = notes;
				Age = age;
				Height = height;
				Weight = weight;
				Eyes = eyes == null ? Color.SandyBrown : (Color)eyes;
				Hair = hair == null ? Color.Black : (Color)hair;
				Skin = skin == null ? Color.Beige : (Color)skin;
				Bgcolor = bgcolor == null ? Color.Transparent : (Color)bgcolor;
				BannerColor = bannercolor == null ? Color.Transparent : (Color)bannercolor;
				Mugshot = mugshot;
				FullBody = fullbody;
				ArcaneMarks = arcanemarks;
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

		}

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

			public Skill(Skill other):
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

		public sealed class Ability : INoted
		{
			public struct AbilityTag
			{
				public string Name { get; set; }
				public string ShortenedName { get; set; }
				public string Description { get; set; }
			}

			public string Name { get; set; }
			public string Requirements { get; set; }
			public string Description { get; set; }
			public List<string> Notes { get; set; }
			public int[] Buffs { get; set; }
			public List<AbilityTag> Tags { get; set; }

			public Ability(Ability Other) :
				this(Other.Name, Other.Requirements, Other.Description, Other.Notes, Other.Buffs, Other.Tags)
			{ }
			public Ability()
			{ }
			public Ability(string n, string re, string de) :
				this(n, re, de, new List<string>())
			{ }
			public Ability(string n, string re, string de, List<string> nts) :
				this(n,re,de,nts,new int[App.StatCount])
			{ }
			public Ability(string n, string re, string de, List<string> nts, int[] bfs) :
				this(n,re,de,nts,bfs,new List<AbilityTag>())
			{ }
			public Ability(string n, string re, string de, List<string> nts, int[] bfs, List<AbilityTag> tgs)
			{
				this.Name = n;
				this.Description = de;
				this.Notes = nts;
				this.Buffs = bfs;
				Tags = tgs;

				if (re == String.Empty || re == null)
				{
					this.Requirements = App.Cf.Lang.Ent["noRequirements"];
				}
				else
				{
					this.Requirements = re;
				}

			}

			[IgnoreDataMember]
			[JsonIgnore]
			public string FullName
			{
				get
				{
					const string s = " ({0})";
					string str = String.Empty;
					foreach(Ability.AbilityTag tag in Tags)
					{
						str += String.Format(s, tag.ShortenedName);
					}
					return str;
				}
				set
				{
					this.Name = value;
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
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

		}

		public sealed class Job : INoted
		{

			public struct JobGrowth
			{

				public List<List<byte>> BaseAttack { get; set; }
				public List<List<byte>> Saving { get; set; } //Throws
				public List<Ability> Abilities { get; set; }
				public List<List<byte>> DailySpells { get; set; }

			}

			public string Name { get; set; }
			public byte Level { get; set; }
			public List<string> Competence { get; set; }
			public Dice HPDice { get; set; }
			public int SkillPoints { get; set; }
			public JobGrowth Growth { get; set; }
			private Entity parent;

			public Job(Job other) :
				this(other.Name, other.Level, other.Competence, other.HPDice, other.SkillPoints, other.Growth)
			{ }
			public Job(Entity parent) :
				this()
			{
				this.parent = parent;
			}
			public Job() :
				this("")
			{ }
			public Job(string name) :
				this(name, 1)
			{ }
			public Job(string name, byte level) :
				this(name, level, new List<string>())
			{ }
			public Job(string name, byte level, List<string> competence) :
				this(name, level, competence, new Dice(1, 6))
			{ }
			public Job(string name, byte level, List<string> competence, Dice hpd) :
				this(name, level, competence, hpd, 1)
			{ }
			public Job(string name, byte level, List<string> competence, Dice hpd, int skillpoints) :
				this(name, level, competence, hpd, skillpoints, new JobGrowth())
			{ }
			public Job(string name, byte level, List<string> competence, Dice hpd, int skillpoints, JobGrowth gr)
			{
				Name = name;
				Level = level;
				Competence = competence;
				HPDice = hpd;
				SkillPoints = skillpoints;
				Growth = gr;
			}

			public List<string> Notes { get; set; }
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

		}

		/*------------------------- Field and Property Declaration -------------------------*/

		[IgnoreDataMember]
		protected int[] baseStats = new int[App.StatCount];
		protected int[] miscBuffs = new int[App.StatCount];

		[IgnoreDataMember]
		protected int id;
		[IgnoreDataMember]
		protected int pid; //player list id
		protected Player player;
		protected byte level = 1;
		protected List<Skill> skills = new List<Skill>();
		protected uint[] spentSpells = new uint[App.Cf.Options.EntityValues["maxSpellLevel"]];

		protected ExperienceGrant expgrant;
		protected ArmorClass armorclass;
		protected Health health;
		protected Job job;
		protected Inventory inventory = new Inventory();
		protected Inventory.Equipped equipped = new Inventory.Equipped();
		protected List<Item.Potion.Effect> activeeffects = new List<Item.Potion.Effect>();


		public byte SkillPointModifier { get; set; } //Added to the class and race skill points for calculation
		public byte ExtraSkillPoints { get; set; }  //Added to the final calculation of skill points
		public Description Desc { get; set; }

		public List<Item.Potion.Effect> ActiveEffects
		{
			get
			{
				return activeeffects;
			}
			set
			{
				activeeffects = value;
			}
		}
		public Inventory Inventory
		{
			get
			{
				return inventory;
			}
			set
			{
				inventory = value;
			}
		}
		public Inventory.Equipped Equipped
		{
			get
			{
				return equipped;
			}
			set
			{
				inventory = value;
			}
		}
		public uint[] SpentSpells
		{
			get
			{
				return spentSpells;
			}
		}

		public ExperienceGrant Expgrant
		{
			get
			{
				return expgrant;
			}
			set
			{
				expgrant = value;
			}
		}
		public ArmorClass ArmorC
		{
			get
			{
				return armorclass;
			}
			set
			{
				armorclass = value;
			}
		}
		public Health HP
		{
			get
			{
				return health;
			}
			set
			{
				health = value;
			}
		}
		public Job Class
		{
			get
			{
				return job;
			}
			set
			{
				job = value;
			}
		}
		public List<Skill> Skills
		{
			get
			{
				return skills;
			}
		}

		public byte Level
		{
			get
			{
				return level;
			}
			set
			{
				level = value;
			}
		}

		[IgnoreDataMember]
		[JsonIgnore]
		public int Id
		{
			get
			{
				return this.id;
			}
		}

		public int GetEffectsStats(Stats ind)
		{
			int v = 0;
			foreach(Item.Potion.Effect e in ActiveEffects)
			{
				v += e[ind];
			}
			return v;
		}

		public int GetBaseStats(Stats ind)
		{
			return this.baseStats[(byte)ind];
		}
		public void AddBaseStats(Stats ind, int x)
		{
			this.baseStats[(byte)ind] += x;
		}
		public void SetBaseStats(Stats ind, int x)
		{
			this.baseStats[(byte)ind] = x;
		}

		public int GetMiscBuffs(Stats ind)
		{
			return this.miscBuffs[(byte)ind];
		}
		public void AddMiscBuffs(Stats ind, int x)
		{
			this.miscBuffs[(byte)ind] += x;
		}
		public void SetMiscBuffs(Stats ind, int x)
		{
			this.miscBuffs[(byte)ind] = x;
		}

		public int GetBaseMod(Stats stat)
		{
			byte i = (byte)stat;
			return ((this.baseStats[i] + this.miscBuffs[i]) / 2) - 5;
		}

		public int GetBaseMod(Stats a, Stats b)
		{
			return (GetBaseMod(b) + (GetBaseMod(a) * 2)) / 2;
		}

		public virtual int GetMod(Stats stat)
		{
			byte i = (byte)stat;
			return ((this.baseStats[i] + this.miscBuffs[i] + GetEffectsStats(stat) ) / 2) - 5;
		}

		public virtual int GetMod(Stats a, Stats b)
		{
			return (GetMod(b) + (GetMod(a) * 2)) / 2;
		}

		public Player GetPlayer()
		{
			return this.player;
		}

		public void SetPlayer(Player ply)
		{
		}

		public static int Create(byte level, string name)
		{
			Entity newent = new Entity(level, name);
			int newentid = newent.Register();

			Log.Debug("Creating new entity from scratch. Entity name: {0}; Entity ID: {1}", name, newentid);

			return newentid;
		}

		public void RenovateParenthood()
		{
			const string logstring = "Renovated the reference of object: {0} as a child of {1}. ID: {3} ||| {4}";
			expgrant.parent = this; Log.Verbose(logstring, expgrant.GetType(), this.GetType(), this.Id, expgrant.parent == this);
			armorclass.parent = this; Log.Verbose(logstring, armorclass.GetType(), this.GetType(), this.Id, armorclass.parent == this);
			health.parent = this; Log.Verbose(logstring, health.GetType(), this.GetType(), this.Id, health.parent == this);
			for (int ind = 0; ind < Skills.Count; ind++)
			{
				Skill skl = Skills[ind];
				skl.parent = this;
				Skills[ind] = skl; Log.Verbose(logstring, Skills[ind].GetType(), this.GetType(), this.Id, Skills[ind].parent == this);
			}
		}

		public static int Create(string name)
		{
			Entity newent = DeserializeFromFile.Json<Entity>(App.Directories.Entities, name + ".entity");
			int newentid = newent.Register();
			newent.RenovateParenthood();

			Log.Debug("Creating new entity out of a Json file. Entity name: {0}; Entity ID: {1}", name, newentid);

			return newentid;
		}

		public virtual void Unregister()
		{
			Log.Debug("Unregistering Entity {0} of Id {1}", this.Desc.Name, this.Id);
			Loaded.Entities.Remove(this.Id);
		}

		private int Register()
		{
			this.id = Loaded.Entities.Add(this);
			return id;
		}

		public virtual void Serialize()
		{
			SerializeToFile.Json(this, App.Directories.Entities, this.Desc.Name + ".entity");
		}
		
		public Entity()
		{
		}

		protected Entity(byte level, string name)
		{
			this.level = level;
			this.Expgrant = new ExperienceGrant(this, 69, 120);
			this.HP = new Health(this);
			this.ArmorC = new ArmorClass(this,0,0,0,0,0,0,0);
			this.HP.SetBaseHP();
			this.skills.Add(new Skill(this, "Lockpicking", Stats.dexterity, 0, 5, new FlagsArray<Skill.FlagList>(new bool[] { true, false, true })));
			this.skills.Add(new Skill(this, "Diplomacy", Stats.charisma, 3, 2, new FlagsArray<Skill.FlagList>(new bool[] { true, false, false })));
			this.Desc = new Description();
			this.Desc.Name = name;
		}

	}

	public class Character : Entity
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

		protected List<Ability> feats = new List<Ability>();
		protected List<Ability> abilities = new List<Ability>();
		protected Experience exp;

		public byte FreeLevels { get; set; }
		public List<Job> Jobs { get; set; }
		public Experience Exp
		{
			get
			{
				return exp;
			}
			set
			{
				exp = value;
			}
		}
		public List<Ability> Feats
		{
			get
			{
				return feats;
			}
			set
			{
				feats = value;
			}
		}
		public List<Ability> Abilities
		{
			get
			{
				return abilities;
			}
			set
			{
				abilities = value;
			}
		}

		new public void RenovateParenthood()
		{
			const string logstring = "Renovated the reference of object: {0} as a child of {1}. ID: {3} ||| {4}";
			base.RenovateParenthood();
			exp.parent = this; Log.Verbose(logstring, exp.GetType(), this.GetType(), this.Id, exp.parent == this);
		}

		public override void Serialize()
		{
			SerializeToFile.Json(this, App.Directories.Characters, this.Desc.Name + ".character");
		}

		public Character()
		{
		}

		protected Character(byte level, string name) : base(level, name)
		{
			this.Exp = new Experience(this);
			this.feats.Add(new Ability("Fleeting Presence", null, "This character can disappear from existence at will", new List<string>(), new int[App.StatCount]));
			this.abilities.Add(new Ability("Power Surge", null, "Augments strength and constitution", new List<string>(), new int[] { 2, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
		}

		new public static int Create(byte level, string name)
		{
			Character newchar = new Character(level, name);
			int newcharid = newchar.Register();

			Log.Debug("Creating new character from scratch. Character name: {0}; Character ID: {1}", name, newcharid);

			return newcharid;
		}
		new public static int Create(string name)
		{
			Character newchar = DeserializeFromFile.Json<Character>(App.Directories.Characters, name + ".character");
			int newcharid = newchar.Register();
			newchar.RenovateParenthood();

			Log.Debug("Creating new character out of a Json file. Character name: {0}; Character ID: {1}",name, newcharid);

			return newcharid;
		}

		public override void Unregister()
		{
			Log.Debug("Unregistering Character {0} of Id {1}",this.Desc.Name, this.Id);
			Loaded.Characters.Remove(this.Id);
		}

		private int Register()
		{
			this.id = Loaded.Characters.Add(this);
			return this.id;
		}

		public int GetAbilityBuffs(Stats ind)
		{
			int total = 0;
			foreach (Ability abi in this.abilities)
			{
				total += abi.Buffs[(byte)ind];
			}
			return total;
		}

		public int GetFeatBuffs(Stats ind)
		{
			int total = 0;
			foreach (Ability abi in this.feats)
			{
				total += abi.Buffs[(byte)ind];
			}
			return total;
		}

		public override int GetMod(Stats stat)
		{
			byte i = (byte)stat;
			return ((this.baseStats[i] + this.miscBuffs[i] + GetEffectsStats(stat) + this.GetAbilityBuffs(stat) + this.GetFeatBuffs(stat)) / 2) - 5;
		}
		public override int GetMod(Stats a, Stats b)
		{
			return (GetMod(b) + (GetMod(a) * 2)) / 2;
		}

	}



	public class Player
	{

		private uint id;

		public string name;
		public uint Id
		{
			get
			{
				return this.id;
			}
		}
		public List<Entity> entities;
		public List<Character> characters;
		public List<string> notes;

	}

}