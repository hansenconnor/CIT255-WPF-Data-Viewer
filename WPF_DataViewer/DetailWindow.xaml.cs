using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace WPF_DataViewer
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
       
        private MediumPublication _selectedPublication;

        public MediumPublication SelectedPublication
        {
            get { return _selectedPublication; }
            set { _selectedPublication = value; }
        }


        public DetailWindow(MediumPublication publication)
        {
            InitializeComponent();

            _selectedPublication = publication;

            // Add the description to the Window
            _publicationDescription.Inlines.Add(new Run(_selectedPublication.description));
            // Add the title
            _publicationTitle.Content = _selectedPublication.name;
            // Add the URL
            _publicationLink.Inlines.Add(new Run(_selectedPublication.url));
            Uri publicationLink = new Uri(_selectedPublication.url);
            _publicationLink.NavigateUri = publicationLink;

            



            var publicationImage = new Image();
            var fullFilePath = _selectedPublication.imageUrl;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();

            _publicationImage.Source = bitmap;

        }

        private void Label_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
