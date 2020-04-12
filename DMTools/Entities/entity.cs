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
		public static readonly Entity _NULL = null;

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

		protected ExperienceGrant expgrant = new ExperienceGrant();
		protected ArmorClass armorclass = new ArmorClass();
		protected Health health = new Health();
		protected Job job = new Job();
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
			foreach (Item.Potion.Effect e in ActiveEffects)
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
			return ((this.baseStats[i] + this.miscBuffs[i] + GetEffectsStats(stat)) / 2) - 5;
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
			expgrant.parent = this; Log.Verbose(logstring, expgrant.GetType(), this.GetType(), this.Id.ToString(), expgrant.parent == this);
			armorclass.parent = this; Log.Verbose(logstring, armorclass.GetType(), this.GetType(), this.Id.ToString(), armorclass.parent == this);
			health.parent = this; Log.Verbose(logstring, health.GetType(), this.GetType(), this.Id.ToString(), health.parent == this);
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
			this.ArmorC = new ArmorClass(this, 0, 0, 0, 0, 0, 0, 0);
			this.HP.SetBaseHP();
			this.skills.Add(new Skill(this, "Lockpicking", Stats.dexterity, 0, 5, new FlagsArray<Skill.FlagList>(new bool[] { true, false, true })));
			this.skills.Add(new Skill(this, "Diplomacy", Stats.charisma, 3, 2, new FlagsArray<Skill.FlagList>(new bool[] { true, false, false })));
			this.Desc = new Description();
			this.Desc.Name = name;
		}

	}
}