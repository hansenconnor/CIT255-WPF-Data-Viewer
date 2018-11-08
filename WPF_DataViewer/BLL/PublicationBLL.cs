using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_DataViewer.DAL;

namespace WPF_DataViewer.BLL
{
    class PublicationBLL
    {
        IDataService _dataService;

        // Constructor
        public PublicationBLL(IDataService dataService)
        {
            _dataService = dataService;
        }

        public ObservableCollection<MediumPublication> GetPublications()
        {
            // Create collection to hold publications
            ObservableCollection<MediumPublication> publicationCollection;

            // Get the publications
            publicationCollection = _dataService.GetPublications();

            // Return the publications
            return publicationCollection;
        }
    }
}
