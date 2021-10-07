using Meetings.API.Attributes;
using Meetings.API.Models;
using Meetings.API.Models.Common;
using Meetings.Client.Interface.Unit;
using Meetings.Common.Enums;
using Meetings.Common.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Meetings.API.Controllers
{
    [ApiController]
    [CheckJwt(Allows = new AccountType[] { AccountType.Admin })]
    [Route("v1/grade")]
    public class GradeController : ControllerBase
    {
        #region Private Fields
        private readonly IClientUnit _client;
        #endregion


        #region Private Methods

        #endregion


        #region Constructors
        public GradeController(IClientUnit client)
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
        public ActionResult<ResponseWrapper<List<GradeResponse>>> GetAll(int? operator_id, string school)
        {
            try
            {
                int i = 1;
                var res = new ResponseWrapper<List<GradeResponse>>()
                {
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true,
                    Data = new List<GradeResponse>()
                };
                var response = _client.Admin.GetGrades(operator_id, school);
                foreach (var item in response)
                {
                    res.Data.Add(new GradeResponse()
                    {
                        GradeName = item,
                        Id = i++
                    });
                }
                return Ok(res);
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
