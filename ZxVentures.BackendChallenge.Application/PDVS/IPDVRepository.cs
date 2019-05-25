using System.Collections.Generic;
using System.Threading.Tasks;
using ZxVentures.BackendChallenge.Application.Repository;
using ZXVentures.BackendChallenge.Domain;

namespace ZxVentures.BackendChallenge.Application.PDVS
{
    public interface IPDVRepository : IBaseRepository<PDV>
    {
        Task<List<PDV>> Search(double x, double y);
    }
}
