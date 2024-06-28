using Microsoft.IdentityModel.Tokens;
using PE_PRN212_SU24TrialTest_DoLongAnh.Repo;
using PE_PRN212_SU24TrialTest_DoLongAnh.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Shapes;

namespace PE_PRN212_SU24TrialTest_DoLongAnh.WPF
{
    /// <summary>
    /// Interaction logic for CreateUpdateAirConditioner.xaml
    /// </summary>
    public partial class CreateUpdateAirConditioner : Window
    {
        private const string updateTitle = "Update Air Conditioner";
        private readonly SupplierCompanyRepository _supplierRepo = new();
        private readonly AirConditionerRepository _acRepo = new();
        public AirConditioner? selectedAc { get; set; } = null;

        public CreateUpdateAirConditioner()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboSupplier.Items.Clear();
            cboSupplier.ItemsSource = _supplierRepo.GetAllSuppliers();
            cboSupplier.DisplayMemberPath = nameof(SupplierCompany.SupplierName);
            cboSupplier.SelectedValuePath = nameof(SupplierCompany.SupplierId);
            cboSupplier.SelectedIndex = 0;
            if (selectedAc != null)
            {
                lblTitle.Content = updateTitle;

                txtAirConditionerId.Text = selectedAc.AirConditionerId.ToString();
                txtAirConditionerId.IsEnabled = false;

                txtAirConditionerName.Text = selectedAc.AirConditionerName;
                txtDollarPrice.Text = selectedAc.DollarPrice.ToString();
                txtFeatureFunction.Text = selectedAc.FeatureFunction;
                txtQuantity.Text = selectedAc.Quantity.ToString();
                txtSoundPressureLevel.Text = selectedAc.SoundPressureLevel;
                txtAirConditionerWarranty.Text = selectedAc.Warranty;
                cboSupplier.SelectedValue = selectedAc.SupplierId;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidInputFields())
            {
                MessageBox.Show("Action unsuccessful!!\nPlease ensure info in entered correctly", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            //var selectedSupplier = cboSupplier.SelectedValue
            AirConditioner? actionResult = null;
            AirConditioner newAc = new()
            {
                AirConditionerId = int.Parse(txtAirConditionerId.Text),
                AirConditionerName = txtAirConditionerName.Text,
                Warranty = txtAirConditionerWarranty.Text,
                DollarPrice = double.Parse(txtDollarPrice.Text),
                FeatureFunction = txtFeatureFunction.Text,
                Quantity = int.Parse(txtQuantity.Text),
                SoundPressureLevel = txtSoundPressureLevel.Text,
                SupplierId = cboSupplier.SelectedValue as string
            };
            if (selectedAc != null)
            {
                actionResult = _acRepo.UpdateAirConditioner(newAc);
            }//end update flow
            else
            {
                actionResult = _acRepo.AddAirConditioner(newAc);
            }//end add flow

            if (actionResult != null)
            {
                MessageBox.Show("Action successful!!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Action unsuccessful!!", "Result", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            this.Close();
        }

        private void numberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Get the full string of the text box
            TextBox textBox = sender as TextBox;
            string text = textBox!.Text.Insert(textBox.SelectionStart, e.Text);

            bool IsEventHandled = true;

            int enteredValue;
            if (Int32.TryParse(text, out enteredValue))
            {
                IsEventHandled = false;
            }
            e.Handled = IsEventHandled;
        }
        private void doubleOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Get the full string of the text box
            TextBox textBox = sender as TextBox;
            string text = textBox!.Text.Insert(textBox.SelectionStart, e.Text);

            bool IsEventHandled = true;

            double enteredValue;
            if (double.TryParse(text, out enteredValue))
            {
                IsEventHandled = false;
            }
            e.Handled = IsEventHandled;
        }

        private bool IsAcNameCorrectFormat(string acName)
        {
            Regex regex = new Regex("(?:\\b[A-Z1-9][a-zA-Z0-9!@#$%^&*()_+={}\\[\\]:;\"'<>,.?\\/\\\\|-]*\\b\\s*)+");
            return regex.IsMatch(acName);
        }

        private bool ValidInputFields()
        {
            bool noErrors = true;
            if (selectedAc == null)
            {
                if (!ValidAcId())
                {
                    noErrors = false;
                }
            }//end check Id when creating

            if (!ValidAcName())
            {
                noErrors = false;
            }

            if (!ValidAcWarranty())
            {
                noErrors = false;
            }

            if (!ValidAcSoundPressure())
            {
                noErrors = false;
            }

            if (!ValidAcFeature())
            {
                noErrors = false;
            }

            if (!ValidAcQuantity())
            {
                noErrors = false;
            }

            if (!ValidAcPrice())
            {
                noErrors = false;
            }

            return noErrors;
        }

        private bool ValidAcId()
        {
            string acStringId = txtAirConditionerId.Text;
            if (acStringId.IsNullOrEmpty())
            {
                lblErrAirConditionerId.Content = "*Required";
                return false;
            }

            bool noErrors = true;

            int acIntId = 0;
            if (!Int32.TryParse(acStringId, out acIntId))
            {
                noErrors = false;
                lblErrAirConditionerId.Content = "Id require number only";
            }//end invalid input
            else
            {
                var existedAc = _acRepo.GetAcById(acIntId);
                if (existedAc != null)
                {
                    noErrors = false;
                    lblErrAirConditionerId.Content = "Duplicate id";
                }
            }//end duplcate id

            if (noErrors)
            {
                lblErrAirConditionerId.Content = "";
            }
            return noErrors;
        }

        private bool ValidAcName()
        {
            string acName = txtAirConditionerName.Text;
            if (acName.IsNullOrEmpty())
            {
                lblErrAirConditionerName.Content = "*Required";
                return false;
            }

            bool noErrors = true;

            if (acName.Length < 5 || 90 <= acName.Length)
            {
                noErrors = false;
                lblErrAirConditionerName.Content = "Name must between 5 and 90 characters";
            }//end invalid name length
            else
            {
                if (!IsAcNameCorrectFormat(acName))
                {
                    noErrors = false;
                    lblErrAirConditionerName.Content = "AirConditionerName must begin with the capital letter or digits (1 – 9)";
                }
            }//end invalid name format

            if (noErrors)
            {
                lblErrAirConditionerName.Content = "";
            }
            return noErrors;
        }

        private bool ValidAcWarranty()
        {
            string acWarranty = txtAirConditionerWarranty.Text;
            if (acWarranty.IsNullOrEmpty())
            {
                lblErrWarranty.Content = "*Required";
                return false;
            }
            bool noErrors = true;

            if (noErrors)
            {
                lblErrWarranty.Content = "";
            }
            return noErrors;
        }

        private bool ValidAcSoundPressure()
        {
            string acSoundPressure = txtSoundPressureLevel.Text;
            if (acSoundPressure.IsNullOrEmpty())
            {
                lblErrSoundPressureLevel.Content = "*Required";
                return false;
            }
            bool noErrors = true;

            if (noErrors)
            {
                lblErrSoundPressureLevel.Content = "";
            }
            return noErrors;
        }

        private bool ValidAcFeature()
        {
            string acFeature = txtFeatureFunction.Text;
            if (acFeature.IsNullOrEmpty())
            {
                lblErrFeatureFunction.Content = "*Required";
                return false;
            }
            bool noErrors = true;

            if (noErrors)
            {
                lblErrFeatureFunction.Content = "";
            }
            return noErrors;
        }

        private bool ValidAcQuantity()
        {
            string acQuantity = txtQuantity.Text;
            if (acQuantity.IsNullOrEmpty())
            {
                lblErrQuantity.Content = "*Required";
                return false;
            }

            const int invalidQuantityInput = -1;

            bool noErrors = true;
            int acIntQuantity = 0;
            if (!Int32.TryParse(acQuantity, out acIntQuantity))
            {
                noErrors = false;
                acIntQuantity = invalidQuantityInput;
                lblErrQuantity.Content = "Quantity require number only";
            }//end invalid input

            if (acIntQuantity != invalidQuantityInput)
            {
                if (acIntQuantity < 0 || 4_000_000 < acIntQuantity)
                {
                    noErrors = false;
                    lblErrQuantity.Content = "Value entered must be between 0 to 4,000,000";
                }
            }//end value out of range

            if (noErrors)
            {
                lblErrQuantity.Content = "";
            }
            return noErrors;
        }

        private bool ValidAcPrice()
        {
            string acPrice = txtDollarPrice.Text;
            if (acPrice.IsNullOrEmpty())
            {
                lblErrDollarPrice.Content = "*Required";
                return false;
            }

            const double invalidDolarPriceInput = -1;

            bool noErrors = true;
            double acDoublePrice = 0;
            if (!Double.TryParse(acPrice, out acDoublePrice))
            {
                noErrors = false;
                acDoublePrice = invalidDolarPriceInput;
                lblErrDollarPrice.Content = "Price require number only";
            }//end invalid input

            if (acDoublePrice != invalidDolarPriceInput)
            {
                if (acDoublePrice < 0 || 4_000_000 < acDoublePrice)
                {
                    noErrors = false;
                    lblErrDollarPrice.Content = "Value entered must be between 0 to 4,000,000";
                }
            }//end value out of range

            if (noErrors)
            {
                lblErrDollarPrice.Content = "";
            }
            return noErrors;
        }
    }
}
