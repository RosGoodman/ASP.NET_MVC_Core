
using ByteDataSaver;
using PseudoScaner.Converter;
using System.Diagnostics;

namespace PseudoScaner.ScanerJobs
{
    /// <summary> Класс, описывающий работу. (Получение данных). </summary>
    internal class ScanEmulatorJob : IScanEmulatorJob
    {
        private IScanFileEmulator _scan;
        private IDataSaver _dataSaver;
        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _ramCounter;

        /// <summary> Создать экземпляр класса ScanEmulatorJob. </summary>
        public ScanEmulatorJob(IScanFileEmulator scan, IDataSaver dataSaver)
        {
            _scan = scan;
            _dataSaver = dataSaver;
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        /// <summary> Выполнение работы. </summary>
        /// <returns></returns>
        public async Task Execute()
        {
            //получение значения занятости процессора
            int cpuUsageInPercent = Convert.ToInt32(_cpuCounter.NextValue());

            //получение значения загруженности оперативной памяти
            int avalibleMBytes = Convert.ToInt32(_ramCounter.NextValue());

            //время
            DateTimeOffset time = DateTimeOffset.UtcNow;

            //получение данных файла
            string fileData = _scan.GetFakeDataFromFile("fakePath");

            //библиотека, записыавающая данные
            _dataSaver.SaveByte(new DataConverter().ConvertToByte(time, cpuUsageInPercent, avalibleMBytes, fileData));
        }
    }
}
