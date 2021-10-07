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
    [Route("v1/class_of_school")]
    public class ClassOfSchoolController : ControllerBase
    {
        #region Private Fields
        private readonly IClientUnit _client;
        #endregion


        #region Private Methods

        #endregion


        #region Constructors
        public ClassOfSchoolController(IClientUnit client)
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
        #endregion

        #region PUT

        #endregion

        #region DELETE

        #endregion

        #endregion

        #endregion

    }
}
