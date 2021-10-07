using Meetings.API.ObjectConverters.Interface;
using Meetings.API.ObjectConverters.Interface.Unit;
using Meetings.Client.Interface.Unit;
using Meetings.Services.Interface.Unit;

namespace Meetings.API.ObjectConverters.Implementation.Unit
{
    public class ConverterUnit : IConverterUnit
    {

        #region Private Fields
        private IUserConverter _user;
        private IEventConverter _event;
        private readonly IServiceUnit _service;
        private readonly IClientUnit _client;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public ConverterUnit(IServiceUnit service, IClientUnit client)
        {
            _service = service;
            _client = client;
        }
        #endregion

        #region Properties

        #endregion

        #region Fields
        public IUserConverter User =>
            _user ??= new UserConverter(_service);

        public IEventConverter Event =>
            _event ??= new EventConverter(_service, _client);

        #endregion

        #region Methods

        #endregion

    }
}
