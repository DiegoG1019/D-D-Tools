using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.GUI.Elements.Components;
using System;
using System.Drawing;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public partial class SkillColumn : CharacterUserControl
    {

        public SkillColumn()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();
        }

        protected override void CharacterUserControl_HeldCharacterChanged()
        {
            SkillNameTextBox.Text = HeldSkill.Name;
            ArmorPenalizerCheckBox.Checked = HeldSkill.PenalizedByArmorFlag;
            JobSkillCheckBox.Checked = HeldSkill.JobSkillFlag;
            TrainedOnlyCheckBox.Checked = HeldSkill.TrainedOnlyFlag;
            KeyStatListBox.SelectedIndex = (int)HeldSkill.KeyStat;
            RanksNumericUpDown.Value = HeldSkill.Rank;
            MiscRanksNumericUpDown.Value = HeldSkill.MiscRanks;
        }
        public int SkillIndex { get; set; }
        public Skill HeldSkill => HeldCharacter.Skills[SkillIndex];

        private void SkillNameTextBox_TextChanged(object sender, EventArgs e) => HeldSkill.Name = SkillNameTextBox.Text;
        private void JobSkillCheckBox_CheckedChanged(object sender, EventArgs e) => HeldSkill.JobSkillFlag = JobSkillCheckBox.Checked;
        private void TrainedOnlyCheckBox_CheckedChanged(object sender, EventArgs e) => HeldSkill.TrainedOnlyFlag = TrainedOnlyCheckBox.Checked;
        private void KeyStat_SelectedIndexChanged(object sender, EventArgs e) => HeldSkill.KeyStat = (Stats)KeyStatListBox.SelectedIndex;
        private void RanksNumericUpDown_ValueChanged(object sender, EventArgs e) => HeldSkill.Rank = (int)RanksNumericUpDown.Value;
        private void MiscRanksNumericUpDown_ValueChanged(object sender, EventArgs e) => HeldSkill.MiscRanks = (int)MiscRanksNumericUpDown.Value;
        private void ArmorPenalizerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            HeldSkill.PenalizedByArmorFlag = ArmorPenalizerCheckBox.Checked;
            if (ArmorPenalizerCheckBox.Checked)
            {
                ArmorPenaltyTextBox.BackColor = Color.White;
                ArmorPenaltyTextBox.Text = HeldCharacter.Equipped.ArmorPenalty.ToString();
                return;
            }
            ArmorPenaltyTextBox.BackColor = Color.Gray;
            ArmorPenaltyTextBox.Text = String.Empty;
        }
    }
}
