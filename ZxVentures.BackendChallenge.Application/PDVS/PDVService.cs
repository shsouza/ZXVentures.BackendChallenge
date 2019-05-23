using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZXVentures.BackendChallenge.Domain;

namespace ZxVentures.BackendChallenge.Application.PDVS
{
    public class PDVService
    {

        private readonly IPDVRepository pdvRepository;

        public PDVService(IPDVRepository pdvRepository)
        {
            this.pdvRepository = pdvRepository;
        }

        public async Task<Guid> Create()
        {
            return Guid.Empty;
        }

        public async Task<PDV> Get(Guid id)
        {
            return await pdvRepository.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IList<PDV>> Search(double lat, double lng)
        {
            return null;
        }
    }
}
