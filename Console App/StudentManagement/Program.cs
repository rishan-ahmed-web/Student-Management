
using StudentManagement;

IStudentService services = new StudentService();

while (true)
{
    try
    {
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. View all student");
        Console.WriteLine("3. Search student");
        Console.WriteLine("4. Update marks");
        Console.WriteLine("5. Delete student");
        Console.WriteLine("6. Top 3 student");
        Console.WriteLine("7. Average Marks");
        Console.WriteLine("8. Grade Report");
        Console.WriteLine("0. Exit");
        Console.Write("Choose: ");
        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                // Add student
                Console.Write("Enter  id : ");
                string id = Console.ReadLine() ?? "";

                Console.Write("Enter name : ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Enter a marks : ");
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out int marks))
                {
                    services.Add(new Student(id,name,marks));
                    Console.WriteLine("Added student");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number ");
                }
                break;

            case "2":
                // View all student
                var students = services.GetAll();
                if(students.Count == 0)
                    Console.WriteLine("No students found");
                else
                    foreach (var student in students)
                    {
                        student.ShowInfo();
                    }

                break;

            case "3":
                // Search student
                Console.Write("Search student: ");
                string search = Console.ReadLine() ?? "";

                var results = services.SearchByName(search);
                
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
                string inputId = Console.ReadLine() ?? "";
                
                Console.Write("Enter new marks: ");
                string newMarksInput = Console.ReadLine() ?? "";

                if (int.TryParse(newMarksInput, out int newMarks))
                {
                    bool updated = services.UpdateMarks(inputId, newMarks);
                    if(updated)
                        Console.WriteLine("Marks Updated");
                    else
                        Console.WriteLine("Student not found");
                    
                    Console.WriteLine("Update successful");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }

                break;

            case "5":
                Console.Write("Enter id : ");
                string deleteId = Console.ReadLine() ?? "";

                bool deleted = services.DeleteStudent(deleteId);
                if (deleted)
                    Console.WriteLine("Student delete success");
                else
                    Console.WriteLine("Student not found");

                break;

            case "6":

                Console.WriteLine("============Top 3 Student=============");
                var topStudent = services.GetTopStudents(3);
                foreach(var top in topStudent)
                {
                    Console.WriteLine($"Name: {top.Name} | Marks: {top.Marks} | Grade: {top.Grade}");
                }
                break;

            case "7":
                Console.WriteLine("==========Average Marks==============");
                var average = services.GetAverage();
                Console.WriteLine($"Average Marks: {average:F2}");
                break;

            case "8":
                Console.WriteLine("========= Grade Report ========");
                var report = services.GetGradeReport();
                if(report.Count == 0)
                {
                    Console.WriteLine("No students found");
                }
                else
                {
                    foreach(var item in report)
                    {
                        Console.WriteLine($"Grade: {item.Key} | Students: {item.Value}");
                    }
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


