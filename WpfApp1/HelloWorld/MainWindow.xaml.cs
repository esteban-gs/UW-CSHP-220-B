using Microsoft.EntityFrameworkCore;
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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// use this for next assignment: https://www.wpf-tutorial.com/basic-controls/the-passwordbox-control/

        private Models.User user = new Models.User();

        public MainWindow()
        {
            InitializeComponent();
            // using the inMemory entity
            uxMainWindowContainer.DataContext = user;

            uxContainer.DataContext = user;
            // using the Sample Context to access DB with EF
            var sample = new SampleContext();
            sample.User.Load();
            var users = sample.User.Local.ToObservableCollection();
            uxList.ItemsSource = users;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);

            var window = new SecondWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }

        private void ValidateForm(object sender, TextChangedEventArgs e)
        {
            uxSubmit.IsEnabled = false;
            if (!string.IsNullOrWhiteSpace(uxName.Text) && !string.IsNullOrWhiteSpace(uxPassword.Text))
            {
                uxSubmit.IsEnabled = true;
            }

        }
    }
}
