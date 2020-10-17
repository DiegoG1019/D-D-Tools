using DiegoG.DnDTDesktop.Characters;
using DiegoG.DnDTDesktop.GUI.Elements.Components;
using System.Windows.Forms;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public partial class JobTab : CharacterUserControl
    {
        public JobTab()
        {
            InitializeComponent();
        }

        public JobList HeldJobs => HeldCharacter.Jobs;

        protected override void CharacterUserControl_HeldCharacterChanged()
        {
            for (int ind = 0; ind < HeldCharacter.Skills.Count; ind++)
            {
                var nsc = new JobColumn() { JobIndex = ind };
                JobColumnTable.Controls.Add(nsc);
            }
        }

        private void characterGUITableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
