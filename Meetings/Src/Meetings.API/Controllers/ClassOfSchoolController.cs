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
    [Route("v1/class_of_school")]
    public class ClassOfSchoolController : ControllerBase
    {
        #region Private Fields
        private readonly IServiceUnit _service;
        private readonly IConverterUnit _converter;
        #endregion


        #region Private Methods

        #endregion


        #region Constructors
        public ClassOfSchoolController(IServiceUnit service, IConverterUnit converter)
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
        //[HttpPost]
        //[Route("")]
        //public ActionResult<ResponseWrapper<bool>> AddClassOfSchool(AddClassOfSchoolRequest model)
        //{
        //    try
        //    {
        //        _service.BeginTransaction();

        //        var classOfSchool = _service.ClassOfSchool.AddClassOfSchool(model.ClassName, model.SchoolGrade_Id);
        //        foreach (var subject in model.Subjects)
        //        {
        //            _service.SubjectClass.AddSubjectClass(subject, classOfSchool.Id);
        //        }

        //        _service.CommitTransaction();
        //        return Ok(new ResponseWrapper<bool>()
        //        {
        //            Message = MessageHelper.SuccessfullyAdded,
        //            Success = true,
        //            Data = true
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        _service.RollBackTransaction();
        //        return BadRequest(new ResponseWrapper<object> { Data = null, Success = false, Message = ex.Message });
        //    }
        //}

        #endregion

        #region GET
        [HttpGet("")]
        public ActionResult<PagedResponse<List<ClassOfSchoolResponse>>> GetAll(long? opertor_id, string school, string grade, int? pageSize, int? pageIndex)
        {
            try
            {
                var classOfSchools = _service.All.GetClassesOfSchool();

                if (opertor_id.HasValue)
                    classOfSchools = classOfSchools.Where(w => w.SchoolGrade.School.Operator_Id == opertor_id.Value);

                if (!string.IsNullOrWhiteSpace(school))
                    classOfSchools = classOfSchools.Where(w => w.SchoolGrade.School.Abbreviaton.Equals(school));

                if (!string.IsNullOrWhiteSpace(grade))
                    classOfSchools = classOfSchools.Where(w => w.SchoolGrade.Grade.GradeName.Equals(grade));


                var total = 0;
                if (pageIndex.HasValue && pageSize.HasValue && pageSize.Value > 0)
                {
                    total = (int)Math.Ceiling(classOfSchools.Count() / (double)pageSize.Value);
                    classOfSchools = classOfSchools.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);
                }

                var res = new PagedResponse<List<ClassOfSchoolResponse>>()
                {
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true,
                    TotalPages = total,
                    Data = new List<ClassOfSchoolResponse>()
                };

                foreach (var cl in classOfSchools)
                {
                    res.Data.Add(_converter.ClassOfSchool.GetClassOfSchoolResponse(cl));
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
        //[HttpPut]
        //[Route("{id}")]
        //public ActionResult<ResponseWrapper<bool>> EditClassOfSchool(long id, AddClassOfSchoolRequest model)
        //{
        //    try
        //    {
        //        _service.BeginTransaction();

        //        var subjectClasses = _service.All.GetSubjectClasses().Where(a => a.Class_Id == id).ToList();
        //        foreach (var subjectClass in subjectClasses)
        //        {
        //            _service.SubjectClass.RemoveSubjectClass(subjectClass.Id);
        //        }


        //        var classOfSchool = _service.ClassOfSchool.AddClassOfSchool(model.ClassName, model.SchoolGrade_Id);
        //        foreach (var subject in model.Subjects)
        //        {
        //            _service.SubjectClass.AddSubjectClass(subject, classOfSchool.Id);
        //        }

        //        _service.CommitTransaction();
        //        return Ok(new ResponseWrapper<bool>()
        //        {
        //            Message = MessageHelper.SuccessfullyUpdated,
        //            Success = true,
        //            Data = true
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        _service.RollBackTransaction();
        //        return BadRequest(new ResponseWrapper<object> { Data = null, Success = false, Message = ex.Message });
        //    }
        //}
        #endregion

        #region DELETE
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<ResponseWrapper<bool>> RemoveClassOfSchool(long id)
        {
            try
            {
                _service.BeginTransaction();

                var subjectClasses = _service.All.GetSubjectClasses().Where(a => a.Class_Id == id).ToList();
                foreach (var subjectClass in subjectClasses)
                {
                    _service.SubjectClass.RemoveSubjectClass(subjectClass.Id);
                }
                _service.ClassOfSchool.RemoveClassOfSchool(id);


                _service.CommitTransaction();
                return Ok(new ResponseWrapper<bool>()
                {
                    Message = MessageHelper.SuccessfullyDeleted,
                    Success = true,
                    Data = true
                });
            }
            catch (Exception ex)
            {
                _service.RollBackTransaction();
                return BadRequest(new ResponseWrapper<object> { Data = null, Success = false, Message = ex.Message });
            }
        }
        #endregion

        #endregion

        #endregion

    }
}
