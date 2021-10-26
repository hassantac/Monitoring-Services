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
    [Route("v1/grade")]
    public class GradeController : ControllerBase
    {
        #region Private Fields

        private readonly IClientUnit _client;

        #endregion Private Fields



        #region Constructors

        public GradeController(IClientUnit client)
        {
            _client = client;
        }

        #endregion Constructors



        #region Methods

        #region End Points



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

                res.Data = res.Data.OrderBy(o => o.GradeName).ToList();
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

        #endregion GET

        #endregion End Points

        #endregion Methods
    }
}