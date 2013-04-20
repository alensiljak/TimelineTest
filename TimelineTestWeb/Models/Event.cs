using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    /// <summary>
    /// See http://timeline.codeplex.com/wikipage?title=Use%20the%20Control%20from%20HTML&referringTitle=User%20Documentation
    /// </summary>
    public class Event
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsDuration { get; set; }
        public string Image { get; set; }
        public string TeaserImage { get; set; }
        public string Color { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}