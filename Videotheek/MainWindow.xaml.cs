using System;
using System.Collections.Generic;
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
using Gemeenschap;

namespace Videotheek
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource filmViewSource = ((CollectionViewSource)(this.FindResource("filmViewSource")));
            var manager = new Videomanager();
            filmViewSource.Source = manager.GetFilms();
            genreNrCbBox.DisplayMemberPath = "GenreName";
            genreNrCbBox.SelectedValuePath = "GenreNr";           
            genreNrCbBox.ItemsSource = manager.GetGenre();
            
        }

        private void btToevoegbevestig_Click(object sender, RoutedEventArgs e)
        {
            layoutInstel(); 
        }

        private void layoutInstel ()
        {
            //lbFilms.SelectedItem = null;
            btToevoegbevestig.Content = "Bevestigen";
            btVerwijdAnnuleer.Content = "Annuleren";
            btAllesOpslaan.IsEnabled = false;
            btVerhuur.IsEnabled = false;
            lbFilms.IsEnabled = false;
            titelTextBox.IsReadOnly = false;
            genreNrCbBox.IsEnabled = true;
            inVoorraadTextBox.IsReadOnly = false;
            uitVoorraadTextBox.IsReadOnly = false;
            prijsTextBox.IsReadOnly = false;
            totaalVerhuurdTextBox.IsReadOnly = false;
        }
           }

}
