
using ByteDataSaver;
using PseudoScaner.Converter;
using Quartz;
using System.Diagnostics;

namespace PseudoScaner.ScanerJobs
{
    internal class ScanEmulatorJob : IJob
    {
        private Scan _scan;
        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _ramCounter;
        private DataSaver _dataSaver;

        public ScanEmulatorJob()
        {
            _scan = new Scan();
            _cpuCounter = new PerformanceCounter("Processon", "% Processor Time", "_Total");
            _ramCounter = new PerformanceCounter("Memory", "Avalible MBytes");
            _dataSaver = new DataSaver();
        }

        public Task Execute(IJobExecutionContext context)
        {
            //получение значения занятости процессора
            int cpuUsageInPercent = Convert.ToInt32(_cpuCounter.NextValue());

            //получение значения загруженности оперативной памяти
            int avalibleMBytes = Convert.ToInt32(_ramCounter.NextValue());

            //время
            DateTimeOffset time = DateTimeOffset.UtcNow;

            //получение данных файла
            string fileData = _scan.GetDataFromFile("path");    //ToDo: past file path

            _dataSaver.SaveByte(new DataConverter().ConvertToByte(time, cpuUsageInPercent, avalibleMBytes, fileData));

            return Task.CompletedTask;
        }
    }
}
