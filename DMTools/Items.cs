using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using System.Collections;

namespace DnDTDesktop
{
    public class Item: INoted, IFlagged<Item.FlagList>
    {
        /*-------------------------Sub Class Declaration-------------------------*/
        public struct ItemDamage
        {
            public Dice Small { get; set; }
            public Dice Medium { get; set; }
            public Dice Big { get; set; }
        }

        public struct ItemAttackThrow
        {
            public Stats KeyStat { get; set; }
            public Stats? SecondaryStat { get; set; }
        }

        public struct ItemCriticalHit
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
                    else
                    {
                        return String.Format("{0}; x{1}", Minimum, Multiplier);
                    }
                }
            }
            public ItemCriticalHit(byte Min, byte Max, byte Mult)
            {
                Minimum = Min;
                Maximum = Max;
                Multiplier = Mult;
            }
            public ItemCriticalHit(byte Min, byte Mult)
            {
                Minimum = Min;
                Maximum = Min;
                Multiplier = Mult;
            }
        }

        public class Armor : Item
        {
            public int Bonif { get; set; }
            public ushort MaximumDeterity { get; set; }
            public int Penalty { get; set; }
            public byte SpellFailure { get; set; } //Percentage
            public int SpeedPenalty { get; set; }

            public Armor() : base() { }
        }

        public abstract class Weapon : Item
        {
            public class Melee : Weapon
            {
                public ItemCriticalHit Critical { get; set; }

                public Melee() : base()
                {
                    Critical = new ItemCriticalHit();
                }

            }

            public class Ranged : Weapon
            {
                //Type here represents the type the weapon would be if it was used as a Melee weapon
                //It really doesn't have any more info than a regular weapon tbh
                public Ranged() : base() { }
            }

            public class Ammo : Weapon // As of now, it's really just a Melee weapon
            {
                public ItemCriticalHit Critical { get; set; }
                public Ammo()
                {
                    Critical = new ItemCriticalHit();
                }
            }
            //It helps me keep things organized, okay?

            public Weapon() : base()
            {
                Damage = new ItemDamage();
                AttackThrow = new ItemAttackThrow();
            }

            public ItemDamage Damage { get; set; }
            public ItemAttackThrow AttackThrow { get; set; }
            public string Type { get; set; }

        }

        public class Key : Item
        {
            public List<char> Pins { get; set; }
            public string Code
            {
                get
                {
                    return String.Join("",Pins);
                }
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
                private readonly int[] bonus = new int[App.statCount];
                public string Description { get; set; }
                public int Duration { get; set; }  //Seconds
                public int[] Bonus { get; set; }
                public int this[Stats index]
                {
                    get
                    {
                        return bonus[(int)index];
                    }
                    set
                    {
                        bonus[(int)index] = value;
                    }
                }

                public Effect() { }
                public Effect(int[] b, string d, int dur)
                {
                    bonus = b;
                    Description = d;
                    Duration = dur;
                }
            }

            public List<Effect> Effects { get; set; }
            public byte Fill { get; set; } //Percentage

            public Potion() : base()
            {
                LockQuantity();
                Effects = new List<Effect>();
                Fill = 100;
            }

            public Potion(List<Effect> Fx, byte fill, long v) : base(v)
            {
                LockQuantity();
                Effects = Fx;
                Fill = fill;
            }

            private int[] AdjustBonus(byte OtherFill, int[] OtherBonus)
            {
                float newfill = OtherFill / 100f;
                for(int i = 0; i < OtherBonus.Length; i++)
                {
                    OtherBonus[i] = (int)(OtherBonus[i] * newfill);
                }
                return OtherBonus;
            }

            private int AdjustDuration(byte OtherFill, int Duration)
            {
                return (int)(Duration * (OtherFill / 100f));
            }

            private long AdjustValue(byte OtherFill, long value)
            {
                return (long)(value * (OtherFill / 100f));
            }

            public Potion Separate(byte OtherFill) {

                if (OtherFill > Fill)
                {
                    throw new InvalidOperationException("Cannot separate a potion by taking more than what it currently holds");
                }
                else
                {
                    if (OtherFill == Fill)
                    {
                        throw new InvalidOperationException("Cannot separate a potion by taking the same amount that it currently holds. (Just take the potion itself.)");
                    }
                }

                Fill -= OtherFill;

                List<Effect> fx = new List<Effect>();
                List<Effect> tfx = new List<Effect>();
                foreach (Effect e in this.Effects)
                {
                    fx.Add(new Effect(AdjustBonus(OtherFill, e.Bonus), e.Description, AdjustDuration(OtherFill, e.Duration)));
                    tfx.Add(new Effect(AdjustBonus(Fill, e.Bonus), e.Description, AdjustDuration(Fill, e.Duration)));
                }

                Effects = tfx;
                Value = new PriceTag(AdjustValue(Fill, Value.basevalue));

                return new Potion(fx, OtherFill, AdjustValue(OtherFill, Value.basevalue));

            }

            public void Dilute(byte fill)
            {
                Value = new PriceTag((long)(Value.basevalue * (fill*0.002f)));
                Fill += fill;
            }

        }

        /*------------------------- Field and Property Declaration -------------------------*/

        public enum FlagList
        {
            QuantityLocked
        }

        private dynamic quant = 0; //This value is ever either an uint or a bool

        public string Name { get; set; }
        public string Description { get; set; }
        public PriceTag Value { get; set; }
        public float Weight { get; set; }
        public List<string> Notes { get; set; }
        public float RangeIncrement { get; set; }
        public uint Quantity
        {
            get
            {
                return Flags[FlagList.QuantityLocked] ? Convert.ToInt32(quant) : quant;
            }
            set
            {
                if (Flags[FlagList.QuantityLocked])
                {
                    if(value.GetType() == true.GetType()) //If it's a boolean
                    {
                        quant = value;
                        return;
                    }
                    quant = (value > 0) ? true : false;
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

        public Item()
        {
            Flags = new FlagsArray<FlagList>();
            Value = new PriceTag();
            Notes = new List<string>();
        }
        public Item(long v)
        {
            Flags = new FlagsArray<FlagList>();
            Value = new PriceTag(v);
            Notes = new List<string>();
        }
        public Item(PriceTag v)
        {
            Flags = new FlagsArray<FlagList>();
            Value = v;
            Notes = new List<string>();
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

            public Bag() : base()
            {
            }

        }

        public class Slot<T> : Bag<T> where T : Item
        {
            new public void Add(T item)
            {
                item.LockQuantity();
                base.Add(item);
            }
        }

        public class Equipped : Inventory
        {
            [JsonPropertyName("EquippedArmor")]
            new public Slot<Item.Armor> Armors { get; set; }

            [JsonPropertyName("EquippedWeapons")]
            new public Slot<Item.Weapon>[] Weapons { get; set; }
            public List<Inventory> Bags { get; set; }
            
            new public float Weight
            {
                get
                {
                    float v = 0;
                    foreach(Item.Armor i in Armors)
                    {
                        v += i.Weight;
                    }
                    foreach(Slot<Item.Weapon> S in Weapons)
                    {
                        foreach(Item.Weapon i in S)
                        {
                            v += i.Weight;
                        }
                    }
                    foreach(Inventory i in Bags)
                    {
                        v += i.Weight;
                    }
                    v += base.Weight;
                    return v;
                }
            }

            public int MaximumDexterity
            {
                get
                {
                    int v = 2_147_483_647;
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

            public Equipped()
            {
                Armors = new Slot<Item.Armor>();
                Weapons = new Slot<Item.Weapon>[3];
                for(int i = 0; i < Weapons.Length; i++)
                {
                    Weapons[i] = new Slot<Item.Weapon>();
                }
                Other = new Slot<Item>();
                Keychain = new Slot<Item.Key>();
                Bags = new List<Inventory>();
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
        public float MaximumWeight { get; set; }

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
        public float Weight
        {
            get
            {
                float v = 0;
                foreach(Item i in Armors)
                {
                    v += i.Weight * i.Quantity;
                }
                foreach(Bag<Item.Weapon> list in Weapons) //But a Slot inherits a Bag so it's okay to not hide this
                {
                    foreach(Item i in list)
                    {
                        v += i.Weight * i.Quantity;
                    }
                }
                foreach(Item i in Other)
                {
                    v += i.Weight * i.Quantity;
                }
                foreach(Item i in Keychain)
                {
                    v += i.Weight * i.Quantity;
                }
                foreach(Item i in Potions)
                {
                    v += i.Weight;
                }
                return v;
            }
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public PriceTag Value
        {
            get
            {
                long v = 0;
                foreach (Item i in Armors)
                {
                    v += i.Value.basevalue * i.Quantity;
                }
                foreach (Bag<Item.Weapon> list in Weapons) //But a Slot inherits a Bag so it's okay to not hide this
                {
                    foreach (Item i in list)
                    {
                        v += i.Value.basevalue * i.Quantity;
                    }
                }
                foreach (Item i in Other)
                {
                    v += i.Value.basevalue * i.Quantity;
                }
                foreach (Item i in Keychain)
                {
                    v += i.Value.basevalue * i.Quantity;
                }
                return new PriceTag(v);
            }
        }

        public Inventory()
        {
            Armors = new Bag<Item.Armor>();
            Weapons = new Bag<Item.Weapon>[3];
            for(int i = 0; i < Weapons.Length; i++)
            {
                Weapons[i] = new Bag<Item.Weapon>();
            }
            Other = new Bag<Item>();
            Keychain = new Bag<Item.Key>();
            Potions = new Slot<Item.Potion>();
        }

    }

}
