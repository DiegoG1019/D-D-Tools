using DiegoG.DnDTDesktop.Characters;
using DiegoG.DnDTDesktop.GUI.Elements.Components;
using System.Windows.Forms;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public partial class SmallHealthCard : CharacterUserControl
    {
        public Health HeldHP => HeldCharacter.Health;

        public SmallHealthCard()
        {
            InitializeComponent();
        }

        protected override void CharacterUserControl_HeldCharacterChanged()
        {
            NonLethalDamageTextBox.TextBoxText = HeldHP.NonlethalDamage.Damage.ToString();
            LethalDamageTextBox.TextBoxText = HeldHP.LethalDamage.Damage.ToString();
            EffectHealthTextBox.TextBoxText = HeldHP.EffectHP.ToString();
            NonLethalHPTextBox.TextBoxText = HeldHP.NonLethalHP.ToString();
            RemainingHPTextBox.TextBoxText = HeldHP.RemainingHP.ToString();
            BaseHPTextBox.TextBoxText = HeldHP.BaseHP.ToString();
        }

        private void NonLethalDamageTextBox_Load(object sender, System.EventArgs e)
        {

        }
    }
}
