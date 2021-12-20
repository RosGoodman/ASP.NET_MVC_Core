namespace ByteDataSaver
{
    /// <summary> Сохранение данных в различные файлы. </summary>
    public class DataSaver : IDataSaver
    {
        /// <summary> Сохранить данные в txt. </summary>
        /// <param name="data"> Массив байт. </param>
        public void SaveByte(byte[] data)
        {
            BinaryWriter Writer = null;
            string Name = "byteDataFromPseudoScaner.txt";

            using StreamWriter fstream = new StreamWriter(Name, true, System.Text.Encoding.Default);

            // запись массива байтов в файл
            fstream.WriteLine(BitConverter.ToString(data));

            //просто для отображения в консоли. Для программы строка не нужна.
            Console.WriteLine(BitConverter.ToString(data));
        }
    }
}