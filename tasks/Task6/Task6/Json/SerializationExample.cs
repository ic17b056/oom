using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Models;

namespace Task6.Json
{
    class SerializationExample
    {
        public static void Run(ITrack[] tracks)
        {
            var song = tracks[0];

            // 1. serialize a single song to a JSON string
            Console.WriteLine(JsonConvert.SerializeObject(song));

            // 2. ... with nicer formatting
            Console.WriteLine(JsonConvert.SerializeObject(song, Formatting.Indented));

            // 3. serialize all items
            // ... include type, so we can deserialize sub-classes to interface type
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(tracks, settings));

            // 4. store json string to file "items.json" on your Desktop
            var text = JsonConvert.SerializeObject(tracks, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "tracks.json");
            File.WriteAllText(filename, text);

            // 5. deserialize items from "items.json"
            // ... and print Description and Price of deserialized items
            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<ITrack[]>(textFromFile, settings);
            foreach (var x in itemsFromFile)
            {
                Console.WriteLine($"Title: {x.Title} Artist:");
                foreach (var y in x.GetArtists())
                {
                    Console.WriteLine($"{y.Name}");
                }
            }
        }
    }
}
