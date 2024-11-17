using AdoNet.DAL;
using AdoNet.Models;
using System.Data;

namespace AdoNet.Services
{
    internal class StudentService
    {
        private static Sql _sql;

        public StudentService()
        {
            _sql = new Sql();
        }

        public void AddStudent(Student student)
        {
            int result = _sql.ExecuteCommand($"INSERT INTO Students VALUES ('{student.Name}','{student.Surname}',{student.Age})");
            if (result > 0)
            {
                Console.WriteLine("Student added.");
            }
            else
            {
                Console.WriteLine("Student was not added.");
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            DataTable table = _sql.ExecuteQuery("SELECT * FROM Students");

            foreach (DataRow item in table.Rows)
            {
                Student student = new Student((int)item["Id"], item["Name"].ToString(), item["Surname"].ToString(), (int)item["Age"]);

                students.Add(student);
            }
            return students;
        }

        public void DeleteStudent(int id)
        {
            int result = _sql.ExecuteCommand($"DELETE FROM Students WHERE Id = {id}");
            if (result > 0)
            {
                Console.WriteLine($"Student deleted.");
            }
            else
            {
                Console.WriteLine("Student was not deleted.");
            }
        }

        public Student GetId(int id)
        {
            DataTable result = _sql.ExecuteQuery($"SELECT * FROM Students WHERE Id = {id}");

            DataRow row = result.Rows[0];
            Student student = new Student((int)row["Id"], row["Name"].ToString(), row["Surname"].ToString(), (int)row["Age"]);

            return student;

        }

        public void UpdateStudent(int id, string name, string surname, int age)
        {
            int result = _sql.ExecuteCommand($"UPDATE Students SET Name = '{name}', Surname = '{surname}', Age = {age} WHERE Id = {id}");

            if (result > 0)
            {
                Console.WriteLine($"Student updated.");
            }
            else
            {
                Console.WriteLine("Student was not updated.");
            }
        }
    }
}
