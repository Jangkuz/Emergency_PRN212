using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnhdlSE181818WPF.Resources
{
    public static class ResuableEvent
    {
        public static void OnWindowLoaded(object sender, RoutedEventArgs e, Customer? curUser)
        {
            if (sender is Window window)
            {
                //Console.WriteLine($"Window {window.Title} loaded.");
                if(curUser == null)
                {
                    MessageBox.Show("User not logined, please login!", "Invalid operation", MessageBoxButton.OK, MessageBoxImage.Error);
                    var loginWindow = new LoginWindow();
                    loginWindow.Show();
                    ((Window)sender).Close();
                }
                // Add additional logic here
            }
        }
    }
}
