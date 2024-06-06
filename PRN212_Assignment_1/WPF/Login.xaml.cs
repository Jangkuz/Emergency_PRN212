using Repositories.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnhdlSE181818WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //validation
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                System.Windows.Forms.MessageBox.Show("Pleae input both email & password", "Input plz.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AdminService adminSer = new();
            if (adminSer.CheckLogin(txtEmail.Text, txtPassword.Text))
            {
                AdminMain adM = new();
                adM.Show();
                this.Hide();
            }//end admin login
            else
            {
                CustomerServices cusService = new();
                Customer? cus = cusService.CheckLogin(txtEmail.Text, txtPassword.Text);
                if (cus == null)
                {
                    System.Windows.Forms.MessageBox.Show("Login failed. Check the email and password again!", "Wrong credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cus.CustomerStatus != 1)
                {
                    System.Windows.Forms.MessageBox.Show("You have no permission to access this function!", "Wrong privilege", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CustomerMain w = new();
                w.Show();
                this.Hide();
            }//end customer login
        }
    }
}
