using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Meetings.Client
{
    public static class HttpCaller
    {
        public static readonly string HostName = "https://api.ebay.com/";
        public static string Token = "";

        public static string Post(string requestUrl, object param)
        {
            try
            {
                string rawJsonBody = JsonSerializer.Serialize(param);

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers["Authorization"] = "bearer:" + Token;

                // Write Request Body
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(rawJsonBody);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream() ?? throw new InvalidOperationException());
                string result = streamReader.ReadToEnd();

                return result;
            }
            catch (WebException webex)
            {
                using StreamReader stream = new StreamReader(webex.Response.GetResponseStream() ?? throw new InvalidOperationException());
                string err = stream.ReadToEnd();

                return err;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static string Get(string requestUrl)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "GET";
                httpWebRequest.Headers["Authorization"] = "bearer " + Token;

                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    string result = streamReader.ReadToEnd();
                    return result;
                }
            }
            catch (WebException webEx)
            {
                using (StreamReader stream = new StreamReader(webEx.Response.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    string err = stream.ReadToEnd();

                    throw new Exception(err);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static string Put(string requestUrl, object param)
        {
            try
            {
                var rawJsonBody = JsonSerializer.Serialize(param);

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "PUT";
                httpWebRequest.Headers["Authorization"] = "bearer:" + Token;

                // Write Request Body
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(rawJsonBody);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    string result = streamReader.ReadToEnd();

                    return result;
                }
            }
            catch (WebException webex)
            {
                using (StreamReader stream = new StreamReader(webex.Response.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    string err = stream.ReadToEnd();

                    return err;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static string Delete(string requestUrl)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "DELETE";
                httpWebRequest.Headers["Authorization"] = "bearer:" + Token;

                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    string result = streamReader.ReadToEnd();
                    return result;
                }
            }
            catch (WebException webEx)
            {
                using (StreamReader stream = new StreamReader(webEx.Response.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    string err = stream.ReadToEnd();

                    return err;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static string Get(string requestUrl, object param)
        {
            try
            {
                string rawJsonBody = JsonSerializer.Serialize(param);

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "GET";

                // Write Request Body
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(rawJsonBody);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    string result = streamReader.ReadToEnd();

                    return result;
                }
            }
            catch (WebException webex)
            {
                using (StreamReader stream = new StreamReader(webex.Response.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    string err = stream.ReadToEnd();

                    return err;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static string PostString(string requestUrl, string form)
        {
            var wc = new WebClient();

            wc.Headers["Content-type"] = "application/json";
            wc.Encoding = Encoding.UTF8;

            return wc.UploadString(requestUrl, form);
        }

        public static string GetRequest(string requestUrl)
        {
            WebClient wc = new WebClient();

            wc.Headers["Content-type"] = "application/x-www-form-urlencoded";
            wc.Encoding = Encoding.UTF8;

            return wc.DownloadString(requestUrl);
        }
    }
}