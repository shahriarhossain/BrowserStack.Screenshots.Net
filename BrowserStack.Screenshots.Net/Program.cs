using BrowserStackTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserStack.Screenshot.Net
{
    class Program
    {
        const string userName = "--Your BrowserStack UserName goes here--";
        const string accessKey = "--Your BrowserStack  AccessKey goes here--";
        static void Main(string[] args)
        {
            //Authenticate
            Screenshot.Net.Services.Screenshot s = new Services.Screenshot(userName, accessKey);

            //Get Available Browser List
            var availableBrowserList = s.GetAvailableBrowser();

            //Generate Screenshot
            var browser1 = new Browser()
            {
                os = "Windows",
                os_version = "10",
                browser = "chrome",
                browser_version = "37.0"
            };

            var browser2 = new Browser()
            {
                os = "Windows",
                os_version = "10",
                browser = "chrome",
                browser_version = "38.0"
            };

            var rootob1 = new RootBrowser()
            {
                url = "google.com",
                callback_url = null,
                win_res = "1024x768",
                mac_res = "1920x1080",
                quality = "compressed",
                wait_time = 5,
                orientation = "portrait",
                browsers = new List<Browser>()
            };

            rootob1.browsers.Add(browser1);
            rootob1.browsers.Add(browser2);

            var screenshotGenerated = s.GenerateScreenshot(rootob1);
            string jobIdForGeneratedScreenshot = screenshotGenerated.job_id;

            //Get Generated Screenshot
            var getScreenshotResult = s.GetGeneratedScreenshot(jobIdForGeneratedScreenshot);
        }
    }
}



