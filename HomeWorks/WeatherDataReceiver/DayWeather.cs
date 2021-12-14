

namespace WeatherDataReceiver;

/// <summary> Класс, описывающий данные о погоде одного дня. </summary>
public struct DayWeather
{
    /// <summary> Дата. </summary>
    public string Day { get; internal set; }
    /// <summary> Изображение погоды. </summary>
    public string IconAddress { get; internal set; }
    /// <summary> Температура днем. </summary>
    public string TempDay { get; internal set; }
    /// <summary> Температура ночью. </summary>
    public string TempNight { get; internal set; }
}
