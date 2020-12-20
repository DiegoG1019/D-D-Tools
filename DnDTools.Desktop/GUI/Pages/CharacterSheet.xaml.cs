using DiegoG.DnDTools.Base;
using DiegoG.DnDTools.Base.Characters;
using System.Windows.Controls;

namespace DiegoG.DnDTools.Desktop.GUI.Pages
{
    /// <summary>
    /// Interaction logic for CharacterSheet.xaml
    /// </summary>
    public partial class CharacterSheet : Page
    {
        public string HeldCharacterFileName { get; set; }
        public Character HeldCharacter => DnDManager.Characters[HeldCharacterFileName];

        public CharacterSheet()
        {
            InitializeComponent();
        }
    }
}
