
using StudentManagement;



List<Student> students = new List<Student>();

while (true)
{
    try
    {
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. View all student");
        Console.WriteLine("3. Search student");
        Console.WriteLine("4. Update marks");
        Console.WriteLine("0. Exit");
        Console.Write("Choose: ");
        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                // Add student
                Console.Write("Enter  id : ");
                string id = Console.ReadLine() ?? "";

                if (students.Any(s => s.Id == id))
                {
                    throw new ArgumentException("Id  already exists");
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
                // View all student
                foreach (Student student in students)
                {
                    student.ShowInfo();
                }
                break;

            case "3":
                // Search student
                Console.Write("Search student: ");
                string search = Console.ReadLine() ?? "";
                var results = students.Where(s => s.Name.Contains(search,StringComparison.OrdinalIgnoreCase))
                              .ToList();
                
                if(results.Count > 0)
                {
                    foreach(var  result in results)
                    {
                        result.ShowInfo();
                    }
                }
                else
                {
                    Console.WriteLine("Student not found");
                }

                break;

            case "4":
                // Update marks
                Console.Write("Enter id : ");
                string inputid = Console.ReadLine() ?? "";
                var foundStudent = students.FirstOrDefault(s => s.Id == inputid);
                if(foundStudent == null)
                {
                    Console.WriteLine("Student not found");
                    break;
                    
                }
                Console.Write("Enter new marks: ");
                string newMarksInput = Console.ReadLine() ?? "";

                if (int.TryParse(newMarksInput, out int newMarks))
                {
                    foundStudent.UpdateMarks(newMarks);
                    Console.WriteLine("Update successful");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }

                break;

            case "0":
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


