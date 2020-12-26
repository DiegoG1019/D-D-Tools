using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using DiegoG.DnDTools.Base.Other;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    public class InitiativeProperty : CharacterTrait<InitiativeProperty>, ICharacterProperty
    {
        public int Bonus
        {
            get => BonusField;
            set
            {
                BonusField = value;
                NotifyPropertyChanged();
            }
        }
        private int BonusField;

        public int BasePoints
        {
            get => BasePointsField;
            set
            {
                BasePointsField = value;
                NotifyPropertyChanged();
            }
        }
        private int BasePointsField;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int EffectPoints
        {
            get => EffectPointsField;
            set
            {
                EffectPointsField = value;
                NotifyPropertyChanged();
            }
        }
        private int EffectPointsField;

        /// <summary>
        /// Rolls a D20, stores it in BasePoints and returns the value
        /// </summary>
        /// <returns>The result from the D20 roll applied to BasePoints property</returns>
        public int RollInitiative()
        {
            BasePoints = Dice.D20.Roll();
            return BasePoints;
        }

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Total => BasePoints + Bonus + EffectPoints;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int BaseTotal => BasePoints + Bonus + Parent.Stats[Enumerations.Stats.Dexterity].Total;
    }
}
