using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZXVentures.BackendChallenge.Application.PDVS;
using ZXVentures.BackendChallenge.Domain;
using ZXVentures.BackendChallenge.Domain.People;

namespace ZxVentures.BackendChallenge.Application.PDVS
{
    public class PDVService
    {
        private readonly IPDVRepository pdvRepository;

        public PDVService(IPDVRepository pdvRepository)
        {
            this.pdvRepository = pdvRepository;
        }

        public async Task<Guid> Create(NewPDV newPDV)
        {
            var owner = new NaturalPeople(newPDV.Owner);

            var company = new LegalPeople(newPDV.TradingName, newPDV.TradingName, newPDV.Document, owner);

            var pdv = new PDV(newPDV.Code, company, newPDV.CoverageArea, newPDV.Address);

            await pdvRepository.Add(pdv);

            return pdv.Id;
        }

        public async Task<PDV> Get(Guid id)
        {
            return await pdvRepository.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<PDV>> Search(double x, double y)
        {
            return await pdvRepository.Search(x, y);
        }
    }
}
