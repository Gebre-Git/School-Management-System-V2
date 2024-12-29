using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Systems;

namespace School_Managment_System
{
    public class Admin 
    {
        public static void Student_Managment_System()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            Console.WriteLine("\t\t\t\t-----------------------------------------------------");
            Console.WriteLine("\t\t\t\t-----------------------------------------------------");
            Console.WriteLine("\t\t\t\t---------Wellcome to Student Managment System--------");
            Console.WriteLine("\t\t\t\t-----------------------------------------------------");
            Console.WriteLine("\t\t\t\t-----------------------------------------------------");
            Console.WriteLine("\n\t\t1------ Student registration\n\n\t\t2------Students List\n\n\t\t3------Students roster\n\n\t\t4------Messages\n\n\t\t5------Students Attendance\n\n\t\t6------Back");
                int option = int.Parse(Console.ReadLine());
            if (option == 1) { Student_registration(); }
            else if (option == 2) { Student_list(); }
            else if (option == 3) { Student_roster(); }
            else if (option == 4)
            {
                Console.WriteLine("Write the Message Here (Use Enter Key when you finished)");
                string message = Console.ReadLine();
                string filepath = $"Messages to students1.txt";
                File.AppendAllText(filepath, $"\n{message}");
                File.AppendAllText(filepath, $"\n\n\t\tThis Message is written on : {DateTime.Now.DayOfWeek} , {DateTime.Now}");
            }
            else if (option == 5) { Student_attendance(); }
            else if (option == 6) { admin(); }
            else
            {
                Console.WriteLine("INVALID INPUT please Choose correctly (1-3) : ");
                Student_Managment_System();
            }





            static void Student_registration()
            {
                Console.Clear();
                string name_chake = @"^[a-zA-Z ]+$";
                string phone_chake = @"^(09|07)\d{8}$";
                string birth_date_chake = @"^\d{4}$";
                string gender_chake = @"^(M|F)$";
                Console.WriteLine("\nRegister Here :-");
                string first_name = "";
                bool end_f_name = false;
                while (!end_f_name)
                {
                    Console.Write("\n\t\tFirst Name  : ");
                    first_name = Console.ReadLine();
                    bool re_first_name = Regex.IsMatch(first_name, name_chake);
                    if (re_first_name == false)
                    {
                        string message = "Please enter the correct name format (letters only!)";
                        Tool.WarningMessage(message);
                    }
                    else { end_f_name = true; }
                }
                string middle_name = "";
                bool end_m_name = false;
                while (!end_m_name)
                {
                    Console.Write("\n\t\tMiddle Name : ");
                    middle_name = Console.ReadLine();
                    bool re_middle_name = Regex.IsMatch(middle_name, name_chake);
                    if (re_middle_name == false)
                    {
                        string message = "Please enter the correct name format (letters only!)";
                        Tool.WarningMessage(message);
                    }
                    else { end_m_name = true; }
                }
                string last_name = "";
                bool end_l_name = false;
                while (!end_l_name)
                {
                    Console.Write("\n\t\tLast Name   : ");
                    last_name = Console.ReadLine();
                    bool re_last_name = Regex.IsMatch(last_name, name_chake);
                    if (re_last_name == false)
                    {
                        string message = "Please enter the correct name format (letters only!)";
                        Tool.WarningMessage(message);
                    }
                    else { end_l_name = true; }
                }
                string new_birth_date = "";
                bool end_birth_date = false;
                while (!end_birth_date)
                {
                    Console.Write("\n\t\tBirth date (only the year)  : ");
                    int birth_date = int.Parse(Console.ReadLine());
                    new_birth_date = Convert.ToString(birth_date);
                    bool re_birth_date = Regex.IsMatch(new_birth_date, birth_date_chake);
                    if (re_birth_date == false || birth_date < 0 || birth_date > DateTime.Now.Year)
                    {
                        string message = "Please enter the correct birth date format (your birth date!)";
                        Tool.WarningMessage(message);
                    }
                    else { end_birth_date = true; }
                }
                string gender = "";
                bool end_gender = false;
                while (!end_gender)
                {
                    Console.Write("\n\t\tGender(M/F) : ");
                    gender = Console.ReadLine().ToUpper();
                    bool re_gender = Regex.IsMatch(gender, gender_chake);
                    if (re_gender == false)
                    {
                        string message = "Please enter the correct gender format (M/F)";
                        Tool.WarningMessage(message);
                    }
                    else { end_gender = true; }
                }
                string phone_number = "";
                bool end_phone_number = false;
                while (!end_phone_number)
                {
                    Console.Write("\n\t\tPhone number : ");
                    phone_number = Console.ReadLine();
                    bool re_phone_number = Regex.IsMatch(phone_number, phone_chake);
                    if (re_phone_number == false)
                    {
                        string message = "Please enter the correct Ethiopia phone number format (09******** or 07********)";
                        Tool.WarningMessage(message);
                    }
                    else { end_phone_number = true; }
                }
                string grade = "";
                int int_grade = 0;
                bool end_grade = false;
                while (!end_grade)
                {
                    Console.Write("\n\t\tGrade  : ");
                    grade = Console.ReadLine();
                    int_grade = int.Parse(grade);
                    if (int_grade < 9 || int_grade > 12)
                    {
                        string message = "Please enter the grade in range of 9 and 12";
                        Tool.WarningMessage(message);
                    }
                    else { end_grade = true; }
                }
                string Id;
                checkId(out Id);
                static void checkId(out string id)
                {
                    string possibleId;
                    int counter = 0;
                    string idholder = "";
                    int studs = 1;
                    while (studs < 9999)
                    {
                        if (studs < 10)
                        {
                            possibleId = "000" + studs;
                        }
                        else if (studs < 100 && studs > 9)
                        {
                            possibleId = "00" + studs;
                        }
                        else
                        {
                            possibleId = "0" + studs;
                        }

                        for (int grade = 9; grade < 13; grade++)
                        {
                            string filepath = $"Grade {grade} students status.csv";
                            string[] studlist = File.ReadAllLines(filepath);
                            for (int i = 1; i < studlist.Length; i++)
                            {
                                string[] parts = studlist[i].Split(",");
                                string preid = parts[7].Substring(5);
                                if (preid == possibleId)
                                {
                                    counter++;
                                }


                            }

                        }
                        if (counter == 0)
                        {
                            idholder += "STEM-" + possibleId;
                            studs = 10000;
                        }
                        else
                        {
                            idholder = "";
                            counter = 0;

                        }

                        studs++;

                    }
                    id = idholder;
                }

                List<status> student_register = new List<status>
                {
                    new status {firstName = first_name , middleName = middle_name , lastName = last_name , Gender = gender ,Birth_Date = new_birth_date, Grade =grade,Phone_number = phone_number, Student_ID = Id }
                };

                List<status> row = new List<status>
                {
                    new status{firstName = "FirstName",middleName = "Middlename",lastName = "LastName",Gender = "Gender",Birth_Date = "birth date",Grade = "Grade",Phone_number = "Phone No",Student_ID = "ID"}
                };

                string filepath = $"Grade {grade} students status.csv";
                writecsv(filepath, student_register, row);
                Console.WriteLine($"\nThe student data is written successfully in {filepath}");

                static void writecsv(string filename, List<status> data, List<status> row)
                {
                    var file = data.Select(student => $"{student.firstName},{student.middleName},{student.lastName},{student.Gender},{student.Birth_Date},{student.Grade},{student.Phone_number},{student.Student_ID}");
                    var Rowdata = row.Select(student => $"{student.firstName},{student.middleName},{student.lastName},{student.Gender},{student.Birth_Date},{student.Grade},{student.Phone_number},{student.Student_ID}");

                    if (File.Exists(filename))
                    {
                        File.AppendAllLines(filename, file);
                    }
                    else
                    {
                        File.AppendAllLines(filename, Rowdata);
                        File.AppendAllLines(filename, file);
                    }
                }
                Console.WriteLine("Do you want to register again(yes to accept or any key to break): ");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "yes")
                {
                    Student_registration();
                }
                else
                { Console.WriteLine("The program is exiting... "); }

            }



