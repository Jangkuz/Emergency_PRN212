using System.Windows;

namespace AnhdlSE181818WPF
{
    /// <summary>
    /// Interaction logic for AdminCreateReport.xaml
    /// </summary>
    public partial class AdminCreateReport : Window
    {
        public AdminCreateReport()
        {
            InitializeComponent();
        }

        private void btnBackToAdmin_Click(object sender, RoutedEventArgs e)
        {
                //System.Windows.Application.Current.Shutdown();
                this.Close();
        }
    }
}
