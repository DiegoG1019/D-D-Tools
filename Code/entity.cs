using System;

namespace DnDTools{

    public class Entity{

        private byte[] baseStats;
        private byte[] tempStats;
        private byte[] miscBuffs;
        private byte[] baseModifiers;
        private byte[] modifiers;
        public byte skillPointModifier;
        public byte extraSkillPoints;
        private byte level = 1;
        public ExperienceGrant expgrant;

        public byte getLevel(){
            return this.level;
        }

        public Entity(byte level){
            this.level = level;
            this.expgrant = new ExperienceGrant(this,69,120);
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

        public uint getExp(){
            byte l = this.parent.getLevel();
            return ((l*(l-1)*500)+(this.baseexp*l))+this.extra;
        }

    }

}