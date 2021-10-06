using Meetings.Common.Helper;
using Meetings.DTO.DbModels;
using Meetings.Repositories.Interface.Unit;
using Meetings.Services.Implementation.GetServices;
using Meetings.Services.Interface;
using Meetings.Services.Interface.GetServices;
using System;

namespace Meetings.Services.Implementation
{
    internal class SubjectClassService : ISubjectClassService
    {
        #region Private Fields
        private readonly IRepositoryUnit _repo;
        private readonly IAllService _all;
        private readonly IByIdService _byId;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public SubjectClassService(IRepositoryUnit repo)
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
        public bool AddSubjectClass(long subject_id, long class_id)
        {
            if (!_byId.AnySubject(subject_id))
                throw new Exception(MessageHelper.NotFound("subject"));

            if (!_byId.AnyClassOfSchool(class_id))
                throw new Exception(MessageHelper.NotFound("Class"));

            var subjectClass = new SubjectClass()
            {
                Subject_Id = subject_id,
                Class_Id = class_id
            };

            _repo.SubjectClass.Create(subjectClass);
            _repo.Save();

            return true;
        }

        public bool RemoveSubjectClass(long id)
        {
            var SubjectClass = _byId.GetSubjectClass(id);
            if (SubjectClass == null)
                throw new Exception(MessageHelper.NotFound("School Grade"));


            _repo.SubjectClass.Delete(SubjectClass);
            _repo.Save(SubjectClass);

            return true;
        }
        #endregion
    }


}
