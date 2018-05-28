using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Model
{
    class Artist
    {
        private String name;

        public Artist(String name)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null || value.Length == 0) throw new Exception("Artist must not be empty.");
                this.name = value;
            }
        }
    }

}
