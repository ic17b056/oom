using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task6.Json;
using Task6.Models;
using Task6.PullPush;
using Task6.Tasks;

namespace Task6
{
    class Program
    {

        public class AsyncAwaitDemo
        {
            public async Task DoStuff()
            {
                await Task.Run(() =>
                {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    LongRunningOperation();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                });
            }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            private static async Task<string> LongRunningOperation()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            {
                int counter;

                for (counter = 0; counter < 50000; counter++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(counter);
                }

                return "Counter = " + counter;
            }
        }

        static List<T> Filter<T>(List<T> xs, Func<T, Boolean> filter)
        {
            var result = new List<T>();
            foreach (var x in xs) {
                if (filter(x)) result.Add(x);
            }
            return result;
        }

        static void Main(string[] args)
        {
            var xs = new List<int>() { 1, 5, 2, 3, 4 };
            var ys = Filter<int>(xs, x => x % 2 == 0);

            List<Artist> artists = new List<Artist>();
            artists.Add(new Artist("Test"));
            artists.Add(new Artist("asdf"));
            artists.Add(new Artist("Falco"));
            artists.Add(new Artist("newArtist"));
            artists.Add(new Artist("Falcon"));
            artists.Add(new Artist("Falcone"));


            var artistsFiltered = artists.Where(o => o.Name.Contains("Falco"));

            foreach (Artist art in artistsFiltered)
            {
                Console.WriteLine(art.Name);
            }


            PullExample.Run();
            PushExample.Run();
            PushExampleWithSubject.Run();

            var oneNumberPerSecond = Observable.Interval(TimeSpan.FromSeconds(1));

            var lowNums = from n in oneNumberPerSecond
                          where n < 5
                          select n;

            Console.WriteLine("Numbers < 5:");

            lowNums.Subscribe(lowNum =>
            {
                Console.WriteLine(lowNum);
            });

            

            var t2 = new Thread(() =>
                {
                    int i = 1000;
                    while (i < 1010)
                    {
                        Console.WriteLine(i++);
                    }
                });
            t2.Start();


            TasksExample.Run();

            NewTaksExample.Run();

            var asyncawait = new AsyncAwaitDemo();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            asyncawait.DoStuff();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            int a = 0;
            while (a < 10)
            {
                Console.WriteLine("Do something AsyncAwait");
                a++;
            }

            oneNumberPerSecond = Observable.Interval(TimeSpan.FromSeconds(1));

            var stringsFromNumbers = from n in oneNumberPerSecond
                                     select new string('*', (int)n);

            Console.WriteLine("Strings from numbers:");

            stringsFromNumbers.Subscribe(num =>
            {
                Console.WriteLine(num);
            });
        }
    }
}
