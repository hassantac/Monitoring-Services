using Meetings.Common.Helper;
using Meetings.DTO.DbModels;
using Meetings.Repositories.Interface.Unit;
using Meetings.Services.Implementation.GetServices;
using Meetings.Services.Interface;
using Meetings.Services.Interface.GetServices;
using System;
using System.Linq;

namespace Meetings.Services.Implementation
{
    internal class SubjectService : ISubjectService
    {
        #region Private Fields
        private readonly IRepositoryUnit _repo;
        private readonly IAllService _all;
        private readonly IByIdService _byId;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public SubjectService(IRepositoryUnit repo)
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
        public Subject AddSubject(long subject_id, string name)
        {
            if (_all.GetSubjects().Any(a => a.SubjectName.Equals(name)))
                throw new Exception(MessageHelper.AlreadyExist("Subject"));

            var op = new Subject()
            {
                Subject_Id = subject_id,
                SubjectName = name
            };

            _repo.Subject.Create(op);
            _repo.Save();

            return op;
        }

        public bool EditSubject(long id, long subject_id, string name)
        {
            var op = _byId.GetSubject(id);
            if (op == null)
                throw new Exception(MessageHelper.NotFound("Subject"));

            if (_all.GetSubjects().Any(a => a.SubjectName.Equals(name) && a.Id != id))
                throw new Exception(MessageHelper.AlreadyExist("Subject"));

            op.SubjectName = name;
            op.Subject_Id = subject_id;
            op.UpdatedAt = DateTime.UtcNow;


            _repo.Subject.Update(op);
            _repo.Save(op);

            return true;
        }

        public bool RemoveSubject(long id)
        {
            var op = _byId.GetSubject(id);
            if (op == null)
                throw new Exception(MessageHelper.NotFound("Subject"));

            op.IsDeleted = true;
            op.UpdatedAt = DateTime.UtcNow;

            _repo.Subject.Update(op);
            _repo.Save(op);

            return true;

        }
        #endregion
    }

}
