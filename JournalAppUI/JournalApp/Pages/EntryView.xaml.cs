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
    /// Interaction logic for EntryView.xaml
    /// </summary>
    public partial class EntryView : Page
    {
        Entry BaseEntry = new Entry();
       
        public EntryView()
        {
            InitializeComponent();
            EntryList.ItemsSource = BaseEntry.GetEntry(UserContext.User);
            Application.Current.Resources["GridVisibility"] = Visibility.Visible;
        }

        private void NewEntry_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"Pages\NewEntryView.xaml", UriKind.RelativeOrAbsolute));
        }

        private void EntryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Entry entry = new Entry();
            EntryViewText.SelectAll();
            EntryViewText.Selection.Text = "";
            entry = (Entry)EntryList.SelectedItem;
            BaseEntry = entry;
            TitleText.Text = entry.Title;
            DateText.Text = entry.EntryDate.ToShortDateString();
            LocationText.Text = $"{entry.Location.City}, {entry.Location.State}";
            EntryViewText.AppendText(entry.Text);
        }

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
            EntryViewText.SelectAll();
            BaseEntry.Text = EntryViewText.Selection.Text;
            BaseEntry.User = UserContext.User;
            BaseEntry.UpdateEntry();
            SnackbarThree.MessageQueue.Enqueue($"{BaseEntry.Title} Has been updated");
        }
    }
}
