using Meetings.API.Models;
using Meetings.DTO.DbModels;

namespace Meetings.API.ObjectConverters.Interface
{
    public interface IClassOfSchoolConverter
    {
        ClassOfSchoolResponse GetClassOfSchoolResponse(ClassOfSchool classOfSchool);
    }
}
