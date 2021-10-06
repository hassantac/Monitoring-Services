using Meetings.Common.Enums;
using Meetings.DTO.DbModels;

namespace Meetings.Services.Interface
{
    public interface ISchoolService
    {
        School AddSchool(string name, string code, string address, string contact_us, string principal_name,
                       SchoolType school_type, string contact_number, string principal, string emirate, string abbreviaton,
                       long operator_Id);
        bool EditSchool(long id, string name, string code, string address, string contact_us, string principal_name,
                      SchoolType school_type, string contact_number, string principal, string emirate, string abbreviaton,
                      long operator_Id);
        bool RemoveSchool(long id);
    }
}
