using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DiegoG.DnDTDesktop.Other
{
    public interface IHistoried
    {
        ObservableCollection<int> History { get; set; }
    }
}
