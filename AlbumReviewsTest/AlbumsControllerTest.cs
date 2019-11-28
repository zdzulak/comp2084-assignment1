using comp2084_assignment1.Controllers;
using comp2084_assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumReviewsTest
{
    [TestClass]
    public class AlbumsControllerTest
    {
        private zackalbumsContext _context;
        AlbumsController albumsController;
        List<Albums> albums = new List<Albums>();

        [TestInitialize] // runs this method before every test
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<zackalbumsContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _context = new zackalbumsContext(options);

           //creating mock data
           var artist = new Artists
           {
               ArtistId = 100,
               ArtistName = "System Of A Down"
           };

            albums.Add(new Albums
            {
                AlbumId = 10,
                AlbumArt = "",
                AlbumName = "System Of A Down",
                Artist = artist,
                ReleaseYear = 1998,
                Rating = 6
            });

            albums.Add(new Albums
            {
                AlbumId = 20,
                AlbumArt = "",
                AlbumName = "Toxicity",
                Artist = artist,
                ReleaseYear = 2001,
                Rating = 7
            });

            albums.Add(new Albums
            {
                AlbumId = 30,
                AlbumArt = "",
                AlbumName = "Steal This Album!",
                Artist = artist,
                ReleaseYear = 2002,
                Rating = 9
            });

            foreach (var a in albums)
            {
                _context.Add(a);
            }
            _context.SaveChanges();

            albumsController = new AlbumsController(_context);
        }

        [TestMethod]
        public void IndexViewLoads()
        {
            // act
            var result = albumsController.Index();

            var viewResult = (ViewResult)result.Result;
            // assert
            Assert.AreEqual("Index", viewResult.ViewName);
        }

        [TestMethod]
        public void IndexLoadsAlbums()
        {
            // act
            var result = albumsController.Index();
            var viewResult = (ViewResult)result.Result;
            List<Albums> model = (List<Albums>)viewResult.Model;

            // assert
            CollectionAssert.AreEqual(albums.OrderBy(a => a.AlbumName).ToList(), model);
        }

        [TestMethod]
        public void DetailsValidIdLoadsView()
        {
            // act
            var result = (ViewResult)albumsController.Details(10).Result;

            // assert
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIdLoadsAlbums()
        {
            // act
            var result = (ViewResult)albumsController.Details(30).Result;
            var model = (Albums)result.Model; 

            // assert
            Assert.AreEqual(albums[2], model);
        }
    }
}
