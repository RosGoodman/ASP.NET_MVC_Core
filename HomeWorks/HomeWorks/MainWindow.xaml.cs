
using System.Windows;
using WeatherDataReceiver;

namespace HomeWorks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Receiver receiver = new Receiver();
            receiver.RequestTo("https://yandex.ru/pogoda/month?lat=59.938951&lon=30.315635&via=hnav");
        }
    }
}
