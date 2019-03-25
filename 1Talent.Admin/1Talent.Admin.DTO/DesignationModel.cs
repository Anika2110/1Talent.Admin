using OneRPP.Restful.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1Talent.Admin.DTO
{
    public class DesignationModel
    {
        [Required]
        [IfExists("SelectDesigation")]
        public int DesignationId { get; set; }
        public string DesignationTitle { get; set; }
    }
}
