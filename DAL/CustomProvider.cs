namespace DAL;
public class CustomProvider<T> : IDatabaseMethods<T>
{
    public void Write(List<T>? list, string file)
    {
        List<string> lines = new List<string>();
        foreach (T item in list)
        {
            string serializedItem = item.ToString();
            lines.Add(serializedItem);
        }
        File.WriteAllText(file, string.Join(Environment.NewLine, lines));
        
    }
    public List<T>? Read(string file)
    {
        List<T>? data = new List<T>();
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            object item = ParseEntity(line);
            data.Add((T)item);
        }
        return data;
    }

    private static object ParseEntity(string input)
    {
        string[] parts = input.Split(new[] { "{", "}" }, StringSplitOptions.RemoveEmptyEntries);
        string typeName = parts[0].Split(' ')[1].Trim();
        switch (typeName)
        {
            case "Student":
                return ParseStudent(parts[1]);
            case "Baker":
                return ParseBaker(parts[1]);
            case "Entrepreneur":
                return ParseEntrepreneur(parts[1]);
            default:
                throw new ArgumentException("Unknown entity type");
        }
    }
    private static Student ParseStudent(string data)
    {
        var properties = ParseProperties(data);
        return new Student(properties["FirstName"], properties["LastName"], Int32.Parse(properties["Course"]),
            properties["StudentCard"], properties["BirthDate"]);
    }
    private static Baker ParseBaker(string data)
    {
        var properties = ParseProperties(data);
        return new Baker(properties["FirstName"], properties["LastName"]);
    }
    private static Entrepreneur ParseEntrepreneur(string data)
    {
        var properties = ParseProperties(data);
        return new Entrepreneur(properties["FirstName"], properties["LastName"]);
    }
    private static Dictionary<string, string> ParseProperties(string data)
    {
        string[] propertyPairs = data.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        var properties = new Dictionary<string, string>();

        foreach (var pair in propertyPairs)
        {
            string a = pair.Replace("'", "");
            a = a.Replace(" ", "");
            string[] keyValue = a.Split(':', StringSplitOptions.RemoveEmptyEntries);
            string key = keyValue[0].Trim();
            string value = keyValue[1].Trim();
            properties.Add(key, value);
        }
        return properties;
    }
}