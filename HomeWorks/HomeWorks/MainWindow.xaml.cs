using System.Windows;

namespace HomeWorks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WeatherViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new WeatherViewModel();
            DataContext = _viewModel;
        }

        /// <summary> Кнопка. Загрузить данные о погоде с Yandex. </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadWeatherFromYandex();
        }
    }
}
