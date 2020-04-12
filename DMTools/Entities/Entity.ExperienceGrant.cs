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
		public struct ExperienceGrant
		{

			public uint Baseexp { get; set; }
			public uint Extra { get; set; }

			[IgnoreDataMember]
			public Entity parent;

			public ExperienceGrant(Entity parent)
			{
				this.parent = parent;
				this.Baseexp = 1;
				this.Extra = 0;
			}
			public ExperienceGrant(Entity parent, uint b)
			{
				this.parent = parent;
				this.Baseexp = b;
				this.Extra = 0;
			}
			public ExperienceGrant(Entity parent, uint b, uint e)
			{
				this.parent = parent;
				this.Baseexp = b;
				this.Extra = e;

			}

			[IgnoreDataMember]
			[JsonIgnore]
			public uint Grant
			{
				get
				{
					byte l = parent.Level;
					return (uint)(((l * (l - 1) * 500) + (this.Baseexp * l)) + this.Extra);
				}
			}

		}

	}
}
