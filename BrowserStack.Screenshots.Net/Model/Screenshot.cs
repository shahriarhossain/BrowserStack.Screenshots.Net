namespace BrowserStack.Screenshot.Net.Model
{
    public class Screenshot
    {
        public string os { get; set; }
        public string os_version { get; set; }
        public string browser { get; set; }
        public string id { get; set; }
        public string state { get; set; }
        public string browser_version { get; set; }
        public string url { get; set; }
        public string device { get; set; }

   
        public string thumb_url { get; set; }
        public string image_url { get; set; }
        public string created_at { get; set; }
    }
}
