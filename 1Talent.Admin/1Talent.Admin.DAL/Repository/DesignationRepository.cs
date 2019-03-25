using _1Talent.Admin.DTO;
using OneRPP.Restful.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1Talent.Admin.DAL.Repository
{
    public class DesignationRepository:DaoRepository<DesignationModel>
    {
        //public DesignationModel DeleteDesignation(int id, DTO.DesignationModel designation)
        //{
        //    var designations = new DesignationModel { DesignationId = id };
        //    return ExecuteQuery<DesignationModel>(designation, "DeleteDesignation");
        //}
    }
}
