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
    internal class OperatorService : IOperatorService
    {
        #region Private Fields
        private readonly IRepositoryUnit _repo;
        private readonly IAllService _all;
        private readonly IByIdService _byId;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public OperatorService(IRepositoryUnit repo)
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
        public bool AddOperator(long operator_id, string name)
        {
            if (_all.GetOperators().Any(a => a.OperatorName.Equals(name)))
                throw new Exception(MessageHelper.AlreadyExist("Operator"));

            var op = new Operator()
            {
                Operator_Id = operator_id,
                OperatorName = name
            };

            _repo.Operator.Create(op);
            _repo.Save();

            return true;
        }

        public bool EditOperator(long id, long operator_id, string name)
        {
            var op = _byId.GetOperator(id);
            if (op == null)
                throw new Exception(MessageHelper.NotFound("Operator"));

            if (_all.GetOperators().Any(a => a.OperatorName.Equals(name) && a.Id != id))
                throw new Exception(MessageHelper.AlreadyExist("Operator"));

            op.OperatorName = name;
            op.Operator_Id = operator_id;
            op.UpdatedAt = DateTime.UtcNow;


            _repo.Operator.Update(op);
            _repo.Save(op);

            return true;
        }

        public bool RemoveOperator(long id)
        {
            var op = _byId.GetOperator(id);
            if (op == null)
                throw new Exception(MessageHelper.NotFound("Operator"));

            op.IsDeleted = true;
            op.UpdatedAt = DateTime.UtcNow;

            _repo.Operator.Update(op);
            _repo.Save(op);

            return true;

        }
        #endregion
    }
}
