using BrowserStackTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
