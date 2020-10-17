using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DiegoG.DnDTDesktop.Other
{
    public interface IHistoried<T>
    {
        ObservableCollection<T> History { get; set; }
    }
}
