
using System.Windows;
using DiskReportModule.ViewModel;

namespace DiskReportModule.View
{
    /// <summary>
    /// Логика взаимодействия для DiskReportWindow.xaml
    /// </summary>
    public partial class DiskReportWindow : Window
    {
        //предполагается заппуск модуля из основной программы с указанием имени диска

        public DiskReportWindow(string diskName)
        {
            InitializeComponent();
            DataContext = new ReportWindowViewModel(diskName);
        }
    }
}
