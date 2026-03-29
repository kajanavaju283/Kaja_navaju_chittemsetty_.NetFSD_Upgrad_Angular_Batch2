using System;
using System.Collections.Generic;
using System.Linq;

// Changed namespace slightly to avoid overlaps
namespace Dotnet_C_Demo.HandsOn_week6_day2_Final
{
    // Renamed to 'StudentEntry' to avoid ambiguity with existing 'Student' class
    public class StudentEntry
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }
    }

    // Repository Interface
    public interface IStudentRepository
    {
        void AddStudent(StudentEntry student);
        List<StudentEntry> GetAllStudents();
        StudentEntry GetStudentById(int id);
        void DeleteStudent(int id);
    }

    // Repository Implementation
    public class StudentRepository : IStudentRepository
    {
        private List<StudentEntry> _storage = new List<StudentEntry>();

        public void AddStudent(StudentEntry student)
        {
            _storage.Add(student);
            Console.WriteLine($"Added: {student.StudentName}");
        }

        public List<StudentEntry> GetAllStudents()
        {
            return _storage;
        }

        public StudentEntry GetStudentById(int id)
        {
            return _storage.FirstOrDefault(s => s.StudentId == id);
        }

        public void DeleteStudent(int id)
        {
            var item = GetStudentById(id);
            if (item != null) _storage.Remove(item);
        }
    }

    internal class problem7
    {
        // This is the method Visual Studio looks for
        static void Main(string[] args)
        {
            Console.WriteLine("--- Student Data Management (Repository Pattern) --- \n");

            IStudentRepository repo = new StudentRepository();

            // Adding data using the new class name
            repo.AddStudent(new StudentEntry { StudentId = 101, StudentName = "Kaja", Course = "FSD" });

            Console.WriteLine("\nTotal Students: " + repo.GetAllStudents().Count);
            Console.WriteLine("\nExecution Success. Press any key...");
            Console.ReadKey();
        }
    }
}