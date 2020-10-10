using System.Collections.Generic;

namespace DiegoG.DnDTDesktop.Other
{
    public interface IHistoried<T>
    {
        List<T> History { get; set; }
    }
}
