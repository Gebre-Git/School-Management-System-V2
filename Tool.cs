using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace School_Managment_System
{
    class Tool
    {
        public static void WarningMessage(string message)
        {
            for (int i = 5; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t" + message + $" : wait for {i} seconds\n");
                Thread.Sleep(1000);
            }
        }
        public static void PrintArray(string[] args)
        {
            foreach (string i in args)
            {
                Console.WriteLine(i);
            }
        }
        public static void PrintArray(int[] args)
        {
            foreach (int i in args)
            {
                Console.WriteLine(i);
            }
        }
        public static void PasswordChake(string password, ref bool re_Enter)
        {
            string strong_password = @"^\S+$";
            string medium_password = @"^[a-zA-Z0-9]+$";
            string weak_password = @"^(\d+|[a-zA-Z]+)$";
            if (Regex.IsMatch(password, weak_password))
            {
                Console.WriteLine("\n\tYour password is weak! you can re-enter the password to make it strong.");
                Console.WriteLine("\tStrong Password: Should contain letters, numbers and symbole ");
                Console.Write("\tPress T or t to enter the password again: ");
                string tryAgain = Console.ReadLine().ToLower();
                if (tryAgain != "t")
                {
                    Console.WriteLine("\tYou can use this password to access your profile.");
                    re_Enter = false;
                }
            }
            else if (Regex.IsMatch(password, medium_password))
            {
                Console.WriteLine("\n\tYour password is medium! you can re-enter the password to make it strong.");
                Console.WriteLine("\tStrong Password: Should contain letters, numbers and symbole ");
                Console.WriteLine("\tPress T or t to enter the password again: ");
                string tryAgain = Console.ReadLine().ToLower();
                if (tryAgain != "t")
                {
                    Console.WriteLine("\tYou can use this password to access your profile.");
                    re_Enter = false;
                }
            }
            else if (Regex.IsMatch(password, strong_password))
            {
                Console.WriteLine("\tYour password is strong! use this password to access your profile.");
                re_Enter = false;
            }
            else
            {
                Console.WriteLine("\tThis password is not VALID! enter the password again: ");
            }
        }

    }
}
