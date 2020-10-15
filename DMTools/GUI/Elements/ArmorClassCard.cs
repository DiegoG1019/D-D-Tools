using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiegoG.DnDTDesktop.GUI.Elements.Components;
using DiegoG.DnDTDesktop.Characters;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public partial class ArmorClassCard : CharacterUserControl
    {
        public ArmorClass HeldAC => HeldCharacter.ArmorClass;
        public ArmorClassCard()
        {
            InitializeComponent();
            BonusACTextBox.ValueChanged += BonusACTextBox_ValueChanged;
            BaseACTextBox.Numeric.ValueChanged += BaseACTextBoxNumeric_ValueChanged;
            ArmorACTextBox.Numeric.ValueChanged += ArmorACTextBoxNumeric_ValueChanged;
            SizeACTextBox.Numeric.ValueChanged += SizeACTextBoxNumeric_ValueChanged;
            NaturalACTextBox.Numeric.ValueChanged += NaturalACTextBoxNumeric_ValueChanged;
            DeflexACTextBox.Numeric.ValueChanged += DeflexACTextBoxNumeric_ValueChanged;
        }

        protected override void CharacterUserControl_HeldCharacterChanged()
        {
            TouchACTextBox.Text = HeldAC.TouchAC.ToString();
            UnawareACTextBox.Text = HeldAC.UnawareAC.ToString();
            BonusACTextBox.Value = HeldAC.Bonus;
            ACTextBox.TextBoxText = HeldAC.AC.ToString();
            BaseACTextBox.NumericValue = HeldAC.BaseAC;
            ArmorACTextBox.NumericValue = HeldAC.Armor;
            DexterityACTextBox.TextBoxText = HeldCharacter.Stats[Stats.Dexterity].Total.ToString();
            SizeACTextBox.NumericValue = HeldAC.Size;
            NaturalACTextBox.NumericValue = HeldAC.Natural;
            DeflexACTextBox.NumericValue = HeldAC.Deflex;
            EffectACTextBox.TextBoxText = HeldAC.Effect.ToString();
        }

        private void DeflexACTextBoxNumeric_ValueChanged(object sender, EventArgs e)
        {
            HeldAC.Deflex = DeflexACTextBox.NumericValue;
        }

        private void NaturalACTextBoxNumeric_ValueChanged(object sender, EventArgs e)
        {
            HeldAC.Natural = NaturalACTextBox.NumericValue;
        }

        private void SizeACTextBoxNumeric_ValueChanged(object sender, EventArgs e)
        {
            HeldAC.Size = SizeACTextBox.NumericValue;
        }

        private void ArmorACTextBoxNumeric_ValueChanged(object sender, EventArgs e)
        {
            HeldAC.Armor = ArmorACTextBox.NumericValue;
        }

        private void BaseACTextBoxNumeric_ValueChanged(object sender, EventArgs e)
        {
            HeldAC.BaseAC = BaseACTextBox.NumericValue;
        }

        private void BonusACTextBox_ValueChanged(object sender, EventArgs e)
        {
            HeldAC.Bonus = SizeACTextBox.NumericValue;
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TouchACTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void UnawareACTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ACTextBox_Load(object sender, EventArgs e)
        {

        }
    }
}
