using Meetings.API.Models;
using Meetings.API.ObjectConverters.Interface;
using Meetings.DTO.DbModels;
using Meetings.Services.Interface.Unit;

namespace Meetings.API.ObjectConverters.Implementation
{
    internal class ClassOfSchoolConverter : IClassOfSchoolConverter
    {
        #region Private Fields
        private readonly IServiceUnit _service;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public ClassOfSchoolConverter(IServiceUnit service)
        {
            _service = service;
        }
        #endregion

        #region Properties

        #endregion

        #region Fields

        #endregion

        #region Methods
        public ClassOfSchoolResponse GetClassOfSchoolResponse(ClassOfSchool classOfSchool)
        {
            var res = new ClassOfSchoolResponse()
            {
                Id = classOfSchool.Id,
                ClassName = classOfSchool.SecondaryName
            };
            var schoolGrade = _service.ById.GetSchoolGrade(classOfSchool.SchoolGrade_Id);
            if (schoolGrade != null)
            {
                var grade = _service.ById.GetGrade(schoolGrade.Grade_Id);
                if (grade != null)
                {
                    res.Grade_Id = grade.Id;
                    res.Grade = grade.GradeName;
                }

            }

            return res;
        }
        #endregion
    }
}
