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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        User user = new User();

        public LogIn()
        {
            InitializeComponent();
        }

        private void UserLogIn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Check input
            user.UserName = UserNameText.Text;
            user.Password = PasswordText.Password;
            UserContext.User = user.GetUser(user).FirstOrDefault();
            if (UserContext.PasswordCorrect(user))
            {
             this.NavigationService.Navigate(new Uri(@"Pages\EntryView.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                UserNameText.Text = "Password incorrect ";
                PasswordText.Password = null;
            }

        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"Pages\CreateUser.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
