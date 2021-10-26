using Meetings.API.Utils.KeysAndValues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UAParser;

namespace Meetings.API.Utils.Request
{
    internal static class RequestHelper
    {
        #region Methods

        public static RequestClientModel GetRequestClientModel(HttpContext context)
        {
            try
            {
                RequestClientModel model = new RequestClientModel
                {
                    // Header
                    ApiKey = GetApiTokenHeaderValue(context.Request),
                    Token = GetAuthorizationTokenHeaderValue(context.Request),
                    PortalKey = GetPortalHeaderValue(context.Request),
                    Nonce = GetNonceHeaderValue(context.Request),
                    Signature = GetSignatureHeaderValue(context.Request),
                    ContentHash = GetContentHashHeaderValue(context.Request)
                };

                var uaParser = Parser.GetDefault();
                ClientInfo clientInfo = uaParser.Parse(GetUserAgentHeaderValue(context.Request));

                // Browser info
                model.BrowserName = clientInfo.UA.Family;
                model.BrowserVersion = clientInfo.UA.Major + "." + clientInfo.UA.Minor + "." + clientInfo.UA.Patch;

                // Browser OS info
                model.BrowserPlatformName = clientInfo.OS.Family;
                model.BrowserPlatformVersion = clientInfo.OS.Major + "." + clientInfo.OS.Minor + "." + clientInfo.OS.Patch + "." + clientInfo.OS.PatchMinor;

                // Browser Device Info
                model.BrowserDeviceName = clientInfo.Device.Family;
                model.BrowserDeviceModel = clientInfo.Device.Model;
                model.BrowserDeviceBrand = clientInfo.Device.Brand;
                model.BrowserDeviceIsSpider = clientInfo.Device.IsSpider;

                // Http
                model.HttpVerb = context.Request.Method;
                model.Host = context.Request.Host.Host;
                model.Url = context.Request.GetDisplayUrl();

                using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    model.RequestBody = reader.ReadToEnd();
                }

                // Other
                model.IsMobileDevice = IsMobileDevice(context.Request);
                model.TraceIdentifier = context.TraceIdentifier;

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        //public static RequestClientModel RequestClientDetails(HttpContext context)
        //{
        //    try
        //    {
        //        RequestClientModel model = new RequestClientModel();

        //        var request = context.Request;

        //        // Http Verb
        //        string httpVerb = request.Method.ToString();
        //        model.HttpVerb = httpVerb;

        //        HttpHeaderValueCollection<ProductInfoHeaderValue> userAgentHeader = request.Headers.UserAgent;

        //        // Browser
        //        var userAgent = request.Headers["User-Agent"].ToString();

        //        var browser = new HttpBrowserCapabilities { Capabilities = new Hashtable { { string.Empty, request.Headers.UserAgent } } };
        //        var factory = new BrowserCapabilitiesFactory();
        //        factory.ConfigureBrowserCapabilities(new NameValueCollection(), browser);
        //        if (userAgent.Contains("PostmanRuntime"))
        //        {
        //            model.BrowserName = userAgent;
        //        }
        //        else
        //        {
        //            model.BrowserName = browser.Browser;
        //        }
        //        model.BrowserVersion = browser.Version;
        //        model.BrowserPlatform = browser.Platform;

        //        // Check Potal
        //        var portalHeader = request.Headers.ToList().FirstOrDefault(f => f.Key == ApiHeaders.PORTAL);
        //        if (!string.IsNullOrWhiteSpace(portalHeader.Key))
        //        {
        //            if (!string.IsNullOrWhiteSpace(portalHeader.Value.FirstOrDefault()))
        //            {
        //                string portalValue = portalHeader.Value.FirstOrDefault();

        //                if (portalValue.All(char.IsDigit))
        //                {
        //                    int portalId = int.Parse(portalValue);

        //                    var isPortalExist = Enum.IsDefined(typeof(PortalEnum), portalId);
        //                    if (isPortalExist)
        //                    {
        //                        model.PortalId = portalId;
        //                    }

        //                }
        //            }
        //        }

        //        // Host
        //        model.Host = request.HttpContext.Connection.RemoteIpAddress.ToString();

        //        // Ip
        //        model.Ip = GetClientIp(request);

        //        // Request Body
        //        model.RequestBody = request.Content.ReadAsStringAsync().Result;

        //        // Is Mobile Device
        //        model.IsMobileDevice = IsMobileDevice(request);

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        throw;
        //    }
        //}

        //public static RequestClientModel RequestClientDetails()
        //{
        //    try
        //    {
        //        RequestClientModel model = new RequestClientModel();

        //        var context = HttpContext.;

        //        // Http Verb
        //        string httpVerb = context.Request.HttpMethod;
        //        model.HttpVerb = httpVerb;

        //        // Browser
        //        var userAgent = context.Request.UserAgent.ToString();
        //        var browser = context.Request.Browser;
        //        if (userAgent.Contains("PostmanRuntime"))
        //        {
        //            model.BrowserName = userAgent;
        //        }
        //        else
        //        {
        //            model.BrowserName = browser.Browser;
        //            model.BrowserVersion = browser.Version;
        //            model.BrowserPlatform = browser.Platform;
        //        }

        //        // Portal Id
        //        model.PortalId = GetPortalValue();

        //        //Host
        //        model.Host = context.Request.Url.Host;

        //        // Ip
        //        model.Ip = GetIP();

        //        // Request Body

        //        try
        //        {
        //            if (context.Request.InputStream != null && context.Request.InputStream.Length > 0)
        //            {
        //                using (var stream = new StreamReader(context.Request.InputStream))
        //                {
        //                    string body = stream.ReadToEnd();
        //                    model.RequestBody = body;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex.Message);
        //        }

        //        // Token
        //        model.Token = GetAuthToken();

        //        // Url
        //        model.Url = context.Request.Url.AbsoluteUri;

        //        // EndPoint
        //        model.EndPoint = context.Request.Url.AbsolutePath;

        //        // Is Mobile Device
        //        model.IsMobileDevice = IsMobileDevice(userAgent);

        //        return model;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        throw;
        //    }
        //}

        //public static string GetClientIp(HttpRequestMessage request)
        //{
        //    if (request.Properties.ContainsKey("MS_HttpContext"))
        //    {
        //        return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
        //    }
        //    else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
        //    {
        //        RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
        //        return prop.Address;
        //    }
        //    else if (HttpContext.Current != null)
        //    {
        //        return HttpContext.Current.Request.UserHostAddress;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public static String GetIP()
        //{
        //    String ip =
        //        HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        //    if (string.IsNullOrEmpty(ip))
        //    {
        //        ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        //    }

        //    return ip;
        //}

        //public static bool IsMobileDevice(string request)
        //{
        //    string u = request;
        //    var b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        //    var v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        //    var returnVal = b.IsMatch(u) || v.IsMatch(u.Substring(0, 4));
        //    return returnVal;
        //}

        //public static long? GetPortalValue()
        //{
        //    var context = HttpContext.Current;

        //    long? id = null;

        //    var portalHeader = context.Request.Headers.AllKeys.Any(a => a == ApiHeaders.PORTAL);

        //    if (portalHeader)
        //    {
        //        var portalValues = context.Request.Headers.GetValues(ApiHeaders.PORTAL);

        //        if (portalValues.Any() && portalValues.FirstOrDefault().All(char.IsDigit))
        //        {
        //            var value = portalValues.First();
        //            int portalId = int.Parse(value);
        //            var isPortalExist = Enum.IsDefined(typeof(PortalEnum), portalId);

        //            if (isPortalExist)
        //            {
        //                id = portalId;
        //            }
        //        }
        //    }

        //    return id;
        //}

        //public static string GetAuthToken()
        //{
        //    string token = null;

        //    var context = HttpContext;

        //    var authHeader = context.Request.Headers.AllKeys.Any(a => a == ApiHeaders.AUTHORIZATION);
        //    if (authHeader)
        //    {
        //        var authValues = context.Request.Headers.GetValues(ApiHeaders.AUTHORIZATION);

        //        if (authValues.Any())
        //        {
        //            token = authValues.FirstOrDefault();
        //        }
        //    }

        //    return token;
        //}

        public static bool IsMobileDevice(HttpRequest request)
        {
            try
            {
                string u = GetUserAgentHeaderValue(request);

                if (string.IsNullOrWhiteSpace(u))
                {
                    throw new Exception("Not found user agent");
                }

                var b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                var v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                var returnVal = b.IsMatch(u) || v.IsMatch(u.Substring(0, 4));
                return returnVal;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        // Header Values

        public static string GetUserAgentHeaderValue(HttpRequest request)
        {
            try
            {
                if (request.Headers.Keys.Any(a => a == ApiHeaders.USER_AGENT))
                {
                    return request.Headers[ApiHeaders.USER_AGENT];
                }

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public static string GetAuthorizationTokenHeaderValue(HttpRequest request)
        {
            try
            {
                if (request.Headers.Keys.Any(a => a == ApiHeaders.AUTHORIZATION))
                {
                    return request.Headers[ApiHeaders.AUTHORIZATION];
                }

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public static string GetPortalHeaderValue(HttpRequest request)
        {
            try
            {
                if (request.Headers.Keys.Any(a => a.Equals(ApiHeaders.PORTAL, StringComparison.CurrentCultureIgnoreCase)))
                {
                    return request.Headers[ApiHeaders.PORTAL];
                }

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public static string GetApiTokenHeaderValue(HttpRequest request)
        {
            try
            {
                if (request.Headers.Keys.Any(a => a == ApiHeaders.TOKEN))
                {
                    return request.Headers[ApiHeaders.TOKEN];
                }

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public static string GetNonceHeaderValue(HttpRequest request)
        {
            try
            {
                if (request.Headers.Keys.Any(a => a == ApiHeaders.NONCE))
                {
                    return request.Headers[ApiHeaders.NONCE];
                }

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public static string GetContentHashHeaderValue(HttpRequest request)
        {
            try
            {
                if (request.Headers.Keys.Any(a => a == ApiHeaders.CONTENT_HASH))
                {
                    return request.Headers[ApiHeaders.CONTENT_HASH];
                }

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public static string GetSignatureHeaderValue(HttpRequest request)
        {
            try
            {
                if (request.Headers.Keys.Any(a => a == ApiHeaders.SIGNATURE))
                {
                    return request.Headers[ApiHeaders.SIGNATURE];
                }

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion Methods
    }
}