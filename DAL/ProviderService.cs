namespace DAL;

public class ProviderService<T>
{
    private const string fileBIN = "fileBIN.bin";
    private const string fileJSON = "fileJSON.json";
    private const string fileXML = "fileXML.xml";
    private const string fileCustom = "fileCustom.txt";
    
    [Obsolete]
    public void Write(List<T>? list, int input)
    {
        try
        {
            switch (input)
            {
                case 1:
                {
                    BinProvider<T> a = new BinProvider<T>();
                    a.Write(list, fileBIN);
                    break;
                }
                case 2:
                {
                    JSONProvider<T> b = new JSONProvider<T>();
                    b.Write(list, fileJSON);
                    break;
                }
                case 3:
                {
                    XMLProvider<T> c = new XMLProvider<T>();
                    c.Write(list, fileXML);
                    break;
                }
                case 4:
                {
                    CustomProvider<T> d = new CustomProvider<T>();
                    d.Write(list, fileCustom);
                    break;
                }
            }
        }
        catch (Exception)
        {

        }
    }
    [Obsolete]
    public List<T>? Read(int input)
    {
        List<T>? list = null;
        try
        {
            switch (input)
            {
                case 1:
                {
                    BinProvider<T> a = new BinProvider<T>();
                    list = a.Read(fileBIN);
                    break;
                }
                case 2:
                {
                    JSONProvider<T> a = new JSONProvider<T>();
                    list = a.Read(fileJSON);
                    break;
                }
                case 3:
                {
                    XMLProvider<T> a = new XMLProvider<T>();
                    list = a.Read(fileXML);
                    break;
                }
                case 4:
                {
                    CustomProvider<T> a = new CustomProvider<T>();
                    list = a.Read(fileCustom);
                    break;
                }
            }
        }
        catch (Exception)
        {
            
        }

        return list;
    }

    public void DeleteAllFromFile(int input)
    {
        try
        {
            switch (input)
            {
                case 1:
                {
                    DBMethods a = new DBMethods();
                    a.DeleteAllFromFile(fileBIN);
                    break;
                }
                case 2:
                {
                    DBMethods a = new DBMethods();
                    a.DeleteAllFromFile(fileJSON);
                    break;
                }
                case 3:
                {
                    DBMethods a = new DBMethods();
                    a.DeleteAllFromFile(fileXML);
                    break;
                }
                case 4:
                {
                    DBMethods a = new DBMethods();
                    a.DeleteAllFromFile(fileCustom);
                    break;
                }
            }
        }
        catch (Exception)
        {

        }
    }
}