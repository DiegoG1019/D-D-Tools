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
		public sealed class Description : INoted
		{
			public string Name { get; set; }
			public string Fullname { get; set; }
			public string Race { get; set; }
			public string Alignment { get; set; }
			public string Deity { get; set; }
			public string BodyType { get; set; }
			public Sizes Size { get; set; }
			public string Bio { get; set; }
			public string Intro { get; set; }
			public string Personality { get; set; }
			public string Gender { get; set; }
			public List<string> Notes { get; set; }
			public ulong Age { get; set; }
			public Length Height { get; set; }
			public Mass Weight { get; set; }
			public Color Eyes { get; set; }
			public Color Hair { get; set; }
			public Color Skin { get; set; }
			public Color Bgcolor { get; set; }
			public Color BannerColor { get; set; }
			public Bitmap Mugshot { get; set; }
			public Bitmap FullBody { get; set; }
			public List<Bitmap> ArcaneMarks { get; set; }

			public Description(Description other) :
				this(other.Name, other.Fullname, other.Race, other.Alignment, other.Deity, other.BodyType, other.Size, other.Bio, other.Intro, other.Personality, other.Gender, other.Notes, other.Age, other.Height, other.Weight, other.Eyes, other.Hair, other.Skin, other.Bgcolor, other.BannerColor, other.Mugshot, other.FullBody, other.ArcaneMarks)
			{ }
			public Description() :
				this(String.Empty)
			{ }
			public Description(string name) :
				this(name, String.Empty)
			{ }
			public Description(string name, string fullname) :
				this(name, fullname, String.Empty)
			{ }
			public Description(string name, string fullname, string race) :
				this(name, fullname, race, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment) :
				this(name, fullname, race, alignment, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity) :
				this(name, fullname, race, alignment, deity, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype) :
				this(name, fullname, race, alignment, deity, bodytype, Sizes.Medium)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size) :
				this(name, fullname, race, alignment, deity, bodytype, size, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, String.Empty)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, new List<string>())
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, 0)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, new Length(1M, Length.Units.Meter))
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, new Mass(1M, Mass.Units.Kilogram))
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, hair, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair, Color? skin) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, hair, skin, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair, Color? skin, Color? bgcolor) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, hair, skin, bgcolor, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair, Color? skin, Color? bgcolor, Color? bannercolor) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, hair, skin, bgcolor, bannercolor, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair, Color? skin, Color? bgcolor, Color? bannercolor, Bitmap mugshot) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, hair, skin, bgcolor, bannercolor, mugshot, null)
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair, Color? skin, Color? bgcolor, Color? bannercolor, Bitmap mugshot, Bitmap fullbody) :
				this(name, fullname, race, alignment, deity, bodytype, size, bio, intro, personality, gender, notes, age, height, weight, eyes, hair, skin, bgcolor, bannercolor, mugshot, fullbody, new List<Bitmap>())
			{ }
			public Description(string name, string fullname, string race, string alignment, string deity, string bodytype, Sizes size, string bio, string intro, string personality, string gender, List<string> notes, ulong age, Length height, Mass weight, Color? eyes, Color? hair, Color? skin, Color? bgcolor, Color? bannercolor, Bitmap mugshot, Bitmap fullbody, List<Bitmap> arcanemarks)
			{
				Name = name;
				Fullname = fullname;
				Race = race;
				Alignment = alignment;
				Deity = deity;
				BodyType = bodytype;
				Size = size;
				Bio = bio;
				Intro = intro;
				Personality = personality;
				Gender = gender;
				Notes = notes;
				Age = age;
				Height = height;
				Weight = weight;
				Eyes = eyes == null ? Color.SandyBrown : (Color)eyes;
				Hair = hair == null ? Color.Black : (Color)hair;
				Skin = skin == null ? Color.Beige : (Color)skin;
				Bgcolor = bgcolor == null ? Color.Transparent : (Color)bgcolor;
				BannerColor = bannercolor == null ? Color.Transparent : (Color)bannercolor;
				Mugshot = mugshot;
				FullBody = fullbody;
				ArcaneMarks = arcanemarks;
			}

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
