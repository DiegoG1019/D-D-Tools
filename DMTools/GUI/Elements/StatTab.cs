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
        public CharacterStat<Stats, CharacterStatProperty> HeldStats => HeldCharacter.Stats;
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
            BaseTotalNumericBox.Numeric.Value = HeldStats[SelectedStat].BasePoints;
            ExtraPointsLabeledNumeric.Numeric.Value = HeldStats[SelectedStat].Bonus;
            BaseModifierLabeledTextBox.TextBoxText = HeldStats[SelectedStat].BaseModifier.ToString();
            FullModifierLabeledTextBox.TextBoxText = HeldStats[SelectedStat].Modifier.ToString();
            EffectPointsLabeledTextBox.TextBoxText = HeldStats[SelectedStat].EffectPoints.ToString();
            TotalPointsLabeledTextBox.TextBoxText = $"{HeldStats[SelectedStat].BaseTotal} ({HeldStats[SelectedStat].Total})";
        }

        private void ExtraPointsNumeric_ValueChanged(object sender, EventArgs e)
        {
            HeldStats[SelectedStat].Bonus = (int)ExtraPointsLabeledNumeric.Numeric.Value;
        }

        private void BaseTotalNumeric_ValueChanged(object sender, EventArgs e)
        {
            HeldStats[SelectedStat].BasePoints = (int)BaseTotalNumericBox.Numeric.Value;
        }

        private void EffectPointsLabeledTextBox_Load(object sender, EventArgs e)
        {

        }
    }
}
