using DAL;

namespace BLL;

public class CreateService
{
    EntityService<Entity> a = new EntityService<Entity>();
    DBService<Entity> b = new DBService<Entity>();
    public void createStudent(string fName, string lName, int course, string sCard, string bDate, int DBinput)
    {
        Student student = new Student(fName, lName, course, sCard, bDate);
        List<Entity>? list = new List<Entity>();
        if (b.ReadDB(DBinput) != null)
        {
            list = b.ReadDB(DBinput);
        }
        list = a.AddEntity(list, student);
        b.WriteDB(list, DBinput);
    }
    public void createBaker(string fName, string lName, int DBinput)
    {
        Baker baker = new Baker(fName, lName);
        List<Entity>? list = new List<Entity>();
        if (b.ReadDB(DBinput) != null)
        {
            list = b.ReadDB(DBinput);
        }
        list = a.AddEntity(list, baker);
        b.WriteDB(list, DBinput);
    }
    public void createEntrepreneur(string fName, string lName, int DBinput)
    {
        Entrepreneur entrepreneur = new Entrepreneur(fName, lName);
        List<Entity>? list = new List<Entity>();
        if (b.ReadDB(DBinput) != null)
        {
            list = b.ReadDB(DBinput);
        }
        list = a.AddEntity(list, entrepreneur);
        b.WriteDB(list, DBinput);
    }
}