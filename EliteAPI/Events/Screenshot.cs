using System;

namespace EliteAPI
{
    public class ScreenshotInfo
    {
        public DateTime timestamp { get; set; }
        public string Filename { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public string System { get; set; }
		public string Body { get; set; }
	}
}
