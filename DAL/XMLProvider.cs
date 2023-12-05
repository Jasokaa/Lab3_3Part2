using System.Xml.Serialization;
//дописати видалення файлу
namespace DAL;
public class XMLProvider<T> : IDatabaseMethods<T>
{
    public XMLProvider() {}
    public void Write(List<T>? list, string file)
    {
        File.WriteAllText(file, string.Empty);
        using (FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate))
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
            formatter.Serialize(fileStream, list);
        }
    }
    public List<T>? Read(string file)
    {
        List<T>? deserializedObjects;
        using (FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate))
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
            deserializedObjects = (List<T>)formatter.Deserialize(fileStream)!;
        }
        return deserializedObjects;
    }
}