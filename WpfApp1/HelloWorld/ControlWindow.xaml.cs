using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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
    /// Interaction logic for ControlWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window
    {
        public ControlWindow()
        {
            InitializeComponent();
        }

        private void uxLocal_Clicked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            if (checkBox.IsChecked.Value)
            {
                var msg = Application.Current.FindResource("LocalChecked").ToString();
                MessageBox.Show(msg);
            }
            else
            {
                MessageBox.Show($"Local UnChecked");
            }
        }

        private void uxNavigator_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Convert the Uri into a string
            var fileName = e.Uri.AbsoluteUri;

            // Pass the fileName to the helper class
            var processStartInfo = new ProcessStartInfo(fileName)
            {
                UseShellExecute = true,
                Verb = "open",
            };

            // Start a new process
            Process.Start(processStartInfo);
        }
    }
}
