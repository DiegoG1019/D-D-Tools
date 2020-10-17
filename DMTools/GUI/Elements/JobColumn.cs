using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.GUI.Elements.Components;
using System;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public partial class JobColumn : CharacterUserControl
    {
        public int JobIndex { get; set; }
        public Job HeldJob => HeldCharacter.Jobs[JobIndex];
        public JobColumn()
        {
            InitializeComponent();
        }

        protected override void CharacterUserControl_HeldCharacterChanged()
        {
            JobLevelNumeric.Value = HeldJob.Level;
            JobNameTextBox.Text = HeldJob.Name;
        }

        private void JobLevelNumeric_ValueChanged(object sender, EventArgs e) => HeldJob.Level = (int)JobLevelNumeric.Value;
        private void JobNameTextBox_TextChanged(object sender, EventArgs e) => HeldJob.Name = JobNameTextBox.Text;
    }
}
