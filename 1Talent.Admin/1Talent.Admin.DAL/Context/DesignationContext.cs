
using _1Talent.Admin.DTO;
using OneRPP.Restful.DAO;
using OneRPP.Restful.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1Talent.Admin.DAL.Context
{
    public class DesignationContext : DaoContext
    {
        public DesignationContext(IServiceProvider serviceProvider) : base(serviceProvider, "DefaultConnection")
        {
        }
        [QueryPath("Designation")]
        public virtual DaoRepository<DesignationModel> DaoRepository { get; set; }
    }
}
