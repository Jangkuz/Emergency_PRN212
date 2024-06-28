using Microsoft.IdentityModel.Tokens;
using PE_PRN212_SU24TrialTest_DoLongAnh.Repo;
using PE_PRN212_SU24TrialTest_DoLongAnh.Repo.Entities;
using System;
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

namespace PE_PRN212_SU24TrialTest_DoLongAnh.WPF
{
    /// <summary>
    /// Interaction logic for AirConditionerShow.xaml
    /// </summary>
    public partial class AirConditionerManager : Window
    {
        private readonly AirConditionerRepository _airConditionerRepo = new();
        private readonly SupplierCompanyRepository _supplierCompanyRepo = new();
        public StaffMember? loginedStaff { private get; set; }
        private AirConditioner? selectedAirCon;
        public AirConditionerManager()
        {
            InitializeComponent();
        }

        private void dtgAirConditioner_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            SetDtgItemsSource(_airConditionerRepo.GetAllAC());
        }

        private void SetDtgItemsSource(List<AirConditioner> airConditioners)
        {
            var itemsSource = airConditioners.Select(ac => new
            {
                AirConditionerId = ac.AirConditionerId,
                AirConditionerName = ac.AirConditionerName,
                Warranty = ac.Warranty,
                SoundPressureLevel = ac.SoundPressureLevel,
                FeatureFunction = ac.FeatureFunction,
                Quantity = ac.Quantity,
                DollarPrice = ac.DollarPrice,
                SupplierId = ac.SupplierId,
                Supplier = _supplierCompanyRepo.GetSupplierCompanyById(ac.SupplierId!)!.SupplierName
                //Supplier = ac.Supplier?.SupplierName
            }).ToList();
            dtgAirConditioner.ItemsSource = null;
            dtgAirConditioner.ItemsSource = itemsSource;
        }

        private void EnableButtonForAdmin(object sender, RoutedEventArgs e)
        {
            if (loginedStaff == null)
            {
                return;
            }//end loginedStaff is null

            if (loginedStaff.Role != 1)
            {
                return;
            }//end loginedStaff is not admin

            if (sender is Button)
            {
                ((Button)sender).IsEnabled = true;
            }
        }

        private T? GetDtgSelectedItemAttr<T>(object selectedItem, string attrName)
        {
            if (selectedItem == null)
            {
                return default(T);
            }

            T result = default(T);

            try
            {
                System.Type itemType = selectedItem.GetType();
                result = (T)itemType
                    .GetProperty(attrName)!
                    .GetValue(selectedItem, null)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDtgSelectedItemAttr: " + ex.Message);
            }
            return result;

        }

        private void btnCreate_Loaded(object sender, RoutedEventArgs e)
        {
            EnableButtonForAdmin(sender, e);
        }

        private void btnUpdate_Loaded(object sender, RoutedEventArgs e)
        {
            EnableButtonForAdmin(sender, e);
        }

        private void btnDelete_Loaded(object sender, RoutedEventArgs e)
        {
            EnableButtonForAdmin(sender, e);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string featureFuncDes = txtFeatureFunction.Text;
            List<AirConditioner> searchResult = new();
            try
            {
                //util method: parst string to number, handle exception
                int inputQuantity = 0;
                if (!txtQuantity.Text.IsNullOrEmpty())
                {
                    inputQuantity = int.Parse(txtQuantity.Text);

                }
                searchResult = _airConditionerRepo.SearchByFeatureAndQuantity(featureFuncDes, inputQuantity);
            }
            catch (FormatException formatEx)
            {
                Console.WriteLine("AirConditionerManager_btnSearch_Click: " + formatEx.Message);
                MessageBox.Show("Please enter a valid quantity", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                SetDtgItemsSource(searchResult);
            }
        }

        private void dtgAirConditioner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgAirConditioner.SelectedItem != null)
            {
                //System.Type type = dtgAirConditioner.SelectedItem.GetType();
                //int selectedAirConId = (int)type.GetProperty("AirConditionerId")!.GetValue(dtgAirConditioner.SelectedItem, null)!; 

                int selectedAirConId = GetDtgSelectedItemAttr<int>(dtgAirConditioner.SelectedItem, "AirConditionerId");

                selectedAirCon = _airConditionerRepo.GetAcById(selectedAirConId);

            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //create create/update window
            CreateUpdateAirConditioner createUpdateWindow = new();
            createUpdateWindow.ShowDialog();
            ReloadDataGrid();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAirCon == null)
            {
                MessageBox.Show("Please select an air conditioner to continue", "Incomplete action", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            CreateUpdateAirConditioner createUpdateWindow = new();
            createUpdateWindow.selectedAc = selectedAirCon;
            createUpdateWindow.ShowDialog();
            ReloadDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAirCon == null)
            {
                MessageBox.Show("Please select an air conditioner to continue", "Incomplete action", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var msgBoxResult = MessageBox.Show("Are you sure you truly want to delete this item?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (msgBoxResult == MessageBoxResult.Yes)
            {
                _airConditionerRepo.DeleteAirConditioner(selectedAirCon);
            }
            ReloadDataGrid();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new();
            loginWindow.Show();
            this.Close();
        }
    }
}
