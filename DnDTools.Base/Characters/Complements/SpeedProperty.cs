using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Items.Inventory;
using DiegoG.DnDTools.Base.Items;
using DiegoG.Utilities.Measures;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    public class SpeedProperty : CharacterTrait<SpeedProperty>, ICharacterProperty
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

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
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
        public Length BoardSpeed { get; private set; }
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Total
        {
            get
            {

            }
        }
        private int? TotalField;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int BaseTotal => BasePoints + Bonus;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int ArmorModifier
        {
            get => ArmorModiferField;
            set
            {
                ArmorModiferField = value;
                NotifyPropertyChanged();
            }
        }
        private int ArmorModiferField;

        private Bag<Armor> EquippedArmorBag;
        public SpeedProperty()
        {
            BoardSpeed = new(Total / 5, Length.Units.Square);
            EquippedArmorBag = Parent.Equipped.Armors;
            PropertyChanged += SpeedProperty_PropertyChanged;
        }

        private void SpeedProperty_PropertyChanged(object sender, PropertyChangedEventArgs e)
            => BoardSpeed = new(Total / 5, Length.Units.Square);

        private void Equipped_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Parent.Equipped.Armors))
            {
                EquippedArmorBag.PropertyChanged -= Armors_PropertyChanged;
                EquippedArmorBag = Parent.Equipped.Armors;
                EquippedArmorBag.PropertyChanged += Armors_PropertyChanged;
            }
        }

        private void Armors_PropertyChanged(object sender, PropertyChangedEventArgs e)
            => ArmorModifier = Parent.Equipped.ArmorSpeedModifier;
    }
}
