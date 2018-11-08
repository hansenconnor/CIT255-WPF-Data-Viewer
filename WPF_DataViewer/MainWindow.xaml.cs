using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using WPF_DataViewer.DAL;
using WPF_DataViewer.BLL;

namespace WPF_DataViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<MediumPublication> _publications;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the publications observable
            _publications = new ObservableCollection<MediumPublication>();

            // Get URL for GET request
            string apiGetPath = AppConfig.apiGetUserPath;

            // Initialize DAL
            JsonDataService jsonDataService = new JsonDataService(apiGetPath);

            // Initialize BLL
            PublicationBLL publicationBLL = new PublicationBLL(jsonDataService);

            // Get a collection of publications
            ObservableCollection<MediumPublication> publications = publicationBLL.GetPublications();

            // Shorthand for adding publications from BLL method to _publications var???
            publications.ToList().ForEach(_publications.Add);

            // Add the collection
            //foreach (var publication in publications)
            //{
            //    _publications.Add(publication);
            //}

            _list.ItemsSource = _publications;
        }


























        // Called on form load => IS ENTRY POINT
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    APICallAndBindToDataGrid();
        //}



        /// <summary>
        /// Make GET request to API, deserialize response (JSON) then bind response list to DataGridView control
        /// </summary>
        //private void APICallAndBindToDataGrid()
        //{
        //    // Get URL for GET request
        //    string apiGetPath = AppConfig.apiGetUserPath;


        //    //
        //    // Create new json data service and pass the base url for API requests
        //    //
        //    // IDataService dataService = new XmlDataService(dataFilePath); // TODO: Use Json service here 
        //    IDataService dataService = new JsonDataService(apiGetPath);


        //    // GET request to the user endpoint => format JSON response => return as MediumUser List
        //    // Set _characters (_users) to a list of users returned from the API call
        //    // TODO: Replace _characters with _users or _mediumUsers

        //    _publications = dataService.ReadAll(); // Update data bindings to correctly map the character class
        //                                          // Also, can modify ReadAll to accept an object type
        //                                          // to conditionally handle field mapping.

        //    //
        //    // bind list to DataGridView control
        //    //
        //    var bindingList = new BindingList<MediumPublication>(_publications);
        //    var source = new BindingSource(bindingList, null);

        //    // TODO:  Possibly rename control name attribute to mach new Data Access schema
        //    dataGridView_Characters.DataSource = source;

        //    //
        //    // configure DataGridView control
        //    //
        //    this.dataGridView_Characters.Columns["Id"].Visible = true;
        //    this.dataGridView_Characters.Columns["name"].Visible = true;
        //    this.dataGridView_Characters.Columns["description"].Visible = false;
        //    this.dataGridView_Characters.Columns["url"].Visible = false;
        //    this.dataGridView_Characters.Columns["imageUrl"].Visible = false;
        //    //this.dataGridView_Characters.Columns["url"].Visible = false;
        //    //this.dataGridView_Characters.Columns["imageUrl"].Visible = false;
        //}
    }
}
