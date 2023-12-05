using System.Runtime.Serialization.Formatters.Binary;

namespace DAL;
public class BinProvider<T> : IDatabaseMethods<T>
{
    public BinProvider() {}
    [Obsolete]
    public void Write(List<T>? list, string file)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate))
        {
            formatter.Serialize(fileStream, list);
        }
    }
    [Obsolete]
    public List<T>? Read(string file)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate))
        {
            return (List<T>)formatter.Deserialize(fileStream);
        }
    }
}