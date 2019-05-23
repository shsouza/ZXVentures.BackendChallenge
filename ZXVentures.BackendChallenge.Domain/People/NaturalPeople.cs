using System;

namespace ZXVentures.BackendChallenge.Domain.People
{
    public class NaturalPeople
    {
        public string Name { get; set; }

        protected NaturalPeople() { }

        public NaturalPeople(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome da pessoa é necessário.");

            Name = name;
        }
    }
}
