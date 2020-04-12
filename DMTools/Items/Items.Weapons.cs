using System;

namespace DnDTDesktop
{
    public partial class Item
	{
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
	}
}
