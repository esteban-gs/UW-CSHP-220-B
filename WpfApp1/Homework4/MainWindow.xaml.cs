using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsValidPostalCode { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextChangedEventArgs e)
        {
            var fullText = UxNumberTextBox.Text;

            var usZipRegEx = @"^(\d{5}(?:\-\d{4})?)$";
            var caZipRegEx = @"^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} *\d{1}[A-Z]{1}\d{1}$";
            Regex usRegex = new Regex(usZipRegEx);
            Regex caRegex = new Regex(caZipRegEx);

            IsValidPostalCode = (usRegex.IsMatch(fullText)) || (caRegex.IsMatch(fullText));

            //Enable Submit if validation passes
            UxSubmit.IsEnabled = IsValidPostalCode;

            Uxoutput.Content = $"Valid Postal Code: {IsValidPostalCode}";
        }
    }
}
