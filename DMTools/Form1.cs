using System;
using System.Windows.Forms;

namespace DnDTDesktop
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = App.version.Full;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private int CharacterSerializationsCounter = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Loaded.Characters.Objects[App.tchar].Serialize();
            label2.Text = "Character serialized: " + CharacterSerializationsCounter;
            CharacterSerializationsCounter++;

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
