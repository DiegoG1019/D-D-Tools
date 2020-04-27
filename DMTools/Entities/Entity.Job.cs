using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTDesktop
{
	public partial class Entity
	{
		public sealed class Job : INoted
		{
			public struct JobGrowth
			{

				public List<List<byte>> BaseAttack { get; set; }
				public List<List<byte>> Saving { get; set; } //Throws
				public List<Ability> Abilities { get; set; }
				public List<List<byte>> DailySpells { get; set; }

			}

			public string Name { get; set; }
			public byte Level { get; set; }
			public List<string> Competence { get; set; }
			public Dice HPDice { get; set; }
			public int SkillPoints { get; set; }
			public JobGrowth Growth { get; set; }
			private Entity parent;

			public Job(Job other) :
				this(other.Name, other.Level, other.Competence, other.HPDice, other.SkillPoints, other.Growth)
			{ }
			public Job(Entity parent) :
				this()
			{
				this.parent = parent;
			}
			public Job() :
				this("")
			{ }
			public Job(string name) :
				this(name, 1)
			{ }
			public Job(string name, byte level) :
				this(name, level, new List<string>())
			{ }
			public Job(string name, byte level, List<string> competence) :
				this(name, level, competence, new Dice(1, 6))
			{ }
			public Job(string name, byte level, List<string> competence, Dice hpd) :
				this(name, level, competence, hpd, 1)
			{ }
			public Job(string name, byte level, List<string> competence, Dice hpd, int skillpoints) :
				this(name, level, competence, hpd, skillpoints, new JobGrowth())
			{ }
			public Job(string name, byte level, List<string> competence, Dice hpd, int skillpoints, JobGrowth gr)
			{
				Name = name;
				Level = level;
				Competence = competence;
				HPDice = hpd;
				SkillPoints = skillpoints;
				Growth = gr;
			}

			public List<string> Notes { get; set; }
			public string AllNotes
			{
				get
				{
					const string a = "-{0}\n";
					string c = "";
					foreach (string b in Notes)
					{
						c += String.Format(a, b);
					}
					if (c.Length > 0)
					{
						return c.Substring(0, c.Length - 1);
					}
					else
					{
						return c;
					}
				}
			}

		}
	}
}
