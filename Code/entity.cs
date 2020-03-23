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

}