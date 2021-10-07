using Meetings.Client.Interface;
using Meetings.Client.Models;
using Meetings.Common.Helper;
using Meetings.Services.Interface.Unit;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetings.Client.Implementation
{
    internal class GraphClient : IGraphClient
    {
        #region Private Fields
        private GraphServiceClient graphClient;
       // private List<ClassesList> listOfClasses;
        private readonly IServiceUnit _service;
        #endregion

        #region Private Methods
        private GraphServiceClient CreateGraphHelper()
        {
            var clientId = AppSettingHelper.GetClientId();
            var tenantId = AppSettingHelper.GetTenant();
            var clientSecret = AppSettingHelper.GetClientSecret();

            var confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithTenantId(tenantId)
                .WithClientSecret(clientSecret)
                .Build();

            var authProvider = new ClientCredentialProvider(confidentialClientApplication);
            return new GraphServiceClient(authProvider);
        }
        private void DecomposeOrganizer(string name)
        {
            Class = Grade = School = string.Empty;
            if (!string.IsNullOrWhiteSpace(name))
            {
                var data = name.Split('@');
                if (data.Length >= 2)
                {
                    if (data[0].Length > 5)
                    {
                        var className = new AdminClient().GetClasses(data[0]);
                        //if (className == null)
                        //{
                        //    var classSmall = ;
                        //    if (classSmall != null)
                        //    {
                        //        listOfClasses.Add(new ClassesList()
                        //        {
                        //            ExtendedClass = classSmall.ClassName,
                        //            ExtendedGrade = classSmall.Grade,
                        //            ExtendedSchool = className.ExtendedSchool,
                        //            NickName = data[0]
                        //        });
                        //    }
                        //}
                        if (className != null)
                        {
                            School = className.School;
                            Grade = className.Grade;
                            Class = className.ClassName;
                        }
                    }
                }
            }
        }

        private void DecomposeSubject(string eSubject)
        {
            int strIndex, strSecondIndex;
            try
            {
                strIndex = eSubject.IndexOf('-');
                strSecondIndex = eSubject.IndexOf('-', strIndex + 1);
                Subject = eSubject.Substring(strIndex + 1, strSecondIndex - strIndex - 1);
            }
            catch (Exception)
            {
                Subject = "Others";
            }
        }

        private ExtendedEvent GetExtendedEvent(Event e)
        {
            var res = new ExtendedEvent
            {
                Subject = e.Subject,
                Organizer = e.Organizer,
                Start = e.Start,
                End = e.End,
                WebLink = e.WebLink,
                BodyContent = e.Body.Content,
                ExtendedClass = Class,
                ExtendedSubject = Subject,
                ExtendedSchool = School,
                ExtendedGrade = Grade,
                EventId = e.Id
            };

            return res;
        }

        private async Task Iterate(GraphServiceClient graphClient, IUserCalendarViewCollectionPage events, List<ExtendedEvent> allEvents)
        {
            // Create a page iterator to iterate over subsequent pages
            // of results. Build a list from the results
            var pageIterator = PageIterator<Event>.CreatePageIterator(
                graphClient, events,
                (e) =>
                {
                    DecomposeOrganizer(e.Organizer?.EmailAddress?.Address);
                    DecomposeSubject(e.Subject);
                    allEvents.Add(GetExtendedEvent(e));
                    return true;
                }
            );
            await pageIterator.IterateAsync();
        }
        #endregion

        #region Constructor
        public GraphClient(IServiceUnit service)
        {
            //listOfClasses = new List<ClassesList>();
            _service = service;
            School = Subject = Class = Grade = string.Empty;
            graphClient = CreateGraphHelper();
        }
        #endregion

        #region Properties
        public string School { get; set; }
        public string Subject { get; set; }
        public string Class { get; set; }
        public string Grade { get; set; }
        #endregion

        #region Fields

        #endregion

        #region Methods
        public async Task<List<ExtendedEvent>> GetEventsAsync(string user_id, DateTime start, DateTime end, int max_events, string filter)
        {
            var allEvents = new List<ExtendedEvent>();

            var viewOptions = new List<QueryOption>
                {
                    new QueryOption("startDateTime", start.ToString("o")),
                    new QueryOption("endDateTime", end.ToString("o"))
                };

            var events = await graphClient.Users[user_id].CalendarView.Request(viewOptions)
                   .Filter(filter)// filter by event filter
                   .Top(max_events)
                   .Select(e => new
                   {
                       e.Subject,
                       e.Organizer,
                       e.Start,
                       e.End,
                       e.WebLink,
                       e.Id,
                       e.IsAllDay,
                       e.IsCancelled,
                       e.Body
                   })// Only return fields app will use
                   .OrderBy("start/dateTime") // Order results chronologically
                   .GetAsync();

            if (events.NextPageRequest != null)
            {
                foreach (var e in events)
                {
                    DecomposeOrganizer(e.Organizer?.EmailAddress?.Address);
                    DecomposeSubject(e.Subject);
                    allEvents.Add(GetExtendedEvent(e));
                }
                await Iterate(graphClient, events, allEvents);
            }
            else
            {
                foreach (var e in events)
                {
                    DecomposeOrganizer(e.Organizer?.EmailAddress?.Address);
                    allEvents.Add(GetExtendedEvent(e));
                }
            }
            return allEvents;
        }



        public string GetUserId(string client_principal)
        {
            // get the user by using his principal name
            string userFilter = string.Format($"mail eq '{client_principal}'");

            var user = graphClient.Users
              .Request()
              .Filter(userFilter)
              .Select(e => new
              {
                  e.DisplayName,
                  e.Mail,
                  e.Id
              })
              .GetAsync().Result;


            return user.Count == 0 ? throw new Exception(MessageHelper.NotFound("User Id")) : user[0].Id;
        }
        #endregion
    }
}
