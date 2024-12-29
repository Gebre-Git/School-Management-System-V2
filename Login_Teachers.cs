using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Systems;

namespace School_Managment_System
{
    public  class Login_Teachers
    {
        public static void Login_as_teacher()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t*** Ligin Here ***");
            Console.Write("User Name: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            int grade = 9;
            while (grade < 13)
            {
                string filepath = $"Grade {grade} Teachers status.csv";
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
                Console.WriteLine("\n\n\t\t\t1:Edit students roster\n\n\t\t\t2:Messages from Adminstrator\n\n\t\t\t3:Messages for studentsn\n\t\t\t4:Set Attendance");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1) { edit_roster(grade, subject); }
                else if (choice == 2) 
                {
                    Console.Clear();
                    string filepath = $"Messages to Teachers.txt";

                    Console.WriteLine(File.ReadAllText(filepath));
                }
                else if (choice == 3) { Message_for_students(grade,subject); }
                else if (choice == 4) { set_Attendance(); }
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
                    string x = "";
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
                                    x += Convert.ToString(j);
                                }

                            }
                            if (firstname.ToLower() == parts[0].ToLower() && middletname.ToLower() == parts[1].ToLower())
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
                static void Message_for_students(string grade,string subject)
                {
                    Console.Clear();
                    Console.WriteLine("Write the Message Here (Use Enter Key when you finished)");
                    string message = Console.ReadLine();
                    string filepath = $"Messages to {grade} students.txt";
                    File.AppendAllText(filepath, $"\n{message}");
                    File.AppendAllText(filepath, $"\n\n\t\tThis Message is written on : {DateTime.Now.DayOfWeek} , {DateTime.Now}");
                    File.AppendAllText(filepath, $"\n\n\t\tFrom grade {grade} {subject} teacher");
                }

                static void set_Attendance()
                {
                    string datenow = Convert.ToString(DateTime.Now.Day) + "-" + Convert.ToString(DateTime.Now.Month) + "-" + Convert.ToString(DateTime.Now.Year);
                    Console.Write("Please enter Grade:");
                    int grade = int.Parse(Console.ReadLine());
                    Console.Write("Number of absent students");
                    int absent = int.Parse(Console.ReadLine());
                    string[] absents = new string[absent];
                    Console.Write("Please enter absent students name: ");
                    for (int i = 0; i < absents.Length; i++)
                    {

                        absents[i] = Console.ReadLine();
                    }
                    string filename = $"attendace grade {grade} students.csv";
                    string[] field = File.ReadAllLines(filename);
                    int count = 0;
                    field[0] += "," + Convert.ToString(datenow);
                    for (int i = 1; i < field.Length; i++)
                    {

                        string[] parts = field[i].Split(",");
                        for (int j = 0; j < absents.Length; j++)
                        {
                            if (parts[0].ToLower() == absents[j].ToLower())

                            {
                                field[i] += ",A";
                                count = 0;
                                break;


                            }
                            count++;


                        }
                        if (count != 0
                        )
                        {
                            field[i] += ",-";
                            count = 0;


                        }

                    }
                    File.WriteAllLines(filename, field);
                }
            }
        }
    }
}
