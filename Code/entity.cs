using System;
using System.Collections.Generic;
using System.Drawing;

namespace DnDTools{

    public class Entity{

        private int[] baseStats     = new int[Enum.GetNames(typeof(Stats)).Length];
        private int[] tempStats     = new int[Enum.GetNames(typeof(Stats)).Length];
        private int[] miscBuffs     = new int[Enum.GetNames(typeof(Stats)).Length];

        public byte skillPointModifier;
        public byte extraSkillPoints;
        public byte level = 1;
        private uint id;
        public ExperienceGrant expgrant;
        public ArmorClass armorC;
        public Health health;
        public Description desc;
        public List<Skill> skills;
        public uint[] spentSpells = new uint[Cf.Options.EntityValues["maxSpellLevel"]];

        public int getBaseStats(Stats ind){
            return this.baseStats[(byte)ind];
        }
        public void addBaseStats(Stats ind, int x){
            this.baseStats[(byte)ind] += x;
        }
        public void setBaseStats(Stats ind, int x){
            this.baseStats[(byte)ind] = x;
        }

        public int getTempStats(Stats ind){
            return this.tempStats[(byte)ind];
        }
        public void addTempStats(Stats ind, int x){
            this.tempStats[(byte)ind] += x;
        }
        public void setTempStats(Stats ind, int x){
            this.tempStats[(byte)ind] = x;
        }

        public int getMiscBuffs(Stats ind){
            return this.miscBuffs[(byte)ind];
        }
        public void addMiscBuffs(Stats ind, int x){
            this.miscBuffs[(byte)ind] += x;
        }
        public void setMiscBuffs(Stats ind, int x){
            this.miscBuffs[(byte)ind] = x;
        }

        public int getBaseMod(Stats stat){
            byte i = (byte)stat;
            return ((this.baseStats[i]+this.miscBuffs[i])/2)-5;
        }

        public int getMod(Stats stat){
            byte i = (byte)stat;
            return ((this.baseStats[i]+this.miscBuffs[i]+this.tempStats[i])/2)-5;
        }

        public uint getId(){
            return this.id;
        }

        public Entity(byte level, string name){
            this.level = level;
            this.expgrant = new ExperienceGrant(this,69,120);
            this.health = new Health(this);
            this.armorC = new ArmorClass(this);
            this.health.setBaseHP();
            this.skills.Add(new Skill(this, "Lockpicking", Stats.dex, 0, 5, true, false, true));
            this.skills.Add(new Skill(this, "Diplomacy", Stats.cha, 3, 2, true, false, false));
            this.desc = new Description(name);
        }

    }

    public class Character: Entity{
        public byte freeLevels;
        public Experience exp;

        public Character(byte level, string name): base(level,name){
            this.exp = new Experience(this);
        }
    }
    
    public struct ExperienceGrant{

        private uint baseexp;
        private uint extra;
        private Entity parent;

        public ExperienceGrant(Entity parent){
            this.parent = parent;
            this.baseexp = 1;
            this.extra = 0;
        }
        public ExperienceGrant(Entity parent, uint b){
            this.parent = parent;
            this.baseexp = b;
            this.extra = 0;
        }
        public ExperienceGrant(Entity parent, uint b, uint e){
            this.parent = parent;
            this.baseexp = b;
            this.extra = e;
        }

        public void setBaseGrant(uint b){
            this.baseexp = b;
        }

        public uint getBaseGrant(){
            return this.baseexp;
        }

        public void setExtra(uint b){
            this.extra = b;
        }

        public uint getExtra(){
            return this.extra;
        }

        public void addBase(uint b){
            this.baseexp = (this.baseexp+b);
        }

        public void subBase(uint b){
            this.baseexp = (this.baseexp-b);
        }

        public void addExtra(uint b){
            this.baseexp = (this.extra+b);
        }

        public void subExtra(uint b){
            this.baseexp = (this.extra-b);
        }

        public uint get(){
            byte l = this.parent.level;
            return (uint)(((l*(l-1)*500)+(this.baseexp*l))+this.extra);
        }

    }

    public struct Experience: Historied<uint,int>{

        private uint current;

        private uint required;

        private float multiplier;
        private List<int> history;
        private Character parent;

        public Experience(Character p){
            this.parent = p;
            this.current = 0;
            this.multiplier = 1F;
            this.required = 0;
            this.history = new List<int>();
            this.setRequired();
        }

        public uint get(){
            return this.current;
        }
        public int get(int i){
            return this.history[i];
        }
        
