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
    [Route("v1/subject")]
    public class SubjectController : ControllerBase
    {
        #region Private Fields

        private readonly IClientUnit _client;

        #endregion Private Fields



        #region Constructors

        public SubjectController(IClientUnit client)
        {
            _client = client;
        }

        #endregion Constructors



        #region Methods

        #region End Points



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

        [HttpGet("class")]
        public ActionResult<ResponseWrapper<List<SubjectResponse>>> GetAll(string email, string address)
        {
            try
            {
                var res = new ResponseWrapper<List<SubjectResponse>>()
                {
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true,
                    Data = new List<SubjectResponse>()
                };

                return Ok(_client.Admin.GetClasses((email, address)));
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