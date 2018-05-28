using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4.Model;

namespace Task4.Tests
{
    [TestFixture]
    class CompositionTest
    {
        [Test]
        public void CanCreateComposition()
        {
            var artist = new Artist("Artist1");
            var x = new Composition("Compostion1", 2, artist, "Artist2");

            Assert.IsTrue(x.Title == "Compostion1");
            Assert.IsTrue(x.Duration == 2);
            Assert.IsTrue(x.Composer.Name == "Artist1");
            foreach (Artist artists in x.GetArtists())
            {
                Assert.IsTrue(artists.Name == "Artist2");
            }
        }

        [Test]
        public void CanCreateCompositionWithDurationZero()
        {
            var artist = new Artist("Artist1");
            var x = new Composition("Compostion1", 0, artist, "Artist2");

            Assert.IsTrue(x.Title == "Compostion1");
            Assert.IsTrue(x.Duration == 0);
            Assert.IsTrue(x.Composer.Name == "Artist1");
            foreach (Artist artists in x.GetArtists())
            {
                Assert.IsTrue(artists.Name == "Artist2");
            }
        }

    }
}
