﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task6.Tasks
{
    public static class TasksExample
    {
        public static void Run()
        {
            var random = new Random();

            var xs = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var tasks = new List<Task<int>>();

            foreach (var x in xs)
            {
                var task = Task.Run(() =>
                {
                    Console.WriteLine($"[T] computing result for {x}");
                    Task.Delay(TimeSpan.FromSeconds(5.0 + random.Next(10))).Wait();
                    Console.WriteLine($"[T] done computing result for {x}");
                    return x * x;
                });

                tasks.Add(task);
            }

            Console.WriteLine("doing something else ...");

            var tasks2 = new List<Task<int>>();
            foreach (var task in tasks)
            {
                tasks2.Add(
                    task.ContinueWith(t => { Console.WriteLine($"[C] result is {t.Result}"); return t.Result; })
                );
            }

            var cts = new CancellationTokenSource();
            var primeTask = ComputePrimes(cts.Token);

            Console.ReadLine();
            cts.Cancel();
            Console.WriteLine("canceled ComputePrimes");

            Console.ReadLine();
        }

        public static Task<bool> IsPrime(int x, CancellationToken ct)
        {
            return Task.Run(() =>
            {
                for (var i = 2; i < x - 1; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    if (x % i == 0) return false;
                }
                return true;
            }, ct);
        }

        public static async Task ComputePrimes(CancellationToken ct)
        {
            for (var i = 100000000; i < 100001000; i++)
            {
                ct.ThrowIfCancellationRequested();
                if (await IsPrime(i, ct)) Console.WriteLine($"[P] prime number: {i}");
            }
        }
    }
}
