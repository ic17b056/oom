using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task6.Models;

namespace Task6.Tasks
{
    public static class NewTaksExample
    {
        public static void Run()
        {
            var random = new Random();

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

            var tasks = new List<Task<ITrack>>();

            foreach (var track in tracks)
            {
                var task = Task.Run(() =>
                {
                    Console.WriteLine($"[T] computing result for {track.Title}");
                    Task.Delay(TimeSpan.FromSeconds(5.0 + random.Next(10))).Wait();
                    Console.WriteLine($"[T] done computing result for {track.Title}");
                    return track;
                });

                tasks.Add(task);
            }

            Console.WriteLine("doing something else ...");

            var tasks2 = new List<Task<ITrack>>();
            foreach (var task in tasks)
            {
                tasks2.Add(
                    task.ContinueWith(t => { Console.WriteLine($"[C] result is {t.Result.Duration}"); return t.Result; })
                );
            }

            Console.ReadLine();
        }
    }
}
