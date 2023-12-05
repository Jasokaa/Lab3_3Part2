using System.Diagnostics;
namespace DAL;
using System.IO;
public class DBMethods
{
    public void DeleteAllFromFile(string file)
    {
        File.WriteAllText(file, string.Empty);
    }
}