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
    internal class GradeService : IGradeService
    {
        #region Private Fields
        private readonly IRepositoryUnit _repo;
        private readonly IAllService _all;
        private readonly IByIdService _byId;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public GradeService(IRepositoryUnit repo)
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
        public bool AddGrade(long grade_id, string name)
        {
            if (_all.GetGrades().Any(a => a.GradeName.Equals(name)))
                throw new Exception(MessageHelper.AlreadyExist("Grade"));

            var op = new Grade()
            {
                Grade_Id = grade_id,
                GradeName = name
            };

            _repo.Grade.Create(op);
            _repo.Save();

            return true;
        }

        public bool EditGrade(long id, long grade_id, string name)
        {
            var op = _byId.GetGrade(id);
            if (op == null)
                throw new Exception(MessageHelper.NotFound("Grade"));

            if (_all.GetGrades().Any(a => a.GradeName.Equals(name) && a.Id != id))
                throw new Exception(MessageHelper.AlreadyExist("Grade"));

            op.GradeName = name;
            op.Grade_Id = grade_id;
            op.UpdatedAt = DateTime.UtcNow;


            _repo.Grade.Update(op);
            _repo.Save(op);

            return true;
        }

        public bool RemoveGrade(long id)
        {
            var op = _byId.GetGrade(id);
            if (op == null)
                throw new Exception(MessageHelper.NotFound("Grade"));

            op.IsDeleted = true;
            op.UpdatedAt = DateTime.UtcNow;

            _repo.Grade.Update(op);
            _repo.Save(op);

            return true;

        }
        #endregion
    }

}