        public int getItems(){
            return this.history.Count;
        }

        public uint getRequired(){
            return this.required;
        }

        public int getRequiredLeft(){
            return (int)(this.required-this.current);
        }

        public void add(uint v){
            this.current += v;
        }

        public void sub(uint v){
            if(v > this.current){
                this.current = 0;
            }else{
                this.current -= v;
            }
        }

        public void setMultiplier(float v){
            this.multiplier = v;
        }

        ///<summary><c>SetFreeLevel</c> This method picks between the four available free level choices to set the multiplier. The range is 0-3.
        public float freeLevelmultiplier(byte fl){
            switch(fl){
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
                    throw new TooManyFreeLevels(String.Format("The entity \"{0}\" of ID \"{1}\" has too many free levels", this.parent.desc.name, this.parent.getId()));
                    break;
            }
        }

        public void gain(uint v){
            this.add((uint)(v*(this.multiplier*this.freeLevelmultiplier(this.parent.freeLevels))));
            this.history.Add((int)v);
        }

        public bool didLevel(){
            return this.current >= this.required;
        }

        //More stuff happens when an entity levels up, but that requires the Job and Job.Growth structures
        public void levelUp(){
            if(this.didLevel()){
                this.current -= this.required;
                this.parent.level++;
            }else{
                throw new CantLevelUpYet(String.Format("The entity \"{0}\" of ID \"{1}\" attempted to level up without a right to", this.parent.desc.name, this.parent.getId()));
            }
        }

        public void setRequired(){
            byte l = this.parent.level;
            this.required = (uint)((l+1)*(l)*500);
        }
        public void setRequired(uint v){
            this.required = (uint)v;
        }

    }

    public struct ArmorClass{

        public enum flags{
            featDex
        }

        public int baseac; //base armor class
        public int armor;
        public int size;
        public int natural;
        public int deflex;
        public int temporary;
        public int misc;
        private Entity parent;
        private int featDex; //A variable to use in case the character has a feat that enables dex to always be used
        private bool[] flagsArr;

        public bool getFlag(byte i){ //You'll notice there's no "set" method
            return flagsArr[i];
        }

