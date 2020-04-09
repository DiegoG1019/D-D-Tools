using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using System.Collections;

namespace DnDTDesktop
{
	public class Item : INoted, IFlagged<Item.FlagList>
	{
		/*-------------------------Sub Class Declaration-------------------------*/
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

		public class Armor : Item
		{
			public int Bonif { get; set; }
			public ushort MaximumDeterity { get; set; }
			public int Penalty { get; set; }
			public Percentage SpellFailure { get; set; } //Percentage
			public int SpeedPenalty { get; set; }

			public Armor(Armor other) :
				this(other.Bonif, other.MaximumDeterity, other.Penalty, other.SpellFailure, other.SpeedPenalty, other)
			{ }
			public Armor() :
				this(0)
			{ }
			public Armor(int bonif) :
				this(bonif, ushort.MaxValue)
			{ }
			public Armor(int bonif, ushort maxdex) :
				this(bonif, maxdex, 0)
			{ }
			public Armor(int bonif, ushort maxdex, int penalty) :
				this(bonif, maxdex, penalty, 0)
			{ }
			public Armor(int bonif, ushort maxdex, int penalty, float spellfail) :
				this(bonif, maxdex, penalty, spellfail, 0)
			{ }
			public Armor(int bonif, ushort maxdex, int penalty, float spellfail, int speedpenalty) :
				this(bonif, maxdex, penalty, spellfail, speedpenalty, new Item())
			{ }
			public Armor(int bonif, ushort maxdex, int penalty, float spellfail, int speedpenalty, Item obj) :
				this(bonif, maxdex, penalty, new Percentage(spellfail), speedpenalty, obj)
			{ }
			public Armor(int bonif, ushort maxdex, int penalty, Percentage spellfail, int speedpenalty, Item obj) :
				base(obj)
			{
				Bonif = bonif;
				MaximumDeterity = maxdex;
				Penalty = penalty;
				SpellFailure = spellfail;
				SpeedPenalty = speedpenalty;
			}
		}

		public class Weapon : Item
		{
			public class Melee : Weapon
			{
				public ItemCriticalHit Critical { get; set; }

				public Melee(Melee other) :
					this(other.Critical, other)
				{ }
				public Melee() :
					this(new ItemCriticalHit())
				{ }
				public Melee(ItemCriticalHit crit) :
					this(crit, new Weapon())
				{ }
				public Melee(ItemCriticalHit crit, Weapon obj) :
					base(obj)
				{
					Critical = crit;
				}
			}

			public class Ranged : Weapon
			{
				//Type here represents the type the weapon would be if it was used as a Melee weapon

				public Length Range { get; set; }

				public Ranged(Ranged other) :
					this(other.Range, other)
				{ }
				public Ranged() :
					this(new Length(10M, Length.Units.Foot), new Weapon())
				{ }
				public Ranged(Length rng) :
					this(rng, new Weapon())
				{ }
				public Ranged(Length rng, Weapon obj) :
					base(obj)
				{
					Range = rng;
				}
			}

			public class Ammo : Weapon // As of now, it's really just a Melee weapon
			{
				public ItemCriticalHit Critical { get; set; }
				public Ammo(Ammo other) :
					this(other.Critical, other)
				{ }
				public Ammo() :
					this(new ItemCriticalHit())
				{ }
				public Ammo(ItemCriticalHit crit) :
					this(crit, new Weapon())
				{ }
				public Ammo(ItemCriticalHit crit, Weapon obj) :
					base(obj)
				{
					Critical = crit;
				}
			}
			//It helps me keep things organized, okay?
			public ItemDamage Damage { get; set; }
			public ItemAttackThrow AttackThrow { get; set; }
			public string Type { get; set; }
			public string Impact { get; set; }
			public Length Reach { get; set; }

