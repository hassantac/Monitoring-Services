using Meetings.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetings.Client.Interface
{
    public interface IGraphClient
    {
        Task<List<ExtendedEvent>> GetEventsAsync(string user_id, DateTime start, DateTime end, int max_events, string filter);

        public string GetUserId(string client_principal);
    }
}