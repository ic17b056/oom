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
            List<Artist> list = new List<Artist>();
            list.Add(new Artist("Artist1"));

            var tracks = new ITrack[]
            {
                new Song("Song1", 2, list),
                new Song("Song2", 2, list),
                new Song("Song3", 2, list),
                new Song("Song4", 3, list),
                new Song("Song5", 4, list),
                new Composition("Composition1", 2, artist, list),
                new Composition("Composition2", 3, artist, list),
                 new Composition("Composition3", 4, artist, list),
            };

            foreach (var x in tracks)
            {
                Console.WriteLine($"Title: {x.Title.ToString()} Artist:");
                foreach (var y in x.Artists)
                {
                    Console.WriteLine($"{y.Name.ToString()}");
                }
            }

            SerializationExample.Run(tracks);
            Console.ReadLine();
        }
    }
}
