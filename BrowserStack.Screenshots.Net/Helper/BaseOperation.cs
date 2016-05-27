using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserStack.Screenshot.Net.Helper
{
    public static class BaseOperation
    {
        public static T ExecutePost<T, K>(RestRequest request, string endPoint, K obj, string userName = "default", string accessKey = "default") where T : class, new()
        {
            var restClient = new RestClient(endPoint)
            {
                Authenticator = new HttpBasicAuthenticator(userName, accessKey)
            };

            request.Method = Method.POST;
          
            request.AddHeader("Content-Type", "application/json");

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,

                Converters = new List<JsonConverter> 
                { 
                    new IsoDateTimeConverter()
                    {
                        DateTimeFormat= "yyyy-MM-dd HH:mm:ss"
                    }
                }
            };

            var myContentJson = JsonConvert.SerializeObject(obj, settings);

            request.AddParameter("application/json", myContentJson, ParameterType.RequestBody);

            var response = restClient.Execute<T>(request);

            //To make it async http://stackoverflow.com/questions/21779206/how-to-use-restsharp-with-async-await
            //var cancellationTokenSource = new CancellationTokenSource();
            //var response2 = restClient.ExecuteTaskAsync<T>(request, cancellationTokenSource.Token);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var browserStackException = new ApplicationException(message, response.ErrorException);
                throw browserStackException;
            }
            return response.Data;
        }

        public static T ExecuteGet<T>(RestRequest request, string endPoint, string userName = "default", string accessKey = "default") where T : class, new()
        {
            var restClient = new RestClient(endPoint)
            {
                Authenticator = new HttpBasicAuthenticator(userName, accessKey)
            };

            request.Method = Method.GET;

            request.AddHeader("Content-Type", "application/json");

            var response = restClient.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var browserStackException = new ApplicationException(message, response.ErrorException);
                throw browserStackException;
            }
            return response.Data;
        }
    }
}