			public Weapon(Weapon other) :
				this(other.Damage, other.AttackThrow, other.Type, other.Impact, other.Reach, other)
			{ }
			public Weapon() :
				this(new ItemDamage())
			{ }
			public Weapon(ItemDamage dmg) :
				this(dmg, new ItemAttackThrow())
			{ }
			public Weapon(ItemDamage dmg, Stats atk) :
				this(dmg, new ItemAttackThrow(atk))
			{ }
			public Weapon(ItemDamage dmg, Stats atkStat1, Stats atkStat2) :
				this(dmg, new ItemAttackThrow(atkStat1, atkStat2))
			{ }
			public Weapon(ItemDamage dmg, ItemAttackThrow atkthrow) :
				this(dmg, atkthrow, String.Empty)
			{ }
			public Weapon(ItemDamage dmg, ItemAttackThrow atkthrow, string tp) :
				this(dmg, atkthrow, tp, String.Empty)
			{ }
			public Weapon(ItemDamage dmg, ItemAttackThrow atkthrow, string tp, string im) :
				this(dmg, atkthrow, tp, im, new Length(1, Length.Units.Square))
			{ }
			public Weapon(ItemDamage dmg, ItemAttackThrow atkthrow, string tp, string im, Length reach) :
				this(dmg, atkthrow, tp, im, reach, new Item())
			{ }
			public Weapon(ItemDamage dmg, ItemAttackThrow atkthrow, string tp, string im, Length reach, Item obj) :
				base(obj)
			{
				Damage = dmg;
				AttackThrow = atkthrow;
				Type = tp;
				Reach = reach;
				Impact = im;
			}

		}

		public class Key : Item
		{

			public List<char> Pins { get; set; }
			public string Code
			{
				get
				{
					return String.Join("", Pins);
				}
				set
				{
					Pins = new List<char>(value.ToCharArray());
				}
			}

			public Key(Key other) :
				this(other.Code, other)
			{ }
			public Key() :
				this(String.Empty)
			{ }
			public Key(string c) :
				this(c, new Item())
			{ }
			public Key(string c, Item obj) :
				base(obj)
			{
				Code = c;
			}

			public bool IsSame(Key other)
			{
				return (this.Code == other.Code);
			}

		}

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

