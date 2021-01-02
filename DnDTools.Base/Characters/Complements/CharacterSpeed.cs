using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using DiegoG.DnDTools.Base.Items;
using DiegoG.Utilities.Measures;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    public class CharacterSpeed : CharacterTrait<CharacterSpeed>, ICharacterProperty
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

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public Length BoardSpeed
        {
            get
            {
                if (BoardSpeedField is not null)
                    return BoardSpeedField;
                BoardSpeed = new(Total / 5, Length.Units.Square);
                return BoardSpeedField;
            }
            private set => BoardSpeedField = value;
        }
        public Length BoardSpeedField;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Total
        {
            get
            {
                if (TotalField is not null)
                    return (int)TotalField;
                Parent.Equipped.Armors.PropertyChanged += Armors_PropertyChanged;
                TotalField = Parent.Equipped.ArmorSpeedModifier;
                return (int)TotalField;
            }
        }
        private int? TotalField;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int BaseTotal => BasePoints + Bonus;

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int ArmorModifier
        {
            get => ArmorModiferField;
            private set
            {
                ArmorModiferField = value;
                NotifyPropertyChanged();
            }
        }
        private int ArmorModiferField;

        public CharacterSpeed() => PropertyChanged += SpeedProperty_PropertyChanged;

        private void SpeedProperty_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            TotalField = BaseTotal + EffectPoints + ArmorModifier;
            BoardSpeedField = new(Total / 5, Length.Units.Square);
        }

        private void Armors_PropertyChanged(object sender, PropertyChangedEventArgs e)
            => ArmorModifier = Parent.Equipped.ArmorSpeedModifier;
    }
}
