using ClosedXML.Excel;
using Meetings.API.Models;
using Meetings.DTO.DbModels;

namespace Meetings.API.ObjectConverters.Interface
{
    public interface IEventConverter
    {
        CalenderEventResponse GetEventResponse(CalenderEvent userEvent);
        void SyncEvents();
        void GetExcelResponse(IXLWorksheet worksheet, int index, CalenderEvent userEvent);
    }
}