			public Potion Separate(Percentage OtherFill) {

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
					tfx.Add(new Effect( e.Description, AdjustDuration(Fill, e.Duration), AdjustBonus(Fill, e.Bonus)));
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

		/*------------------------- Field and Property Declaration -------------------------*/

		public enum FlagList
		{
			QuantityLocked
		}

		private uint quant = 0;

		public string Name { get; set; }
		public string Description { get; set; }
		public PriceTag Value { get; set; }
		public Mass Weight { get; set; }
		public List<string> Notes { get; set; }
		public Length RangeIncrement { get; set; }
		public uint Quantity
		{
			get
			{
				return quant;
			}
			set
			{
				if (Flags[FlagList.QuantityLocked])
				{
					if (value.GetType() == true.GetType()) //If it's a boolean
					{
						quant = value;
						return;
					}
					quant = (value > 0U) ? 1U : 0U;
				}
				else
				{
					quant = value;
				}
			}
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

		public Item(Item other) :
			this(other.Name, other.Description, other.Weight, other.Value, other.Quantity, other.Notes, other.RangeIncrement, other.Flags)
		{ }
		public Item() :
			this(String.Empty)
		{ }
		public Item(string name) :
			this(name, String.Empty)
		{ }
		public Item(string name, string description) :
			this(name, description, new Mass(1M, Mass.Units.Pound))
		{ }
		public Item(string name, string description, Mass weight) :
			this(name, description, weight, 1)
		{ }
		public Item(string name, string description, Mass weight, ulong value) :
			this(name, description, weight, value, 1)
		{ }
		public Item(string name, string description, Mass weight, ulong value, uint quantity) :
			this(name, description, weight, value, quantity, new List<string>())
		{ }
		public Item(string name, string description, Mass weight, ulong value, uint quantity, List<string> notes) :
			this(name, description, weight, value, quantity, notes, new Length(1M, Length.Units.Foot))
		{ }
		public Item(string name, string description, Mass weight, ulong value, uint quantity, List<string> notes, Length rangeincrement) :
			this(name, description, weight, value, quantity, notes, rangeincrement, new FlagsArray<FlagList>())
		{ }
		public Item(string name, string description, Mass weight, ulong value, uint quantity, List<string> notes, Length rangeincrement, FlagsArray<FlagList> flg) :
			this(name, description, weight, new PriceTag(value), quantity, notes, rangeincrement, flg)
		{ }
		public Item(string name, string description, Mass weight, PriceTag value, uint quantity, List<string> notes, Length rangeincrement, FlagsArray<FlagList> flg)
		 {
			Name = name;
			Description = description;
			Weight = weight;
			Value = value;
			Notes = notes;
			RangeIncrement = rangeincrement;
			Flags = flg;
			Quantity = quantity;
		 }

		public FlagsArray<FlagList> Flags { get; set; }

		public void LockQuantity()
		{
			Flags[FlagList.QuantityLocked] = true;
			Quantity = 1;
		}
		public void LockQuantity(uint q)
		{
			Flags[FlagList.QuantityLocked] = true;
			Quantity = q;
		}

		public void UnlockQuantity()
		{

		}

	}

	public class Inventory
	{
		public class Bag<T> : List<T> where T : Item
		{
			new public void Add(T item)
			{
				if (Contains(item))
				{
					int i = IndexOf(item);
					if (!this[i].Flags[Item.FlagList.QuantityLocked])
					{
						this[IndexOf(item)].Quantity += item.Quantity;
						return;
					}
				}
				base.Add(item);
			}
			new public bool Remove(T item)
			{
				for (int i = 0; i < Count; i++)
				{
					if (this[i].Name == item.Name)
					{
						if (this[i].Quantity > item.Quantity)
						{
							this[i].Quantity -= item.Quantity;
							return true;
						}
						else
						{
							this.RemoveAt(i);
							return true;
						}
					}
				}
				return false;
			}
			protected bool Baseremove(T item)
			{
				return base.Remove(item);
			}

			public Bag() : base() { }
			public Bag(Bag<T> other) :
				base(other)
			{ }
		}

		public class Slot<T> : Bag<T> where T : Item
		{
			new public void Add(T item)
			{
				item.LockQuantity();
				base.Add(item);
			}
			new public bool Remove(T item) 
			{
				return Baseremove(item);
			}
			public Slot() : base() { }
			public Slot(Slot<T> other) :
				base(other)
			{ }
		}

		public class Equipped : Inventory
		{
			[JsonPropertyName("EquippedArmor")]
			new public Slot<Item.Armor> Armors { get; set; }

			[JsonPropertyName("EquippedMeleeWeapons")]
			public Slot<Item.Weapon.Melee> MeleeWeapons { get; set; }

			[JsonPropertyName("EquippedAmmunition")]
			public Bag<Item.Weapon.Ammo> Ammunition { get; set; }

			[JsonPropertyName("EquippedRangedWeapons")]
			public Slot<Item.Weapon.Ranged> RangedWeapons { get; set; }
			public List<Inventory> Bags { get; set; }

			public int MaximumDexterity
			{
				get
				{
					int v = int.MaxValue;
					foreach(Item.Armor a in Armors)
					{
						if(v > a.MaximumDeterity)
						{
							v = a.MaximumDeterity;
						}
					}
					return v;
				}
			}

			public Equipped(Equipped other) :
				this(new Slot<Item.Armor>(other.Armors), new Slot<Item.Weapon.Melee>(other.MeleeWeapons), new Bag<Item.Weapon.Ammo>(other.Ammunition), new Slot<Item.Weapon.Ranged>(other.RangedWeapons), new List<Inventory>(other.Bags))
			{ }
			private Equipped(Slot<Item.Armor> armors, Slot<Item.Weapon.Melee> melees, Bag<Item.Weapon.Ammo> ammos, Slot<Item.Weapon.Ranged> rangewpns, List<Inventory> bags) :
				base()
			{
				Armors = armors;
				MeleeWeapons = melees;
				Ammunition = ammos;
				RangedWeapons = rangewpns;
				Bags = bags;
			}
			public Equipped() :
				this(new Slot < Item.Armor >(), new Slot< Item.Weapon.Melee >(), new Bag< Item.Weapon.Ammo >(), new Slot< Item.Weapon.Ranged >(), new List< Inventory >())
			{

			}

		}

		public enum WeaponIndex
		{
			Melee, Ranged, Ammo
		}
		public Bag<Item.Armor> Armors { get; set; }
		public Bag<Item.Weapon>[] Weapons { get; set; }
		public Bag<Item> Other { get; set; }
		public Bag<Item.Key> Keychain { get; set; }
		public Slot<Item.Potion> Potions { get; set; }
		public string Name { get; set; }
		public Mass MaximumWeight { get; set; }

		[IgnoreDataMember]
		[JsonIgnore]
		public bool IsOverFilled
		{
			get
			{
				return Weight > MaximumWeight;
			}
		}
		
		[IgnoreDataMember]
		[JsonIgnore]
		public Mass Weight
		{
			get
			{
				decimal v = 0;
				foreach(Item i in Armors)
				{
					v = i.Weight.Kilogram * i.Quantity;
				}
				foreach(Bag<Item.Weapon> list in Weapons) //But a Slot inherits a Bag so it's okay to not hide this
				{
					foreach(Item i in list)
					{
						v += i.Weight.Kilogram * i.Quantity;
					}
				}
				foreach(Item i in Other)
				{
					v += i.Weight.Kilogram * i.Quantity;
				}
				foreach(Item i in Keychain)
				{
					v += i.Weight.Kilogram * i.Quantity;
				}
				foreach(Item i in Potions)
				{
					v += i.Weight.Kilogram;
				}
				return new Mass(v, Mass.Units.Kilogram);
			}
		}

		[IgnoreDataMember]
		[JsonIgnore]
		public PriceTag Value
		{
			get
			{
				ulong v = 0;
				foreach (Item i in Armors)
				{
					v += i.Value.basevalue.v * i.Quantity;
				}
				foreach (Bag<Item.Weapon> list in Weapons) //But a Slot inherits a Bag so it's okay to not hide this
				{
					foreach (Item i in list)
					{
						v += i.Value.basevalue.v * i.Quantity;
					}
				}
				foreach (Item i in Other)
				{
					v += i.Value.basevalue.v * i.Quantity;
				}
				foreach (Item i in Keychain)
				{
					v += i.Value.basevalue.v * i.Quantity;
				}
				return new PriceTag(v);
			}
		}

		public Inventory(Inventory other) :
			//this(other.Armors, other.Weapons, other.Other, other.Keychain, other.Potions)
			this(new Bag<Item.Armor>(other.Armors), new Bag<Item.Weapon>[3], new Bag<Item>(other.Other), new Bag<Item.Key>(other.Keychain), new Slot<Item.Potion>(other.Potions))
		{
			for (int i = 0; i < Weapons.Length; i++)
			{
				Weapons[i] = new Bag<Item.Weapon>(other.Weapons[i]);
			}
		}
		private Inventory(Bag<Item.Armor> armors, Bag<Item.Weapon>[] weapons, Bag<Item> other, Bag<Item.Key> keychain, Slot<Item.Potion> potions){
			Armors = armors;
			Weapons = weapons;
			Other = other;
			Keychain = keychain;
			Potions = potions;
		}
		public Inventory() :
			this(new Bag<Item.Armor>(), new Bag<Item.Weapon>[3], new Bag<Item>(), new Bag<Item.Key>(), new Slot<Item.Potion>())
		{
			for(int i = 0; i < Weapons.Length; i++)
			{
				Weapons[i] = new Bag<Item.Weapon>();
			}
		}

	}

}
