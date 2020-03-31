using System;
using System.Collections.Generic;
using System.Drawing;

namespace DMTools
{

    public class Entity
    {

        protected int[] baseStats = new int[App.statCount];
        protected int[] tempStats = new int[App.statCount];
        protected int[] miscBuffs = new int[App.statCount];

        protected int id;
        protected int pid; //player list id
        protected Player player;

        public byte skillPointModifier; //Added to the class and race skill points for calculation
        public byte extraSkillPoints; //Added to the final calculation of skill points
        public byte level = 1;
        public ExperienceGrant expgrant;
        public ArmorClass armorC;
        public Health health;
        public Description desc;
        public List<Skill> skills = new List<Skill>();
        public Job job;
        public uint[] spentSpells = new uint[Cf.Options.EntityValues["maxSpellLevel"]];

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

        public int GetTempStats(Stats ind)
        {
            return this.tempStats[(byte)ind];
        }
        public void AddTempStats(Stats ind, int x)
        {
            this.tempStats[(byte)ind] += x;
        }
        public void SetTempStats(Stats ind, int x)
        {
            this.tempStats[(byte)ind] = x;
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

        virtual public int GetMod(Stats stat)
        {
            byte i = (byte)stat;
            return ((this.baseStats[i] + this.miscBuffs[i] + this.tempStats[i]) / 2) - 5;
        }

        virtual public int GetMod(Stats a, Stats b)
        {
            return (GetMod(b) + (GetMod(a) * 2)) / 2;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public Player GetPlayer()
        {
            return this.player;
        }

        virtual public void SetPlayer(Player ply)
        {
        }

        public static int Create(byte level, string name)
        {
            return new Entity(level, name).Register();
        }

        public void Unregister()
        {
            Loaded.Entities.Remove(this.id);
        }

        private int Register()
        {
            this.id = Loaded.Entities.Add(this);
            return id;
        }

        private Entity(byte level, string name)
        {
            this.level = level;
            expgrant = new ExperienceGrant(this, 69, 120);
            this.health = new Health(this);
            this.armorC = new ArmorClass(this);
            this.health.SetBaseHP();
            this.skills.Add(new Skill(this, "Lockpicking", Stats.dexterity, 0, 5, new bool[] { true, false, true }));
            this.skills.Add(new Skill(this, "Diplomacy", Stats.charisma, 3, 2, new bool[] { true, false, false }));
            this.desc = new Description(name);
            this.Register();
        }
        public Entity(byte level, string name, bool? hasParent)
        {
            this.level = level;
            this.expgrant = new ExperienceGrant(this, 69, 120);
            this.health = new Health(this);
            this.armorC = new ArmorClass(this);
            this.health.SetBaseHP();
            this.skills.Add(new Skill(this, "Lockpicking", Stats.dexterity, 0, 5, new bool[] { true, false, true }));
            this.skills.Add(new Skill(this, "Diplomacy", Stats.charisma, 3, 2, new bool[] { true, false, false }));
            this.desc = new Description(name);
        }

    }

    public class Character : Entity
    {

        public byte freeLevels;
        public Experience exp;
        public List<Ability> feats = new List<Ability>();
        public List<Ability> abilities = new List<Ability>();
        new public List<Job> job;

        private Character(byte level, string name) : base(level, name, null)
        {
            this.exp = new Experience(this);
            this.feats.Add(new Ability("Fleeting Presence", null, "This character can disappear from existence at will", new List<string>(), new int[App.statCount], new bool[] { true, false, false, true }));
            this.abilities.Add(new Ability("Power Surge", null, "Augments strength and constitution", new List<string>(), new int[] { 2, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
            this.Register();
        }

        new public static int Create(byte level, string name)
        {
            return new Character(level, name).Register();
        }

        new public void Unregister()
        {
            Loaded.Characters.Remove(this.id);
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
                total += abi.buffs[(byte)ind];
            }
            return total;
        }

        public int GetFeatBuffs(Stats ind)
        {
            int total = 0;
            foreach (Ability abi in this.feats)
            {
                total += abi.buffs[(byte)ind];
            }
            return total;
        }

        override public int GetMod(Stats stat)
        {
            byte i = (byte)stat;
            return ((this.baseStats[i] + this.miscBuffs[i] + this.tempStats[i] + this.GetAbilityBuffs(stat) + this.GetFeatBuffs(stat)) / 2) - 5;
        }

    }

    public struct ExperienceGrant
    {

        public uint baseexp;
        public uint extra;

        private Entity parent;

        public ExperienceGrant(Entity parent)
        {
            this.parent = parent;
            this.baseexp = 1;
            this.extra = 0;
        }
        public ExperienceGrant(Entity parent, uint b)
        {
            this.parent = parent;
            this.baseexp = b;
            this.extra = 0;
        }
        public ExperienceGrant(Entity parent, uint b, uint e)
        {
            this.parent = parent;
            this.baseexp = b;
            this.extra = e;
        }

        public uint Grant
        {
            get
            {
                byte l = this.parent.level;
                return (uint)(((l * (l - 1) * 500) + (this.baseexp * l)) + this.extra);
            }
        }

    }

    public struct Experience : IHistoried<int>
    {

        public float multiplier;

        private uint current;
        private uint required;

        private readonly List<int> history;
        private readonly Character parent;

        public Experience(Character p)
        {
            this.parent = p;
            this.current = 0;
            this.multiplier = 1F;
            this.required = 0;
            this.history = new List<int>();
            this.SetRequired();
        }

        public uint Current
        {
            get
            {
                return this.current;
            }
        }

        public int GetHistory(int i)
        {
            return this.history[i];
        }

        public int HistoryEntries
        {
            get
            {
                return this.history.Count;
            }
        }

        public int Left
        {
            get
            {
                return (int)(this.required - this.current);
            }
        }

        public int Progress
        {
            get
            {
                return (int)(((float)(this.current) / (float)(this.required)) * 100f);
            }
        }

        public void Add(uint v)
        {
            this.current += v;
        }

        public void Sub(uint v)
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
        public float FreeLevelmultiplier
        {
            get
            {
                switch (this.parent.freeLevels)
                {
                    case 0:
                        return 1F;
                        break;
                    case 1:
                        return 0.75F;
                        break;
                    case 2:
                        return 0.5F;
                        break;
                    case 3:
                        return 0.25F;
                        break;
                    default:
                        throw new TooManyFreeLevels(String.Format("The entity \"{0}\" of ID \"{1}\" has too many free levels", this.parent.desc.name, this.parent.Id));
                        break;
                }
            }
        }



        public void Gain(uint v)
        {
            this.Add((uint)(v * (this.multiplier * this.FreeLevelmultiplier)));
            this.history.Add((int)v);
        }

        public bool DidLevel
        {
            get
            {
                return this.current >= this.required;
            }
        }

        //More stuff happens when an entity levels up, but that requires the Job and Job.Growth structures
        public void LevelUp()
        {
            if (this.DidLevel)
            {
                this.current -= this.required;
                this.parent.level++;
            }
            else
            {
                throw new CantLevelUpYet(String.Format("The entity \"{0}\" of ID \"{1}\" attempted to level up without a right to", this.parent.desc.name, this.parent.Id));
            }
        }

        public void SetRequired()
        {
            byte l = this.parent.level;
            this.required = (uint)((l + 1) * (l) * 500);
        }

        public uint Required
        {
            get
            {
                return this.required;
            }
            set
            {
                this.required = value;
            }
        }

    }

    public struct ArmorClass
    {

        public enum Flags
        {
            featDex
        }

        public int baseac; //base armor class
        public int armor;
        public int size;
        public int natural;
        public int deflex;
        public int temporary;
        public int misc;
        private int featDex; //A variable to use in case the character has a feat that enables dexterity to always be used
        private readonly Entity parent;
        private readonly bool[] flagsArr;

        public bool GetFlag(byte i)
        {
            return flagsArr[i];
        }

        ///----------------------------  armor,  size, natural, deflex, temporary,     misc, baseac
        public ArmorClass(Entity parent, int a, int s, int n, int d, int temp, int misc, int b)
        {
            this.parent = parent;
            this.baseac = b;
            this.armor = a;
            this.size = s;
            this.natural = n;
            this.deflex = d;
            this.temporary = temp;
            this.misc = misc;
            this.featDex = 0;
            this.flagsArr = new bool[1];
        }
        public ArmorClass(Entity parent, int a, int s, int n, int d, int temp, int misc)
        {
            this.parent = parent;
            this.baseac = 10;
            this.armor = a;
            this.size = s;
            this.natural = n;
            this.deflex = d;
            this.temporary = temp;
            this.misc = misc;
            this.featDex = 0;
            this.flagsArr = new bool[1];
        }
        public ArmorClass(Entity parent, int a, int s, int n, int d, int temp)
        {
            this.parent = parent;
            this.baseac = 10;
            this.armor = a;
            this.size = s;
            this.natural = n;
            this.deflex = d;
            this.temporary = temp;
            this.misc = 0;
            this.featDex = 0;
            this.flagsArr = new bool[1];
        }
        public ArmorClass(Entity parent, int a, int s, int n, int d)
        {
            this.parent = parent;
            this.baseac = 10;
            this.armor = a;
            this.size = s;
            this.natural = n;
            this.deflex = d;
            this.temporary = 0;
            this.misc = 0;
            this.featDex = 0;
            this.flagsArr = new bool[1];
        }
        public ArmorClass(Entity parent, int a, int s, int n)
        {
            this.parent = parent;
            this.baseac = 10;
            this.armor = a;
            this.size = s;
            this.natural = n;
            this.deflex = 0;
            this.temporary = 0;
            this.misc = 0;
            this.featDex = 0;
            this.flagsArr = new bool[1];
        }
        public ArmorClass(Entity parent, int a, int s)
        {
            this.parent = parent;
            this.baseac = 10;
            this.armor = a;
            this.size = s;
            this.natural = 0;
            this.deflex = 0;
            this.temporary = 0;
            this.misc = 0;
            this.featDex = 0;
            this.flagsArr = new bool[1];
        }
        public ArmorClass(Entity parent, int a)
        {
            this.parent = parent;
            this.baseac = 10;
            this.armor = a;
            this.size = 0;
            this.natural = 0;
            this.deflex = 0;
            this.temporary = 0;
            this.misc = 0;
            this.featDex = 0;
            this.flagsArr = new bool[1];
        }
        public ArmorClass(Entity parent)
        {
            this.parent = parent;
            this.baseac = 10;
            this.armor = 0;
            this.size = 0;
            this.natural = 0;
            this.deflex = 0;
            this.temporary = 0;
            this.misc = 0;
            this.featDex = 0;
            this.flagsArr = new bool[1];
        }

        public uint AC
        {
            get
            {
                int a = (this.baseac + this.armor + this.size + this.natural + this.deflex + this.temporary + this.misc + this.parent.GetMod(Stats.dexterity));
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

        public uint TouchAC
        {
            get
            {
                int a = (this.baseac + this.size + this.misc + this.deflex + this.parent.GetMod(Stats.dexterity));
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

        public uint UnawareAC
        {
            get
            {
                int a = (this.baseac + this.armor + this.size + this.natural + this.misc + this.featDex);
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

        public void EnableFeatDex(bool t)
        {
            if (t)
            {
                this.featDex = this.parent.GetMod(Stats.dexterity) + this.deflex;
            }
            else
            {
                this.featDex = 0;
            }
            this.flagsArr[(int)ArmorClass.Flags.featDex] = t;
        }

    }

    public struct Hurt : IHistoried<int>
    {

        private uint damage;
        private readonly List<int> history;

        public Hurt(uint dmg)
        {
            this.damage = dmg;
            this.history = new List<int>();
        }

        public uint Damage
        {
            get
            {
                return this.damage;
            }
        }
        public int GetHistory(int i)
        {
            return this.history[i];
        }

        public int HistoryEntries
        {
            get
            {
                return this.history.Count;
            }
        }

        public void Harm(int d)
        {
            if ((d < 0) && (Math.Abs(d) > this.damage))
            {
                this.damage = 0u;
            }
            else
            {
                this.damage = (uint)(this.damage + d);
            }
            this.history.Add(d);
        }

        public void Heal(int h)
        {
            if (h > this.damage)
            {
                this.damage = 0u;
            }
            else
            {
                this.damage = (uint)(this.damage - h);
            }
            this.history.Add(-h);
        }

    }

    public struct Health
    {

        private uint basehp;
        public Hurt lethalDamage;
        public Hurt nonlethalDamage;
        public List<uint> hpthrows; //This is a List, as opposed to a simple Array, because while usually levels cap out at 20, this is D&D we're talking about. I want the user to be able to expand it as necessary.
        //This list will have to be displayed and handled with this in mind.
        private readonly Entity parent;

        public Health(Entity p)
        {
            this.basehp = 0;
            this.parent = p;
            this.lethalDamage = new Hurt(0);
            this.nonlethalDamage = new Hurt(0);
            this.hpthrows = new List<uint>(new uint[20]);
        }
        public Health(Entity p, uint h)
        {
            this.basehp = h;
            this.parent = p;
            this.lethalDamage = new Hurt(0);
            this.nonlethalDamage = new Hurt(0);
            this.hpthrows = new List<uint>(new uint[20]);

        }

        public void SetBaseHP()
        {
            for (byte i = 0; i <= this.parent.level; i++)
            {
                int n = (int)(this.hpthrows[i] + this.parent.GetMod(Stats.constitution));
                if (n > 1)
                {
                    this.basehp = (uint)(this.basehp + n);
                }
                else
                {
                    this.basehp++;
                }
            }
        }
        public uint BaseHP
        {
            set
            {
                this.basehp = value;
            }
            get
            {
                return this.basehp;
            }
        }

        public int HP
        {
            get
            {
                return (int)(this.basehp - (this.lethalDamage.Damage + this.nonlethalDamage.Damage));
            }
        }

        public int NlHP
        {
            get
            {
                return (int)(this.basehp - this.lethalDamage.Damage);
            }
        }

        public bool Dead
        {
            get
            {
                return this.HP <= Cf.Options.EntityValues["dead"];
            }
        }

        public bool BleedingOut
        {
            get
            {
                return this.HP <= Cf.Options.EntityValues["bleedingOut"];
            }
        }

        public bool Down
        {
            get
            {
                return this.HP <= Cf.Options.EntityValues["down"];
            }
        }

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

    public struct Description
    {

        public string name;
        public string fullname;
        public string race;
        public string alignment;
        public string deity;
        public string bodyType;
        public string size;
        public string bio;
        public string intro;
        public string personality;
        public string gender;
        public List<string> notes;
        public ulong age;
        public uint height; //cm
        public float weight; //kg
        public Color eyes;
        public Color hair;
        public Color skin;
        public Color? bgcolor;
        public Color? bannerColor;
        public Image mugshot;
        public Image fullBody;
        public List<Image> arcaneMarks;

        public Description(string name)
        {
            this.name = name;
            this.fullname = name;
            this.race = "Human";
            this.alignment = "True Neutral";
            this.deity = "None";
            this.bodyType = "Humanoid";
            this.size = "Medium";
            this.bio = "None";
            this.intro = "No intro";
            this.personality = "Blank";
            this.gender = "Unknown";
            this.notes = new List<string>();
            this.age = 0;
            this.height = 0;
            this.weight = 0;
            this.eyes = Color.FromName("White");
            this.hair = Color.FromName("Black");
            this.skin = Color.FromName("Bisque");
            this.bgcolor = null;
            this.bannerColor = null;
            this.mugshot = null;
            this.fullBody = null;
            this.arcaneMarks = new List<Image>();
        }

    }

    public struct Skill : IFlagged<Skill.Flags>
    {

        public enum Flags
        {
            trainedOnly, penalizedByArmor, JobSkill
        };

        public string name;
        public Stats keyStat;
        public uint level;
        public uint miscLevels;

        private bool[] flagsArr;
        private readonly Entity parent;

        public Skill(Entity p, string name, Stats keyStat)
        {
            this.parent = p;
            this.name = name;
            this.keyStat = keyStat;
            this.miscLevels = 0;
            this.level = 0;
            this.flagsArr = new bool[Enum.GetNames(typeof(Skill.Flags)).Length];
        }
        public Skill(Entity p, string name, Stats keyStat, uint miscLevels)
        {
            this.parent = p;
            this.name = name;
            this.keyStat = keyStat;
            this.miscLevels = miscLevels;
            this.level = 0;
            this.flagsArr = new bool[Enum.GetNames(typeof(Skill.Flags)).Length];
        }
        public Skill(Entity p, string name, Stats keyStat, uint miscLevels, uint level)
        {
            this.parent = p;
            this.name = name;
            this.keyStat = keyStat;
            this.miscLevels = miscLevels;
            this.level = level;
            this.flagsArr = new bool[Enum.GetNames(typeof(Skill.Flags)).Length];
        }
        public Skill(Entity p, string name, Stats keyStat, uint miscLevels, uint level, bool[] flg)
        {
            this.parent = p;
            this.name = name;
            this.keyStat = keyStat;
            this.miscLevels = miscLevels;
            this.level = level;
            this.flagsArr = flg;
        }

        public bool GetFlag(Skill.Flags i)
        {
            return this.flagsArr[(byte)i];
        }
        public void Train(uint l)
        {
            this.level += l;
        }
        public long Mod
        {
            get
            {
                int val = (int)(this.parent.GetMod(this.keyStat) + this.miscLevels);
                if (this.GetFlag(Flags.JobSkill))
                {
                    return val + this.level;
                }
                else
                {
                    return val + (this.level / 2);
                }
            }
        }

    }

    public struct Ability : IFlagged<Ability.Flags>
    {

        public enum Flags
        {
            extraordinary, spellLike, psiLike, supernatural
        };

        private string name;
        public string requirements;
        public string description;
        public List<string> notes;
        private bool[] flagsArr;
        public int[] buffs;

        public Ability(string n, string re, string de)
        {
            this.name = n;
            this.description = de;
            this.notes = new List<string>();
            this.buffs = new int[Enum.GetNames(typeof(Stats)).Length];
            this.flagsArr = new bool[Enum.GetNames(typeof(Ability.Flags)).Length];

            if (re == "null" || re == "" || re == null)
            {
                this.requirements = Cf.Lang.ent["noRequirements"];
            }
            else
            {
                this.requirements = re;
            }

        }
        public Ability(string n, string re, string de, List<string> notes)
        {
            this.name = n;
            this.description = de;
            this.notes = notes;
            this.buffs = new int[Enum.GetNames(typeof(Stats)).Length];
            this.flagsArr = new bool[Enum.GetNames(typeof(Ability.Flags)).Length];

            if (re == "null" || re == "" || re == null)
            {
                this.requirements = Cf.Lang.ent["noRequirements"];
            }
            else
            {
                this.requirements = re;
            }

        }
        public Ability(string n, string re, string de, List<string> nts, int[] bfs)
        {
            this.name = n;
            this.description = de;
            this.notes = nts;
            this.buffs = bfs;
            this.flagsArr = new bool[Enum.GetNames(typeof(Ability.Flags)).Length];

            if (re == "null" || re == "" || re == null)
            {
                this.requirements = Cf.Lang.ent["noRequirements"];
            }
            else
            {
                this.requirements = re;
            }

        }
        public Ability(string n, string re, string de, List<string> nts, int[] bfs, bool[] flg)
        {
            this.name = n;
            this.description = de;
            this.notes = nts;
            this.buffs = bfs;
            this.flagsArr = flg;

            if (re == "null" || re == "" || re == null)
            {
                this.requirements = Cf.Lang.ent["noRequirements"];
            }
            else
            {
                this.requirements = re;
            }

        }


        public bool GetFlag(Ability.Flags ind)
        {
            return this.flagsArr[(byte)ind];
        }

        public string FullName
        {
            get
            {
                string str = this.name;
                if (this.GetFlag(Ability.Flags.extraordinary))
                {
                    str += " (Ex)";
                }
                if (this.GetFlag(Ability.Flags.spellLike))
                {
                    str += " (Sl)";
                }
                if (this.GetFlag(Ability.Flags.psiLike))
                {
                    str += " (Pl)";
                }
                if (this.GetFlag(Ability.Flags.supernatural))
                {
                    str += " (Sn)";
                }
                return str;
            }
            set
            {
                this.name = value;
            }
        }

        public string AllNotes
        {
            get
            {
                const string a = "-{0}\n";
                string c = "";
                foreach (string b in notes)
                {
                    c += String.Format(a, b);
                }
                return c.Substring(0, c.Length - 1);
            }
        }

    }

    public class Job
    {

        public class Growth
        {


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