
using System.Text;

namespace PseudoScaner.Converter
{
    /// <summary> Конвертирование данных. </summary>
    internal struct DataConverter
    {
        /// <summary> Конвертировать данные в массив байт. </summary>
        /// <param name="time"> Время. </param>
        /// <param name="cpuData"> Данные CPU. </param>
        /// <param name="ramData"> Данные. RAM </param>
        /// <param name="text"> Текст файла. </param>
        /// <returns> Массив байт. </returns>
        internal byte[] ConvertToByte(DateTimeOffset time, int cpuData, int ramData, string text)
        {
            return Encoding.ASCII.GetBytes($"{time}, cpuUsage: {cpuData}, ramUsage: {ramData}, text: {text}");
        }
    }
}
