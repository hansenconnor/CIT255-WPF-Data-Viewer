using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_DataViewer.DAL
{
    interface IDataService
    {
        ObservableCollection<MediumPublication> GetPublications();
    }
}
