using Meetings.Common.Helper;
using Meetings.DTO.DbModels;
using Meetings.Repositories.Interface.Unit;
using Meetings.Services.Implementation.GetServices;
using Meetings.Services.Interface;
using Meetings.Services.Interface.GetServices;
using System;

namespace Meetings.Services.Implementation
{
    internal class ClassOfSchoolService : IClassOfSchoolService
    {
        #region Private Fields
        private readonly IRepositoryUnit _repo;
        private readonly IAllService _all;
        private readonly IByIdService _byId;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public ClassOfSchoolService(IRepositoryUnit repo)
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
        public ClassOfSchool AddClassOfSchool(string class_name, string class_full_name, string short_name, string teams, string nick, long school_grade_id)
        {
            if (!_byId.AnySchoolGrade(school_grade_id))
                throw new Exception(MessageHelper.NotFound("School Grade"));

            var classOfSchool = new ClassOfSchool()
            {
                SecondaryName = class_name,
                ClassName = class_full_name,
                TeamsObjectId = teams,
                MailNickName = nick,
                ShortName = short_name,
                SchoolGrade_Id = school_grade_id
            };

            _repo.ClassOfSchool.Create(classOfSchool);
            _repo.Save();

            return classOfSchool;
        }

        public bool RemoveClassOfSchool(long id)
        {
            var classOfSchool = _byId.GetClassOfSchool(id);
            if (classOfSchool == null)
                throw new Exception(MessageHelper.NotFound("class"));


            _repo.ClassOfSchool.Delete(classOfSchool);
            _repo.Save(classOfSchool);

            return true;
        }
        #endregion
    }

}
