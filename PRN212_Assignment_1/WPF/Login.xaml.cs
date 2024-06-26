﻿using Repositories.Entities;
using Services;
using System.Windows;
using System.Windows.Input;

namespace AnhdlSE181818WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private CustomerServices _cusService = new();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //validation
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Pleae input both email & password", "Input plz.", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            AdminService adminSer = new();
            if (adminSer.CheckLogin(txtEmail.Text, txtPassword.Password))
            {
                AdminMain adM = new();
                adM.Show();
                this.Close();
            }//end admin login
            else
            {
                Customer? cus = _cusService.CheckLogin(txtEmail.Text, txtPassword.Password);
                if (cus == null)
                {
                    MessageBox.Show("Login failed. Check the email and password again!", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (cus.CustomerStatus != 1)
                {
                   MessageBox.Show("You have no permission to access this function!", "Wrong privilege", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                CustomerMain w = new();
                w.CurUser = cus;
                w.Show();
                this.Close();
            }//end customer login
        }

        private void btnManageCustomer_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void winLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
