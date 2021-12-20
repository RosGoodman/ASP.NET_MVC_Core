namespace PseudoScaner
{
    internal interface IScanFileEmulator
    {
        string GetFakeDataFromFile(string path = "");
    }
}