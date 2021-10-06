using Meetings.Client.Interface;
using Meetings.Client.Interface.Unit;
using Meetings.Services.Interface.Unit;

namespace Meetings.Client.Implementation.Unit
{
    internal class ClientUnit : IClientUnit
    {
        #region Private Fields
        private IGraphClient _graph;
        private readonly IServiceUnit _service;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public ClientUnit(IServiceUnit service)
        {
            _service = service;
        }
        #endregion

        #region Properties
        public IGraphClient Graph =>
            _graph ??= new GraphClient(_service);
        #endregion

        #region Fields

        #endregion

        #region Methods

        #endregion
    }
}
