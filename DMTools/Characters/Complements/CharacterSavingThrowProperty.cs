using System;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    [Serializable]
    public class CharacterSavingThrowProperty : CharacterTrait<CharacterSavingThrowProperty>, ICharacterProperty
    {
        public Stats BaseStat { get; set; }
        public int BasePoints { get; set; }
        public int Bonus { get; set; }
        public int EffectPoints { get; set; }
        public int BaseTotal => BasePoints + Parent.Stats[BaseStat].Total + Bonus;
        public int Total => BaseTotal + EffectPoints;
    }
}
