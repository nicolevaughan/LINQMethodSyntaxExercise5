namespace LINQMethodSyntaxExercise5
{

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public double Tuition { get; set; }
    }
    public class StudentClubs
    {
        public int StudentID { get; set; }
        public string ClubName { get; set; }
    }
    public class StudentGPA
    {
        public int StudentID { get; set; }
        public double GPA { get; set; }
    }

    public class Program
    {
        public static void Main()
        {

            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
                new Student() { StudentID = 2, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
                new Student() { StudentID = 3, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
                new Student() { StudentID = 4, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
                new Student() { StudentID = 5, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
                new Student() { StudentID = 6, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
                new Student() { StudentID = 7, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
        };
            // Student GPA Collection
            IList<StudentGPA> studentGPAList = new List<StudentGPA>() {
                new StudentGPA() { StudentID = 1,  GPA=4.0} ,
                new StudentGPA() { StudentID = 2,  GPA=3.5} ,
                new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
                new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
                new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
                new StudentGPA() { StudentID = 6,  GPA=2.5} ,
                new StudentGPA() { StudentID = 7,  GPA=1.0 }
            };
            // Club collection
            IList<StudentClubs> studentClubList = new List<StudentClubs>() {
            new StudentClubs() {StudentID=1, ClubName="Photography" },
            new StudentClubs() {StudentID=1, ClubName="Game" },
            new StudentClubs() {StudentID=2, ClubName="Game" },
            new StudentClubs() {StudentID=5, ClubName="Photography" },
            new StudentClubs() {StudentID=6, ClubName="Game" },
            new StudentClubs() {StudentID=7, ClubName="Photography" },
            new StudentClubs() {StudentID=3, ClubName="PTK" },
        };

            var groupedGPA = studentGPAList.OrderByDescending(o => o.GPA).GroupBy(s => s.GPA);

            foreach (var GPAGroup in groupedGPA)
            {
                Console.WriteLine("GPA Group: " + GPAGroup.Key);

                foreach(StudentGPA s in GPAGroup) {
                    Console.WriteLine("Student ID: " + s.StudentID);
                    Console.WriteLine("Student GPA: " + s.GPA);
                    
                        }
                Console.WriteLine("-------------------------------------");
            }

            var groupedClub = studentClubList.OrderBy(o=> o.ClubName).GroupBy(s => s.ClubName);

            foreach (var clubGroup in groupedClub)
            {
                Console.WriteLine("Club Group: " + clubGroup.Key);

                foreach(StudentClubs s in clubGroup)
                {
                    Console.WriteLine("Student ID: " + s.StudentID);
                }
                Console.WriteLine("-------------------------------------");
            }

            var countGPA = studentGPAList.Count(s=>s.GPA>=2.5 && s.GPA<=4.0);
            Console.WriteLine("Number of Students with GPA of 2.5 to 4.0");
            Console.WriteLine(countGPA);
            Console.WriteLine("-------------------------------------");

            var averageTuition = studentList.Average(s=>s.Tuition);
            averageTuition = Math.Round(averageTuition, 2);
            Console.WriteLine("Average of Student Tuition");
            Console.WriteLine(averageTuition);
            Console.WriteLine("-------------------------------------");

            var maxTuition = studentList.Max(s=>s.Tuition);

            
               foreach (Student s in studentList)
               {
                    if (maxTuition == s.Tuition)
                    {
                        Console.WriteLine($"Student Name: {s.StudentName}\nMajor: {s.Major}\nTuition: " + maxTuition);
                    }
               }
            Console.WriteLine("-------------------------------------");

            var studentGPAs = from s in studentList
                              join g in studentGPAList
                              on s.StudentID equals g.StudentID
                              select new { s.StudentName, g.GPA, s.Major };
            Console.WriteLine("Student GPAs");
            Console.WriteLine();
            foreach (var s in studentGPAs)
            {
                Console.WriteLine($"Name: {s.StudentName} \t\tGPA: {s.GPA}    \t\tMajor: {s.Major}");
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------");

            var innerJoin = studentList.Join(studentClubList,
                                    student => student.StudentID,
                                    club => club.StudentID,
                                    (student, club) => new
                                    {
                                        StudentName = student.StudentName,
                                        ClubName = club.ClubName
                                    });
            Console.WriteLine("Students who belong to the Game Club");
            foreach (var s in innerJoin)
            {
                if (s.ClubName == "Game")
                Console.WriteLine($"Name: {s.StudentName}    \t\tClub: {s.ClubName}");
            }
        }
    }
}

