
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WeatherDataReceiver;

namespace HomeWorks
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DayWeather> _daysWeather;

        /// <summary> Коллекция дней с данными о погоде. </summary>
        public ObservableCollection<DayWeather> DaysWeather
        {
            get { return _daysWeather; }
            set
            {
                _daysWeather = value;
                OnPropertyChanged("DaysWeather");
            }
        }

        public WeatherViewModel() { }

        /// <summary> Загрузить данные о погоде. типа "команда" </summary>
        public async void LoadWeatherFromYandex()
        {
            Facade facade = new Facade();
            DaysWeather = await Task.Run(() => facade.GetWeatherFromYandexAsync());
        }

        #region propertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
}
