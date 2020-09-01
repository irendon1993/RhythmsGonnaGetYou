using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;





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
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsExplicit { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int BandId { get; set; }
        public Band Band { get; set; }

    }

    class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }

        public List<Album> Albums { get; set; }
    }
    class RhythmGonnaGetYouContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Band> Bands { get; set; }

        // BOILER PLATE
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=Rhythm");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RhythmGonnaGetYouContext();

            var bands = context.Bands;
            var albums = context.Albums.Include(album => album.Band);

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
                Console.WriteLine("Would you like to add an album for a band?: ADDALBUM");
                Console.WriteLine("Would you like let a band go?: FIRE");
                Console.WriteLine("Would you like to resign a band?: RESIGN");
                Console.WriteLine("Would you like to view a band's albums?: DISCOGRAPHY");
                Console.WriteLine("Would you like to see the timeline of Albums: ORDER");
                Console.WriteLine("Would you like to view all the bands signed?: ROSTER");
                Console.WriteLine("Would you like to view all unsigned bands?: UNSIGNED");
                Console.WriteLine("Would you like to exit the database?: QUIT");

                var choice = Console.ReadLine().ToUpper();
                if (choice == "ADDBAND")
                {
                    Console.WriteLine("What is the new band's name?");
                    var name = Console.ReadLine();
                    Console.WriteLine("What is the new band's country of origin?");
                    var countryOfOrigin = Console.ReadLine();
                    Console.WriteLine("How many members are in the new band?");
                    var numberOfMembers = int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the new band's website?");
                    var website = Console.ReadLine();
                    Console.WriteLine("What is the new band's style?");
                    var style = Console.ReadLine();
                    Console.WriteLine("Is the new band signed?");
                    var isSigned = Boolean.Parse(Console.ReadLine());
                    Console.WriteLine("What is the new band's contact name?");
                    var contactName = Console.ReadLine();
                    Console.WriteLine("What is the new band's contact phone number?");
                    var contactPhoneNumber = Console.ReadLine();

                    var newBand = new Band
                    {
                        Name = name,
                        CountryOfOrigin = countryOfOrigin,
                        NumberOfMembers = numberOfMembers,
                        Website = website,
                        Style = style,
                        IsSigned = isSigned,
                        ContactName = contactName,
                        ContactPhoneNumber = contactPhoneNumber
                    };

                    context.Bands.Add(newBand);
                    context.SaveChanges();
                }
                if (choice == "VIEW")
                {
                    foreach (var band in bands)
                    {
                        Console.WriteLine(band.Name);
                    }

                }
                if (choice == "ADDALBUM")
                {
                    Console.WriteLine("What is the new album's title?");
                    var title = Console.ReadLine();

                    Console.WriteLine("Is the new album explicit?");
                    var isExplict = Boolean.Parse(Console.ReadLine());

                    Console.WriteLine("When was the Album released? Example:Jan 01 2001");
                    var releaseDate = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("What is the band Id for the new album?");
                    var bandId = int.Parse(Console.ReadLine());

                    var newAlbum = new Album
                    {
                        Title = title,
                        IsExplicit = isExplict,
                        ReleaseDate = releaseDate,
                        BandId = bandId
                    };
                    context.Albums.Add(newAlbum);
                    context.SaveChanges();
                }
                if (choice == "FIRE")
                {
                    Console.WriteLine("What band would you like to let go?");
                    var fireBand = Console.ReadLine();

                    var existingBandToFire = context.Bands.FirstOrDefault(band => band.Name == fireBand);

                    if (existingBandToFire != null)
                    {
                        existingBandToFire.IsSigned = false;
                        context.SaveChanges();
                    }

                }
                if (choice == "RESIGN")
                {
                    Console.WriteLine("What band would you like to sign?");
                    var signBand = Console.ReadLine();

                    var existingBandToSign = context.Bands.FirstOrDefault(band => band.Name == signBand);

                    if (existingBandToSign != null)
                    {
                        existingBandToSign.IsSigned = true;
                        context.SaveChanges();
                    }
                }
                if (choice == "DISCOGRAPHY")
                {
                    Console.WriteLine("What is the band's Id discography would you like to see");
                    var discography = int.Parse(Console.ReadLine());
                    var albumsToView = albums.Where(album => album.Band.Id == discography);
                    foreach (var album in albumsToView)
                    {
                        Console.WriteLine(album.Title);
                    }
                }

                if (choice == "ORDER")
                {

                    var orderBy = albums.OrderBy(albums => albums.ReleaseDate);
                    foreach (var album in orderBy)
                    {
                        Console.WriteLine(album.Title);
                    }
                }

                if (choice == "ROSTER")
                {
                    foreach (var band in bands)
                    {
                        if (band.IsSigned == true)
                        {
                            Console.WriteLine($"{band.Name} is signed");
                        }
                        context.SaveChanges();
                    }
                }
                if (choice == "UNSIGNED")
                {
                    foreach (var band in bands)
                    {
                        if (band.IsSigned == false)
                        {
                            Console.WriteLine($"{band.Name} is not signed");
                        }
                        context.SaveChanges();
                    }
                }
                if (choice == "QUIT")
                {
                    hasQuitApplication = true;
                }








            }
        }
    }
}