using System.Collections.ObjectModel;

namespace DiegoG.DnDTools.Base.Other
{
    public interface IHistoried
    {
        ObservableCollection<int> History { get; set; }
    }
}
