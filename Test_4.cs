using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring string variables and data input from user

            string u1FName, u1LName, u2FName, u2LName, user1, user2;
            Console.WriteLine("(User 1) First name: ");
            u1FName = Console.ReadLine();
            Console.WriteLine("(User 1) Last name: ");
            u1LName = Console.ReadLine();

            Console.WriteLine("\n(User 2) First name: ");
            u2FName = Console.ReadLine();
            Console.WriteLine("(User 2) Last name: ");
            u2LName = Console.ReadLine();

            // Displaying the full name

            Console.WriteLine("\nUser 1 name is: {0} {1}", u1FName, u1LName);
            Console.WriteLine("User 2 name is: {0} {1}", u2FName, u2LName);

            // Converting strings and displaying them

            u1LName = u1LName.ToUpper();
            u2LName = u2LName.ToUpper();

            u1FName = u1FName.ToLower();
            u1FName = u1FName.First().ToString().ToUpper() + u1FName.Substring(1);

            u2FName = u2FName.ToLower();
            u2FName = u2FName.First().ToString().ToUpper() + u2FName.Substring(1);

            Console.WriteLine("\nUser 1 name is: {0} {1}", u1FName, u1LName);
            Console.WriteLine("User 2 name is: {0} {1}", u2FName, u2LName);

            // Comparing last name of 2 users

            if (u1LName == u2LName) Console.WriteLine("\nUser 1 and User 2 last names are the same");
            else if (u1LName.CompareTo(u2LName) == -1) Console.WriteLine("\nLast name of User 1 precedes last name of User 2 alphabetically");
            else Console.WriteLine("\nLast name of User 1 follows last name of User 2 alphabetically");

            if (u1LName.Length > u2LName.Length) Console.WriteLine("\nUser 1 has a longer last name than User 2");
            else if (u1LName.Length < u2LName.Length) Console.WriteLine("\nUser 2 has a longer last name than User 1");
            else Console.WriteLine("\nThe length of both Users last names is the same");

            // Defining two new strings by concetration operator
            user1 = u1FName + " " + u1LName;
            user2 = u2FName + " " + u2LName;

            // Calculating length of new strings and displaying
            Console.WriteLine("\nLength of User1 string is: {0}", user1.Length);
            Console.WriteLine("Length of User2 string is: {0}", user2.Length);

            // Removing last two char of User1 and last four chars of User2
            user1 = user1.Remove(user1.Length - 2, 2);
            user2 = user2.Remove(user2.Length - 4, 4);
            Console.WriteLine("\nUser 1 name without 2 last letters: {0}", user1);
            Console.WriteLine("User 2 name without 4 last letters: {0}", user2);

            // Converting strings to array
            Console.WriteLine("\nStrings presented as an array of characters: ");
            char[] user1array = user1.ToCharArray();
            char[] user2array = user2.ToCharArray();

            // Displaying the array of chars
            foreach (char x in user1array) Console.Write(x + " ");
            Console.WriteLine();
            foreach (char x in user2array) Console.Write(x + " ");
            
            // Awaiting user input
            Console.Read();
        }
    }
}
