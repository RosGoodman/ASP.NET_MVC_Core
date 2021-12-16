
using ByteDataSaver;
using PseudoScaner.Converter;
using Quartz;
using System.Diagnostics;

namespace PseudoScaner.ScanerJobs
{
    /// <summary> Класс, описывающий работу. (Получение данных). </summary>
    internal class ScanEmulatorJob : IJob
    {
        private ScanFileEmulator _scan;
        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _ramCounter;
        private DataSaver _dataSaver;

        /// <summary> Создать экземпляр класса ScanEmulatorJob. </summary>
        public ScanEmulatorJob()
        {
            _scan = new ScanFileEmulator();
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            _dataSaver = new DataSaver();
        }

        /// <summary> Выполнение работы. </summary>
        /// <param name="context"> Контекст. </param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
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
