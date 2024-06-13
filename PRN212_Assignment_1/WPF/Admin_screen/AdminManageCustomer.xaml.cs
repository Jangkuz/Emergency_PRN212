using Repositories.Entities;
using Services;
using System.Windows;
using System.Windows.Controls;

namespace AnhdlSE181818WPF
{
    /// <summary>
    /// Interaction logic for AdminManageCustomer.xaml
    /// </summary>
    public partial class AdminManageCustomer : Window
    {
        private CustomerServices _customerServices = new CustomerServices();
        private Customer? _selected = null;
        public AdminManageCustomer()
        {
            InitializeComponent();
        }

        private void FillDataGridCustomer()
        {
            dtgShowCustomer.ItemsSource = null;
            dtgShowCustomer.ItemsSource = _customerServices.GetCustomers();
        }

        private void btnBackToAdmin_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Application.Current.Shutdown();
            this.Close();
        }

        private void dtgShowCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            //dtgShowCustomer.ItemsSource = null; //clean
            //dtgShowCustomer.ItemsSource = service.GetCustomers();
            FillDataGridCustomer();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dtgShowCustomer.ItemsSource = null;
            dtgShowCustomer.ItemsSource = _customerServices.SearchByNameAndEmail(txtSearchName.Text, txtSearchEmail.Text);
        }

        private void dtgShowCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgShowCustomer.SelectedItems.Count > 0)
            {
                _selected = (Customer)dtgShowCustomer.SelectedItem;
            }
            else
            {
                _selected = null;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null)
            {
                System.Windows.MessageBox.Show("Please select one customer to delete!", "Select one customer", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            MessageBoxResult answer = System.Windows.MessageBox.Show($"Are you sure that you want to delete {_selected.CustomerFullName}?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
            {
                return;
            }

            _customerServices.SetCustomerStatusAsDelete(_selected);

            FillDataGridCustomer();

            _selected = null;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            AdminManageCustomerDetail w = new();
            w.ShowDialog();

            FillDataGridCustomer();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_selected != null)
            {
                AdminManageCustomerDetail w = new();
                w.SelectedCustomer = _selected;

                w.ShowDialog();
                FillDataGridCustomer();
            }
            else
            {
                System.Windows.MessageBox.Show("Please select a certain customer to edit!", "Select on customer", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
