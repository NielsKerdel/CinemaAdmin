using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CinemaAdmin.Domain.Abstract;
using CinemaAdmin.Domain.Entities;
using CinemaAdmin.Administration.Controllers;

namespace CinemaAdmin.UnitTests
{
    [TestClass]
    public class AdminControllerTest
    {

        [TestMethod]
        public void Index_Contains_All_Movies()
        {
            // Arrange - create the mock repository
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns(new Movie[] {
                new Movie {
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
            });
            // Arrange - create a controller
            AdminController target = new AdminController(mock.Object);
            // Action
            Movie[] result = ((IEnumerable<Movie>)target.Index().ViewData.Model).ToArray();
            // Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("Deadpool", result[0].Name);
            Assert.AreEqual("The Divergent Series: Allegiant", result[1].Name);
            Assert.AreEqual("London Has Fallen", result[2].Name);
        }

        [TestMethod]
        public void Can_Edit_Movie()
        {
            // Arrange - create the mock repository
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns(new Movie[] {
            new Movie {
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
            });
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);

            // Act
            Movie p1 = target.Edit(1).ViewData.Model as Movie;
            Movie p2 = target.Edit(2).ViewData.Model as Movie;
            Movie p3 = target.Edit(3).ViewData.Model as Movie;
            // Assert
            Assert.AreEqual(1, p1.Id);
            Assert.AreEqual(2, p2.Id);
            Assert.AreEqual(3, p3.Id);
        }
        [TestMethod]
        public void Cannot_Edit_Nonexistent_Movie()
        {
            // Arrange - create the mock repository
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns(new Movie[] {
            new Movie {
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
            });
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);
            // Act
            Movie result = (Movie)target.Edit(4).ViewData.Model;
            // Assert
            Assert.IsNull(result);

        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Arrange - create mock repository
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);
            // Arrange - create a Movie
            Movie Movie = new Movie { Name = "Test" };
            // Act - try to save the Movie
            ActionResult result = target.Edit(Movie);
            // Assert - check that the repository was called
            mock.Verify(m => m.SaveMovie(Movie));
            // Assert - check the method result type
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Arrange - create mock repository
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);
            // Arrange - create a Movie
            Movie Movie = new Movie { Name = "Test" };
            // Arrange - add an error to the model state
            target.ModelState.AddModelError("error", "error");
            // Act - try to save the Movie

            ActionResult result = target.Edit(Movie);
            // Assert - check that the repository was not called
            mock.Verify(m => m.SaveMovie(It.IsAny<Movie>()), Times.Never());
            // Assert - check the method result type
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }



        [TestMethod]
        public void Can_Delete_Valid_Movies()
        {
            // Arrange - create a Movie
            Movie prod = new Movie { Id = 2, Name = "Test" };
            // Arrange - create the mock repository
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns(new Movie[] {
            new Movie {Id = 1, Name = "P1"},
            prod,
            new Movie {Id = 3, Name = "P3"},
            });
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);
            // Act - delete the Movie
            target.Delete(prod.Id);
            // Assert - ensure that the repository delete method was
            // called with the correct Movie
            mock.Verify(m => m.DeleteMovie(prod.Id));

        }
    }

}
