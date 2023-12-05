using CL;
namespace PL;
internal static class Program
{
   [Obsolete]
   public static void Main(string[] args)
   {
       try
       {
           string file;
           while (true)
           {
               file = ConsoleMenu.DBchooseFile();
               if (file == "1" || file == "2" || file == "3" || file == "4")
               {
                   break;
               }
           }
           string input = ConsoleMenu.commands();
           int returnFromUserInput = ConsoleMenu.userInput(input, int.Parse(file));
           while (returnFromUserInput != 1)
           {
               input = ConsoleMenu.commands();
               returnFromUserInput = ConsoleMenu.userInput(input, int.Parse(file));
           }
       }
       catch (Exception e)
       {
           Console.WriteLine(e.Message);
       }
   } 
}
