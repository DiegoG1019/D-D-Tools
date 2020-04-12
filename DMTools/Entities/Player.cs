using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTDesktop
{
	public class Player
	{
		private uint id;

		public string name;
		public uint Id
		{
			get
			{
				return this.id;
			}
		}
		public List<Entity> entities;
		public List<Character> characters;
		public List<string> notes;

	}
}
