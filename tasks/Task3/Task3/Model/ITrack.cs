using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Model
{
    interface ITrack
    {

        void AddArtist(String Artist);

        List<Artist> GetArtists();
    }
}