            static void Student_list()
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t-----------------------------------------------------");
                Console.WriteLine("\t\t\t\t-----------------------------------------------------");
                Console.WriteLine("\t\t\t\t---------Wellcome to Student Search Part-------------");
                Console.WriteLine("\t\t\t\t-----------------------------------------------------");
                Console.WriteLine("\t\t\t\t-----------------------------------------------------\n");
                Console.WriteLine("\n\t\t\t1---------Using Name\n\n\t\t\t2---------Using Grade\n\n\t\t\t3---------Back");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1) { Using_Name(); }
                else if (choice == 2) { Using_grade(); }
                else if (choice == 3) { Student_Managment_System(); }
                else
                {
                    Console.Write("Invalid input please between 1 - 3: ");
                    Student_list();
                }
                static void Using_Name()
                {
                    Console.Clear();
                    Console.Write("\n\tEnter name:");
                    string input_name = Console.ReadLine();
                    int i = 9;
                    Console.WriteLine($"\t\tRelated search results with name \"{input_name}\": ");
                    while (i < 13)
                    {

                        string filepath = $"Grade {i} students status.csv";
                        List<status> readstudent = ReadFromCsv(filepath);
                        int datenow = DateTime.Now.Year;
                        if (readstudent[1].firstName != "FirstName")
                        {
                            string agestring = readstudent[1].Age;
                            int age = int.Parse(agestring);
                            foreach (var student in readstudent)
                            {
                                if (student.firstName.ToLower() == input_name.ToLower() || student.lastName.ToLower() == input_name.ToLower())
                                {
                                    Console.WriteLine($"\n\t\t\t\tName: {student.FullName}\n\t\t\tAge: {datenow - age}\n\t\t\tGender: {student.Gender}\n\t\t\tGrade: {student.Grade}, \n\t\t\tphone Number: {student.Phone_number}");
                                }
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

                                    lastName = parts[2],
                                    FullName = parts[0] + " " + parts[1] + " " + parts[2],
                                    Gender = parts[3],
                                    Age = parts[4],
                                    Grade = parts[5],
                                    Phone_number = parts[6],
                                };
                            }).ToList();
                        }
                        i++;
                    }
                    Console.ReadKey();

                }
                static void Using_grade()
                {
                    Console.Clear();
                    Console.Write("Please enter grade: ");
                    int input_grade = int.Parse(Console.ReadLine());
                    int i = 9;
                    while (i < 13)
                    {

                        string filepath = $"Grade {i} students status.csv";
                        List<status> readstudents = ReadFromCsv(filepath);

                        string grade = readstudents[1].Grade;

                        if (input_grade == Convert.ToInt32(grade))

                        {
                            Console.WriteLine($"\n\n\t\t\tGrade {i} students profile\n");
                            Console.WriteLine("\t\t|Name \t\t|Age\t|Gender\t|Grade\t|Phone");
                            foreach (var person in readstudents)
                            {
                                if (person.firstName != "FirstName")

                                {
                                    int age = DateTime.Now.Year - int.Parse(readstudents[1].Age);
                                    Console.WriteLine($"\n\t\t|{person.FullName}\t|{age}\t|{person.Gender}\t|{person.Grade}\t|{person.Phone_number}");
                                }
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
                                    FullName = parts[0] + " " + parts[1],
                                    Age = parts[4],
                                    Gender = parts[3],
                                    Grade = parts[5],

                                    Phone_number = parts[6]
                                };
                            }).ToList();


                        }

                        i++;
                    }
                    Console.ReadKey();

                }

            }
            static void Student_attendance()
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t-----------------------------------------------------");
                Console.WriteLine("\t\t\t\t-----------------------------------------------------");
                Console.WriteLine("\t\t\t\t---------Wellcome to Student Attendance Part--------");
                Console.WriteLine("\t\t\t\t-----------------------------------------------------");
                Console.WriteLine("\t\t\t\t-----------------------------------------------------\n");
                Console.WriteLine("\n\t\t1------ Check Absent\n\n\t\t2------ Check Permition\n\n\t\t3------ Back\n\n");
                int option = int.Parse(Console.ReadLine());
                if (option == 1) { check_absent(); }
                else if (option == 2) { Check_Permition(); }
                else if (option == 3) { Student_Managment_System(); }
                else
                {
                    Console.WriteLine("INVALID INPUT please Choose correctly (1-3) : ");
                    Student_attendance();
                }
                static void check_absent()
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\t\t1-------For all students\n\n\t\t2-------For a single student\n\n\t\t3-------Back");
                    int option = int.Parse(Console.ReadLine());
                    if (option == 1) { For_all_students(); }
                    else if (option == 2) { For_a_single_student(); }
                    else if (option == 3) { Student_attendance(); }
                    else
                    {
                        Console.WriteLine("INVALID INPUT please Choose correctly (1-2) : ");
                        check_absent();
                    }
                    static void For_all_students()
                    {
                        Console.Clear();
                        Console.WriteLine("\t\t**********Welcome to For all students part*********\n\n");
                        Console.Write("Enter the grade: ");
                        string grade_input = Console.ReadLine();
                        Console.Write("\nEnter the Date - format := (d/m/y): ");
                        string date_input = Console.ReadLine();
                        string filePath = $"attendace grade {grade_input} students.csv";
                        Read_attendace(filePath, date_input);
                        static void Read_attendace(string filepath, string date)
                        {
                            if (File.Exists(filepath))
                            {
                                string[] lines = File.ReadAllLines(filepath);
                                string[] mianu = lines[0].Split(',');
                                string[] temp = new string[lines.Length];
                                for (int j = 0; j < mianu.Length; j++)
                                {
                                    if (date == mianu[j])
                                    {
                                        for (int i = 0; i < lines.Length; i++)
                                        {
                                            temp = lines[i].Split(',');
                                            if (temp[j] == "P" || temp[j] == "p")
                                            {
                                                Console.WriteLine($"\n\t{temp[0]}\t............................. Permition");
                                            }
                                            else if (temp[j] == "A" || temp[j] == "a")
                                            {
                                                Console.WriteLine($"\n\t{temp[0]}\t............................. Absent");
                                            }
                                            else { continue; }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("The CSV file does not exist.");
                            }

                        }
                    }
                    static void For_a_single_student()
                    {
                        Console.Clear();
                        Console.WriteLine("\t\t*********Welcome to For a single student part**********\n\n");
                        Console.Write("Enter the grade: ");
                        string grade_input = Console.ReadLine();
                        Console.Write("\nEnter the name: ");
                        string name_input = Console.ReadLine();
                        string filePath = $@"attendace grade {grade_input} students.csv";
                        Read_attendace(filePath, name_input);
                        static void Read_attendace(string filepath, string name)
                        {
                            if (File.Exists(filepath))
                            {
                                string[] lines = File.ReadAllLines(filepath);
                                string[] temp = new string[lines.Length];
                                int count_absent = 0, count_permition = 0;
                                string[] mainu_list = lines[0].Split(',');
                                string[] final_data_A = new string[lines.Length + 2];
                                string[] final_data_P = new string[lines.Length + 2];
                                for (int i = 0; i < lines.Length; i++)
                                {
                                    temp = lines[i].Split(',');
                                    if (temp[0] == name)
                                    {
                                        for (int value = 1; value < temp.Length; value++)
                                        {
                                            if (temp[value] == "A" || temp[value] == "a")
                                            {
                                                count_absent++;
                                                final_data_A[value] = mainu_list[value];
                                            }
                                            else if (temp[value] == "P" || temp[value] == "p")
                                            {
                                                count_permition++;
                                                final_data_P[value] = mainu_list[value];
                                            }
                                        }
                                        Console.WriteLine($"\nStudent {name} has {count_absent} absents and {count_permition} permitions");
                                        Console.WriteLine("\nWoud you like to show detiel information (Y/any key): ");
                                        string permition_to_detiel_info = Console.ReadLine().ToUpper();
                                        if (permition_to_detiel_info == "Y")
                                        {
                                            Console.WriteLine($"\t\tThe day for Absent:");
                                            for (int a = 0; a < final_data_A.Length; a++)
                                            {
                                                if (final_data_A[a] != null)
                                                {
                                                    Console.WriteLine($"\n\t\t......{final_data_A[a]}");
                                                }
                                            }
                                            Console.WriteLine($"\n\n\t\tThe day for Permition:");
                                            for (int b = 0; b < final_data_P.Length; b++)
                                            {
                                                if (final_data_P[b] != null)
                                                {
                                                    Console.WriteLine($"\n\t\t......{final_data_P[b]}");
                                                }
                                            }
                                        }
                                        else { Console.WriteLine("......Good bay!....."); }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("The CSV file does not exist.");
                            }
                        }
                    }
                }
                static void Ask_reasone()
                {
                    Console.Clear();
                    Console.WriteLine("******* Welocome to Ask reasone**********");
                }
                static void Check_Permition()
                {
                    Console.Clear();
                    Console.WriteLine("******* Welocome to check permition**********");
                }


            }

            static void Student_roster()
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t-----------------------------------------------------");
                Console.WriteLine("\t\t\t\t-----------------------------------------------------");
                Console.WriteLine("\t\t\t\t---------Wellcome to Student Roster Part-------------");
                Console.WriteLine("\t\t\t\t-----------------------------------------------------");
                Console.WriteLine("\t\t\t\t-----------------------------------------------------\n");
                Console.WriteLine("\n\t\t\t1-------------Save student mark\n\n\t\t\t2-------------See students mark\n\n\t\t\t3-------------Back");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1) { save_roster(); }
                else if (choice == 2) { see_roster(); }
                else if (choice == 3) { Student_Managment_System(); }
                else
                {
                    Console.WriteLine("Please choose correctly (1 - 3)!"); Student_roster();
                }

                static void save_roster()
                {
                    Console.Clear();
                    Console.WriteLine("Please fill the following subjects with correct marks(out of 100%) : ");
                    Console.Write("First Name: ");
                    string F_name = Console.ReadLine();
                    Console.Write("Middle Name:");
                    string M_name = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string L_name = Console.ReadLine();
                    Console.Write("Grade: ");
                    int grade = int.Parse(Console.ReadLine());
                    Console.Write("Mathimatics: ");
                    double math = int.Parse(Console.ReadLine());
                    Console.Write("Chemistry: ");
                    double chemistry = int.Parse(Console.ReadLine());
                    Console.Write("English: ");
                    double English = int.Parse(Console.ReadLine());
                    Console.Write("Physics: ");
                    double Physics = int.Parse(Console.ReadLine());
                    Console.Write("Biology: ");
                    double Biology = int.Parse(Console.ReadLine());
                    Console.Write("ICT: ");
                    int ICT = int.Parse(Console.ReadLine());
                    double average = (math + chemistry + English + Physics + Biology + ICT) / 6;
                    List<status> roster = new List<status>
                {
                    new status {firstName = F_name,middleName = M_name ,lastName =L_name,Grade =Convert.ToString( grade),Maths=Convert.ToString(math),Chem = Convert.ToString(chemistry),Eng = Convert.ToString(English),Phy = Convert.ToString(Physics),Bio=Convert.ToString(Biology),Ict = Convert.ToString(ICT),Average=Convert.ToString(average)}
                };
                    List<status> rowheader = new List<status>
                {
                    new status {firstName = "firstname",middleName = "middlename" ,lastName ="lastname",Grade ="Grade",Maths="Mathimatics",Chem = "Chemistry",Eng = "English",Phy = "Physics",Bio="Biology",Ict = "Ict",Average="Average"}
                };
                    string filepath = $"roster grade {grade} students.csv";
                    writecsv(filepath, roster,rowheader);
                    Console.WriteLine($"The student data is written successfully in {filepath}");

                    static void writecsv(string filename, List<status> data,List<status> row)
                    {
                        var file = data.Select(student => $"{student.firstName},{student.middleName},{student.lastName},{student.Grade},{student.Maths},{student.Chem},{student.Eng},{student.Phy},{student.Bio},{student.Ict},{student.Average}");
                        var rowdata = row.Select(student => $"{student.firstName},{student.middleName},{student.lastName},{student.Grade},{student.Maths},{student.Chem},{student.Eng},{student.Phy},{student.Bio},{student.Ict},{student.Average}");
                        if(File.Exists(filename))
                        {
                            File.AppendAllLines(filename, file);
                        }
                        else
                        {
                            File.AppendAllLines(filename, rowdata);
                            File.AppendAllLines(filename, file);
                        }
                        
                    }
                    Console.WriteLine("Do you want to save student roster again (yes or other key to break)");
                    string option = Console.ReadLine();
                    if ( option.ToLower() =="yes" ) 
                    {
                        save_roster();
                    }
                    else
                    {
                        Console.WriteLine("The program is exitiing...");
                    }
                }
                static void see_roster()
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t\t1-----------all students score\n\n\t\t\t2-----------Students average\n\n\t\t\t3-----------Use student name\n\n\t\t\t4-----------Back");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1) { all_score(); }
                    else if (choice == 2) { students_average(); }
                    else if (choice == 3) { Using_name_roster(); }
                    else if (choice == 4) { Student_roster(); }
                    else { Console.WriteLine("Please enter the between 1-4: "); see_roster(); }
                    static void all_score()
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter The grade : ");
                        string g =Console.ReadLine();

                        int i = 9;
                        while (i < 13)
                        {
                            string filepath = $"roster grade {i} students.csv";
                            List<status> readroster = readfromcsv(filepath);
                            string grad = readroster[1].Grade;
                            if (g == grad)
                            {
                                Console.WriteLine("\t\t|Name\t\t|Grade\t|Math\t|Chem\t|Eng\t|Phy\t|Bio\t|Ict");
                                foreach (var person in readroster)
                                {
                                    if(person.firstName!= "firstname")
                                    {
                                        Console.WriteLine($"\t\t|{person.FullName}\t|{person.Grade}\t|{person.Maths}\t|{person.Chem}\t|{person.Eng}\t|{person.Phy}\t|{person.Bio}\t|{person.Ict}");
                                    }
                                    
                                }
                            }
                            static List<status> readfromcsv(string filepath)
                            {
                                var lines = File.ReadAllLines(filepath);
                                for(int i=1; i<=lines.Length;i++)
                                {

                                }
                                return lines.Select(line =>
                                {
                                    var parts = line.Split(',');
                                    return new status
                                    {
                                        lastName = parts[1],
                                        middleName = parts[2],
                                        firstName = parts[0],
                                        FullName = parts[0] + parts[1],
                                        Grade = parts[3],
                                        Maths = parts[4],
                                        Chem = parts[5],
                                        Eng = parts[6],
                                        Phy = parts[7],
                                        Bio = parts[8],
                                        Ict = parts[9]

                                    };

                                }).ToList();


                            }
                            i++;

                        }
                        Console.ReadKey();

                    }
                    static void students_average()
                    {
                        Console.Clear();
                        Console.WriteLine("\t\tPlease enter the grade : ");
                        string gradee = Console.ReadLine();
                        int i = 9;
                        while (i < 13)
                        {
                            string filepath = $"roster grade {i} students.csv";
                            List<status> readroster = readfromcsv(filepath);

                            string grad = readroster[1].Grade;

                            if (gradee == grad)
                            {

                                List<status> sortedroster = readroster.OrderByDescending(readroster => readroster.Average).ToList();
                                Console.WriteLine($"\t\tGrade {grad} students Rank\n\n");
                                int count = 1;
                                Console.WriteLine("\t\t|Rank\t|Name\t\t|Average");
                                foreach (var person in sortedroster)
                                {
                                    if(person.firstName != "firstname")
                                    {
                                        Console.WriteLine($"\t\t|{count}\t|{person.FullName}\t|{person.Average}");
                                        count++;
                                    }
                                }
                            }
                            static List<status> readfromcsv(string filepath)
                            {
                                var lines = File.ReadAllLines(filepath);
                                return lines.Select(line =>
                                {
                                    var parts = line.Split(',');
                                    return new status
                                    {

                                        firstName = parts[0],
                                        middleName= parts[1],
                                        FullName = parts[0] + parts[1],
                                        Grade = parts[3],
                                        Average = parts[10],


                                    };

                                }).ToList();


                            }
                            i++;

                        }
                        Console.ReadKey();


                    }

                    static void Using_name_roster()
                    {
                        Console.Clear();
                        Console.Write("\n\t\tEnter Name: ");
                        string input_name = Console.ReadLine();
                        int i = 9;
                        Console.WriteLine("\t\t|Name\t\t|Grade\t|Math\t|Chem\t|Eng\t|Phy\t|Bio\t|Ict");
                        while (i < 13)
                        {

                            string filepath = $"roster grade {i} students.csv";
                            List<status> readPeople = ReadFromCsv(filepath);
                            
                            foreach (var person in readPeople)
                            {
                                
                                if (person.firstName.ToLower() == input_name.ToLower() || person.lastName.ToLower() == input_name.ToLower())
                                {
                                    Console.WriteLine($"\t\t|{person.FullName}\t|{person.Grade}\t|{person.Maths}\t|{person.Chem}\t|{person.Eng}\t|{person.Phy}\t|{person.Bio}\t|{person.Ict}");


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
                                        lastName = parts[2],
                                        middleName = parts[1],
                                        FullName = parts[0] + parts[1],
                                        Grade = parts[3],
                                        Maths = parts[4],
                                        Chem = parts[5],
                                        Eng = parts[6],
                                        Phy = parts[7],
                                        Bio = parts[8],
                                        Ict = parts[9],


                                    };
                                }).ToList();


                            }

                            i++;
                        }
                        Console.ReadKey();
                    }
                }

            }
            

        }



        public static void Teacher_Managment_System()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t-----------------------------------------------------");
            Console.WriteLine("\t\t\t\t-----------------------------------------------------");
            Console.WriteLine("\t\t\t\t---------Wellcome to Teachers Managment System--------");
            Console.WriteLine("\t\t\t\t-----------------------------------------------------");
            Console.WriteLine("\t\t\t\t-----------------------------------------------------\n");
            Console.WriteLine("\t1-----------Teacher registration\n\n\t2-----------Teachers List\n\n\t3-----------Messages\n\n\t4-----------Back\n");
            int choice = int.Parse(Console.ReadLine());
            if(choice==1)
            {
                Teacher_Registration();
            }
            else if(choice==2)
            {
                Teachers_Search();
            }
            else if(choice==3)
            {
                Console.Clear();
                Console.WindowHeight = 10;
                Console.WriteLine("Write the Message Here (Use Enter Key when you finished)");
                string message =Console.ReadLine();
                string filepath = $"Messages to Teachers.txt";
                File.AppendAllText(filepath, $"\n{message}");
                File.AppendAllText(filepath, $"\n\n\t\tThis Message is written on : {DateTime.Now.DayOfWeek} , {DateTime.Now}");
            }
            else if(choice == 4) { admin(); }
            else
            {
                Console.WriteLine("Invalid input, please try again");
                Teacher_Managment_System();
            }

            static void Teacher_Registration()
            {
                Console.Clear();
                string name_chake = @"^[a-zA-Z ]+$";
                string phone_chake = @"^(09|07)\d{8}$";
                string birth_date_chake = @"^\d{4}$";
                string gender_chake = @"^(M|F)$";
                string subject_chake = @"^(Biology|Chemistry|English|ICT|Maths)$";
                string user_name_chake = @"^[a-zA-Z0-9]+(_|)[a-zA-Z0-9]+$";

                Console.WriteLine("\nRegister Here :-");
                string first_name = "";
                bool end_f_name = false;
                while (!end_f_name)
                {
                    Console.Write("\n\t\tFirst Name  : ");
                    first_name = Console.ReadLine();
                    bool re_first_name = Regex.IsMatch(first_name, name_chake);
                    if (re_first_name == false)
                    {
                        string message = "Please enter the correct name format (letters only!)";
                        Tool.WarningMessage(message);
                    }
                    else { end_f_name = true; }
                }
                string middle_name = "";
                bool end_m_name = false;
                while (!end_m_name)
                {
                    Console.Write("\n\t\tMiddle Name : ");
                    middle_name = Console.ReadLine();
                    bool re_middle_name = Regex.IsMatch(middle_name, name_chake);
                    if (re_middle_name == false)
                    {
                        string message = "Please enter the correct name format (letters only!)";
                        Tool.WarningMessage(message);
                    }
                    else { end_m_name = true; }
                }
                string last_name = "";
                bool end_l_name = false;
                while (!end_l_name)
                {
                    Console.Write("\n\t\tLast Name   : ");
                    last_name = Console.ReadLine();
                    bool re_last_name = Regex.IsMatch(last_name, name_chake);
                    if (re_last_name == false)
                    {
                        string message = "Please enter the correct name format (letters only!)";
                        Tool.WarningMessage(message);
                    }
                    else { end_l_name =  true; }
                }
                string new_birth_date = "";
                bool end_birth_date = false;
                while (!end_birth_date)
                {
                    Console.Write("\n\t\tBirth date (only the year)  : ");
                    int birth_date = int.Parse(Console.ReadLine());
                    new_birth_date = Convert.ToString(birth_date);
                    bool re_birth_date = Regex.IsMatch(new_birth_date, birth_date_chake);
                    if (re_birth_date == false || birth_date < 0 || birth_date > DateTime.Now.Year)
                    {
                        string message = "Please enter the correct birth date format (your birth date!)";
                        Tool.WarningMessage(message);
                    }
                    else { end_birth_date = true; }
                }
                string gender = "";
                bool end_gender = false;
                while (!end_gender)
                {
                    Console.Write("\n\t\tGender(M/F) : ");
                    gender = Console.ReadLine().ToUpper();
                    bool re_gender = Regex.IsMatch(gender, gender_chake);
                    if (re_gender == false)
                    {
                        string message = "Please enter the correct gender format (M/F)";
                        Tool.WarningMessage(message);
                    }
                    else { end_gender = true; }
                }
                string phone_number = "";
                bool end_phone_number = false;
                while (!end_phone_number)
                {
                    Console.Write("\n\t\tPhone number : ");
                    phone_number = Console.ReadLine();
                    bool re_phone_number = Regex.IsMatch(phone_number, phone_chake);
                    if (re_phone_number == false)
                    {
                        string message = "Please enter the correct Ethiopia phone number format (09******** or 07********)";
                        Tool.WarningMessage(message);
                    }
                    else { end_phone_number = true; }
                }
                string grade = "";
                int int_grade = 0;
                bool end_grade = false;
                while (!end_grade)
                {
                    Console.Write("\n\t\tGrade  : ");
                    grade = Console.ReadLine();
                    int_grade = int.Parse(grade);
                    if (int_grade < 9 || int_grade > 12)
                    {
                        string message = "Please enter the grade in range of 9 and 12";
                        Tool.WarningMessage(message);
                    }
                    else { end_grade = true; }
                }
                string subject = "";
                bool end_subject = false;
                while (!end_subject)
                {
                    Console.Write("\n\t\tSubject : ");
                    subject = Console.ReadLine();
                    bool re_subject = Regex.IsMatch(subject, subject_chake);
                    if (re_subject == false)
                    {
                        string message = "Please enter the correct subjects name (Title case!)";
                        Tool.WarningMessage(message);
                    }
                    else { end_subject = true; }
                }
                string user_name = "";
                bool end_user_name = false;
                while (!end_user_name) {
                    Console.Write("\n\t\tUsername : ");
                    user_name = Console.ReadLine();
                    bool re_user_name = Regex.IsMatch(user_name, user_name_chake);
                    if (re_user_name == false)
                    {
                        string message = "Please enter the correct username format!\n\n\t " +
                                         "Allowed: letter, number and undrescore.\n\n\t" +
                                         "  Warning: you can't start and end with underscore!, No white space!";
                        Tool.WarningMessage(message);
                    }
                    else { end_user_name = true; }
                }
                bool reEnter = true;
                string password = "";
                while (reEnter)
                {
                    Console.Write("\n\t\tpassword  : ");
                    password = Console.ReadLine();
                    if (password.Length < 8 || password.Length > 16)
                    {
                        string message = "Your password length must greater than 8 and less than 16!";
                        Tool.WarningMessage(message);
                        Teacher_Registration();
                    }
                    Tool.PasswordChake(password, ref reEnter);
                }
                Console.WriteLine($"\n\t\t Your Password : {password}\n");
                int count2 = 0;
                for (int grad = 9; grad < 13; grad++)
                {
                    string path = $"Grade {grad} Teachers status.csv"; ;
                    string[] studentlist = File.ReadAllLines(path);
                    for (int i = 1; i < studentlist.Length; i++)
                    {
                        string[] parts = studentlist[i].Split(",");
                        if (parts[8] == user_name)
                        {

                            Console.WriteLine("The user name has already token!");
                            Console.WriteLine("If you want to try again enter T (any other key to exit)");
                            string option = Console.ReadLine();
                            if (option.ToLower() == "t") { Teacher_Registration(); }
                            else
                            {
                                Console.WriteLine("The program is exiting...");
                            }
                            count2++;
                            i = studentlist.Length;
                            int_grade = 13;
                        }


                    }
                }


                if (count2 == 0)
                {
                    List<status> teacher_register = new List<status>
                {
                    new status {firstName = first_name , middleName = middle_name , lastName = last_name , Gender = gender ,Birth_Date = new_birth_date, Grade = grade,Subject = Convert.ToString(subject),Phone_number = phone_number,User_Name = user_name,Password = password  }
                };
                    List<status> row = new List<status>
                {
                    new status{firstName = "FirstName",middleName = "Middlename",lastName = "LastName",Gender = "Gender",Birth_Date = "birth date",Grade = "Grade",Subject = "Subject",Phone_number = "Phone No",User_Name = "User name",Password = "password"}
                };
                    string filepath = $"Grade {grade} Teachers status.csv";
                    writecsv(filepath, teacher_register, row);
                    Console.WriteLine($"The Teacher data is written successfully in {filepath}\n\n");

                    static void writecsv(string filename, List<status> data, List<status> row)
                    {
                        var file = data.Select(student => $"{student.firstName},{student.middleName},{student.lastName},{student.Gender},{student.Birth_Date},{student.Grade},{student.Subject},{student.Phone_number},{student.User_Name},{student.Password}");
                        var rowdata = row.Select(student => $"{student.firstName},{student.middleName},{student.lastName},{student.Gender},{student.Birth_Date},{student.Grade},{student.Subject},{student.Phone_number},{student.User_Name},{student.Password}");
                        if (File.Exists(filename))
                        {
                            File.AppendAllLines(filename, file);
                        }
                        else
                        {
                            File.AppendAllLines(filename, rowdata);
                            File.AppendAllLines(filename, file);
                        }

                    }
                    Console.WriteLine("Do you want to register again(yes to accept or any key to break): ");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "yes")
                    {
                        Teacher_Registration();
                    }
                    else
                    { Console.WriteLine("The program is exiting... "); }
                }



            }


            static void Teachers_Search()
            {
                Console.Clear();
                Console.WriteLine("\n\t\t\t1-------------Using Name \n\n\t\t\t2-------------Using Grade \n\n\t\t\t3-------------Using Subject\n\n\t\t\t4-------------Back");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1) { Using_name(); }
                else if (choice == 2) { Using_grade(); }
                else if (choice == 3) { Using_subject(); }
                else if(choice == 4) { Teacher_Managment_System(); }
                else { Console.WriteLine("INVALID input please try again ");Teachers_Search(); }

                static void Using_name()
                {
                    Console.Clear();
                    Console.Write("\n\tEnter name:");
                    string input_name = Console.ReadLine().ToLower();
                    int i = 9;
                    Console.WriteLine($"\t\tRelated search results with name \"{input_name}\": ");
                    while (i < 13)
                    {

                        string filepath = $"Grade {i} Teachers status.csv";
                        List<status> readteacher = ReadFromCsv(filepath);

                        if (readteacher[1].firstName!= "FirstName")
                        {
                            int datenow = DateTime.Now.Year;
                            int age = datenow - int.Parse(readteacher[1].Age);
                            foreach (var teacher in readteacher)
                            {

                                if ((teacher.firstName.ToLower() == input_name) || (teacher.middleName.ToLower() == input_name) || (teacher.lastName.ToLower() == input_name))
                                {

                                    Console.WriteLine($"\n\t\t\t\tName: {teacher.FullName}\n\t\t\tAge: {age}\n\t\t\tGender: {teacher.Gender}\n\t\t\tGrade: {teacher.Grade}\n\t\t\tSubject: {teacher.Subject}, \n\t\t\tphone Number: {teacher.Phone_number}");
                                }


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
                                    lastName = parts[2],
                                    FullName = parts[0] + " " + parts[1] + " " + parts[2],
                                    Gender = parts[3],
                                    Age = parts[4],
                                    Grade = parts[5],
                                    Subject = parts[6],
                                    Phone_number = parts[7],
                                };
                            }).ToList();
                        }
                        i++;
                    }
                }


                static void Using_grade()
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\tPlease enter the Grade:");
                    string input_grade =Console.ReadLine();
                    int G = 9;

                    while (G < 13)
                    {
                        string filepath = $"Grade {G} Teachers status.csv";
                        List<status> readteacher = ReadFromCsv(filepath);

                        if (input_grade == readteacher[1].Grade)
                        {
                            Console.WriteLine($"\n\n\t\t\tGrade {G} Teachers Data\n");
                            Console.WriteLine("\t\t|Name\t\t|Age \t|Gender\t|Subject\t|Phone");

                            foreach (var person in readteacher)
                            {
                                if(person.firstName!= "FirstName")
                                {
                                    int age = DateTime.Now.Year - int.Parse(readteacher[1].Age);
                                    Console.WriteLine($"\n\t\t|{person.FullName}  \t|{age}\t|{person.Gender}\t|{person.Subject}\t|{person.Phone_number}");
                                }
                                

                            }

                        }




                        static List<status> ReadFromCsv(string filePath)
                        {
                            var data = File.ReadAllLines(filePath);
                            return data.Select(Teachers =>
                            {
                                var parts = Teachers.Split(",");
                                return new status
                                {
                                    firstName = parts[0],
                                    FullName = parts[0] + " " + parts[1],
                                    Gender = parts[3],
                                    Age = parts[4],
                                    Grade = parts[5],
                                    Subject = parts[6],
                                    Phone_number = parts[7]

                                };
                            }).ToList();
                        }
                        G++;
                    }
                }

                static void Using_subject()
                {
                    Console.Clear();
                    Console.Write("\n\tEnter The Subject:");
                    string subject = Console.ReadLine().ToLower();
                    int i = 9;
                    Console.WriteLine($"\t\t\"{subject}\" Teacher/s :\n ");
                    while (i < 13)
                    {

                        string filepath = $"Grade {i} Teachers status.csv";
                        List<status> readteacher = ReadFromCsv(filepath);




                        foreach (var teacher in readteacher)
                        {

                            if (teacher.Subject.ToLower() == subject && teacher.firstName!= "FirstName")
                            {
                                int age = DateTime.Now.Year - int.Parse(readteacher[1].Age);
                                Console.WriteLine($"\n\t\t\t\tName: {teacher.FullName}\n\t\t\tAge: {age}\n\t\t\tGender: {teacher.Gender}\n\t\t\tGrade: {teacher.Grade}, \n\t\t\tSubject: {teacher.Subject}, \n\t\t\tphone Number: {teacher.Phone_number}");
                            }


                        }
                        static List<status> ReadFromCsv(string filePath)
                        {
                            var lines = File.ReadAllLines(filePath);
                            int datenow = DateTime.Now.Year;

                            return lines.Select(line =>
                            {
                                var parts = line.Split(',');
                                return new status
                                {
                                    FullName = parts[0] + " " + parts[1] + " " + parts[2],
                                    Gender = parts[3],
                                    Age =parts[4],
                                    Grade = parts[5],
                                    Subject = parts[6],
                                    Phone_number = parts[7],
                                };
                            }).ToList();
                        }
                        i++;
                    }
                }
            }
        }



        public static void admin()
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            static void main()
            {

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t1----- Student managment system\n\n\t\t\t2----- Teachers Managment System\n\n\t\t\t3----- Employees Managment System");
                try
                {

                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Student_Managment_System();
                            break;
                        case 2:
                            Teacher_Managment_System();
                            break;
                        default:
                            Console.WriteLine("Please enter properly");
                            admin();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine("Enter T to try again (any other key to exit): ");
                    var x = Console.ReadLine();
                    if (x.ToLower() == "t")
                    {
                        admin();
                    }
                    else
                    {
                        Console.WriteLine("The program is exiting");
                    }

                }
            }



            try
            {
                Console.WriteLine("\t\tPlease Enter The Adminstrator Passing code:");
                string password = Console.ReadLine();
                if (password == "0000")
                {
                    main();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tIncorrect Password,If you want to try again enter any key.\n\t\t If you want to exit enter Q");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "q")
                    {
                        Console.WriteLine("The program is exiting ");
                    }



                    else
                    {
                        admin();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                Console.WriteLine("Enter T to try again (any other key to exit): ");
                var x = Console.ReadLine();
                if (x.ToLower() == "t")
                {
                    admin();
                }
                else
                {
                    Console.WriteLine("The program is exiting");
                }
            }




        }
    }
}
