using System.Windows.Forms;

namespace DiegoG.DnDTDesktop.GUI
{
    public partial class MainMenu : Form
    {

        public static TextBox TextBoxGen(string txt, HorizontalAlignment align, DockStyle dock, bool @readonly)
        {
            return new TextBox()
            {
                Text = txt,
                TextAlign = align,
                Dock = dock,
                ReadOnly = @readonly,
            };
        }
        public static TextBox TextBoxGen(string txt, HorizontalAlignment align, DockStyle dock) => TextBoxGen(txt, align, dock, true);
        public static TextBox TextBoxGen(string txt, HorizontalAlignment align) => TextBoxGen(txt, align, DockStyle.Fill);
        public static TextBox TextBoxGen(string txt) => TextBoxGen(txt, HorizontalAlignment.Center);

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, System.EventArgs e)
        {

        }
    }
}
