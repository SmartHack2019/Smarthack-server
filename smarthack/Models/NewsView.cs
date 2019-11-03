using System;

namespace smarthack.Models
{
    public class NewsView
    {
        public Guid Id { get; set; }
        public string Headline { get; set; }
        public string Link { get; set; }
        public DateTime Time { get; set; }
        public double Impact { get; set; }
    }
}
