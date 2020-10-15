using System;
using System.Windows.Forms;
using DiegoG.DnDTDesktop.GUI.Elements.Interfaces;
using DiegoG.DnDTDesktop.GUI.Elements.Components;
using DiegoG.DnDTDesktop.Characters;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public partial class SkillSheet : CharacterUserControl, ICharacterGUI, ICharacterGUIElement
    {
        public SkillList HeldSkillList => HeldCharacter.Skills;
        protected override void CharacterUserControl_HeldCharacterChanged()
        {
            for (int ind = 0; ind < HeldCharacter.Skills.Count; ind++)
            {
                var nsc = new SkillColumn() { SkillIndex = 0 };
                SkillListTable.Controls.Add(nsc);
            }
            MiscSkillPointsNumericUpDown.Value = HeldSkillList.MiscSkillPoints;
            AbilitySkillPointsTextBox.Text = HeldSkillList.AbilitySkillPoints.ToString();
            ExtraSkillPointsNumericUpDown.Value = HeldSkillList.ExtraSkillPoints;
            SpentSkillPointsTextBox.Text = HeldSkillList.SpentSkillPoints.ToString();
            TotalSkillPointsTextBox.Text = HeldSkillList.TotalSkillPoints.ToString();
            MaxJobSkillRankTextBox.Text = HeldSkillList.MaxJobSkillRank.ToString();
            MaxOtherSkillRankTextBox.Text = HeldSkillList.MaxOtherSkillRank.ToString();
        }

        public SkillSheet()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OtherSkillPointsLabel_Click(object sender, EventArgs e)
        {

        }

        private void AbilitySkillToolTip_Popup(object sender, PopupEventArgs e)
        {
        }

        private void MiscSkillPointsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            HeldCharacter.Skills.MiscSkillPoints = (int)MiscSkillPointsNumericUpDown.Value;
        }

        private void BaseJobSkillPointsOpenButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
