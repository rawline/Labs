namespace lab2v2
{
    internal class Program
    {
        static NoteBook notebook = new NoteBook();

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
            Console.WriteLine("4. Exit");
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