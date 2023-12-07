using lab3;

namespace lab3
{
    internal class Program
    {
        static NoteBook notebook = new NoteBook();
        static bool json, xml, sql = false;

        static void Main(string[] args)
        {
            int choice;
            do
            {
                ShowMenu();
                choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        notebook.ViewAllContacts();
                        break;
                    case 2:
                        SearchOptions();
                        break;
                    case 3:
                        notebook.AddNewContact();
                        break;
                    case 4:
                        notebook.ExportToJson();
                        break;
                    case 5:
                        notebook.ExportToXml();
                        break;
                    case 6:
                        notebook.ExportToSql();
                        break;
                    case 7:
                        notebook.ImportFromJson();
                        break;
                    case 8:
                        notebook.ImportFromXml();
                        break;
                    case 9:
                        notebook.ImportFromSql();
                        break;
                    case 10:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            } while (choice != 10);
        }

        static void ShowMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. View all contacts");
            Console.WriteLine("2. Search");
            Console.WriteLine("3. New contact");
            Console.WriteLine("4. Export data to JSON");
            Console.WriteLine("5. Export data to XML");
            Console.WriteLine("6. Export data to SQLite");
            Console.WriteLine("7. Import data from JSON");
            Console.WriteLine("8. Import data from XML");
            Console.WriteLine("9. Import data from SQLite");
            Console.WriteLine("10. Exit");
            Console.Write("> ");
        }

        static int GetUserChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.Write("> ");
            }
            return choice;
        }

        static void SearchOptions()
        {
            Console.WriteLine("Search by");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Surname");
            Console.WriteLine("3. Name and Surname");
            Console.WriteLine("4. Phone");
            Console.WriteLine("5. E-mail");
            Console.Write("> ");

            notebook.SearchContacts(GetUserChoice());
        }
    }
}