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
    public class DesignationsController : ControllerBase
    {
        private readonly IDesignation _idesignation;
        public DesignationsController(IDesignation idesignation)
        {
            _idesignation = idesignation;
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<DesignationModel> Delete(int id, [FromQuery] DesignationModel designation)
        {
            designation.DesignationId = id;
            var desig = _idesignation.RemoveDesignation(designation);
            return Ok(desig);
        }
    }
}
