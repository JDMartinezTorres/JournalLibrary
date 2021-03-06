﻿using System;
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
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Page
    {
        User user = new User();
        public CreateUser()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"Pages\LogIn.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Visibility = Visibility.Collapsed;
            user.FirstName = FirstNameText.Text;
            user.LastName = LastNameText.Text;
            user.MI = MiddleText.Text;
            user.UserName = UserNameText.Text;
            user.Password = PasswordText.Password;
            if (!string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrWhiteSpace(user.LastName) && !string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Password))
            {
                user.NewUser();
                this.NavigationService.Navigate(new Uri(@"Pages\LogIn.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
