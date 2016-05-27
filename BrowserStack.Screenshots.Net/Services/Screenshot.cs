using BrowserStack.Screenshot.Net.Helper;
using BrowserStack.Screenshot.Net.Interface;
using BrowserStack.Screenshot.Net.Model;
using RestSharp;
using System.Collections.Generic;

namespace BrowserStack.Screenshot.Net.Services
{
    // ===============================================================
    // AUTHOR      : Shahriar Hossain, Microsoft MVP
    // PURPOSE     : Perform REST call to BrowserStack Screenshot API
    // ===============================================================

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

        /// <summary>
        /// Get available browser
        /// </summary>
        public List<Browser> GetAvailableBrowser()
        {
            var request = new RestRequest();
            request.Resource = "/browsers.json";
            var x= BaseOperation.ExecuteGet<List<Browser>>(request, baseUrl, UserName, AccessKey);
            return x;
        }

        /// <summary>
        /// Generate screenshot
        /// <param name="browserList">List of browser for which you want to generate screenshot</param>
        /// </summary>
        public RootScreenshot GenerateScreenshot(RootBrowser browserList)
        {
            var request = new RestRequest();
            return BaseOperation.ExecutePost<RootScreenshot, RootBrowser>(request, baseUrl, browserList, UserName, AccessKey);
        }

        /// <summary>
        /// Get screenshot 
        /// <param name="jobId">Get generate screenshot by job id</param>
        /// </summary>
        public RootScreenshot GetGeneratedScreenshot(string jobId)
        {
            var request = new RestRequest();
            request.Resource = string.Format("/{0}.json", jobId);
            return BaseOperation.ExecuteGet<RootScreenshot>(request, baseUrl, UserName, AccessKey);
        }
    }
}
