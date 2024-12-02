using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Author
    {
        public string Name { get; set; }
        public string Biography { get; set; }

        public Author(string name, string biography)
        {
            Name = name;
            Biography = biography;
        }
    }
}
