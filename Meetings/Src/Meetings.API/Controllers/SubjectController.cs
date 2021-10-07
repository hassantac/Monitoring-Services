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
using System.Linq;

namespace Meetings.API.Controllers
{
    [ApiController]
    [CheckJwt(Allows = new AccountType[] { AccountType.Admin })]
    [Route("v1/subject")]
    public class SubjectController : ControllerBase
    {
        #region Private Fields
        private readonly IClientUnit _client;
        #endregion


        #region Private Methods

        #endregion


        #region Constructors
        public SubjectController(IClientUnit client)
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
        public ActionResult<ResponseWrapper<List<SubjectResponse>>> GetAll(int? opertor_id, string school, string grade, string class_name)
        {
            try
            {
                var res = new ResponseWrapper<List<SubjectResponse>>()
                {
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true,
                    Data = new List<SubjectResponse>()
                };
                var subjects = _client.Admin.GetSubjects(opertor_id, school, grade);
                foreach (var item in subjects)
                {
                    res.Data.Add(new SubjectResponse()
                    {
                        Id = item.SubjectId,
                        SubjectName = item.SubjectName
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
