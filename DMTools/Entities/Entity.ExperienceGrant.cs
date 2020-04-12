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
		public class ExperienceGrant
		{
			private CUInt32 bse;
			private CUInt32 ex;
			public uint Baseexp
			{
				get
				{
					return bse.v;
				}
				set
				{
					bse.v = value;
				}
			}
			public uint Extra
			{
				get
				{
					return ex.v;
				}
				set
				{
					ex.v = value;
				}
			}

			[IgnoreDataMember]
			public Entity parent;

			public ExperienceGrant()
			{
				bse = new CUInt32();
				ex = new CUInt32();
			}
			public ExperienceGrant(Entity parent) :
				this(parent, 10)
			{ }
			public ExperienceGrant(Entity parent, uint bse) :
				this(parent, bse, 0)
			{ }
			public ExperienceGrant(Entity parent, uint bse, uint ex) :
				this()
			{
				this.parent = parent;
				this.Baseexp = bse;
				this.Extra = ex;
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
