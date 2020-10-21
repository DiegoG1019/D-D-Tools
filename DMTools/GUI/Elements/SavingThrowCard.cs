using System;
using System.Windows.Forms;
using DiegoG.DnDTDesktop.GUI.Elements.Components;
using DiegoG.DnDTDesktop.Characters.Complements;
using static DiegoG.DnDTDesktop.Enums;
using DiegoG.DnDTDesktop.Properties;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public partial class SavingThrowCard : CharacterUserControl
    {
        private SavingThrows selectedstat;
        public SavingThrows SelectedStat
        {
            get => selectedstat;
            set
            {
                SelectedStatChanged();
                selectedstat = value;
            }
        }
        public CharacterStat<SavingThrows, CharacterSavingThrowProperty> HeldThrowStats => HeldCharacter.SavingThrows;
        public CharacterSavingThrowProperty HeldThrows => HeldThrowStats[SelectedStat];
        public event Action SelectedStatChanged;
        public SavingThrowCard()
        {
            InitializeComponent();
            BonusPointsNumeric.Numeric.ValueChanged += BonusPointsNumeric_ValueChanged;
            SelectedStatChanged += StatCard_SelectedStatChanged;
        }

        protected override void CharacterUserControl_HeldCharacterChanged()
        {
            BonusPointsNumeric.Numeric.Value = HeldThrows.Bonus;
            EffectPointsLabeledTextBox.TextBoxText = HeldThrows.EffectPoints.ToString();
            BaseTotalTextBox.TextBoxText = HeldThrows.BaseTotal.ToString();
            TotalPointsLabeledTextBox.TextBoxText = HeldThrows.Total.ToString();
            BaseStatModifierTextBox.TextBoxText = HeldCharacter.Stats[HeldThrows.BaseStat].Modifier.ToString();
            StatCard_SelectedStatChanged();
        }

        private void BonusPointsNumeric_ValueChanged(object sender, EventArgs e) => HeldThrows.Bonus = BonusPointsNumeric.NumericValue;
        private void StatCard_SelectedStatChanged()
        {
            StatNameLabel.Text = Resources.ResourceManager.GetString(Convert.ToString(SelectedStat));
#if !DESIGN
            BonusPointsNumeric_ValueChanged(this, new EventArgs());
#endif
        }

        private void SavingThrowCard_Load(object sender, EventArgs e)
        {

        }

        private void BaseTotalTextBox_Load(object sender, EventArgs e)
        {

        }

        private void StatNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
