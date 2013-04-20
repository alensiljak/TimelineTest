using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Event
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public string Text { get; set; }
    }
}