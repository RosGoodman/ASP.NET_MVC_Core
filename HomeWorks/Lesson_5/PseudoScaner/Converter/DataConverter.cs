
using System.Text;

namespace PseudoScaner.Converter
{
    internal struct DataConverter
    {
        internal byte[] ConvertToByte(DateTimeOffset time, int cpuData, int ramData, string text)
        {
            return Encoding.ASCII.GetBytes($"{time}, cpuUsage: {cpuData}, ramUsage: {ramData}, text: {text}");
        }
    }
}
