using System.Text.Json;
namespace DAL;
public class JSONProvider<T> : IDatabaseMethods<T>
{
    public JSONProvider() {}
    public void Write(List<T>? list, string file)
    {
        File.WriteAllText(file, string.Empty);
        using (FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fileStream, list);
        }
    }
    public List<T>? Read(string file)
    {
        using (FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate))
        {
            return (List<T>)JsonSerializer.Deserialize(fileStream, typeof(List<T>));
        }
    }
}