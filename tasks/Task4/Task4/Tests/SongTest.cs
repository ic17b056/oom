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
    class SongTest
    {
        [Test]
        public void CanCreateSong()
        {
            var x = new Song("Song1", 2, "Artist1");

            Assert.IsTrue(x.Title == "Song1");
            Assert.IsTrue(x.Duration == 2);
            foreach (Artist artist in x.GetArtists())
            {
                Assert.IsTrue(artist.Name == "Artist1");
            }
        }

        [Test]
        public void CannotCreateSongWithEmptyTitle1()
        {
            Assert.Catch(() =>
            {
                var x = new Song(null, 2, "Artist1");
            });
        }

        [Test]
        public void CannotCreateSongWithEmptyTitle2()
        {
            Assert.Catch(() =>
            {
                var x = new Song("", 2, "Artist1");
            });
        }

        [Test]
        public void CannotCreateSongWithNegaticeDuration()
        {
            Assert.Catch(() =>
            {
                var x = new Song("Song1", -2, "Artist1");
            });
        }

        [Test]
        public void CannotCreateSongWithEmptyArtist1()
        {
            Assert.Catch(() =>
            {
                var x = new Song("Song1", -2, null);
            });
        }

        [Test]
        public void CannotCreateSongWithEmptyArtist2()
        {
            Assert.Catch(() =>
            {
                var x = new Song("Song1", -2, "");
            });
        }

        [Test]
        public void CanAddArtist()
        {
            var x = new Song("Song1", 2, "Artist1");
            x.AddArtist("Artist2");

            Assert.IsTrue(x.Title == "Song1");
            Assert.IsTrue(x.Duration == 2);
            foreach (Artist artist in x.GetArtists())
            {
                Assert.IsTrue(artist.Name == "Artist1" || artist.Name == "Artist2");
            }
        }
    }
}
