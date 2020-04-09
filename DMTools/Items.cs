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
                    return String.Join("", Pins);
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
            public byte Fill { get; set; } //Percentage

            public Potion(Potion other) :
                this(new List<Effect>(other.Effects), other.Fill, other.Value.basevalue)
            { }
            public Potion() :
                this(new List<Effect>(), 100, 0)
            { }
            public Potion(List<Effect> Fx, byte fill, long v) : base("","",new Mass(1M, Mass.Units.Pound),v)
            {
                LockQuantity();
                Effects = Fx;
                Fill = fill;
            }

            private int[] AdjustBonus(byte OtherFill, int[] OtherBonus)
            {
                float newfill = OtherFill / 100f;
                for (int i = 0; i < OtherBonus.Length; i++)
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
                    fx.Add(new Effect(e.Description, AdjustDuration(OtherFill, e.Duration), AdjustBonus(OtherFill, e.Bonus)));
                    tfx.Add(new Effect( e.Description, AdjustDuration(Fill, e.Duration), AdjustBonus(Fill, e.Bonus)));
                }

                Effects = tfx;
                Value = new PriceTag(AdjustValue(Fill, Value.basevalue));

                return new Potion(fx, OtherFill, AdjustValue(OtherFill, Value.basevalue));

            }

            public void Dilute(byte fill)
            {
                Value = new PriceTag((long)(Value.basevalue * (fill * 0.002f)));
                Fill += fill;
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
        public float RangeIncrement { get; set; }
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
        public Item(string name, string description, Mass weight, long value) :
            this(name, description, weight, value, 1)
        { }
        public Item(string name, string description, Mass weight, long value, uint quantity) :
            this(name, description, weight, value, quantity, new List<string>())
        { }
        public Item(string name, string description, Mass weight, long value, uint quantity, List<string> notes) :
            this(name, description, weight, value, quantity, notes, 1F)
        { }
        public Item(string name, string description, Mass weight, long value, uint quantity, List<string> notes, float rangeincrement) :
            this(name, description, weight, value, quantity, notes, rangeincrement, new FlagsArray<FlagList>())
        { }
        public Item(string name, string description, Mass weight, long value, uint quantity, List<string> notes, float rangeincrement, FlagsArray<FlagList> flg) :
            this(name, description, weight, new PriceTag(value), quantity, notes, rangeincrement, flg)
        { }
        public Item(string name, string description, Mass weight, PriceTag value, uint quantity, List<string> notes, float rangeincrement, FlagsArray<FlagList> flg)
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
