using Meetings.API.Attributes;
using Meetings.API.Models;
using Meetings.API.Models.Common;
using Meetings.API.ObjectConverters.Interface.Unit;
using Meetings.Client.Interface.Unit;
using Meetings.Common.Enums;
using Meetings.Common.Helper;
using Meetings.Services.Interface.Unit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace Meetings.API.Controllers
{
    [ApiController]
    [CheckJwt(Allows = new AccountType[] { AccountType.Admin })]
    [Route("v1/school")]
    public class SchoolController : ControllerBase
    {
        #region Private Fields
        private readonly IClientUnit _client;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public SchoolController(IClientUnit client)
        {
            _client = client;
        }
        #endregion

        #region Properties

        #endregion

        #region Fields

        #endregion

        #region Methods

        #region EndPoints

        #region POST

        #endregion

        #region GET
        [HttpGet("")]
        public ActionResult<ResponseWrapper<List<SchoolResponse>>> GetAll(int? operator_id)
        {
            try
            {
                return Ok(new ResponseWrapper<List<SchoolResponse>>()
                {
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true,
                    Data = _client.Admin.GetSchools(operator_id).Select(s => new SchoolResponse()
                    {
                        Abbreviaton = s.Abbreviation,
                        Name = s.Name,
                        Id = s.Id
                    }).ToList()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseWrapper<object>
                {
                    Data = null,
                    Success = false,
                    Message = ex.Message
                });
            }
        }
        #endregion

        #region PUT
        #endregion

        #region DELETE

        #endregion

        #endregion

        #endregion
    }
}
