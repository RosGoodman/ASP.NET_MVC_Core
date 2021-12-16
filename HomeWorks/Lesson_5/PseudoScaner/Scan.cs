

namespace PseudoScaner
{
    internal class Scan
    {
        internal string GetFakeDataFromFile(string path = "")
        {
                var result = new char[10];
                var r = new Random();
                for (int i = 0; i < result.Length; i++)
                {
                    do
                        result[i] = (char)r.Next(127);
                    while (result[i] < '!');
                }

                return new string(result);
        }
    }
}
