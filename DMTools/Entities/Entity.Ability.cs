using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Serilog;

namespace DnDTDesktop
{
	public partial class Entity
	{
		public sealed class Ability : INoted
		{
			public struct AbilityTag
			{
				public string Name { get; set; }
				public string ShortenedName { get; set; }
				public string Description { get; set; }
			}

			public string Name { get; set; }
			public string Requirements { get; set; }
			public string Description { get; set; }
			public List<string> Notes { get; set; }
			public int[] Buffs { get; set; }
			public List<AbilityTag> Tags { get; set; }

			public Ability(Ability Other) :
				this(Other.Name, Other.Requirements, Other.Description, Other.Notes, Other.Buffs, Other.Tags)
			{ }
			public Ability()
			{ }
			public Ability(string n, string re, string de) :
				this(n, re, de, new List<string>())
			{ }
			public Ability(string n, string re, string de, List<string> nts) :
				this(n, re, de, nts, new int[App.StatCount])
			{ }
			public Ability(string n, string re, string de, List<string> nts, int[] bfs) :
				this(n, re, de, nts, bfs, new List<AbilityTag>())
			{ }
			public Ability(string n, string re, string de, List<string> nts, int[] bfs, List<AbilityTag> tgs)
			{
				this.Name = n;
				this.Description = de;
				this.Notes = nts;
				this.Buffs = bfs;
				Tags = tgs;

				if (re == String.Empty || re == null)
				{
					this.Requirements = App.Cf.Lang.Ent["noRequirements"];
				}
				else
				{
					this.Requirements = re;
				}

			}

			[IgnoreDataMember]
			[JsonIgnore]
			public string FullName
			{
				get
				{
					const string s = " ({0})";
					string str = String.Empty;
					foreach (Ability.AbilityTag tag in Tags)
					{
						str += String.Format(s, tag.ShortenedName);
					}
					return str;
				}
				set
				{
					this.Name = value;
				}
			}

			[IgnoreDataMember]
			[JsonIgnore]
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
