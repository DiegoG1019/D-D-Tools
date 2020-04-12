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
		public List<Ability> Feats { get; set; }
		public List<Ability> Abilities { get; set; }
		public Experience Exp { get; set; }
		public byte FreeLevels { get; set; }
		public List<EntityJob> Jobs { get; set; }

		new public void RenovateParenthood()
		{
			const string logstring = "Renovated the reference of object: {0} as a child of {1}. ID: {3} ||| {4}";
			base.RenovateParenthood();
			Exp.parent = this; Log.Verbose(logstring, Exp.GetType(), this.GetType(), this.Id, Exp.parent == this);
		}

		public override void Serialize()
		{
			SerializeToFile.Json(this, App.Directories.Characters, this.Desc.Name + ".character");
		}

		public Character() :
			base()
		{
			Feats = new List<Ability>();
			Abilities = new List<Ability>();
			Exp = new Experience();
			Jobs = new List<EntityJob>();
		}

		protected Character(byte level, string name) : base(level, name)
		{
			Feats = new List<Ability>();
			Abilities = new List<Ability>();
			Exp = new Experience();
			Jobs = new List<EntityJob>();
			this.Exp = new Experience(this);
			this.Feats.Add(new Ability("Fleeting Presence", null, "This character can disappear from existence at will", new List<string>(), new int[App.StatCount]));
			this.Abilities.Add(new Ability("Power Surge", null, "Augments strength and constitution", new List<string>(), new int[] { 2, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
		}

		new public static int Create(string name)
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

			Log.Debug("Creating new character out of a Json file. Character name: {0}; Character ID: {1}", name, newcharid);

			return newcharid;
		}

		public override void Unregister()
		{
			Log.Debug("Unregistering Character {0} of Id {1}", this.Desc.Name, this.Id);
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
			foreach (Ability abi in this.Abilities)
			{
				total += abi.Buffs[(byte)ind];
			}
			return total;
		}

		public int GetFeatBuffs(Stats ind)
		{
			int total = 0;
			foreach (Ability abi in this.Feats)
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

}
