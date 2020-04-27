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

		public uint[] SpentSpells { get; set; }
		public byte Level { get; set; }
		public ExperienceGrant Expgrant { get; set; }
		public ArmorClass ArmorC { get; set; }
		public Health HP { get; set; }
		public EntityJob Job { get; set; }
		public Item.Inventory Inventory { get; set; }
		public Item.Inventory.Equipped Equipped { get; set; }
		public List<Item.Potion.Effect> ActiveEffects { get; set; }
		public List<Skill> Skills { get; set; }

		public byte SkillPointModifier { get; set; } //Added to the class and race skill points for calculation
		public byte ExtraSkillPoints { get; set; }  //Added to the final calculation of skill points
		public Description Desc { get; set; }

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

		public static int Create(string name)
		{
			Entity newent = new Entity(name);
			int newentid = newent.Register();

			Log.Debug("Creating new entity from scratch. Entity name: {0}; Entity ID: {1}", name, newentid);

			return newentid;
		}

		public void RenovateParenthood()
		{
			const string logstring = "Renovated the reference of object: {0} as a child of {1}. ID: {3} / {4}";
			Expgrant.parent = this; Log.Verbose(logstring, Expgrant.GetType(), this.GetType(), this.Id.ToString(), Expgrant.parent == this);
			ArmorC.parent = this; Log.Verbose(logstring, ArmorC.GetType(), this.GetType(), this.Id.ToString(), ArmorC.parent == this);
			HP.parent = this; Log.Verbose(logstring, HP.GetType(), this.GetType(), this.Id.ToString(), HP.parent == this);
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

		public Entity() :
			this(new ExperienceGrant(), new Health(), new ArmorClass(), new Description(), new List<Skill>(), new EntityJob(), new Item.Inventory(), new Item.Inventory.Equipped(), new List<Item.Potion.Effect>(), new uint[App.Cf.Options.EntityValues["maxSpellLevel"]], 1)
		{ }
		public Entity(ExperienceGrant expg, Health hp, ArmorClass ac, Description desc, List<Skill> skls, EntityJob jb, Item.Inventory inv, Item.Inventory.Equipped eqp, List<Item.Potion.Effect> activefx, uint[] spentspells, byte level)
		{
			Expgrant = expg;
			HP = hp;
			ArmorC = ac;
			Desc = desc;
			Skills = skls;
			SpentSpells = spentspells;
			Level = level;
			Job = jb;
			Inventory = inv;
			Equipped = eqp;
			ActiveEffects = activefx;
			HP.SetBaseHP();
		}

		protected Entity(string name) :
			this()
		{
			this.Desc.Name = name;
		}

	}
}