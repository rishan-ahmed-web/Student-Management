
using StudentManagement;


    List<Student> students = new List<Student>();

while (true)
{
    try
    {
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. View all student");
        Console.WriteLine("3. Exit");
        Console.Write("Choose: ");
        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                Console.Write("Enter  id : ");
                string id = Console.ReadLine() ?? "";

                if (students.Any(s => s.Id == id))
                {
                    throw new ArgumentException("Id  already exits");
                }

                Console.Write("Enter name : ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Enter a marks : ");
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out int marks))
                {

                    students.Add(new Student(id, name, marks));
                    Console.WriteLine("Added student");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number ");
                }
                break;

            case "2":
                foreach (Student student in students)
                {
                    student.ShowInfo();
                }
                break;

            case "3":
                return;

            default:
                Console.WriteLine("Invalid option");
                break;

        }
    }

    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}


