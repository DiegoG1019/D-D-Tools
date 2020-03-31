using System;
using System.Collections.Generic;

namespace DMTools
{
	public static class Loaded
	{
		public static LoadedList<Entity> Entities = new LoadedList<Entity>();
		public static LoadedList<Character> Characters = new LoadedList<Character>();

		public class LoadedList<T> where T : class
		{
			private readonly Queue<int> freeIDs;
			public readonly List<T> Objects;
			public readonly List<int> IDs;

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
						Objects.Add(null);
						return Objects.Count-1;
					}
				}
			}

			public LoadedList()
			{
				freeIDs = new Queue<int>();
				Objects = new List<T>();
				IDs = new List<int>();
			}

			public int Add(T v)
			{
				int a = NextID;
				Objects[a] = v;
				IDs.Add(a);
				return a;
			}

			public void Remove(int id)
			{
				freeIDs.Enqueue(id);
				Objects[id] = null;
				IDs.Remove(id);
			}
		}
	}
}
