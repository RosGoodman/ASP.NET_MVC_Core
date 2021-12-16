namespace ByteDataSaver
{
    public struct DataSaver
    {
        public void SaveByte(byte[] data)
        {
            SaveToTxt(data);
        }

        private void SaveToTxt(byte[] data)
        {
            string str = string.Empty;
            for (int i = 0; i < 50; i++)
            {
                str += data[i];
            }
            Console.WriteLine(str);
        }
    }
}