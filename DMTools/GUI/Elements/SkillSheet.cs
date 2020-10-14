using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiegoG.DnDTDesktop.GUI.Elements.Interfaces;
using DiegoG.DnDTDesktop.Characters;
using DiegoG.DnDTDesktop.GUI.Elements.Components;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public partial class SkillSheet : CharacterUserControl, ICharacterGUI, ICharacterGUIElement
    {
        protected override void CharacterUserControl_HeldCharacterChanged()
        {
            for (int ind = 0; ind < HeldCharacter.Skills.Count; ind++)
            {
                var nsc = new SkillColumn() { SkillIndex = 0 };
                SkillListTable.Controls.Add(nsc);
                nsc.Init();
            }
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
    }
}
