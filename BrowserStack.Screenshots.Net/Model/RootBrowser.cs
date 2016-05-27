using System.Collections.Generic;

namespace BrowserStack.Screenshot.Net.Model
{
    public class RootBrowser
    {
        public string url { get; set; }
        public string callback_url { get; set; }
        public string win_res { get; set; }
        public string mac_res { get; set; }
        public string quality { get; set; }
        public int wait_time { get; set; }
        public string orientation { get; set; }
        public List<Browser> browsers { get; set; }
    }
}
