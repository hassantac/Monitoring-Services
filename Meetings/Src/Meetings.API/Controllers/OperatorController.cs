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
    [Route("v1/operator")]
    public class OperatorController : ControllerBase
    {
        #region Private Fields
        private readonly IServiceUnit _service;
        private readonly IConverterUnit _converter;
        #endregion


        #region Private Methods

        #endregion


        #region Constructors
        public OperatorController(IServiceUnit service, IConverterUnit converter)
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
        public ActionResult<ResponseWrapper<bool>> AddOperator(AddOperatorRequest model)
        {
            var token = _converter.User.GetAdminToken(HttpContext);
            var admin = _service.ById.GetUser(token.Id);

            try
            {
                var Operator = _service.Operator.AddOperator(model.Operator_Id, model.OperatorName);

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
        public ActionResult<PagedResponse<List<OperatorResponse>>> GetAll(int? pageSize, int? pageIndex)
        {
            try
            {
                var operators = _service.All.GetOperators();

                var total = 0;
                if (pageIndex.HasValue && pageSize.HasValue && pageSize.Value > 0)
                {
                    total = (int)Math.Ceiling(operators.Count() / (double)pageSize.Value);
                    operators = operators.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);
                }
                return Ok(new PagedResponse<List<OperatorResponse>>()
                {
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true,
                    TotalPages = total,
                    Data = operators.Select(s => new OperatorResponse()
                    {
                        Id = s.Id,
                        OperatorName = s.OperatorName,
                        Operator_Id = s.Operator_Id
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
        public ActionResult<ResponseWrapper<bool>> EditOperator(long id, AddOperatorRequest model)
        {
            try
            {
                return Ok(new ResponseWrapper<bool>()
                {
                    Message = MessageHelper.SuccessfullyUpdated,
                    Success = true,
                    Data = _service.Operator.EditOperator(id, model.Operator_Id, model.OperatorName)
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
        public ActionResult<ResponseWrapper<bool>> RemoveOperator(long id)
        {
            try
            {

                if (_service.All.GetSchools().Any(a => a.Operator_Id == id))
                    throw new Exception("School exist against this Operator, cannot delete");

                return Ok(new ResponseWrapper<bool>()
                {
                    Message = MessageHelper.SuccessfullyDeleted,
                    Success = true,
                    Data = _service.Operator.RemoveOperator(id)
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
