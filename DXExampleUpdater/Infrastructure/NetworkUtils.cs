using System;
using System.Net;

namespace DXExampleUpdater
{
    public class NetworkUtils
    {
        public NetworkUtils()
        {
        }
        public static string GetRedirectUrl(string url)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.AllowAutoRedirect = true;
            var response = request.GetResponse();
            return response.ResponseUri.AbsoluteUri;
            //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            //webRequest.AllowAutoRedirect = false; 
            //webRequest.Timeout = 10000;
            //webRequest.Method = "HEAD";

            //HttpWebResponse webResponse;
            //using (webResponse = (HttpWebResponse)webRequest.GetResponse())
            //{
            //    if ((int)webResponse.StatusCode >= 300 && (int)webResponse.StatusCode <= 399)
            //    {
            //        string uriString = webResponse.Headers["Location"];
            //        webResponse.Close();
            //        if (uriString.IndexOf("://", System.StringComparison.Ordinal) == -1)
            //        {
            //            Uri u = new Uri(new Uri(url), uriString);
            //            uriString = u.ToString();
            //        }
            //        return uriString;
            //    }

            //}
            //return url;
        }

        
    }
}
