using _1Talent.Admin.BLL.Interfaces;
using _1Talent.Admin.DAL.Context;
using _1Talent.Admin.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1Talent.Admin.BLL.Domain
{
    public class Domain:IDomain
    {
        private readonly DomainContext _domainContext;
        public Domain(DomainContext domainContext)
        {
            _domainContext = domainContext;
        }
        public List<DomainModel> ListofDomain()
        {
            return _domainContext.DaoRepository.SelectAll();
        }
        public DomainModel GetDomainFromId(DomainModel domainModel)
        {
            return _domainContext.DaoRepository.Select(domainModel);
        }
    }
}
