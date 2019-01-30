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
using JournalLibrary;

namespace JournalApp.Pages
{
    /// <summary>
    /// Interaction logic for NewEntryView.xaml
    /// </summary>
    public partial class NewEntryView : Page
    {
        //TODO: Instaniate a new Entry Object.
        Entry Entry = new Entry();
        Location Baselocation = new Location();
        public NewEntryView()
        {
            InitializeComponent();
            Baselocation.User = UserContext.User;
            LocationBox.ItemsSource = Baselocation.SelectLocation();
        }

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            Location location = new Location();
            location.User = UserContext.User;
            location.City = InputCity.Text;
            location.State = InputState.Text;
            location.NewLocation();
            LocationBox.ItemsSource = Baselocation.SelectLocation();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Save all Entry Items.
            EntryText.SelectAll();
            Entry.Title = TitleText.Text;
            Entry.Text = EntryText.Selection.Text;
            Entry.EntryDate = DateTime.Parse(DateText.Text);
            Entry.Location = (Location)LocationBox.SelectedItem;
            Entry.User = UserContext.User;
            Entry.NewEntry();
            
            SnackbarThree.MessageQueue.Enqueue($"{Entry.Title} Has been saved");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"Pages\EntryView.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
