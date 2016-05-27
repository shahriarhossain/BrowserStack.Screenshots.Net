using BrowserStack.Screenshot.Net.Model;
using System.Collections.Generic;

namespace BrowserStack.Screenshot.Net.Interface
{
    // ===============================================================
    // AUTHOR      : Shahriar Hossain, Microsoft MVP
    // PURPOSE     : Perform REST call to BrowserStack Screenshot API
    // ===============================================================
    public interface IScreenshot
    {
        #region Property
        string UserName { get; set; }
        string AccessKey { get; set; }

        #endregion Property

        #region Method
        /// <summary>
        /// Get available browser
        /// </summary>
        List<Browser> GetAvailableBrowser();

        /// <summary>
        /// Generate screenshot
        /// <param name="browserList">List of browser for which you want to generate screenshot</param>
        /// </summary>
        RootScreenshot GenerateScreenshot(RootBrowser browserList);

        /// <summary>
        /// Get screenshot 
        /// <param name="jobId">Get generate screenshot by job id</param>
        /// </summary>
        RootScreenshot GetGeneratedScreenshot(string jobId);
        #endregion Method
    }
}
