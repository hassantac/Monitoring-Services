using Meetings.API.Models;
using Meetings.API.ObjectConverters.Interface;
using Meetings.DTO.DbModels;
using Meetings.Services.Interface.Unit;

namespace Meetings.API.ObjectConverters.Implementation
{

    internal class SchoolConverter : ISchoolConverter
    {
        #region Private Fields
        private readonly IServiceUnit _service;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public SchoolConverter(IServiceUnit service)
        {
            _service = service;
        }
        #endregion

        #region Properties

        #endregion

        #region Fields

        #endregion

        #region Methods
        public SchoolResponse GetSchoolResponse(School school)
        {
            var res = new SchoolResponse()
            {
                Abbreviaton = school.Abbreviaton,
                Address = school.Address,
                Code = school.Code,
                ContactNumber = school.ContactNumber,
                ContactUs = school.ContactUs,
                Emirate = school.Emirate,
                Id = school.Id,
                Name = school.Name,
                Operator_Id = school.Operator_Id,
                Operator = _service.ById.GetOperator(school.Operator_Id)?.OperatorName,
                Principal = school.Principal,
                PrincipalName = school.PrincipalName,
                SchoolType = school.SchoolType
            };
            return res;
        }
        #endregion
    }
}
