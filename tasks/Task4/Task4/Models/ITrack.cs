using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Model
{
    interface ITrack
    {
     
        string Title { get; }
        double Duration { get; }
        List<Artist> Artists { get; }

        List<Artist> GetArtists();
    }
}
