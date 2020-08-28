using System;

namespace RhythmsGonnaGetYou
{
    // PROBLEM
    // Create a menu system that shows the following options to the user until they choose to quit your program
    // 
    // EXAMPLE
    // 
    // DATA
    //  Album
    // 
    //     Id
    //     Title
    //     IsExplicit
    //     ReleaseDate
    // 
    // Band
    //     Id
    //     Name
    //     CountryOfOrigin
    //     NumberOfMembers
    //     Website
    //     Style
    //     IsSigned
    //     ContactName
    //     ContactPhoneNumber
    // 
    // 
    // 
    // 
    // ALGORITHM
    // Create a Menu
    // Add a new band
    // View all the bands
    // Add an album for a band
    // Let a band go (update isSigned to false)
    // Resign a band (update isSigned to true)
    // Prompt for a band name and view all their albums
    // View all albums ordered by ReleaseDate
    // View all bands that are signed
    // View all bands that are not signed
    // Quit the program
    class Program
    {
        static void Main(string[] args)
        {
            // Greet User
            Console.WriteLine("Hello, welcome to the Record Company Database");

            // Create quiting variable
            var hasQuitApplication = false;

            // Loop through Menu
            while (hasQuitApplication == false)
            {
                // Create a Menu prompting for Action
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Would you like to add a new band?: ADDBAND");
                Console.WriteLine("Would you like to view all the bands?: VIEW");
                Console.WriteLine("Would you like to add an album?: ADDALBUM");
                Console.WriteLine("Would you like let a band go?: FIRE");
                Console.WriteLine("Would you like to resign a band?: RESIGN");
                Console.WriteLine("Would you like to view a band's albums?: DISCOGRAPHY");
                Console.WriteLine("Would you like to view all the bands signed?: ROSTER");
                Console.WriteLine("Would you like to view all unsigned bands?: UNSIGNED");
                Console.WriteLine("Would you like to exit the database?: QUIT");

                var choice = Console.ReadLine().ToUpper();
                if (choice == "ADDBAND")
                {

                }
                if (choice == "VIEW")
                {

                }
                if (choice == "ADDALBUM")
                {

                }
                if (choice == "FIRE")
                {

                }
                if (choice == "RESIGN")
                {

                }
                if (choice == "DISCOGRAPHY")
                {

                }
                if (choice == "ROTtER")
                {

                }
                if (choice == "UNSIGNED")
                {

                }
                if (choice == "QUIT")
                {
                    hasQuitApplication = true;
                }

                if (choice == )
      }





        }
    }
}
