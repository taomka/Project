using System;

namespace Project
{
    public abstract class Person
    {
        public abstract string Name { get; set; }

        public override string ToString()
        {
            return $"Особа: {Name}";
        }
    }
}
