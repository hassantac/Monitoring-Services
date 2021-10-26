namespace Meetings.API.Utils.Request
{
    internal class RequestClientModel
    {
        #region Properties

        /// <summary>
        /// Index: 0
        /// Type: Client Request Model
        /// Description: Http
        /// </summary>
        public string HttpVerb { get; set; }

        /// <summary>
        /// Index: 1
        /// Type: Client Request Model
        /// Description: Browser
        /// </summary>
        public string BrowserName { get; set; }

        /// <summary>
        /// Index: 2
        /// Type: Client Request Model
        /// Description: Browser
        /// </summary>
        public string BrowserVersion { get; set; }

        /// <summary>
        /// Index: 3
        /// Type: Client Request Model
        /// Description: Browser
        /// </summary>
        public string BrowserPlatformName { get; set; }

        /// <summary>
        /// Index: 4
        /// Type: Client Request Model
        /// Description: Http
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Index: 5
        /// Type: Client Request Model
        /// Description: Http
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// Index: 6
        /// Type: Client Request Model
        /// Description: Http
        /// </summary>
        public string RequestBody { get; set; }

        /// <summary>
        /// Index: 7
        /// Type: Client Request Model
        /// Description: Header
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Index: 8
        /// Type: Client Request Model
        /// Description: Http
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Index: 9
        /// Type: Client Request Model
        /// Description: Http
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// Index: 10
        /// Type: Client Request Model
        /// Description:
        /// </summary>
        public bool? IsMobileDevice { get; set; }

        /// <summary>
        /// Index: 11
        /// Type: Client Request Model
        /// Description:
        /// </summary>
        public string BrowserPlatformVersion { get; set; }

        /// <summary>
        /// Index: 12
        /// Type: Client Request Model
        /// Description: Browser
        /// </summary>
        public string BrowserDeviceName { get; set; }

        /// <summary>
        /// Index: 13
        /// Type: Client Request Model
        /// Description: Browser
        /// </summary>
        public string BrowserDeviceModel { get; set; }

        /// <summary>
        /// Index: 14
        /// Type: Client Request Model
        /// Description: Browser
        /// </summary>
        public bool BrowserDeviceIsSpider { get; set; }

        /// <summary>
        /// Index: 15
        /// Type: Client Request Model
        /// Description: Browser
        /// </summary>
        public string BrowserDeviceBrand { get; set; }

        /// <summary>
        /// Index: 16
        /// Type: Client Request Model
        /// Description: Header
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Index: 17
        /// Type: Client Request Model
        /// Description: Header
        /// </summary>
        public string PortalKey { get; set; }

        /// <summary>
        /// Index: 18
        /// Type: Client Request Model
        /// Description: Header
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// Index: 19
        /// Type: Client Request Model
        /// Description: Header
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// Index: 20
        /// Type: Client Request Model
        /// Description: Header
        /// </summary>
        public string ContentHash { get; set; }

        /// <summary>
        /// Index: 21
        /// Type: Client Request Model
        /// Description: Http
        /// </summary>
        public string TraceIdentifier { get; set; }

        #endregion Properties
    }
}