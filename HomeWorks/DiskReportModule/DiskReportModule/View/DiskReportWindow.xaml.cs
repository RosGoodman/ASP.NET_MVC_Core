
using System.Windows;
using DiskReportModule.ViewModel;

namespace DiskReportModule.View
{
    /// <summary>
    /// Логика взаимодействия для DiskReportWindow.xaml
    /// </summary>
    public partial class DiskReportWindow : Window
    {
        public DiskReportWindow()
        {
            InitializeComponent();
            DataContext = new ReportWindowViewModel();
        }
    }
}
