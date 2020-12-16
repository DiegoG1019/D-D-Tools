using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.Base.Cache
{
    public static class Jobs
    {
        public static IEnumerable<Job> All { get; } = ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyValues<Job>(typeof(Jobs));
    }
}
