using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Json;
using Task4.Model;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Artist artist = new Artist("CompositionArtist");
            var tracks = new ITrack[]
            {
                new Song("Song1", 2, "Artist1"),
                new Song("Song2", 2, "Artist2"),
                new Song("Song3", 2, "Artist3"),
                new Song("Song4", 3, "Artist4"),
                new Song("Song5", 4, "Artist5"),
                new Composition("Composition1", 2, artist, "newArtist1"),
                new Composition("Composition2", 3, artist, "newArtist2"),
                 new Composition("Composition3", 4, artist, "newArtist3"),
            };

            foreach (var x in tracks)
            {
                Console.WriteLine($"Title: {x.Title.ToString()} Artist:");
                foreach (var y in x.GetArtists())
                {
                    Console.WriteLine($"{y.Name.ToString()}");
                }
            }

            SerializationExample.Run(tracks);
            Console.ReadLine();
        }
    }
}
