using System;
using System.Linq;

namespace LINQdemo
{
    class program
    {
        static void Main(string[] args)
        {
            var scores = new[] { 50, 66, 90, 81, 77, 45, 0, 100, 99, 72, 87, 85, 81, 80, 77, 74, 95, 97 };

            foreach (var individualScore in scores)
            {
                Console.WriteLine(individualScore);
            }
            Console.ReadLine();

            var theBestStudents = 
                from individualScore in scores
                where individualScore > 90
                select individualScore;

            foreach(var individualScore in theBestStudents)
            {
                Console.WriteLine("Students who got an A {0}", individualScore);
            }
            Console.ReadLine();

            var theEightyPercentStudents =
                from individualScore in scores
                orderby individualScore ascending
                where individualScore < 90 && individualScore >= 80
                select individualScore;

            foreach (var individualScore in theEightyPercentStudents)
            {
                Console.WriteLine("Students who got a B {0}", individualScore);
            }

            Console.ReadLine();

            List<Student> students = new List<Student>();

            students.Add(new Student("Gary", 10, 5));
            students.Add(new Student("David", 12, 7));
            students.Add(new Student("Chris", 11, 6));
            students.Add(new Student("Lary", 13, 8));
            students.Add(new Student("Noah", 6, 1));

            var sortStudent =
               from student in students
               orderby student.name
               select student.toString();

            foreach (var student in sortStudent)
            {
                Console.WriteLine("The students in the list are {0}", student);
            }
        }
    }
}