using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timetable
{
    class Program
    {
        static Random Random; // Random number source

        const int Chromosomes = 20;
        
        const int Sessions = 10;
        const int Classrooms = 6;
        const int Groups = 12;
        const int Lecturers = 5;
        static string LecturersNames = "ABCDE";
        const int SessionsPerGroup = 4;


        static void Main(string[] args)
        {
            string[,] timetable = new string[Sessions, Classrooms];

            InitialisePopulation(timetable);
            ShowPopulation(timetable);
            Console.Read();
        }

        public static void ShowPopulation(string[,] timetable)
        {
            Console.Write(String.Format(" Classroom: "));
            for (int c = 0; c < Classrooms; c++)
            {
                Console.Write(String.Format(" {0:0}  ", c));
            }
            Console.WriteLine();

            var i = 0;
            for (int s = 0; s < Sessions; s++)
            {
                Console.Write(String.Format("Session {0:00}: ", s));
                for (int c = 0; c < Classrooms; c++)
                {
                    Console.Write(String.Format("{0} ", timetable[s, c]));
                    i++;
                }
                Console.WriteLine();
            }
        }

        public static void InitialisePopulation(string[,] timetable)
        {
            // Assign 4 sessions to each group
            // Cycle round the classrooms and lecturers
            var sessionsAssigned = 0;
            var sessionOfWeek = 0;
            var sessionOfGroup = 0;
            var classroom = 0;
            var group = 0;
            var lecturer = 0;
            while (sessionsAssigned < Groups * SessionsPerGroup) {
                timetable[sessionOfWeek, classroom] = String.Format("{0}{1:00}", LecturersNames[lecturer], group);

                sessionOfWeek++;
                if (sessionOfWeek >= Sessions)
                {
                    sessionOfWeek = 0;
                    classroom++;
                    if (classroom >= Classrooms)
                    {
                        classroom = 0;
                    }
                }

                lecturer++;
                if (lecturer >= Lecturers)
                    lecturer = 0;
                sessionOfGroup++;
                if (sessionOfGroup >= SessionsPerGroup)
                {
                    sessionOfGroup = 0;
                    group++;
                }

                sessionsAssigned++;
            }
        }
    }
}
