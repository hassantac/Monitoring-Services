using Meetings.API.Models;
using Meetings.DTO.DbModels;

namespace Meetings.API.ObjectConverters.Interface
{
    public interface ISchoolConverter
    {
        SchoolResponse GetSchoolResponse(School school);
    }
}
