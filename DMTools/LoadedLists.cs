using System;
using System.Collections.Generic;

namespace DMTools
{
	namespace Loaded
	{
		
		public static class Entities
		{
			private static Queue<int> freeIDs;
			public static List<Entity> objects;
			public static List<int> loaded;
			public static int NextID
            {
                get
                {
                    try
                    {
						return freeIDs.Dequeue();
                    }
                    catch(InvalidOperationException e) //This means the queue is empty
                    {
						objects.Add(null);
						return objects.Count;
                    }
                }
			}
			public static int Add(Entity ent)
			{
				int a = NextID;
				objects[a] = ent;
				loaded.Add(a);
				return a;
			}
			public static void Remove(int id)
			{
				freeIDs.Enqueue(id);
				objects[id] = null;
				loaded.Remove(id);
			}
		}
		public static class Characters
		{
			private static Queue<int> freeIDs;
			private static List<Entity> objects;
			public static List<int> loaded;
			public static int NextID
			{
				get
				{
					try
					{
						return freeIDs.Dequeue();
					}
					catch (InvalidOperationException e) //This means the queue is empty
					{
						objects.Add(null);
						return objects.Count;
					}
				}
			}
			public static int Add(Entity ent)
			{
				int a = NextID;
				objects[a] = ent;
				loaded.Add(a);
				return a;
			}
			public static void Remove(int id)
			{
				freeIDs.Enqueue(id);
				objects[id] = null;
				loaded.Remove(id);
			}
		}
	}
}
