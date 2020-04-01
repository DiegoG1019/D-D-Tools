using System;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

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

        private void button1_Click(object sender, EventArgs e)
        {

            string jsonstring = JsonSerializer.Serialize(Loaded.Characters.Objects[App.tchar], App.JSONOptions);

            using (StreamWriter OutFile = new StreamWriter(new FileStream(Path.Combine(App.Directories.Characters, "Tchar.character.json"), FileMode.Create, FileAccess.Write, FileShare.Read)))
            {
                OutFile.WriteLine(jsonstring);
            }
            /**/

            label2.Text = "Character serialized";

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
