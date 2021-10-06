using Meetings.Common.Helper;
using Meetings.DTO.DbModels;
using Meetings.Repositories.Interface.Unit;
using Meetings.Services.Implementation.GetServices;
using Meetings.Services.Interface;
using Meetings.Services.Interface.GetServices;
using System;

namespace Meetings.Services.Implementation
{
    internal class SchoolGradeService : ISchoolGradeService
    {
        #region Private Fields
        private readonly IRepositoryUnit _repo;
        private readonly IAllService _all;
        private readonly IByIdService _byId;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public SchoolGradeService(IRepositoryUnit repo)
        {
            _repo = repo;
            _all = new AllService(_repo);
            _byId = new ByIdService(_repo);
        }
        #endregion

        #region Properties

        #endregion

        #region Fields

        #endregion

        #region Methods
        public bool AddSchoolGrade(long school_id, long grade_id)
        {
            if (!_byId.AnySchool(school_id))
                throw new Exception(MessageHelper.NotFound("school"));

            if (!_byId.AnyGrade(grade_id))
                throw new Exception(MessageHelper.NotFound("grade"));

            var schoolGrade = new SchoolGrade()
            {
                School_Id = school_id,
                Grade_Id = grade_id
            };

            _repo.SchoolGrade.Create(schoolGrade);
            _repo.Save();

            return true;
        }

        public bool RemoveSchoolGrade(long id)
        {
            var schoolGrade = _byId.GetSchoolGrade(id);
            if (schoolGrade == null)
                throw new Exception(MessageHelper.NotFound("School Grade"));


            _repo.SchoolGrade.Delete(schoolGrade);
            _repo.Save(schoolGrade);

            return true;
        }
        #endregion
    }


}
