using Meetings.API.Attributes;
using Meetings.API.Models;
using Meetings.API.Models.Common;
using Meetings.API.ObjectConverters.Interface.Unit;
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
        private readonly IServiceUnit _service;
        private readonly IConverterUnit _converter;
        #endregion


        #region Private Methods

        #endregion


        #region Constructors
        public SubjectController(IServiceUnit service, IConverterUnit converter)
        {
            _service = service;
            _converter = converter;
        }
        #endregion


        #region Properties

        #endregion


        #region Fields

        #endregion


        #region Methods

        #region End Points

        #region POST
        [HttpPost]
        [Route("")]
        public ActionResult<ResponseWrapper<bool>> AddSubject(AddSubjectRequest model)
        {
            var token = _converter.User.GetAdminToken(HttpContext);
            var admin = _service.ById.GetUser(token.Id);

            try
            {
                var Subject = _service.Subject.AddSubject(model.Subject_Id, model.SubjectName);

                var res = new ResponseWrapper<bool>()
                {
                    Message = MessageHelper.SuccessfullyAdded,
                    Success = true,
                    Data = true
                };


                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseWrapper<object> { Data = null, Success = false, Message = ex.Message });
            }
        }

        #endregion

        #region GET
        [HttpGet("")]
        public ActionResult<PagedResponse<List<SubjectResponse>>> GetAll(long? opertor_id, string school, string grade, string class_name, int? pageSize, int? pageIndex)
        {
            try
            {
                var subjects = _service.All.GetSubjects();

                if (opertor_id.HasValue)
                    subjects = subjects.Where(w => w.SubjectClasses.Any(a => a.ClassOfSchool.SchoolGrade.School.Operator_Id == opertor_id.Value));


                if (!string.IsNullOrWhiteSpace(school))
                    subjects = subjects.Where(w => w.SubjectClasses.Any(a => a.ClassOfSchool.SchoolGrade.School.Abbreviaton.Equals(school)));

                if (!string.IsNullOrWhiteSpace(grade))
                    subjects = subjects.Where(w => w.SubjectClasses.Any(a => a.ClassOfSchool.SchoolGrade.Grade.Equals(grade)));

                if (!string.IsNullOrWhiteSpace(class_name))
                    subjects = subjects.Where(w => w.SubjectClasses.Any(a => a.ClassOfSchool.SecondaryName.Equals(class_name)));

                var total = 0;
                if (pageIndex.HasValue && pageSize.HasValue && pageSize.Value > 0)
                {
                    total = (int)Math.Ceiling(subjects.Count() / (double)pageSize.Value);
                    subjects = subjects.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);
                }
                return Ok(new PagedResponse<List<SubjectResponse>>()
                {
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true,
                    TotalPages = total,
                    Data = subjects.Select(s => new SubjectResponse()
                    {
                        Id = s.Id,
                        SubjectName = s.SubjectName,
                        Subject_Id = s.Subject_Id
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

        [HttpPut]
        [Route("{id}")]
        public ActionResult<ResponseWrapper<bool>> EditSubject(long id, AddSubjectRequest model)
        {
            try
            {
                return Ok(new ResponseWrapper<bool>()
                {
                    Message = MessageHelper.SuccessfullyUpdated,
                    Success = true,
                    Data = _service.Subject.EditSubject(id, model.Subject_Id, model.SubjectName)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseWrapper<object> { Data = null, Success = false, Message = ex.Message });
            }
        }
        #endregion

        #region DELETE
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<ResponseWrapper<bool>> RemoveSubject(long id)
        {
            try
            {

                if (_service.All.GetSubjectClasses().Any(a => a.Subject_Id == id))
                    throw new Exception("Classes exist against this Subject, cannot delete");

                return Ok(new ResponseWrapper<bool>()
                {
                    Message = MessageHelper.SuccessfullyDeleted,
                    Success = true,
                    Data = _service.Subject.RemoveSubject(id)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseWrapper<object> { Data = null, Success = false, Message = ex.Message });
            }
        }
        #endregion

        #endregion

        #endregion

    }
}
