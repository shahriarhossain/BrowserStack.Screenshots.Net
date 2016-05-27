using BrowserStack.Screenshot.Net.Helper;
using BrowserStack.Screenshot.Net.Interface;
using BrowserStackTest.Model;
using RestSharp;
using System.Collections.Generic;

namespace BrowserStack.Screenshot.Net.Services
{
    public class Screenshot : IScreenshot
    {
        public string UserName { get; set; }
        public string AccessKey { get; set; }

        const string baseUrl = "https://www.browserstack.com/screenshots";
        
        public Screenshot(string userName, string accessKey)
        {
            this.UserName = userName;
            this.AccessKey = accessKey;
        }

        public List<Browser> GetAvailableBrowser()
        {
            
            var request = new RestRequest();
            request.Resource = "/browsers.json";
            return BaseOperation.ExecuteGet<List<Browser>>(request, baseUrl, UserName, AccessKey);
        }

        public RootScreenshot GenerateScreenshot(RootBrowser browserList)
        {
            var request = new RestRequest();
            return BaseOperation.ExecutePost<RootScreenshot, RootBrowser>(request, baseUrl, browserList, UserName, AccessKey);
        }

        public RootScreenshot GetGeneratedScreenshot(string jobId)
        {
            var request = new RestRequest();
            request.Resource = string.Format("/{0}.json", jobId);
            return BaseOperation.ExecuteGet<RootScreenshot>(request, baseUrl, UserName, AccessKey);
        }
    }
}
