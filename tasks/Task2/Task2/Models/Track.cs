using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    class Track
    {
        private string title;
        private double duration;
        private string artist;

        public Track(string title, double duration, string artist)
        {
            Title = title;
            Duration = duration;
            UpdateArtist(artist);
        }

        public void UpdateArtist(string artist) => this.artist = artist;

        public double Duration {
            get
            {
                return this.duration;
            }
            set
            {
                // the keyword 'value' represents the value that is assigned
                if (value < 0) throw new Exception("Duration must not be negative.");
                this.duration = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                // the keyword 'value' represents the value that is assigned
                if (value == null && value.Length == 0) throw new Exception("Title must not be empty.");
                this.title = value;
            }
        }

        public string Artist
        {
            get
            {
                return this.artist;
            }
        }

    }

    
}
