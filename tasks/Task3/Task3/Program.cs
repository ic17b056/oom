using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Model;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Song song1 = new Song("Song1", 2, "Artist1");

            Song song2 = new Song("Song2", 2, "Artist2");

            Artist artist3 = new Artist("Artist3");

            Composition composition = new Composition("Composition1", 2, artist3, "artist4");

            song1.AddArtist("Artist5");
            song2.AddArtist("Artist6");
            composition.AddArtist("Artist7");

            Random random = new Random();
            ITrack iTrack = song1;
            switch (random.Next(1, 4))
            {
                case 1: iTrack = song1;
                    break;
                case 2: iTrack = song2;
                    break;
                case 3: iTrack = composition;
                    break;
            }

            foreach(Artist artist in iTrack.GetArtists())
            {
                Console.WriteLine(artist.Name);
            }

            Console.ReadLine();
        }
    }
}
