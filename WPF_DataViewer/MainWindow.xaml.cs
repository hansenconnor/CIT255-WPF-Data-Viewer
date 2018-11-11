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

        /// <summary>
        /// Display the list item details in a new window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Null check
            if (_list.SelectedItem == null)
            {
                MessageBox.Show("Please select a publication to view!", "Error");
                return;
            }

            // Instantiate new detail window and pass the selected publication
            Window detailWindow = new DetailWindow(_list.SelectedItem as MediumPublication);

            // Show the detail window
            detailWindow.Show();
        }


        /// <summary>
        /// Display help window when the Help button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window HelpWindow = new HelpWindow();
            HelpWindow.Show();
        }

        /// <summary>
        /// Get and display the search results when the search button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Get the search query
            var searchQuery = _searchBox.Text;

            // Check if empty
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                MessageBox.Show("Please enter a valid query...", "Error");
                return;
            }

            // Get search results
            var searchedList = _publications.Where(p => p.name.ToUpper().Contains(searchQuery.ToUpper())).ToList();

            // Null check
            if (searchedList == null)
            {
                MessageBox.Show("No results to display. Update your search query and try again.", "Not Found");
                // Display initial result set
                _list.ItemsSource = _publications;
                return;

            }

            // Search results not empty => display results into listbox
            _list.ItemsSource = searchedList;
        }


        /// <summary>
        /// Close the application and all open/active windows when the Exit button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
            {
                Mouse.OverrideCursor = Cursors.AppStarting;
            }
            Cursor activeCursor;
            activeCursor = Cursors.AppStarting;
            Mouse.OverrideCursor = activeCursor;
            Application.Current.Shutdown(); // Close all windows
            Environment.Exit(0); // Exit application
        }


        /// <summary>
        /// Filter the list box items by the publication name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // Sort is static => Users should choose which parameter they wish to sort on
            var sortedList = _publications.OrderBy(p => p.name).ToList();
            _list.ItemsSource = sortedList;
        }


        /// <summary>
        /// Sort the list box items by the publication name where the name is NMC CIT255
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // Filter is static => should be dynamic in future version.
            var filteredList = _publications.Where(p => p.name == "NMC CIT 255").ToList();
            _list.ItemsSource = filteredList;
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
