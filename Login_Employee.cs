using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems;

namespace School_Managment_System
{
    public class Login_Employee
    {
        public static void login_as_employee()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t*** Ligin Here ***");
            Console.Write("User Name:");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            int grade = 9;
            while (grade < 13)
            {
                string filepath = $"F:\\g7\\School Managment System\\teachers\\Grade {grade} Teachers status.csv";
                List<status> readteacher = ReadFromCsv(filepath);




                foreach (var student in readteacher)
                {

                    if ((student.User_Name == username) && (student.Password == password))
                    {
                        teacher_stuf(student.firstName, student.middleName, student.Grade, student.Subject);
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
                            Subject = parts[6],
                            User_Name = parts[9],
                            Password = parts[10],
                        };
                    }).ToList();
                }
                grade++;

            }
            static void teacher_stuf(string first_name, string last_name, string grade, string subject)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t1:Edit students roster\n\n\t\t\t2:Messages from Adminstrator\n\n\t\t\t3:Messages for students");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1) { edit_roster(grade, subject); }
                else if (choice == 2) { message_from_admin(); }
                else if (choice == 3) { Console.Clear(); }
                else
                {
                    Console.WriteLine("Invalid Input, Please choose 1-3");
                    teacher_stuf(first_name, last_name, grade, subject);
                }

                static void edit_roster(string grade, string subject)
                {
                    Console.Clear();
                    Console.Write("Enter student First name : ");
                    string firstname = Console.ReadLine();
                    Console.WriteLine("Enter student Middle name:");
                    string middletname = Console.ReadLine();
                    Console.Write("Enter the new Score :");
                    string score = Console.ReadLine();
                    string filepath = $"roster grade {grade} students.csv";
                    string x="";
                    if (File.Exists(filepath))
                    {
                        string[] roster = File.ReadAllLines(filepath);
                        for (int i = 0; i < roster.Length; i++)
                        {
                            string[] parts = roster[i].Split(',');
                            for (int j = 4; j < parts.Length - 1; j++)
                            {
                                if (subject.ToLower() == (parts[j].ToLower()))
                                {
                                    x +=Convert.ToString(j); 
                                }

                            }
                            if (firstname.ToLower() == parts[0].ToLower() && middletname.ToLower() == parts[1].ToLower() )
                            {
                                parts[int.Parse(x)] = score;
                                roster[i] = string.Join(",", parts);
                                File.WriteAllLines(filepath, roster);
                                Console.WriteLine("The Score is updated!!");
                                break;
                            }
                        }

                    }
                    else { Console.WriteLine("File Doesn't exist!!"); }

                    
                }
                static void message_from_admin()
                {
                    Console.Clear();
                }

            }

        }
    }
}
