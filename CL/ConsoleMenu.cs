using BLL;
using DAL;
namespace CL;
public abstract class ConsoleMenu
{
    private static EntityService<Entity> entityService = new EntityService<Entity>();
    private static CreateService createService = new CreateService();
    private static DBService<Entity> dbService = new DBService<Entity>();
    public static string DBchooseFile()
    {
        Console.Clear();
        string chooseFileSTR = "To choose serialization write:\n" +
                               "1 - BINARY serialization\n" +
                               "2 - JSON serialization\n" +
                               "3 - XML serialization\n" +
                               "4 - CUSTOM serialization\n";
        Console.Write(chooseFileSTR);
        return $"{Console.ReadLine()}";
    }
    public static string commands()
    {
        Console.Clear();
        string commandsSTR = "To choose command write:\n" +
                          "1 - add student\n" +
                          "2 - add baker\n" +
                          "3 - add entrepreneur\n" +
                          "4 - show database\n" +
                          "5 - delete someone\n" + 
                          "6 - calculate the number and show 4th-year students born in the spring\n" +
                          "7 - delete all from database\n" +
                          "8 - add some entities\n" +
                          "EXIT - stop program\n";
        Console.Write(commandsSTR);
        return $"{Console.ReadLine()}";
    }
    public static int userInput(string input, int DBinput)
    {
        try
        {
            switch (input)
            {
                case "1":
                {
                    addStudent(DBinput);
                    return 0;
                }
                case "2":
                {
                    addBaker(DBinput);
                    return 0;
                }
                case "3":
                {
                    addEntrepreneur(DBinput);
                    return 0;
                }
                case "4":
                {
                    showDatabase(DBinput);
                    return 0;
                }
                case "5":
                {
                    deleteSomeone(DBinput);
                    return 0;
                }
                case "6":
                {
                    calculate(DBinput);
                    return 0;
                }
                case "7":
                {
                    deleteDB(DBinput);
                    return 0;
                }
                case "8":
                {
                    addEntities(DBinput);
                    return 0;
                }
                case "EXIT":
                {
                    return 1;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return 0;
    }
    private static void addStudent(int DBinput)
    {
        Console.Clear();
        
        Console.WriteLine("Enter first name:");
        string data = Console.ReadLine();
        while (entityService.InputName(data) == false)
        {
            Console.WriteLine("ERROR! Try again to write:");
            data = Console.ReadLine();
        }
        string firstName = data;
        
        Console.WriteLine("Enter last name:");
        data = Console.ReadLine();
        while (entityService.InputName(data) == false)
        {
            Console.WriteLine("ERROR! Try again to write:");
            data = Console.ReadLine();
        }
        string lastName = data;
        
        Console.WriteLine("Enter course:");
        data = Console.ReadLine();
        while (entityService.InputCourse(data) == false)
        {
            Console.WriteLine("ERROR! Try again to write:");
            data = Console.ReadLine();
        }
        int course = Int32.Parse(data);
        
        Console.WriteLine("Enter student card in format (KB12345678):");
        data = Console.ReadLine();
        while (entityService.InputStudentCard(data) == false)
        {
            Console.WriteLine("ERROR! Try again to write:");
            data = Console.ReadLine();
        }
        string sCard = data;
        
        Console.WriteLine("Enter birth date in format (01.01.2001):");
        data = Console.ReadLine();
        while (entityService.InputBirthDate(data) == false)
        {
            Console.WriteLine("ERROR! Try again to write:");
            data = Console.ReadLine();
        }
        string bDate = data;
        createService.createStudent(firstName, lastName, course, sCard, bDate, DBinput);
    }
    private static void addBaker(int DBinput)
    {
        Console.Clear();
        
        Console.WriteLine("Enter first name:");
        string data = Console.ReadLine();
        while (entityService.InputName(data) == false)
        {
            Console.WriteLine("ERROR! Try again to write:");
            data = Console.ReadLine();
        }
        string firstName = data;
        
        Console.WriteLine("Enter last name:");
        data = Console.ReadLine();
        while (entityService.InputName(data) == false)
        {
            Console.WriteLine("ERROR! Try again to write:");
            data = Console.ReadLine();
        }
        string lastName = data;
        createService.createBaker(firstName, lastName, DBinput);
    }
    private static void addEntrepreneur(int DBinput)
    {
        Console.Clear();
        Console.WriteLine("Enter first name:");
        string data = Console.ReadLine();
        while (entityService.InputName(data) == false)
        {
            Console.WriteLine("ERROR! Try again to write:");
            data = Console.ReadLine();
        }
        string firstName = data;
        Console.WriteLine("Enter last name:");
        data = Console.ReadLine();
        while (entityService.InputName(data) == false)
        {
            Console.WriteLine("ERROR! Try again to write:");
            data = Console.ReadLine();
        }
        string lastName = data;
        createService.createEntrepreneur(firstName, lastName, DBinput);
    }
    private static void showDatabase(int DBinput)
    {
        Console.Clear();
        List<Entity> list = new List<Entity>();
        if (dbService.ReadDB(DBinput) != null)
        {
            list = dbService.ReadDB(DBinput);
            foreach (Entity line in list)
            {
                if (line != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        else
        {
           Console.WriteLine("DB is empty."); 
        }
        Console.ReadLine();
    }
    private static void deleteSomeone(int DBinput)
    {
        Console.Clear();
        List<Entity> list = dbService.ReadDB(DBinput);
        int index = 0;
        foreach (Entity line in list)
        {
            if (line != null)
            {
                Console.WriteLine(index + ": " + line);
                index++;
            }
        }
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                if(!(Int32.Parse(input) >= 0 && Int32.Parse(input)< list.Count))
                {
                    Console.WriteLine("ERROR! Try again to write:");
                    input = Console.ReadLine();
                }
                List<Entity>? newlist = entityService.RemoveEntityByIndex(list,Int32.Parse(input));
                if (newlist != null)
                {
                    dbService.WriteDB(newlist, DBinput);
                }
                else
                {
                    dbService.DeleteAllFromFile(DBinput);
                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    [Obsolete]
    private static void calculate(int DBinput)
    {
        Console.Clear();
        List<Entity>? list = new List<Entity>();
        list = dbService.ReadDB(DBinput);
        List<Student> studentList = entityService.SearchStudent(list);
        Console.WriteLine("There are " + studentList.Count + " student of 4-course born in the spring:");
        foreach (var student in studentList)
        {
            Console.WriteLine(student);
        }
        Console.ReadLine();
    }
    private static void deleteDB(int DBinput)
    {
        Console.Clear();
        dbService.DeleteAllFromFile(DBinput);
        Console.WriteLine("Now DB file is empty");
        Console.ReadLine();
    }
    
    private static void addEntities(int DBinput)
    {
        createService.createStudent("Tom", "Rox", 4, "KB12312312", "03.03.2002", DBinput);
        createService.createBaker("Nana", "Fai", DBinput);
        createService.createStudent("Bob", "Wein", 4, "KB89898989", "20.11.2003", DBinput);
        createService.createStudent("Kate", "Lu", 3, "KB09809809", "30.05.2001", DBinput);
        createService.createStudent("Sem", "Tofi", 4, "KB89898989", "15.04.2003", DBinput);
        createService.createEntrepreneur("Jon", "Vels", DBinput);
        createService.createStudent("Dan", "Koi", 4, "KB56565656", "05.05.2000", DBinput);
    }
}