using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1Talent.Admin.BLL.Interfaces;
using _1Talent.Admin.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1Talent.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainsController : ControllerBase
    {
        private readonly IDomain _idomain;
        public DomainsController(IDomain idomain)
        {
            _idomain = idomain;
        }
        // GET: api/Domains
        [HttpGet]
        public IActionResult Get()
        {
            var domain = _idomain.ListofDomain();
            return Ok(domain);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromQuery]DomainModel domainModel)
        {
            domainModel.DomainId = id;
            var dm = _idomain.GetDomainFromId(domainModel);
            return Ok(dm);
        }
    }
}
