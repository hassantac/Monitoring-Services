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
    [Route("v1/operator")]
    public class OperatorController : ControllerBase
    {
        #region Private Fields
        private readonly IClientUnit _client;
        #endregion


        #region Private Methods

        #endregion


        #region Constructors
        public OperatorController(IClientUnit client)
        {
            _client = client;
        }
        #endregion


        #region Properties

        #endregion


        #region Fields

        #endregion


        #region Methods

        #region End Points

        #region POST

        #endregion

        #region GET
        [HttpGet("")]
        public ActionResult<ResponseWrapper<List<OperatorResponse>>> GetAll()
        {
            try
            {
                var operators = _client.Admin.GetOperators();


                return Ok(new ResponseWrapper<List<OperatorResponse>>()
                {
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true,
                    Data = operators.Select(s => new OperatorResponse()
                    {
                        Id = s.Id,
                        OperatorName = s.Name
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
