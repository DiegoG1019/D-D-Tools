using System;
using DiegoG.DnDTDesktop.Characters;
using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.GUI.Elements.Components;
using DiegoG.DnDTDesktop.Properties;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public partial class StatCard : CharacterUserControl
    {
        private Stats selectedstat;
        public Stats SelectedStat
        {
            get => selectedstat;
            set { SelectedStatChanged(); selectedstat = value; }
        }
        public CharacterStat<Stats> HeldStats => HeldCharacter.Stats;
        public event Action SelectedStatChanged;
        public StatCard()
        {
            InitializeComponent();
            BaseTotalNumericBox.Numeric.ValueChanged += BaseTotalNumeric_ValueChanged;
            ExtraPointsLabeledNumeric.Numeric.ValueChanged += ExtraPointsNumeric_ValueChanged;
            SelectedStatChanged += StatCard_SelectedStatChanged;
        }

        private void StatCard_SelectedStatChanged()
        {
            StatNameLabel.Text = Resources.ResourceManager.GetString(Convert.ToString(SelectedStat));
        }

        protected override void CharacterUserControl_HeldCharacterChanged()
        {
            SelectedStatChanged();
            BaseTotalNumericBox.Numeric.Value = HeldStats.BaseTotal[SelectedStat];
            ExtraPointsLabeledNumeric.Numeric.Value = HeldStats.Bonus[SelectedStat];
            BaseModifierLabeledTextBox.TextBoxText = HeldStats.BaseModifier[SelectedStat].ToString();
            FullModifierLabeledTextBox.TextBoxText = HeldStats.Modifier[SelectedStat].ToString();
            EffectPointsLabeledTextBox.TextBoxText = HeldStats.EffectPoints[SelectedStat].ToString();
            TotalPointsLabeledTextBox.TextBoxText = HeldStats.Total[SelectedStat].ToString();
        }

        private void ExtraPointsNumeric_ValueChanged(object sender, EventArgs e)
        {
            HeldStats.Bonus[SelectedStat] = (int)ExtraPointsLabeledNumeric.Numeric.Value;
        }

        private void BaseTotalNumeric_ValueChanged(object sender, EventArgs e)
        {
            HeldStats.BaseTotal[SelectedStat] = (int)BaseTotalNumericBox.Numeric.Value;
        }
    }
}
