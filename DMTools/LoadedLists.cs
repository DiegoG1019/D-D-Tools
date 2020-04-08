using System;
using System.Collections.Generic;
using System.Collections;
using Serilog;

namespace DnDTDesktop
{
	public static class Loaded
	{
		public static LoadedList<Entity> Entities = new LoadedList<Entity>();
		public static LoadedList<Character> Characters = new LoadedList<Character>();

		public class LoadedList<T> : IEnumerable<int> where T : class
		{
			private readonly Queue<int> freeIDs;
			public readonly List<T> Objects;
			public readonly List<int> IDs;

			private readonly string typeofT = typeof(T).ToString();

			public T this[int index]
			{
				get
				{
					return Objects[index];
				}
				set
				{
					Objects[index] = value;
				}
			}

			public int NextID
			{
				get
				{
					const string grantedid = "Granted the ID 00{0} of {1} Loaded List";
					Log.Verbose("Next {0} Loaded List available ID requested", typeofT);
					try
					{
						int newid = freeIDs.Dequeue();
						Log.Verbose(grantedid, newid, typeofT);
						return newid;
					}
					catch (InvalidOperationException) //This means the queue is Empty
					{
						Log.Verbose("No free IDs available in {0} Loaded List, creating a new one.", typeofT);
						Objects.Add(null);
						int newid = Objects.Count - 1;
						Log.Verbose(grantedid, newid, typeofT);
						return newid;
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
				Log.Debug("Removing object of ID {0} from {1} Loaded List, and adding its now released ID to the freeIDs Queue",id,typeofT);
				freeIDs.Enqueue(id);
				Objects[id] = null;
				IDs.Remove(id);
			}

			public IEnumerator<int> GetEnumerator()
			{
				return IDs.GetEnumerator();
			}
			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

		}
	}
}
