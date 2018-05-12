using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Track track1 = new Track("FirstTrack", 2.5, "FirstArtist");
            Console.WriteLine("Constructor Values Title: " + track1.Title + " Duration: " + track1.Duration + " Artist: " + track1.Artist);
            track1.UpdateArtist("NewArtist");
            Console.WriteLine("After UpdateArtist Values Title: " + track1.Title + " Duration: " + track1.Duration + " Artist: " + track1.Artist);

        }
    }
}
