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
        [IgnoreDataMember]
        protected int[] baseStats = new int[App.statCount];
        protected int[] tempStats = new int[App.statCount];
        protected int[] miscBuffs = new int[App.statCount];

        [IgnoreDataMember]
        protected int id;
        [IgnoreDataMember]
        protected int pid; //player list id
        protected Player player;
        protected byte level = 1;
        protected List<Skill> skills = new List<Skill>();
        protected uint[] spentSpells = new uint[Cf.Options.EntityValues["maxSpellLevel"]];

        protected ExperienceGrant expgrant;
        protected ArmorClass armorclass;
        protected Health health;
        protected Job job;

        public byte SkillPointModifier { get; set; } //Added to the class and race skill points for calculation
        public byte ExtraSkillPoints { get; set; }  //Added to the final calculation of skill points
        public Description Desc { get; set; }

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
        public Health Health
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
        public Job Job
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

        public virtual int GetMod(Stats stat)
        {
            byte i = (byte)stat;
            return ((this.baseStats[i] + this.miscBuffs[i] + this.tempStats[i]) / 2) - 5;
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
            newent.RenovateParenthood();
            int newentid = newent.Register();

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
            this.Health = new Health(this);
            this.ArmorC = new ArmorClass(this,0,0,0,0,0,0,0);
            this.Health.SetBaseHP();
            this.skills.Add(new Skill(this, "Lockpicking", Stats.dexterity, 0, 5, new bool[] { true, false, true }));
            this.skills.Add(new Skill(this, "Diplomacy", Stats.charisma, 3, 2, new bool[] { true, false, false }));
            this.Desc = new Description(name);
        }

    }

    public class Character : Entity
    {

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
            this.feats.Add(new Ability("Fleeting Presence", null, "This character can disappear from existence at will", new List<string>(), new int[App.statCount], new bool[] { true, false, false, true }));
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
            newchar.RenovateParenthood();
            int newcharid = newchar.Register();

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
            return ((this.baseStats[i] + this.miscBuffs[i] + this.tempStats[i] + this.GetAbilityBuffs(stat) + this.GetFeatBuffs(stat)) / 2) - 5;
        }
        public override int GetMod(Stats a, Stats b)
        {
            return (GetMod(b) + (GetMod(a) * 2)) / 2;
        }

    }

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

            Log.Verbose("Created new {0} object for {1} {2} of ID {3}", this.GetType().ToString(), parent.GetType().ToString(), this.parent.Desc.Name, this.parent.Id);

        }
        public ExperienceGrant(Entity parent, uint b)
        {
            this.parent = parent;
            this.Baseexp = b;
            this.Extra = 0;

            Log.Verbose("Created new {0} object for {1} {2} of ID {3}", this.GetType().ToString(), parent.GetType().ToString(), this.parent.Desc.Name, this.parent.Id);

        }
        public ExperienceGrant(Entity parent, uint b, uint e)
        {
            this.parent = parent;
            this.Baseexp = b;
            this.Extra = e;

            Log.Verbose("Created new {0} object for {1} {2} of ID {3}", GetType().ToString(), this.parent.GetType().ToString(), this.parent.Desc.Name, this.parent.Id);

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

    public struct Experience : IHistoried<int>
    {

        public float Multiplier { get; set; }
        public uint crt;
        public uint Required { get; set; }
        public List<int> History { get; set; }
        public uint Current
        {
            get
            {
                return crt;
            }
            set
            {
                if(this.parent != null)
                {
                    this.Gain((uint)Math.Abs(this.crt - value));
                }
                else
                {
                    Add(value);
                    this.History.Add((int)value);
                }
            }
        }


        [IgnoreDataMember]
        public Character parent;

        public Experience(Character p)
        {
            this.parent = p;
            this.crt = 0;
            this.Multiplier = 1F;
            this.Required = 0;
            this.History = new List<int>();
            this.SetRequired();

            Log.Verbose("Created new {0} object for {1} {2} of ID {3}", this.GetType().ToString(), parent.GetType().ToString(), this.parent.Desc.Name, this.parent.Id);

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

        public void Add(uint v)
        {
            this.crt += v;
        }

        public void Sub(uint v)
        {
            if (v > this.crt)
            {
                this.crt = 0;
            }
            else
            {
                this.crt -= v;
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



        public void Gain(uint v)
        {
            this.Add((uint)(v * (this.Multiplier * this.FreeLevelmultiplier)));
            this.History.Add((int)v);
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
            this.Required = (uint)((l + 1) * (l) * 500);
        }

    }

    public struct ArmorClass : IFlagged<ArmorClass.Flags>
    {

        public enum Flags
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
        public bool[] FlagsArr { get; set; }

        [IgnoreDataMember]
        public Entity parent;

        public bool GetFlag(Flags i)
        {
            return FlagsArr[(byte)i];
        }

        ///----------------------------  armor,  size, natural, deflex, temporary,     misc, baseac
        public ArmorClass(Entity parent, int a, int s, int n, int d, int temp, int misc, int b)
        {
            this.parent = parent;
            Armor = a;
            Size = s;
            Natural = n;
            Deflex = d;
            Temporary = temp;
            Misc = misc;
            Baseac = b;
            this.FlagsArr = new bool[1];

            Log.Verbose("Created new {0} object for {1} {2} of ID {3}", this.GetType().ToString(), parent.GetType().ToString(), this.parent.Desc.Name, this.parent.Id);

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
                if (GetFlag(Flags.featDex))
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

    public struct Hurt : IHistoried<int>
    {

        private uint dmg;
        public uint Damage {
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

        public Hurt(uint dmg)
        {
            this.dmg = dmg;
            this.History = new List<int>();
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

    public struct Health
    {

        private uint Basehp;

        public Hurt LethalDamage { get; set; }
        public Hurt NonlethalDamage { get; set; }

        public List<uint> HpThrows { get; set; } //This is a List, as opposed to a simple Array, because while usually levels cap out at 20, this is D&D we're talking about. I want the user to be able to expand it as necessary.
        //This list will have to be displayed and handled with this in mind.

        [IgnoreDataMember]
        public Entity parent;

        public Health(Entity p)
        {
            this.Basehp = 0;
            this.parent = p;
            this.LethalDamage = new Hurt(0);
            this.NonlethalDamage = new Hurt(0);
            this.HpThrows = new List<uint>(new uint[20]);

            Log.Verbose("Created new {0} object for {1} {2} of ID {3}", this.GetType().ToString(), parent.GetType().ToString(), this.parent.Desc.Name, this.parent.Id);

        }
        public Health(Entity p, uint h)
        {
            this.Basehp = h;
            this.parent = p;
            this.LethalDamage = new Hurt(0);
            this.NonlethalDamage = new Hurt(0);
            this.HpThrows = new List<uint>(new uint[20]);

            Log.Verbose("Created new {0} object for {1} {2} of ID {3}", this.GetType().ToString(), parent.GetType().ToString(), this.parent.Desc.Name, this.parent.Id);

        }

        public void SetBaseHP()
        {
            for (byte i = 0; i <= this.parent.Level; i++)
            {
                int n = (int)(this.HpThrows[i] + this.parent.GetMod(Stats.constitution));
                if (n > 1)
                {
                    this.Basehp = (uint)(this.Basehp + n);
                }
                else
                {
                    this.Basehp++;
                }
            }
        }
        public uint BaseHP
        {
            set
            {
                this.Basehp = value;
            }
            get
            {
                return this.Basehp;
            }
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public int HP
        {
            get
            {
                return (int)(this.Basehp - (this.LethalDamage.Damage + this.NonlethalDamage.Damage));
            }
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public int NlHP
        {
            get
            {
                return (int)(this.Basehp - this.LethalDamage.Damage);
            }
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public bool Dead
        {
            get
            {
                return this.HP <= Cf.Options.EntityValues["dead"];
            }
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public bool BleedingOut
        {
            get
            {
                return this.HP <= Cf.Options.EntityValues["bleedingOut"];
            }
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public bool Down
        {
            get
            {
                return this.HP <= Cf.Options.EntityValues["down"];
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

    public struct Description
    {

        public string Name { get; set; }
        public string Fullname { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        public string Deity { get; set; }
        public string BodyType { get; set; }
        public string Size { get; set; }
        public string Bio { get; set; }
        public string Intro { get; set; }
        public string Personality { get; set; }
        public string Gender { get; set; }
        public List<string> Notes { get; set; }
        public ulong Age { get; set; }
        public uint Height { get; set; } //cm
        public float Weight { get; set; } //kg
        public Color Eyes { get; set; }
        public Color Hair { get; set; }
        public Color Skin { get; set; }
        public Color? Bgcolor { get; set; }
        public Color? BannerColor { get; set; }
        public Image Mugshot { get; set; }
        public Image FullBody { get; set; }
        public List<Image> ArcaneMarks { get; set; }

        public Description(string name)
        {
            this.Name = name;
            this.Fullname = name;
            this.Race = "Human";
            this.Alignment = "True Neutral";
            this.Deity = "None";
            this.BodyType = "Humanoid";
            this.Size = "Medium";
            this.Bio = "None";
            this.Intro = "No intro";
            this.Personality = "Blank";
            this.Gender = "Unknown";
            this.Notes = new List<string>();
            this.Age = 0;
            this.Height = 0;
            this.Weight = 0;
            this.Eyes = Color.FromName("White");
            this.Hair = Color.FromName("Black");
            this.Skin = Color.FromName("Bisque");
            this.Bgcolor = null;
            this.BannerColor = null;
            this.Mugshot = null;
            this.FullBody = null;
            this.ArcaneMarks = new List<Image>();
        }

    }

    public struct Skill : IFlagged<Skill.Flags>
    {

        public enum Flags
        {
            trainedOnly, penalizedByArmor, JobSkill
        };

        public string Name { get; set; }
        public Stats KeyStat { get; set; }
        public uint Level { get; set; }
        public uint MiscLevels { get; set; }

        private bool[] FlagsArr { get; set; }

        [IgnoreDataMember]
        public Entity parent;

        public Skill(Entity p, string name, Stats keyStat)
        {
            this.parent = p;
            this.Name = name;
            this.KeyStat = keyStat;
            this.MiscLevels = 0;
            this.Level = 0;
            this.FlagsArr = new bool[Enum.GetNames(typeof(Skill.Flags)).Length];

            Log.Verbose("Created new {0} object for {1} {2} of ID {3}", this.GetType().ToString(), parent.GetType().ToString(), this.parent.Desc.Name, this.parent.Id);

        }
        public Skill(Entity p, string name, Stats keyStat, uint miscLevels)
        {
            this.parent = p;
            this.Name = name;
            this.KeyStat = keyStat;
            this.MiscLevels = miscLevels;
            this.Level = 0;
            this.FlagsArr = new bool[Enum.GetNames(typeof(Skill.Flags)).Length];

            Log.Verbose("Created new {0} object for {1} {2} of ID {3}", this.GetType().ToString(), parent.GetType().ToString(), this.parent.Desc.Name, this.parent.Id);

        }
        public Skill(Entity p, string name, Stats keyStat, uint miscLevels, uint level)
        {
            this.parent = p;
            this.Name = name;
            this.KeyStat = keyStat;
            this.MiscLevels = miscLevels;
            this.Level = level;
            this.FlagsArr = new bool[Enum.GetNames(typeof(Skill.Flags)).Length];

            Log.Verbose("Created new {0} object for {1} {2} of ID {3}", this.GetType().ToString(), parent.GetType().ToString(), this.parent.Desc.Name, this.parent.Id);

        }
        public Skill(Entity p, string name, Stats keyStat, uint miscLevels, uint level, bool[] flg)
        {
            this.parent = p;
            this.Name = name;
            this.KeyStat = keyStat;
            this.MiscLevels = miscLevels;
            this.Level = level;
            this.FlagsArr = flg;

            Log.Verbose("Created new {0} object for {1} {2} of ID {3}", this.GetType().ToString(), parent.GetType().ToString(), this.parent.Desc.Name, this.parent.Id);

        }

        public bool GetFlag(Skill.Flags i)
        {
            return this.FlagsArr[(byte)i];
        }
        public void Train(uint l)
        {
            this.Level += l;
        }
        public long Mod
        {
            get
            {
                int val = (int)(this.parent.GetMod(this.KeyStat) + this.MiscLevels);
                if (this.GetFlag(Flags.JobSkill))
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

    public struct Ability : IFlagged<Ability.Flags>
    {

        public enum Flags
        {
            extraordinary, spellLike, psiLike, supernatural
        };

        public string Name { get; set; }
        public string Requirements { get; set; }
        public string Description { get; set; }
        public List<string> Notes { get; set; }
        public bool[] FlagsArr { get; set; }
        public int[] Buffs { get; set; }

        public Ability(string n, string re, string de)
        {
            this.Name = n;
            this.Description = de;
            this.Notes = new List<string>();
            this.Buffs = new int[Enum.GetNames(typeof(Stats)).Length];
            this.FlagsArr = new bool[Enum.GetNames(typeof(Ability.Flags)).Length];

            if (re == "null" || re == "" || re == null)
            {
                this.Requirements = Cf.Lang.ent["noRequirements"];
            }
            else
            {
                this.Requirements = re;
            }

        }
        public Ability(string n, string re, string de, List<string> notes)
        {
            this.Name = n;
            this.Description = de;
            this.Notes = notes;
            this.Buffs = new int[Enum.GetNames(typeof(Stats)).Length];
            this.FlagsArr = new bool[Enum.GetNames(typeof(Ability.Flags)).Length];

            if (re == "null" || re == "" || re == null)
            {
                this.Requirements = Cf.Lang.ent["noRequirements"];
            }
            else
            {
                this.Requirements = re;
            }

        }
        public Ability(string n, string re, string de, List<string> nts, int[] bfs)
        {
            this.Name = n;
            this.Description = de;
            this.Notes = nts;
            this.Buffs = bfs;
            this.FlagsArr = new bool[Enum.GetNames(typeof(Ability.Flags)).Length];

            if (re == "null" || re == "" || re == null)
            {
                this.Requirements = Cf.Lang.ent["noRequirements"];
            }
            else
            {
                this.Requirements = re;
            }

        }
        public Ability(string n, string re, string de, List<string> nts, int[] bfs, bool[] flg)
        {
            this.Name = n;
            this.Description = de;
            this.Notes = nts;
            this.Buffs = bfs;
            this.FlagsArr = flg;

            if (re == "null" || re == "" || re == null)
            {
                this.Requirements = Cf.Lang.ent["noRequirements"];
            }
            else
            {
                this.Requirements = re;
            }

        }


        public bool GetFlag(Ability.Flags ind)
        {
            return this.FlagsArr[(byte)ind];
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public string FullName
        {
            get
            {
                string str = this.Name;
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
                if(c.Length > 0)
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

    public struct Job
    {

        public struct Growth
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