﻿using Homework3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Homework3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new User { Name = "Lisa", Password = "3LisaPwd" });


            uxList.ItemsSource = users;

        }

        private void uxListNameColumHeader_Click(object sender, RoutedEventArgs e)
        {
            uxList_SortingViewHelper(nameof(User.Password), ListSortDirection.Ascending);
        }

        private void uxListPasswordColumHeader_Click(object sender, RoutedEventArgs e)
        {
            uxList_SortingViewHelper(nameof(User.Name), ListSortDirection.Ascending);
        }


        // Shared functionality for uxList
        private void uxList_SortingViewHelper(string propName, ListSortDirection direction)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            uxList.Items.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(propName, direction));
        }
    }
}
