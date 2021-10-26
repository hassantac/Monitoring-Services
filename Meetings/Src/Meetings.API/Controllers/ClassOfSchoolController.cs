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
    [Route("v1/class_of_school")]
    public class ClassOfSchoolController : ControllerBase
    {
        #region Private Fields

        private readonly IClientUnit _client;

        #endregion Private Fields



        #region Constructors

        public ClassOfSchoolController(IClientUnit client)
        {
            _client = client;
        }

        #endregion Constructors



        #region Methods

        #region End Points



        #region GET

        [HttpGet("")]
        public ActionResult<ResponseWrapper<List<ClassOfSchoolResponse>>> GetAll(int? opertor_id, string school, string grade)
        {
            try
            {
                var classOfSchools = _client.Admin.GetClasses(opertor_id, school, grade);

                var res = new ResponseWrapper<List<ClassOfSchoolResponse>>()
                {
                    Data = new List<ClassOfSchoolResponse>(),
                    Message = MessageHelper.SuccessfullyDeleted,
                    Success = true
                };

                foreach (var item in classOfSchools)
                {
                    res.Data.Add(new ClassOfSchoolResponse()
                    {
                        ClassName = item.ClassName,
                        Id = item.Id
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

        #endregion GET

        #endregion End Points

        #endregion Methods
    }
}