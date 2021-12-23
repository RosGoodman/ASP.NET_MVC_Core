
using System.Windows;
using DiskReportModule.View;

namespace Starter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DiskReportWindow reportWindow = new DiskReportWindow();
            reportWindow.Show();
        }
    }
}
