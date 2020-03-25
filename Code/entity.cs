using System;
using System.Collections.Generic;

namespace DnDTools{

    public class Entity{

        // Base values for            str con dex wis inte cha fort refl will spd initiative
        public int[] baseStats     = { 0 , 0 , 0 , 0 , 0  , 0 , 0  , 0  , 0  , 0 ,    0      };
        public int[] tempStats     = { 0 , 0 , 0 , 0 , 0  , 0 , 0  , 0  , 0  , 0 ,    0      };
        public int[] miscBuffs     = { 0 , 0 , 0 , 0 , 0  , 0 , 0  , 0  , 0  , 0 ,    0      };

        public byte skillPointModifier;
        public byte extraSkillPoints;
        public byte level = 1;
        public string name;
        private uint id;
        public ExperienceGrant expgrant;
        public ArmorClass armorC = new ArmorClass();
        public Health health;

        public byte getLevel(){
            return this.level;
        }

        public int getBaseMod(byte i){
            return ((this.baseStats[i]+this.miscBuffs[i])/2)-5;
        }

        public int getMod(byte i){
            return ((this.baseStats[i]+this.miscBuffs[i]+this.tempStats[i])/2)-5;
        }

        public uint getId(){
            return this.id;
        }

        public Entity(byte level){
            this.level = level;
            this.expgrant = new ExperienceGrant(this,69,120);
            this.health = new Health(this);
            this.health.setBaseHP();
        }

    }

    public class Character: Entity{
        public byte freeLevels;
        public Experience exp;

        public Character(byte level): base(level){
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

        public void setMultipler(float v){
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
                    throw new TooManyFreeLevels(String.Format("The entity \"{0}\" of ID \"{1}\" has too many free levels", this.parent.name, this.parent.getId()));
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
                throw new CantLevelUpYet(String.Format("The entity \"{0}\" of ID \"{1}\" attempted to level up without a right to", this.parent.name, this.parent.getId()));
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

        ///---------------------------- baseac, armor,  size, natural, deflex, temporary,     misc
        public ArmorClass(Entity parent, int b, int a, int s,   int n,  int d,  int temp, int misc){
            
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

        public uint get(){
            return (uint)(this.baseac + this.armor + this.size + this.natural + this.deflex + this.temporary + this.misc + this.parent.getMod((byte)Stats.dex));
        }

        public uint touch(){
            return (uint)(this.baseac + this.size + this.misc + this.deflex + this.parent.getMod((byte)Stats.dex));
        }

        public uint unaware(){
            return (uint)(this.baseac + this.armor + this.size + this.natural + this.misc + this.featDex);
        }

        public void enableFeatDex(bool t){
            if(t){
                this.featDex = this.parent.getMod((byte)Stats.dex) + this.deflex;
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
                this.damage -= (uint)(this.damage -h);
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
                int n = (int)(this.hpthrows[i] + this.parent.getMod((byte)Stats.con));
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

}