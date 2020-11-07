using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DiegoG.DnDNetCore.Other
{
    public interface IHistoried
    {
        ObservableCollection<int> History { get; set; }
    }
}
