using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for RGBWindow.xaml
    /// </summary>
    public partial class RGBWindow : Window
    {
        public RGBWindow()
        {
            InitializeComponent();
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            var value = uxNumber.Value;
            MessageBox.Show("Your number is " + value);

        }
    }
}
