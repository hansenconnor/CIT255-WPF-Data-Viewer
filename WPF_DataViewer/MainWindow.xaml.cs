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

            // Get a list of Medium Publications
            _publications = new ObservableCollection<MediumPublication>
            {
                new Person {Name = "connor", Age = 22 },
                new Person {Name = "connor", Age = 22 },
                new Person {Name = "connor", Age = 22 },
                new Person {Name = "connor", Age = 22 },
                new Person {Name = "connor", Age = 22 }
            };

            _list.ItemsSource = _publications;
        }
    }
}
