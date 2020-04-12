using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace DnDTDesktop
{
    public partial class Item
	{
		public class Inventory : Item
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
						foreach (Item.Armor a in Armors)
						{
							if (v > a.MaximumDeterity)
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
					this(new Slot<Item.Armor>(), new Slot<Item.Weapon.Melee>(), new Bag<Item.Weapon.Ammo>(), new Slot<Item.Weapon.Ranged>(), new List<Inventory>())
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
			public Mass FullWeight
			{
				get
				{
					decimal v = Weight.Kilogram;
					foreach (Item i in Armors)
					{
						v = i.Weight.Kilogram * i.Quantity;
					}
					foreach (Bag<Item.Weapon> list in Weapons) //But a Slot inherits a Bag so it's okay to not hide this
					{
						foreach (Item i in list)
						{
							v += i.Weight.Kilogram * i.Quantity;
						}
					}
					foreach (Item i in Other)
					{
						v += i.Weight.Kilogram * i.Quantity;
					}
					foreach (Item i in Keychain)
					{
						v += i.Weight.Kilogram * i.Quantity;
					}
					foreach (Item i in Potions)
					{
						v += i.Weight.Kilogram;
					}
					return new Mass(v, Mass.Units.Kilogram);
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
			public PriceTag FullValue
			{
				get
				{
					CUInt64 v = Value.basevalue;
					foreach (Item i in Armors)
					{
						v.v += i.Value.basevalue.v * i.Quantity;
					}
					foreach (Bag<Item.Weapon> list in Weapons) //But a Slot inherits a Bag so it's okay to not hide this
					{
						foreach (Item i in list)
						{
							v.v += i.Value.basevalue.v * i.Quantity;
						}
					}
					foreach (Item i in Other)
					{
						v.v += i.Value.basevalue.v * i.Quantity;
					}
					foreach (Item i in Keychain)
					{
						v.v += i.Value.basevalue.v * i.Quantity;
					}
					return new PriceTag(v.v);
				}
			}

			public Inventory(Inventory other) :
				//this(other.Armors, other.Weapons, other.Other, other.Keychain, other.Potions)
				this(new Bag<Item.Armor>(other.Armors), new Bag<Item.Weapon>[3], new Bag<Item>(other.Other), new Bag<Item.Key>(other.Keychain), new Slot<Item.Potion>(other.Potions), other.MaximumWeight, other)
			{
				for (int i = 0; i < Weapons.Length; i++)
				{
					Weapons[i] = new Bag<Item.Weapon>(other.Weapons[i]);
				}
			}
			private Inventory(Bag<Item.Armor> armors, Bag<Item.Weapon>[] weapons, Bag<Item> other, Bag<Item.Key> keychain, Slot<Item.Potion> potions, Mass maxweight, Item obj) :
				base(obj)
			{
				Armors = armors;
				Weapons = weapons;
				Other = other;
				Keychain = keychain;
				Potions = potions;
				MaximumWeight = maxweight;
				LockQuantity();
			}
			public Inventory() :
				this(new Bag<Item.Armor>(), new Bag<Item.Weapon>[3], new Bag<Item>(), new Bag<Item.Key>(), new Slot<Item.Potion>(), new Mass(100M, Mass.Units.Kilogram), new Item())
			{
				for (int i = 0; i < Weapons.Length; i++)
				{
					Weapons[i] = new Bag<Item.Weapon>();
				}
			}

		}
	}
}