        ///----------------------------  armor,  size, natural, deflex, temporary,     misc, baseac
        public ArmorClass(Entity parent, int a, int s,   int n,  int d,  int temp, int misc, int b){
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
        public ArmorClass(Entity parent, int a, int s,   int n,  int d,  int temp, int misc){
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
        public ArmorClass(Entity parent, int a, int s,   int n,  int d,  int temp){
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
        public ArmorClass(Entity parent, int a, int s,   int n,  int d){
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
        public ArmorClass(Entity parent, int a, int s,   int n){
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
        public ArmorClass(Entity parent, int a, int s){
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
        public ArmorClass(Entity parent, int a){
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
        public ArmorClass(Entity parent){
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

        public uint get(){
            int a = (this.baseac + this.armor + this.size + this.natural + this.deflex + this.temporary + this.misc + this.parent.getMod(Stats.dex));
            if(a>0){
                return (uint)a;
            }else{
                return 0u;
            }
        }

        public uint touch(){
            int a = (this.baseac + this.size + this.misc + this.deflex + this.parent.getMod(Stats.dex));
            if(a>0){
                return (uint)a;
            }else{
                return 0u;
            }
        }

        public uint unaware(){
            int a = (this.baseac + this.armor + this.size + this.natural + this.misc + this.featDex);
            if(a>0){
                return (uint)a;
            }else{
                return 0u;
            }
        }

        public void enableFeatDex(bool t){
            if(t){
                this.featDex = this.parent.getMod(Stats.dex) + this.deflex;
            }else{
                this.featDex = 0;
            }
            this.flagsArr[(int)ArmorClass.flags.featDex] = t;
        }

    }

    public struct Hurt: Historied<uint, int>{

        private uint damage;
        private List<int> history;

        public Hurt(byte a){
            this.damage = 0;
            this.history = new List<int>();
        }

        public uint get(){
            return this.damage;
        }
        public int get(int i){
            return this.history[i];
        }
        public int getItems(){
            return this.history.Count;
        }

        public void hurt(int d){
            if((d < 0) && (Math.Abs(d) > this.damage)){
                this.damage = 0u;
            }else{
                this.damage = (uint)(this.damage +d);
            }
            this.history.Add(d);
        }

        public void heal(int h){
            if(h > this.damage){
                this.damage = 0u;
            }else{
                this.damage = (uint)(this.damage -h);
            }
            this.history.Add(-h);
        }

    }
    
    public struct Health{

        private uint basehp;
        public Hurt lethalDamage;
        public Hurt nonlethalDamage;
        public List<uint> hpthrows; //This is a List, as opposed to a simple Array, because while usually levels cap out at 20, this is D&D we're talking about. I want the user to be able to expand it as necessary.
        //This list will have to be displayed and handled with this in mind.
        private Entity parent;

        public  Health(Entity p){
            this.basehp = 0;
            this.parent = p;
            this.lethalDamage = new Hurt(0);
            this.nonlethalDamage = new Hurt(0);
            this.hpthrows = new List<uint>( new uint[20] );
        }
        public Health(Entity p, uint h){
            this.basehp = h;
            this.parent = p;
            this.lethalDamage = new Hurt(0);
            this.nonlethalDamage = new Hurt(0);
            this.hpthrows = new List<uint>( new uint[20] );

        }

        public void setBaseHP(){
            for(byte i = 0; i <= this.parent.level; i++){
                int n = (int)(this.hpthrows[i] + this.parent.getMod(Stats.con));
                if(n > 1){
                    this.basehp = (uint)(this.basehp + n);
                }else{
                    this.basehp++;
                }
            }
        }
        public void setBaseHP(uint h){
            this.basehp = h;
        }

        public uint getBaseHP(){
            return this.basehp;
        }

        public int getHP(){
            return (int)(this.basehp - (this.lethalDamage.get()+this.nonlethalDamage.get()));
        }

        public int getNlHP(){
            return (int)(this.basehp - this.lethalDamage.get());
        }

        public bool isDead(){
            return this.getHP() <= Cf.Options.EntityValues["dead"];
        }

        public bool isBleedingOut(){
            return this.getHP() <= Cf.Options.EntityValues["bleedingOut"];
        }

        public bool isDown(){
            return this.getHP() <= Cf.Options.EntityValues["down"];
        }

        public string getState(){
            if(this.isDead()){
                return "Dead";
            }else{
                if(this.isBleedingOut()){
                    return "Bleeding out";
                }else{
                    if(this.isDown()){
                        return "Down";
                    }
                }
            }
            return "Fine";
        }

        public string omaeWaMou(){
            if(this.isDead()){
                return "Shindeiru";
            }else{
                return "";
            }
        }

    }

    public struct Description{

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
        public Image arcaneMark;

        public Description(string name){
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
            this.arcaneMark = null;
        }

    }

    public struct Skill: Flagged<Skill.flags>{
        
        public enum flags{
            trainedOnly, penalizedByArmor, JobSkill
        };

        public string name;
        public Stats keyStat;
        public uint level;
        public uint miscLevels;

        private bool[] flagsArr;
        private Entity parent;

        public Skill(Entity p, string name, Stats keyStat){
            this.parent = p;
            this.name = name;
            this.keyStat = keyStat;
            this.miscLevels = 0;
            this.level = 0;
            this.flagsArr = new bool[3];
        }
        public Skill(Entity p, string name, Stats keyStat, uint miscLevels){
            this.parent = p;
            this.name = name;
            this.keyStat = keyStat;
            this.miscLevels = miscLevels;
            this.level = 0;
            this.flagsArr = new bool[3];
        }
        public Skill(Entity p, string name, Stats keyStat, uint miscLevels, uint level){
            this.parent = p;
            this.name = name;
            this.keyStat = keyStat;
            this.miscLevels = miscLevels;
            this.level = level;
            this.flagsArr = new bool[3];
        }
        public Skill(Entity p, string name, Stats keyStat, uint miscLevels, uint level, bool to, bool pba, bool jk){
            this.parent = p;
            this.name = name;
            this.keyStat = keyStat;
            this.miscLevels = miscLevels;
            this.level = level;
            this.flagsArr = new bool[3];
            this.flagsArr[(byte)Skill.flags.trainedOnly] = to;
            this.flagsArr[(byte)Skill.flags.penalizedByArmor] = pba;
            this.flagsArr[(byte)Skill.flags.JobSkill] = jk;
        }

        public bool getFlag(flags i){
            return this.flagsArr[(byte)i];
        }
        public void train(uint l){
            this.level += l;
        }
        public long getMod(){
            int val = (int)(this.parent.getMod(this.keyStat) + this.miscLevels);
            if(this.getFlag(flags.JobSkill)){
                return val + this.level;
            }else{
                return val + (this.level/2);
            }
        }

    }

}