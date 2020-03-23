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
        private byte level;

        public byte getLevel(){
            return this.level;
        }

    }

}