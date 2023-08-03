namespace StudentGradeCalculatorApp
{
    public class MainApp
    {
        string Name;
        int NumberOfSubjects;

        StudentGradeCalculator? Calculator;

        public static void Main()
        {
            var app = new MainApp();
            app.Run();
        }

        void Run()
        {
            Console.WriteLine("Welcome to the Student Grade Calculator application!");
            this.GetStudentName();
            this.GetNumberOfSubjects();

            this.Calculator = new StudentGradeCalculator(this.Name, this.NumberOfSubjects);
            this.GetGradeForSubjects();

            Console.WriteLine("\n\nYour Report:" +
                              $"\n| Name: {this.Calculator.Name}" +
                              $"\n| Number of subjects taken: {this.Calculator.NumberOfSubjects}" +
                              "\n| Subject Grades: ");
            this.Calculator.PrintSubjectGrades("|\t=> ");
            Console.WriteLine($"| Average Grade: {this.Calculator.Calculate()}");
        }

        void GetStudentName()
        {
            Console.WriteLine("Please Enter your name.");
            this.Name = Console.ReadLine()!;

            while (this.Name == null || this.Name.Length == 0)
            {
                Console.WriteLine("The name you entered is not valid. Please enter a valid name.");
                this.Name = Console.ReadLine();
            }
        }

        void GetNumberOfSubjects()
        {
            Console.WriteLine("Please enter the number of subjects you are taking.");
            string userInput = Console.ReadLine()!;
            bool convertedToNumber = int.TryParse(userInput, out this.NumberOfSubjects);

            while (!convertedToNumber || this.NumberOfSubjects < 0)
            {
                Console.WriteLine("The number you entered is not valid. Please enter a valid number.");
                userInput = Console.ReadLine();
                convertedToNumber = int.TryParse(userInput, out this.NumberOfSubjects);
            }
        }

        void GetGradeForSubjects()
        {
            Console.WriteLine(
                $"You have entered {this.NumberOfSubjects} as the number of subjects you are taking. Please enter the grades for each subject. (Subject name, grade)");
            for (var _ = 0; _ < this.NumberOfSubjects; _++)
            {
                int isSubjectAdded = -1;

                while (isSubjectAdded == -1)
                {
                    Console.WriteLine($"Please enter the name for subject number {_ + 1}.");
                    string subjectName = Console.ReadLine();

                    while (subjectName == null || subjectName.Length == 0)
                    {
                        Console.WriteLine("The name you entered is not valid. Please enter a valid name.");
                        subjectName = Console.ReadLine();
                    }

                    Console.WriteLine($"Now please enter the grade for the course {subjectName}.");
                    string? userGrade = Console.ReadLine();
                    bool convertedToNumber = int.TryParse(userGrade, out int grade);

                    while (!convertedToNumber || grade < 0 || grade > 100)
                    {
                        Console.WriteLine(
                            "The grade you entered is not valid. Please enter a valid grade between 0 and 100.");
                        userGrade = Console.ReadLine();
                        convertedToNumber = int.TryParse(userGrade, out grade);
                    }

                    isSubjectAdded = this.Calculator.AddSubject(subjectName, grade);

                    if (isSubjectAdded == -1)
                    {
                        Console.WriteLine(
                            $"The subject {subjectName} already exists. Please enter a different subject name.");
                    }
                }
            }
        }
    }


    public class StudentGradeCalculator
    {
        public string Name { get; }
        public int NumberOfSubjects { get; }
        private Dictionary<string, int> Grades;

        public StudentGradeCalculator(string name, int numberOfSubjects)
        {
            (Name, NumberOfSubjects) = (name, numberOfSubjects);
            Grades = new Dictionary<string, int>();
        }

        public int AddSubject(string subjectName, int grade)
        {
            try
            {
                Grades.Add(subjectName, grade);
                return 0;
            }
            catch (ArgumentException)
            {
                return -1;
            }
        }

        public int GetSubjectGrade(string subjectName)
        {
            try
            {
                return Grades[subjectName];
            }
            catch (KeyNotFoundException)
            {
                return -1;
            }
        }

        public float Calculate()
        {
            int totalSum = 0;

            foreach (KeyValuePair<string, int> subjectGrade in this.Grades)
            {
                totalSum += subjectGrade.Value;
            }

            return totalSum / NumberOfSubjects;
        }

        public void PrintSubjectGrades(string prefix)
        {
            foreach (KeyValuePair<string, int> subject in this.Grades)
            {
                Console.WriteLine($"{prefix}{subject.Key} - {subject.Value}");
            }
        }
    }
}