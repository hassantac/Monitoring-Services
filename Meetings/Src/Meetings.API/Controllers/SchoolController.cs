using Meetings.API.Attributes;
using Meetings.API.Models;
using Meetings.API.Models.Common;
using Meetings.Client.Interface.Unit;
using Meetings.Common.Enums;
using Meetings.Common.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meetings.API.Controllers
{
    [ApiController]
    [CheckJwt(Allows = new AccountType[] { AccountType.Admin })]
    [Route("v1/school")]
    public class SchoolController : ControllerBase
    {
        #region Private Fields

        private readonly IClientUnit _client;

        #endregion Private Fields



        #region Constructor

        public SchoolController(IClientUnit client)
        {
            _client = client;
        }

        #endregion Constructor



        #region Methods

        #region EndPoints



        #region GET

        [HttpGet("")]
        public ActionResult<ResponseWrapper<List<SchoolResponse>>> GetAll(int? operator_id)
        {
            try
            {
                var list = _client.Admin.GetSchools(operator_id).Select(s => new SchoolResponse()
                {
                    Abbreviaton = s.Abbreviation,
                    Name = s.Name,
                    Id = s.Id
                }).ToList();

                return Ok(new ResponseWrapper<List<SchoolResponse>>()
                {
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true,
                    Data = list.OrderBy(o => o.Name).ToList()
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

        #endregion GET

        #endregion EndPoints

        #endregion Methods
    }
}