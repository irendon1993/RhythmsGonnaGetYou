using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;




namespace RhythmsGonnaGetYou
{
    // PROBLEM
    // Create a menu system that shows the following options to the user until they choose to quit your program
    // 
    // EXAMPLE
    // 
    // DATA

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

    class Album
    {
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public bool IsExplict { get; set; }

        // public date MyProperty { get; set; }

    }
    a
    class Band
    {
        public int BandId { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
    }
    class RhythmContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Band> Bands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=Rhythm");
        }
    }
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








            }
        }
    }
