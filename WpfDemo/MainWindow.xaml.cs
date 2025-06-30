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

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ShowSelectedDate_Click(object sender, RoutedEventArgs e)
        {
            if (MyDatePicker.SelectedDate.HasValue)
            {
                DateTime selected = MyDatePicker.SelectedDate.Value;
                MessageBox.Show($"تاریخ انتخاب‌شده (میلادی): {selected:yyyy/MM/dd}", "تاریخ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("هیچ تاریخی انتخاب نشده است.", "خطا", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

}