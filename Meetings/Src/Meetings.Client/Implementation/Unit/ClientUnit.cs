using Meetings.Client.Interface;
using Meetings.Client.Interface.Unit;
using Meetings.Services.Interface.Unit;

namespace Meetings.Client.Implementation.Unit
{
    internal class ClientUnit : IClientUnit
    {
        #region Private Fields

        private IGraphClient _graph;
        private IAdminClient _admin;
        private readonly IServiceUnit _service;

        #endregion Private Fields



        #region Constructor

        public ClientUnit(IServiceUnit service)
        {
            _service = service;
        }

        #endregion Constructor

        #region Properties

        public IGraphClient Graph =>
            _graph ??= new GraphClient(_service);

        public IAdminClient Admin =>
            _admin ??= new AdminClient();

        #endregion Properties
    }
}