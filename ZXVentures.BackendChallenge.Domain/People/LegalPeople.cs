using System;

namespace ZXVentures.BackendChallenge.Domain.People
{
    public class LegalPeople
    {
        public string TradingName { get; set; }

        public string Name { get; set; }
        
        public string Document { get; set; }

        public NaturalPeople Owner { get; set; }

        protected LegalPeople() { }

        public LegalPeople(string tradingName, string name, string document, NaturalPeople owner)
        {
            if (string.IsNullOrWhiteSpace(tradingName))
                throw new ArgumentException("O nome fantasia é necessário.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome é necessário.");

            if (string.IsNullOrWhiteSpace(document))
                throw new ArgumentException("O documento é necessário.");

            if (owner == null)
                throw new ArgumentException("O proprietário é necessário.");

            TradingName = tradingName;
            Name = name;
            Document = document;
            Owner = owner;
        }
    }
}
