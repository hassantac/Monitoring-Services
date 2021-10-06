using ClosedXML.Excel;
using Meetings.API.Attributes;
using Meetings.API.Models.Common;
using Meetings.API.ObjectConverters.Interface.Unit;
using Meetings.API.Utils;
using Meetings.API.Utils.Messages;
using Meetings.Common.Enums;
using Meetings.Common.Helper;
using Meetings.Services.Interface.Unit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace Meetings.API.Controllers
{
    [ApiController]
    [Route("v1/export")]
   
    public class ExportController : ControllerBase
    {
        #region Private Fields
        private readonly IServiceUnit _service;
        private readonly IConverterUnit _converter;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public ExportController(IConverterUnit converter, IServiceUnit service)
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

        #endregion

        #region GET

        [HttpGet("{name}/view")]
        public ActionResult<bool> ViewBannerImage(string name)
        {
            try
            {
                var basePath = AppSettingHelper.GetExcelFilePath();

                if (System.IO.File.Exists(basePath + name))
                {
                    var fileExtension = Path.GetExtension(basePath + name);

                    var openFile = System.IO.File.OpenRead(basePath + name);

                    return File(openFile, MimeTypeMap.GetMimeType(fileExtension));
                }
                else
                {
                    return NotFound(new ResponseWrapper<object>(false, MessageHelper.DataNotFound, ApiError.NotFound(), null));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseWrapper<object>
                {
                    Data = null,
                    Message = ex.Message,
                    Success = false
                });
            }
        }


        [HttpGet("")]
        [CheckJwt(Allows = new[] { AccountType.Admin })]
        public ActionResult<ResponseWrapper<string>> Export()
        {
            var token = _converter.User.GetAdminToken(HttpContext);
            var user = _service.ById.GetUser(token.Id);
            try
            {
                using var workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Events");
                worksheet.Cell(1, 1).Value = "Event Subject";
                worksheet.Cell(1, 2).Value = "Start";
                worksheet.Cell(1, 3).Value = "End";
                worksheet.Cell(1, 4).Value = "Event Id";
                worksheet.Cell(1, 5).Value = "Weblink";
                worksheet.Cell(1, 6).Value = "Subject";
                worksheet.Cell(1, 7).Value = "School";
                worksheet.Cell(1, 8).Value = "Class";
                int index = 2;

                var userEvents = _service.All.GetEvents().Where(w => w.UserEvents.Any(a => a.User_Id == token.Id));



                string fileName = Guid.NewGuid().ToString() + ".xlsx";
                var filePath = AppSettingHelper.GetExcelFilePath();

                foreach (var userEvent in userEvents)
                {
                    _converter.Event.GetExcelResponse(worksheet, index, userEvent);
                    index++;
                }

                var stream = System.IO.File.Create(filePath + fileName);
                workbook.SaveAs(stream);
                stream.Close();

                workbook.Dispose();

                return Ok(new ResponseWrapper<string>()
                {
                    Data = $"v1/export/{fileName}/view",
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseWrapper<object>
                {
                    Data = null,
                    Message = ex.Message,
                    Success = false
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
