using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.Utilities.Collections;
using System.Collections.Generic;

namespace DiegoG.DnDTools.Base.Cache
{
    public static class Jobs
    {
        public static IEnumerable<Job> All { get; } = ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyValues<Job>(typeof(Jobs));
    }
}
