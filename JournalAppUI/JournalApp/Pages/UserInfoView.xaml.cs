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
    /// Interaction logic for UserInfoView.xaml
    /// </summary>
    public partial class UserInfoView : Page
    {
        User user = UserContext.User;

        public UserInfoView()
        {
            InitializeComponent();
            FirstNameText.Text = user.FirstName;
            LastNameText.Text = user.LastName;
            MiddleText.Text = user.MI;
            UserNameText.Text = user.UserName;
            PasswordText.Password = user.Password;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            user.FirstName = FirstNameText.Text;
            user.LastName = LastNameText.Text;
            user.MI = MiddleText.Text;
            user.UserName = UserNameText.Text;
            user.Password = PasswordText.Password;
            user.UpdateUser();
            this.NavigationService.Navigate(new Uri(@"Pages\EntryView.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"Pages\EntryView.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
