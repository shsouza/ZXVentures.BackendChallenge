using MongoDB.Driver.GeoJsonObjectModel;
using System;
using ZXVentures.BackendChallenge.Domain.People;

namespace ZXVentures.BackendChallenge.Domain
{
    public class PDV
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public LegalPeople Company { get; set; }

        public GeoJsonMultiPolygon<GeoJson2DCoordinates> CoverageArea { get; set; }

        public GeoJsonPoint<GeoJson2DCoordinates> Address { get; set; }

        protected PDV() { }

        public PDV(string code, LegalPeople company, GeoJsonMultiPolygon<GeoJson2DCoordinates> coverageArea, GeoJsonPoint<GeoJson2DCoordinates> address)
        {
            if (company == null)
                throw new ArgumentException("A empresa é necessária.");

            if (coverageArea == null)
                throw new ArgumentException("A área de cobertura é necessária");

            if (address == null)
                throw new ArgumentException("O endereço é necessário.");

            Code = code;
            Id = Guid.NewGuid();
            Company = company;
            CoverageArea = coverageArea;
            Address = address;
        }

    }
}
