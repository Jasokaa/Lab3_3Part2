namespace BLL;
using DAL;
public class DBService<T>
{
    ProviderService<T> providerService = new ProviderService<T>();
    [Obsolete]
    public void WriteDB(List<T>? list, int input)
    {
        try
        {
            providerService.Write(list, input);
        }
        catch (Exception)
        {
            // ignored
        }
    }
    [Obsolete]
    public List<T>? ReadDB(int input)
    {
        List<T>? list = null;
        try
        {
            list = providerService.Read(input);
        }
        catch (Exception)
        {
            // ignored
        }
        return list;
    }
    public void DeleteAllFromFile(int input)
    {
        try
        {
            providerService.DeleteAllFromFile(input);
        }
        catch (Exception)
        {
            // ignored
        }
    }
}