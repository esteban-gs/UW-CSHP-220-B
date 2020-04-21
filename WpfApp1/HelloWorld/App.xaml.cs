using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Application.Current.DispatcherUnhandledException +=
                Current_DispatchesException;
        }

        private void Current_DispatchesException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.Exception;
            MessageBox.Show(ex.Message, "Unhandled Exception");
            e.Handled = true;

            if (e.Exception is OutOfMemoryException)
            {
                //
            }
        }
    }
}
