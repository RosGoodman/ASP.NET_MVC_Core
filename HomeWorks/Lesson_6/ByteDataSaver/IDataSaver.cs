
namespace ByteDataSaver;

public interface IDataSaver
{
    /// <summary> Сохранить данные в txt. </summary>
    /// <param name="data"> Массив байт. </param>
    public void SaveByte(byte[] data);
}
