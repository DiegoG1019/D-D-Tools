using System;
using System.Collections.Generic;

namespace DnDTools{

    public class Entity{

        private byte[] baseStats;
        private byte[] tempStats;
        private byte[] miscBuffs;
        private byte[] baseModifiers;
        private byte[] modifiers;
        public byte skillPointModifier;
        public byte extraSkillPoints;
        public byte level = 1;
        public string name;
        private uint id;
        public ExperienceGrant expgrant;

        public byte getLevel(){
            return this.level;
        }

        public uint getId(){
            return this.id;
        }

        public Entity(byte level){
            this.level = level;
            this.expgrant = new ExperienceGrant(this,69,120);
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

    public struct Experience: Historied{

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

        public dynamic get(){
            return this.current;
        }
        public dynamic get(int i){
            return this.history[i];
        }
        
        public int getItems(){
            return this.history.Count;
        }

        public uint getRequired(){
            return this.required;
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

}