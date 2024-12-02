using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Genre
    {
        public GenreType Type { get; set; }

        public Genre(GenreType type)
        {
            Type = type;
        }
    }
}
