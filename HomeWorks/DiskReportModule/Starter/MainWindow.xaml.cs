
using System.Windows;

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
            DiskReportModule.View.DiskReportWindow reportWindow = new DiskReportModule.View.DiskReportWindow("C:\\");
        }
    }
}
