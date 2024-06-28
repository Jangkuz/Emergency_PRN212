using PE_PRN212_SU24TrialTest_DoLongAnh.Repo;
using PE_PRN212_SU24TrialTest_DoLongAnh.Repo.Entities;
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

namespace PE_PRN212_SU24TrialTest_DoLongAnh.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly StaffMemberRepository _staffRepo = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string loginEmail = txtEmail.Text;
            string loginPwd = txtPassword.Password;

            StaffMember? loginStaff = _staffRepo.CheckLogin(loginEmail, loginPwd);
            if (loginStaff == null)
            {
                MessageBox.Show("Invalid email or password", "Login unsuccessful", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (loginStaff.Role == 3)
            {
                MessageBox.Show("You have no pemission to access this function!", "Unauthorized", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            } // end loginStaff is Member

            AirConditionerManager acManagerWin = new();
            acManagerWin.loginedStaff = loginStaff;
            acManagerWin.Show();
            this.Close();
        }

    }
}