using BrowserStack.Screenshot.Net.Model;
using System.Collections.Generic;

namespace BrowserStack.Screenshot.Net.Interface
{
    public interface IScreenshot
    {
        #region Property
        string UserName { get; set; }
        string AccessKey { get; set; }

        #endregion Property

        #region Method
        List<Browser> GetAvailableBrowser();

        RootScreenshot GenerateScreenshot(RootBrowser browserList);

        RootScreenshot GetGeneratedScreenshot(string jobId);
        #endregion Method
    }
}
