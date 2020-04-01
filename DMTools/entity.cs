using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

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

        public byte SkillPointModifier { get; set; } //Added to the class and race skill points for calculation
        public byte ExtraSkillPoints { get; set; }  //Added to the final calculation of skill points
        public ExperienceGrant Expgrant { get; set; }
        public ArmorClass ArmorC { get; set; }
        public Health Health { get; set; }
        public Description Desc { get; set; }
        public Job Job { get; set; }

        public uint[] SpentSpells
        {
            get
            {
                return spentSpells;
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

        public int GetMod(Stats stat)
        {
            byte i = (byte)stat;
            return ((this.baseStats[i] + this.miscBuffs[i] + this.tempStats[i]) / 2) - 5;
        }

        public int GetMod(Stats a, Stats b)
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

        protected Entity(byte level, string name)
        {
            this.level = level;
            this.Expgrant = new ExperienceGrant(this, 69, 120);
            this.Health = new Health(this);
            this.ArmorC = new ArmorClass(this,null,null,null,null,null,null,null);
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

        public byte FreeLevels { get; set; }
        public Experience Exp { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Ability> Feats
        {
            get
            {
                return feats;
            }
        }
        public List<Ability> Abilities
        {
            get
            {
                return abilities;
            }
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
            return newchar.Register();
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

        new public int GetMod(Stats stat)
        {
            byte i = (byte)stat;
            return ((this.baseStats[i] + this.miscBuffs[i] + this.tempStats[i] + this.GetAbilityBuffs(stat) + this.GetFeatBuffs(stat)) / 2) - 5;
        }

    }

    public struct ExperienceGrant
    {

        public uint Baseexp { get; set; }
        public uint Extra { get; set; }

        private readonly Entity parent;

        public ExperienceGrant(Entity parent)
        {
            this.parent = parent;
            this.Baseexp = 1;
            this.Extra = 0;
        }
        public ExperienceGrant(Entity parent, uint b)
        {
            this.parent = parent;
            this.Baseexp = b;
            this.Extra = 0;
        }
        public ExperienceGrant(Entity parent, uint b, uint e)
        {
            this.parent = parent;
            this.Baseexp = b;
            this.Extra = e;
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
        public uint Current { get; private set; }
        public uint Required { get; private set; }

        private readonly List<int> history;
        private readonly Character parent;

        public Experience(Character p)
        {
            this.parent = p;
            this.Current = 0;
            this.Multiplier = 1F;
            this.Required = 0;
            this.history = new List<int>();
            this.SetRequired();
        }

        public int GetHistory(int i)
        {
            return this.history[i];
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public int HistoryEntries
        {
            get
            {
                return this.history.Count;
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
            this.Current += v;
        }

        public void Sub(uint v)
        {
            if (v > this.Current)
            {
                this.Current = 0;
            }
            else
            {
                this.Current -= v;
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
            this.history.Add((int)v);
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

        //More stuff happens when an entity levels up, but that requires the Job and Job.Growth structures
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

    public struct ArmorClass: IFlagged<ArmorClass.Flags>
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

        private readonly Entity parent;
        public bool[] FlagsArr { get; set; }

        public bool GetFlag(Flags i)
        {
            return FlagsArr[(byte)i];
        }

        ///----------------------------  armor,  size, natural, deflex, temporary,     misc, baseac
        public ArmorClass(Entity parent, int? a, int? s, int? n, int? d, int? temp, int? misc, int? b)
        {
            this.parent = parent;
            if(a == null)
            {
                Baseac = 0;
            }
            else
            {
                Baseac = (int)b;
            }

            if (s == null)
            {
                Size = 0;
            }
            else
            {
                Size = (int)s;
            }

            if (n == null)
            {
                Natural = 0;
            }
            else
            {
                Natural = (int)n;
            }

            if (d == null)
            {
                Deflex = 0;
            }
            else
            {
                Deflex = (int)d;
            }

            if (temp == null)
            {
                Temporary = 0;
            }
            else
            {
                Temporary = (int)temp;
            }

            if (misc == null)
            {
                Misc = 0;
            }
            else
            {
                Misc = (int)misc;
            }

            if (a == null)
            {
                Armor = 0;
            }
            else
            {
                Armor = (int)a;
            }

            this.FlagsArr = new bool[1];
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

        public uint Damage { get; private set; }
        private readonly List<int> history;

        public Hurt(uint dmg)
        {
            this.Damage = dmg;
            this.history = new List<int>();
        }

        public int GetHistory(int i)
        {
            return this.history[i];
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public int HistoryEntries
        {
            get
            {
                return this.history.Count;
            }
        }

        public void Harm(int d)
        {
            if ((d < 0) && (Math.Abs(d) > this.Damage))
            {
                this.Damage = 0u;
            }
            else
            {
                this.Damage = (uint)(this.Damage + d);
            }
            this.history.Add(d);
        }

        public void Heal(int h)
        {
            if (h > this.Damage)
            {
                this.Damage = 0u;
            }
            else
            {
                this.Damage = (uint)(this.Damage - h);
            }
            this.history.Add(-h);
        }

    }

    public struct Health
    {

        public uint Basehp { get; private set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public Hurt LethalDamage { get; }
        [IgnoreDataMember]
        [JsonIgnore]
        public Hurt NonlethalDamage { get; }

        public List<uint> HpThrows { get; set; } //This is a List, as opposed to a simple Array, because while usually levels cap out at 20, this is D&D we're talking about. I want the user to be able to expand it as necessary.
        //This list will have to be displayed and handled with this in mind.
        private readonly Entity parent;

        public Health(Entity p)
        {
            this.Basehp = 0;
            this.parent = p;
            this.LethalDamage = new Hurt(0);
            this.NonlethalDamage = new Hurt(0);
            this.HpThrows = new List<uint>(new uint[20]);
        }
        public Health(Entity p, uint h)
        {
            this.Basehp = h;
            this.parent = p;
            this.LethalDamage = new Hurt(0);
            this.NonlethalDamage = new Hurt(0);
            this.HpThrows = new List<uint>(new uint[20]);

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

        private bool[] FlagsArr { get; }
        private readonly Entity parent;

        public Skill(Entity p, string name, Stats keyStat)
        {
            this.parent = p;
            this.Name = name;
            this.KeyStat = keyStat;
            this.MiscLevels = 0;
            this.Level = 0;
            this.FlagsArr = new bool[Enum.GetNames(typeof(Skill.Flags)).Length];
        }
        public Skill(Entity p, string name, Stats keyStat, uint miscLevels)
        {
            this.parent = p;
            this.Name = name;
            this.KeyStat = keyStat;
            this.MiscLevels = miscLevels;
            this.Level = 0;
            this.FlagsArr = new bool[Enum.GetNames(typeof(Skill.Flags)).Length];
        }
        public Skill(Entity p, string name, Stats keyStat, uint miscLevels, uint level)
        {
            this.parent = p;
            this.Name = name;
            this.KeyStat = keyStat;
            this.MiscLevels = miscLevels;
            this.Level = level;
            this.FlagsArr = new bool[Enum.GetNames(typeof(Skill.Flags)).Length];
        }
        public Skill(Entity p, string name, Stats keyStat, uint miscLevels, uint level, bool[] flg)
        {
            this.parent = p;
            this.Name = name;
            this.KeyStat = keyStat;
            this.MiscLevels = miscLevels;
            this.Level = level;
            this.FlagsArr = flg;
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
        public bool[] FlagsArr { get; }
        public int[] Buffs { get; }

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