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
using System.Windows.Shapes;

namespace AnhdlSE181818WPF
{
    /// <summary>
    /// Interaction logic for CustomerMain.xaml
    /// </summary>
    public partial class CustomerMain : Window
    {
        public CustomerMain()
        {
            InitializeComponent();
        }

        private void btnManageCustomer_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }
    }
}