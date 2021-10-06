using Meetings.Common.Enums;
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
    internal class SchoolService : ISchoolService
    {
        #region Private Fields
        private readonly IRepositoryUnit _repo;
        private readonly IAllService _all;
        private readonly IByIdService _byId;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public SchoolService(IRepositoryUnit repo)
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
        public School AddSchool(string name, string code, string address, string contact_us, string principal_name,
                              SchoolType school_type, string contact_number, string principal, string emirate,
                              string abbreviaton, long operator_Id)
        {
            if (!_byId.AnyOperator(operator_Id))
                throw new Exception(MessageHelper.NotFound("Operator"));

            if (_all.GetSchools().Any(a => a.Name.Equals(name)))
                throw new Exception(MessageHelper.AlreadyExist("School"));


            var school = new School()
            {
                Name = name,
                Code = code,
                Address = address,
                ContactUs = contact_us,
                PrincipalName = principal_name,
                SchoolType = school_type,
                ContactNumber = contact_number,
                Principal = principal,
                Emirate = emirate,
                Abbreviaton = abbreviaton,
                Operator_Id = operator_Id
            };

            _repo.School.Create(school);
            _repo.Save();

            return school;
        }

        public bool EditSchool(long id, string name, string code, string address, string contact_us,
                               string principal_name, SchoolType school_type, string contact_number, string principal,
                               string emirate, string abbreviaton, long operator_Id)
        {
            var school = _byId.GetSchool(id);
            if (school == null)
                throw new Exception(MessageHelper.NotFound("School"));

            if (_all.GetSchools().Any(a => a.Name.Equals(name) && a.Id != id))
                throw new Exception(MessageHelper.AlreadyExist("School"));

            if (!_byId.AnyOperator(operator_Id))
                throw new Exception(MessageHelper.NotFound("Operator"));

            school.Name = name;
            school.Code = code;
            school.Address = address;
            school.ContactUs = contact_us;
            school.PrincipalName = principal_name;
            school.SchoolType = school_type;
            school.ContactNumber = contact_number;
            school.Principal = principal;
            school.Emirate = emirate;
            school.Abbreviaton = abbreviaton;
            school.Operator_Id = operator_Id;

            _repo.School.Update(school);
            _repo.Save(school);

            return true;
        }

        public bool RemoveSchool(long id)
        {
            var school = _byId.GetSchool(id);
            if (school == null)
                throw new Exception(MessageHelper.NotFound("School"));

            school.IsDeleted = true;
            school.UpdatedAt = DateTime.UtcNow;

            _repo.School.Update(school);
            _repo.Save(school);

            return true;
        }
        #endregion
    }

}
