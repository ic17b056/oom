using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Models;

namespace Task6.Tests
{
        [TestFixture]
        class CompositionTest
        {
            

            [Test]
            public void CanCreateComposition()
            {
                var artist = new Artist("Artist1");
            List<Artist> artistList = new List<Artist>();
            artistList.Add(artist);

                var x = new Composition("Compostion1", 2, artist, artistList);

                Assert.IsTrue(x.Title == "Compostion1");
                Assert.IsTrue(x.Duration == 2);
                Assert.IsTrue(x.Composer.Name == "Artist1");
                foreach (Artist artists in x.Artists)
                {
                    Assert.IsTrue(artists.Name == "Artist1");
                }
            }

            [Test]
            public void CanCreateCompositionWithDurationZero()
            {
            List<Artist> artistList = new List<Artist>();
            var artist = new Artist("Artist1");
            artistList.Add(artist);
            var x = new Composition("Compostion1", 0, artist, artistList);

                Assert.IsTrue(x.Title == "Compostion1");
                Assert.IsTrue(x.Duration == 0);
                Assert.IsTrue(x.Composer.Name == "Artist1");
                foreach (Artist artists in x.GetArtists())
                {
                    Assert.IsTrue(artists.Name == "Artist1");
                }
            }

        }
    
}
