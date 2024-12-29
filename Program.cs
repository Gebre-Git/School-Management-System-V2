using School_Managment_System;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Systems
{

    public class About
    {
        public static void About_us()
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n\n\n\t\tThis System is created by stem grade 11 studentsnamely namely By \n\t\tAbrham Ayana, Gebre Mariam Birhanu," +
                "Natnael Walelgn, Biruk Maru   \n\t\tand Halid Hussen.The system contains the admin sections and      \n\t\tstudents,teachers and" +
                "emloyees login system.                      ");
            Console.ReadKey();
        }
    }
    public class program
    {


        static void Main(string[] args)
        {
            Console.SetCursorPosition(30, 40);
            Console.WriteLine("Loading...");

            int totalProgress = 100;
            for (int i = 0; i <= totalProgress; i++)
            {
                UpdateProgressBar(i, totalProgress);
                Thread.Sleep(5);
                if (i == totalProgress)
                {
                    main();
                    break;
                }
            }
            static void UpdateProgressBar(int currentProgress, int totalProgress)
            {
                int progressBarWidth = 50;
                int progress = (int)((double)currentProgress / totalProgress * progressBarWidth);
                Console.Write($"\r");
                for (int i = 0; i < progressBarWidth; i++)
                {
                    if (i <= progress)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(" ");
                    }

                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write($" {currentProgress}%");

            }


            static void main()
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.SetWindowSize(116, 40);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Black;
                //                Console.Clear();
                int option;

                for (int i = 1; i < 9; i++)
                {

                    for (int x = 1; x < 38; x++)
                    {

                        Console.Write(" ");
                    }
                    Console.ForegroundColor = ConsoleColor.Black;
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(" ");

                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    for (int j = 1; j < 9; j++)
                    {
                        if ((i == 3 && j > 2) || (i == 6 && j < 7))
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("*");
                        }
                    }
                    for (int x = 1; x < 3; x++)
                    {
                        Console.Write(" ");
                    }
                    for (int y = 1; y < 10; y++)
                    {
                        if (y == 1 || y == 2 || y == 8 || y == 9 || (i == 2 && y != 5) || (y == 5 && (i > 2 && i < 5)) || ((y == 4 || y == 5 || y == 6) && (i < 4 && i > 2)))
                        {
                            Console.Write("*");
                        }
                        else { Console.Write(" "); }
                    }
                    for (int x = 1; x < 3; x++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 1; j < 9; j++)
                    {
                        if ((i == 3 && j > 2) || (i == 6 && j < 7))
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("*");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Black;
                    for (int j = 0; j < 45; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("                                |                             |                               |                     ");
                Console.WriteLine("         1:Administrator        |2: Login as Student          |3 Login as teachers            |4 Exit               ");
                Console.WriteLine("                                |                             |                               |                     ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\n\n\n\n\n\t\t\t                                                         ");
                Console.WriteLine("\t\t\t                                                         ");
                Console.WriteLine("\t\t\t    Wellcom To Stem School managment system.This system  \n\t\t\t    is created for administraters, students and teachers \n" +
                    "\t\t\t    and created by stem grade 11 students namely by      \n\t\t\t    Abrham Ayana, Gebre Mariam Birhanu,Natnael Walelgn   \n" +
                    "\t\t\t    and Biruk Maru.While Using This system please enter  \n\t\t\t    only the given choice to choose.                     ");
                Console.WriteLine("\t\t\t                                                         ");
                Console.WriteLine("\t\t\t                                                         ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nEnter a Number from the above options :");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Admin.admin();
                            break;
                        case 2:
                            Login_Student.Login_as_student();
                            break;
                        case 3:
                            Login_Teachers.Login_as_teacher();
                            break;
                        default:
                            Console.Clear();
                            main();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Entry!!");
                    Console.WriteLine("Enter T to try again (any other key to exit): ");
                    var x = Console.ReadLine();
                    if (x.ToLower() == "t")
                    {
                        main();
                    }
                    else
                    {
                        Console.WriteLine("The program is exiting");
                    }
                }
            }
        }
    }
    class status
    {
        public string FullName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string Birth_Date { get; set; }
        public string Subject { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Grade { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public string Student_ID { get; set; }
        public string teacher_ID { get; set; }
        public string Phone_number { get; set; }
        public string Maths { get; set; }
        public string Chem { get; set; }
        public string Phy { get; set; }
        public string Bio { get; set; }
        public string Eng { get; set; }
        public string Ict { get; set; }
        public string Average { get; set; }
        public string Serialkey { get; set; }
    }


}