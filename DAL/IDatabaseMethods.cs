namespace DAL;

public interface IDatabaseMethods<T>
{
    void Write(List<T>? list, string file);
    List<T>? Read(string file);
}