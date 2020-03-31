using System;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Runtime.InteropServices;

namespace DMTools
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
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

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
            /*
            FileStream fileOut = new FileStream(App.WriteDir + "Tchar.character.json", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(fileOut);
            writer.Write(JsonSerializer.Serialize(Loaded.Characters.Objects[App.tchar], App.JSONOptions));
            /**/
        }
    }
}
