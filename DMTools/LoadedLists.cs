using System;
using System.Collections.Generic;

namespace DMTools
{
	public static class Loaded
	{
		public static LoadedList<Entity> Entities = new LoadedList<Entity>();
		public static LoadedList<Character> Characters = new LoadedList<Character>();

		public class LoadedList<T>
		{
			private Queue<int> freeIDs;
			private List<T> objects;
			private List<int> ids;

			public List<T> Objects
			{
				get
				{
					return objects;
				}
			}

			public List<int> IDs
			{
				get
				{
					return ids;
				}
			}

			public int NextID
			{
				get
				{
					try
					{
						return freeIDs.Dequeue();
					}
					catch (InvalidOperationException) //This means the queue is empty
					{
						objects.Add(null);
						return objects.Count;
					}
				}
			}

			public LoadedList()
			{
				freeIDs = new Queue<int>();
				objects = new List<T>();
				ids = new List<int>();
			}

			public int Add(T v)
			{
				int a = NextID;
				objects[a] = v;
				ids.Add(a);
				return a;
			}

			public void Remove(int id)
			{
				freeIDs.Enqueue(id);
				objects[id] = null;
				ids.Remove(id);
			}
		}
	}
}
