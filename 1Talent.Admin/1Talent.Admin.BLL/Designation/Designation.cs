using _1Talent.Admin.BLL.Interfaces;
using _1Talent.Admin.DAL.Context;
using _1Talent.Admin.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1Talent.Admin.BLL.Designation
{
    public class Designation:IDesignation
    {
        private readonly DesignationContext _designationContext;
        public Designation(DesignationContext designationContext)
        {
            _designationContext = designationContext;
        }
        public DesignationModel RemoveDesignation(DesignationModel designation)
        {
            return _designationContext.DaoRepository.Delete(designation);
        }
    }
}
