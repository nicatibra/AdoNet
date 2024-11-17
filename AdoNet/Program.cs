using AdoNet.Models;
using AdoNet.Services;

namespace AdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();

            Student student1 = new Student("Niko", "Ibrahimli", 20);
            Student student2 = new Student("Azad", "Ashurov", 20);

            studentService.AddStudent(student1);
            studentService.AddStudent(student2);

            studentService.DeleteStudent(2);

            foreach (var item in studentService.GetAllStudents())
            {
                Console.WriteLine(item.ToString());
            }

            studentService.UpdateStudent(1, "Nicat", "Ibrahimli", 19);

            Student student = studentService.GetId(1);
            Console.WriteLine($"Student Found: {student.ToString()}");
        }
    }
}
