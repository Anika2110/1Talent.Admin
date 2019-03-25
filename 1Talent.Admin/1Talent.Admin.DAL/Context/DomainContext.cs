
using _1Talent.Admin.DTO;
using OneRPP.Restful.DAO;
using OneRPP.Restful.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1Talent.Admin.DAL.Context
{
    public class DomainContext: DaoContext
    {
        public DomainContext(IServiceProvider serviceProvider) : base(serviceProvider, "DefaultConnection")
        {
        }
        [QueryPath("Domain")]
        public virtual DaoRepository<DomainModel> DaoRepository { get; set; }
    }
}
