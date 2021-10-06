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
    [Route("v1/grade")]
    public class GradeController : ControllerBase
    {
        #region Private Fields
        private readonly IServiceUnit _service;
        private readonly IConverterUnit _converter;
        #endregion


        #region Private Methods

        #endregion


        #region Constructors
        public GradeController(IServiceUnit service, IConverterUnit converter)
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
        public ActionResult<ResponseWrapper<bool>> AddGrade(AddGradeRequest model)
        {
            try
            {
                var Grade = _service.Grade.AddGrade(model.Grade_Id, model.GradeName);

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
        public ActionResult<PagedResponse<List<GradeResponse>>> GetAll(long? operator_id, string school, int? pageSize, int? pageIndex)
        {
            try
            {
                var grades = _service.All.GetGrades();

                if (operator_id.HasValue)
                    grades = grades.Where(w => w.SchoolGrades.Any(a => a.School.Operator_Id == operator_id.Value));

                if (!string.IsNullOrWhiteSpace(school))
                    grades = grades.Where(w => w.SchoolGrades.Any(a => a.School.Abbreviaton.Equals(school)));

                var total = 0;
                if (pageIndex.HasValue && pageSize.HasValue && pageSize.Value > 0)
                {
                    total = (int)Math.Ceiling(grades.Count() / (double)pageSize.Value);
                    grades = grades.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);
                }
                return Ok(new PagedResponse<List<GradeResponse>>()
                {
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true,
                    TotalPages = total,
                    Data = grades.Select(s => new GradeResponse()
                    {
                        Id = s.Id,
                        GradeName = s.GradeName,
                        Grade_Id = s.Grade_Id
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
        public ActionResult<ResponseWrapper<bool>> EditGrade(long id, AddGradeRequest model)
        {
            try
            {
                return Ok(new ResponseWrapper<bool>()
                {
                    Message = MessageHelper.SuccessfullyUpdated,
                    Success = true,
                    Data = _service.Grade.EditGrade(id, model.Grade_Id, model.GradeName)
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
        public ActionResult<ResponseWrapper<bool>> RemoveGrade(long id)
        {
            try
            {

                if (_service.All.GetSchoolGrades().Any(a => a.Grade_Id == id))
                    throw new Exception("School exist against this Grade, cannot delete");

                return Ok(new ResponseWrapper<bool>()
                {
                    Message = MessageHelper.SuccessfullyDeleted,
                    Success = true,
                    Data = _service.Grade.RemoveGrade(id)
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
