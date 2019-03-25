using _1Talent.Admin.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1Talent.Admin.BLL.Interfaces
{
    public interface IDesignation
    {
        DesignationModel RemoveDesignation(DesignationModel designation);
    }
}
