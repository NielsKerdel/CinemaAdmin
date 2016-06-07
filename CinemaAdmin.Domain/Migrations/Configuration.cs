namespace CinemaAdmin.Domain.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CinemaAdmin.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CinemaAdmin.Domain.Concrete.EFDbContext context)
        {
            var persons = new List<Person>
            {
                new Person
                {
                    ID = 1,
                    Name = "Niels Kerdel",
                    Age = 20
                },

                new Person
                {
                    ID = 2,
                    Name = "Bart Helleman",
                    Age = 19
                }
            };

            var accounts = new List<Account>
            {
                new Account
                {
                    ID = 1,
                    Username = "Niels",
                    Password = "Kerdel",
                    Type = "Manager",
                    PersonFK = 1
                },

                new Account
                {
                    ID = 2,
                    Username = "Bart",
                    Password = "Helleman",
                    Type = "Baliemedewerker",
                    PersonFK = 2
                }
            };

            var movies = new List<Movie> {
                new Movie
                {
                    Id = 1,
                    Name = "Deadpool",
                    Description = "Na een duister experiment genezen zijn verwondingen razendsnel en bedenkt hij het alter ego Deadpool. Gewapend met zijn nieuwe gave en een goed gevoel voor (zwarte) humor gaat Deadpool op zoek naar de man die zijn leven bijna verwoestte.",
                    Language = "Engels",
                    Subtitle = "Nederlands",
                    Writer = "Tim Miller",
                    Stars = "Ryan Rinolds, Morena Baccarin",
                    Website = "http://www.deadpoolcore.com",
                    IMDB = "http://www.imdb.com/title/tt1431045/?ref=fnaltt1/",
                    Trailer = "http://www.imdb.com/video/imdb/vi567457049/imdb/embed?autoplay=false&width=490",
                    ImageData = null,
                    Kijkwijzer = "DJH",
                    ThumbnailData = "deadpool_thumb.png",
                    Type = "3D",
                    Duration = 108
                },

                new Movie
                {
                    Id = 2,
                    Name = "The Divergent Series: Allegiant",
                    Description = "n The Divergent Series: Allegiant wagen Tris (Shailene Woodley) en Four (Theo James) zich in de wereld buiten het hek. Zij worden echter al snel in hechtenis genomen door een mysterieuze organisatie, die bekend staat als 'The Bureau of Genetic Welfare'. ",
                    Language = "Engles",
                    Subtitle = "Nederlands",
                    Writer = "Robert Schwentke",
                    Stars = "Shailene Woodley, Zoë Kravitz, Naomi Watts",
                    Website = "http://www.thedivergentseries.movie/#insurgent/",
                    IMDB = "http://www.imdb.com/title/tt3410834/?ref=nvsr4",
                    Trailer = "http://www.imdb.com/video/imdb/vi3709973785/imdb/embed?autoplay=false&width=490",
                    ImageData = null,
                    Kijkwijzer = "CH",
                    ThumbnailData = "the_divergent_series_alligant.png",
                    Type = "",
                    Duration = 114
                },

                new Movie
                {
                    Id = 3,
                    Name = "London Has Fallen",
                    Description = "Wanneer de Engelse premier onder verdachte omstandigheden dood wordt gevonden, gaan alle alarmbellen af. Zijn begrafenis blijkt de ideale plek om een aanslag te plegen en de wereld ligt plots in de handen van slechts drie personen: de president van de Verenigde Staten (Eckhart), zijn meest betrouwbare geheim agent (Butler) en een Engelse MI-6 agent (Charlotte Riley)… ",
                    Language = "Engels",
                    Subtitle = "Nederlands",
                    Writer = "Babak Najafi",
                    Stars = "Gerard Butler, Aaron Eckhart, Morgan Freeman",
                    Website = "http://www.londonhasfallen.com/",
                    IMDB = "http://www.imdb.com/title/tt3300542/?ref=nvsr1",
                    Trailer = "http://www.imdb.com/video/imdb/vi1266857241/imdb/embed?autoplay=false&width=480",
                    ImageData = null,
                    Kijkwijzer = "DJH",
                    ThumbnailData = "londen_has_fallen_thumb.png",
                    Type = "",
                    Duration = 125
                }
            };
            movies.ForEach(s => context.Movies.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            var locations = new List<Location> {
                new Location
                {
                    ID = 1,
                    Name = "Avans Breda",
                    City = "Breda",
                    Address = "Lovensdijksstraat 61",
                    ZipCode = "2839JF",
                    Phone = "0102930293",
                    Mail = "Breda@info.avans.nl",
                    Website = "avans.nl/Locations/Breda"
                },

                new Location
                {
                    ID = 2,
                    Name = "Avans Rotterdam",
                    City = "Rotterdam",
                    Address = "Schouwburgplein 54",
                    ZipCode = "4803HE",
                    Phone = "0109302930",
                    Mail = "Rotterdam@info.avans.nl",
                    Website = "avans.nl/Locations/Rotterdam"
                },

                new Location
                {
                    ID = 3,
                    Name = "Avans Tilburg",
                    City = "Tilburg",
                    Address = "VanGaalWeg 83",
                    ZipCode = "2930JB",
                    Phone = "0103920392",
                    Mail = "Tilburg@info.avans.nl",
                    Website = "avans.nl/Locations/Tilburg"
                }
            };
            locations.ForEach(s => context.Locations.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var halls = new List<Hall> {
                new Hall
                {
                    Id = 1,
                    LocationFK = 1,
                    Name = "Hall 1",
                    TotalSeats = 50,
                    WheelchairAccesibility = false,
                    TotalRows = 5
                },

                new Hall
                {
                    Id = 2,
                    LocationFK = 1,
                    Name = "Hall 2",
                    TotalSeats = 100,
                    WheelchairAccesibility = true,
                    TotalRows = 10
                },

                new Hall
                {
                    Id = 3,
                    LocationFK = 1,
                    Name = "Hall 3",
                    TotalSeats = 150,
                    WheelchairAccesibility = true,
                    TotalRows = 15
                }
            };
            halls.ForEach(s => context.Halls.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();


            var genres = new List<Genre> {
                new Genre
                {
                    ID = 1,
                    Name = "Actie"
                },

                new Genre
                {
                    ID = 2,
                    Name = "Avontuur"
                },

                new Genre
                {
                    ID = 3,
                    Name = "ScienceFiction"
                },

                new Genre
                {
                    ID = 4,
                    Name = "Romantisch"
                },

                new Genre
                {
                    ID = 5,
                    Name = "Thriller"
                }
            };
            genres.ForEach(s => context.Genres.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var schedules = new List<Schedule> {
                new Schedule
                {
                    Id = 1,
                    Date = DateTime.Today,
                    movieFK = 1,
                    hallFK = 1,
                    AvailableSeats = 50
                },

                new Schedule
                {
                    Id = 2,
                    Date = DateTime.Today,
                    movieFK = 2,
                    hallFK = 2,
                    AvailableSeats = 100
                },

                new Schedule
                {
                    Id = 3,
                    Date = DateTime.Today,
                    movieFK = 3,
                    hallFK = 3,
                    AvailableSeats = 150
                }
            };
            schedules.ForEach(s => context.Schedules.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();


            var rows = new List<Row> {
                new Row
                {
                    ID = 1,
                    HallFK = 1,
                    TotalSeats = 10
                },

                new Row
                {
                    ID = 2,
                    HallFK = 1,
                    TotalSeats = 10
                },

                new Row
                {
                    ID = 3,
                    HallFK = 1,
                    TotalSeats = 10
                }
            };
            rows.ForEach(s => context.Rows.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var seats = new List<Seat> {
                new Seat
                {
                    ID = 1,
                    RowFK = 1,
                    HallFK = 1
                },

                new Seat
                {
                    ID = 2,
                    RowFK = 1,
                    HallFK = 1
                },

                new Seat
                {
                    ID = 3,
                    RowFK = 1,
                    HallFK = 1
                }
            };
            seats.ForEach(s => context.Seats.AddOrUpdate(p => p.ID, s));
            context.SaveChanges(); ;


            var orders = new List<Order> {
                new Order
                {
                    ID = 1,
                    OrderCode = 12345,
                    ScheduleFK = 1,
                    TicketFK = 1,
                    Paid = true
                },

                new Order
                {
                    ID = 1,
                    OrderCode = 23456,
                    ScheduleFK = 1,
                    TicketFK = 2,
                    Paid = true
                },

                new Order
                {
                    ID = 1,
                    OrderCode = 98765,
                    ScheduleFK = 1,
                    TicketFK = 3,
                    Paid = false
                }
            };
            orders.ForEach(s => context.Orders.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var rates = new List<Rate> {
                new Rate
                {
                    Name = "Studentenkorting",
                    Discount = 150,
                    Description = "Korting voor studerenden",
                },

                new Rate
                {
                    Name = "65+ korting",
                    Discount = 150,
                    Description = "Korting voor ouderen boven de 65",
                },

                new Rate
                {
                    Name = "Kinderkorting",
                    Discount = 150,
                    Description = "Korting voor kinderen onder de 6 jaar",
                }
            };
            rates.ForEach(s => context.Rates.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var tickets = new List<Ticket> {
                new Ticket
                {
                    ID = 1,
                    MovieFK = 1,
                    HallFK = 1,
                    RowFK = 1,
                    SeatFK = 1,
                    RateFK = 1,
                    OrderCode = 12345,
                    ScheduleFK = 1
                },

                new Ticket
                {
                    ID = 2,
                    MovieFK = 1,
                    HallFK = 1,
                    RowFK = 1,
                    SeatFK = 2,
                    RateFK = 1,
                    OrderCode = 12345,
                    ScheduleFK = 1
                },

                new Ticket
                {
                    ID = 3,
                    MovieFK = 1,
                    HallFK = 1,
                    RowFK = 1,
                    SeatFK = 3,
                    RateFK = 1,
                    OrderCode = 12345,
                    ScheduleFK = 1
                }
            };
            tickets.ForEach(s => context.Tickets.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var chairs = new List<Chair> {
                new Chair
                {
                    ID = 1,
                    SeatFK = 1,
                    ScheduleFK = 1,
                    Reservation = 2
                },

                new Chair
                {
                    ID = 2,
                    SeatFK = 2,
                    ScheduleFK = 1,
                    Reservation = 2
                },

                new Chair
                {
                    ID = 3,
                    SeatFK = 3,
                    ScheduleFK = 1,
                    Reservation = 2
                }
            };
            chairs.ForEach(s => context.Chairs.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();
        }
    }
}
