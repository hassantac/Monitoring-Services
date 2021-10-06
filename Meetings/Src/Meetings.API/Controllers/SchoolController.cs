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
using System.Threading.Tasks;

namespace Meetings.API.Controllers
{
    [ApiController]
    [CheckJwt(Allows = new AccountType[] { AccountType.Admin })]
    [Route("v1/school")]
    public class SchoolController : ControllerBase
    {
        #region Private Fields
        private readonly IServiceUnit _service;
        private readonly IConverterUnit _converter;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public SchoolController(IServiceUnit service, IConverterUnit converter)
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

        #region EndPoints

        #region POST
        [HttpPost("")]
        public ActionResult<ResponseWrapper<bool>> AddSchool(AddSchoolRequest model)
        {
            try
            {
                _service.BeginTransaction();
                var school = _service.School.AddSchool(model.Name, model.Code, model.Address, model.ContactUs, model.Principal,
                                           model.SchoolType, model.ContactNumber, model.Principal, model.Emirate,
                                           model.Abbreviaton, model.Operator_Id);

                foreach (var grade in model.Grades)
                {
                    _service.SchoolGrade.AddSchoolGrade(school.Id, grade);
                }
                _service.CommitTransaction();
                return Ok(new ResponseWrapper<bool>()
                {
                    Message = MessageHelper.SuccessfullyAdded,
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

        #region GET
        [HttpGet("")]
        public ActionResult<PagedResponse<List<SchoolResponse>>> GetAll(long? operator_id, int? pageSize, int? pageIndex)
        {
            try
            {
                var schools = _service.All.GetSchools();

                if (operator_id.HasValue)
                    schools = schools.Where(w => w.Operator_Id == operator_id.Value);

                var total = 0;
                if (pageIndex.HasValue && pageSize.HasValue && pageSize.Value > 0)
                {
                    total = (int)Math.Ceiling(schools.Count() / (double)pageSize.Value);
                    schools = schools.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);
                }
                var res = new PagedResponse<List<SchoolResponse>>()
                {
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true,
                    TotalPages = total,
                    Data = new List<SchoolResponse>()
                };
                foreach (var school in schools)
                {
                    res.Data.Add(_converter.School.GetSchoolResponse(school));
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
        [HttpPut("{id}")]
        public ActionResult<ResponseWrapper<bool>> EditSchool(long id, AddSchoolRequest model)
        {
            try
            {
                _service.BeginTransaction();
                var schoolGrades = _service.All.GetSchoolGrades().Where(w => w.School_Id == id).ToList();
                foreach (var schoolGrade in schoolGrades)
                {
                    _service.SchoolGrade.RemoveSchoolGrade(schoolGrade.Id);
                }


                _service.School.EditSchool(id, model.Name, model.Code, model.Address, model.ContactUs, model.Principal,
                                          model.SchoolType, model.ContactNumber, model.Principal, model.Emirate,
                                          model.Abbreviaton, model.Operator_Id);
                foreach (var grade in model.Grades)
                {
                    _service.SchoolGrade.AddSchoolGrade(id, grade);
                }
                _service.CommitTransaction();
                return Ok(new ResponseWrapper<bool>()
                {
                    Message = MessageHelper.SuccessfullyUpdated,
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

        #region DELETE
        [HttpDelete("{id}")]
        public ActionResult<ResponseWrapper<bool>> DeleteSchool(long id)
        {
            try
            {
                _service.BeginTransaction();

                var schoolGrades = _service.All.GetSchoolGrades().Where(w => w.School_Id == id).ToList();
                foreach (var schoolGrade in schoolGrades)
                {
                    _service.SchoolGrade.RemoveSchoolGrade(schoolGrade.Id);
                }


                _service.School.RemoveSchool(id);

                _service.CommitTransaction();
                return Ok(new ResponseWrapper<bool>()
                {
                    Message = MessageHelper.SuccessfullyUpdated,
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
