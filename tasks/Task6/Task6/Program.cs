using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Json;
using Task6.Models;
using Task6.PullPush;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Artist artist = new Artist("CompositionArtist");
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
            */

            PullExample.Run();

            var oneNumberPerSecond = Observable.Interval(TimeSpan.FromSeconds(1));

            var lowNums = from n in oneNumberPerSecond
                          where n < 5
                          select n;

            Console.WriteLine("Numbers < 5:");

            lowNums.Subscribe(lowNum =>
            {
                Console.WriteLine(lowNum);
            });

            Console.ReadLine();

            oneNumberPerSecond = Observable.Interval(TimeSpan.FromSeconds(1));

            var stringsFromNumbers = from n in oneNumberPerSecond
                                     select new string('*', (int)n);

            Console.WriteLine("Strings from numbers:");

            stringsFromNumbers.Subscribe(num =>
            {
                Console.WriteLine(num);
            });

            Console.ReadLine();
        }
    }
}
