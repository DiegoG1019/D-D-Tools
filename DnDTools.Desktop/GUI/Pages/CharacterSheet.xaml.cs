using DiegoG.DnDTools.Base.Characters;
using DiegoG.DnDTools.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
