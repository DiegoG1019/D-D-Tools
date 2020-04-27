using System;
using System.Windows.Forms;
using Serilog;
using System.Collections.Generic;

namespace DnDTDesktop
{
	public partial class MainMenu : Form
	{

		public int SelectedCharacter { get; private set; }

		private static class JobList
		{

			public enum Index
			{
				Name, Level
			}
			public static List<Label>[] Array { get; set; }

			public static void Add(string name, byte level, FlowLayoutPanel NamePanel, FlowLayoutPanel LevelPanel)
			{
				Label namelabel = new Label();
				Label levellabel = new Label();
				namelabel.Text = name;
				levellabel.Text = level.ToString();
				Array[(int)Index.Name].Add(namelabel);
				Array[(int)Index.Level].Add(levellabel);
				NamePanel.Controls.Add(namelabel);
				LevelPanel.Controls.Add(levellabel);
			}

			static JobList()
			{
				Array = new List<Label>[2];
				for(int i = 0; i<Array.Length; i++)
				{
					Array[i] = new List<Label>();
				}
			}

		}

		public MainMenu()
		{
			SelectedCharacter = 0;
			Log.Information("Constructing MainMenu");
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Log.Information("Loading Main Menu");

			jobListMainLabel.Text = App.Cf.Lang.Gui["jobListMainLabel"];
			foreach(Entity.EntityJob job in Loaded.Characters[SelectedCharacter].Jobs)
			{
				JobList.Add(job.Name, job.Level, jobListFlowLayout, jobListFlowLayoutLevel);
			}
			versionLabel.Text = App.version.Full;

		}

		private void label1_Click_1(object sender, EventArgs e)
		{

		}

		private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void jobListMainLabel_Click(object sender, EventArgs e)
		{

		}
	}
}
