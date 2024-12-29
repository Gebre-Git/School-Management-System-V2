using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Systems;

namespace School_Managment_System
{
    public class Login_Student
    {
        public static void Login_as_student()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t*** Ligin Here ***");
            Console.Write("User Name:");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            int grade = 9;
            while(grade<13)
            {
                string filepath = $"Grade {grade} students status.csv";
                List<status> readstudent = ReadFromCsv(filepath);




                foreach (var student in readstudent)
                {

                    if ((student.User_Name == username) && (student.Password == password))
                    {
                        students_stuf(student.firstName,student.middleName,student.Grade);
                    }
                }
                static List<status> ReadFromCsv(string filePath)
                {
                    var lines = File.ReadAllLines(filePath);
                    return lines.Select(line =>
                    {
                        var parts = line.Split(',');
                        return new status
                        {
                            firstName = parts[0],
                            middleName = parts[1],
                            Grade = parts[5],
                            User_Name = parts[8],
                            Password = parts[9],
                        };
                    }).ToList();
                }
                grade++;

            }
            
            static void students_stuf(string fname,string m_name,string grade)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t1:see your roster\n\n\t\t\t2:Messages from Adminstrator\n\n\t\t\t3:Messages From Teacher");
                int choice = int.Parse(Console.ReadLine());

                if(choice == 1) { roster(fname,m_name); }
                else if(choice == 2) 
                {
                    Console.Clear();
                    string filepath = $"F:\\g7\\School Managment System\\messages\\Messages to students1.txt";

                    Console.WriteLine(File.ReadAllText(filepath));
                }
                else if (choice == 3) 
                {
                    string filepath = $"F:\\g7\\School Managment System\\messages from teachers\\Messages to {grade} students.txt";
                    Console.WriteLine(File.ReadAllText(filepath));
                }
                else { Console.WriteLine("Invalid Input, Please choose 1-3");students_stuf(fname, m_name,grade); }

                static void roster(string fname, string m_name)
                {
                    Console.Clear();
                    int grade = 9;
                    while (grade < 13)
                    {

                        string filepath = $"roster grade {grade} students.csv";
                        List<status> readPeople = ReadFromCsv(filepath);

                        foreach (var person in readPeople)
                        {
                            if(person.firstName.ToLower()==fname.ToLower() && person.middleName.ToLower()==m_name.ToLower())
                            {
                                Console.WriteLine($"\t\t\tMathematics-- {person.Maths}\n\t\t\tchemistry--- {person.Chem}\n\t\t\tEnglish---- {person.Eng}\n\t\t\tPhysics---- {person.Phy}\n\t\t\tBiology---- {person.Bio}\n\t\t\tICT------- {person.Ict}\n\t\t\tAverage----- {person.Average}");
                            }
                        }



                        static List<status> ReadFromCsv(string filePath)
                        {
                            var lines = File.ReadAllLines(filePath);
                            return lines.Select(line =>
                            {
                                var parts = line.Split(',');
                                return new status
                                {
                                    firstName = parts[0],
                                    middleName = parts[1],
                                    Maths = parts[4],
                                    Chem = parts[5],
                                    Eng = parts[6],
                                    Phy = parts[7],
                                    Bio = parts[8],
                                    Ict = parts[9],
                                    Average = parts[10],


                                };
                            }).ToList();


                        }

                        grade++;
                    }

                }
                
                
            }
        }
    }
}
