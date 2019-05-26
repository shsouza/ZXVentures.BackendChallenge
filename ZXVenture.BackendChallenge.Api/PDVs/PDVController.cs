using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZxVentures.BackendChallenge.Application.PDVS;
using ZXVentures.BackendChallenge.Application.PDVS;
using ZXVentures.BackendChallenge.Domain;

namespace ZXVentures.BackendChallenge.Api.PDVs
{
    [Route("api/[controller]")]
    public class PDVController : Controller
    {
        private readonly PDVService pdvService;


        public PDVController(PDVService pdvService)
        {
            this.pdvService = pdvService;
        }

        [HttpGet]
        public async Task<PDV> Get(Guid id)
        {
            return await this.pdvService.Get(id);
        }

        [HttpPost]
        public async Task<Guid> Create([FromBody]NewPDV request)
        {
            return await pdvService.Create(request);
        }

        [HttpGet]
        [Route("search")]
        public async Task<List<PDV>> Search(double x, double y)
        {
            return await pdvService.Search(x, y);
        }
    }
}