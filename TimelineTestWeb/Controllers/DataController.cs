using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class DataController : Controller
    {
        //
        // GET: /Data/

        public ActionResult Index()
        {
            Response.ContentType = "text/xml";

            var events = GetDummyEvents();
            var doc = CreateXDocumentFor(events);
            var model = getStringFromXDocument(doc);

            // return View(model);
            return Content(model, "text/xml");
        }

        private string getStringFromXDocument(XDocument doc)
        {
            var result = printSeparately(doc);
            // var result = approachOne(doc);

            return result;
        }

        private string approachTwo(XDocument doc)
        {
            var wr = new StringWriter();

            doc.Save(wr);

            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                ConformanceLevel = ConformanceLevel.Document,
                Indent = true
            };

            using (XmlWriter writer = XmlWriter.Create(wr, settings))
            {
                doc.Save(writer);
            }

            var result = wr.GetStringBuilder().ToString();

            return result;
        }

        private string approachOne(XDocument doc)
        {
            var stream = new MemoryStream();
            var writer = new XmlTextWriter(stream, new UTF8Encoding());

            doc.Save(writer);

            writer.Flush();
            stream.Position = 0;

            // read from stream.
            var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();

            reader.Close();
            writer.Close();

            return result;
        }

        private string printSeparately(XDocument doc)
        {
            return doc.Declaration.ToString() + Environment.NewLine + doc.ToString();
        }

        private XDocument CreateXDocumentFor(IEnumerable<Event> events)
        {
            // var eventNodes = new XElement()
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("data",
                    from e in events
                    select new XElement("event",
                        new XAttribute("title", e.Title),
                        new XAttribute("start", e.Start.ToString("MM\\/dd\\/yyyy hh:mm:ss tt")),
                        new XAttribute("end", e.End.ToString("MM\\/dd\\/yyyy hh:mm:ss tt")),
                        new XAttribute("isDuration", e.IsDuration.ToString()),
                        new XAttribute("color", e.Color),
                        new XAttribute("image", e.Image),
                        new XAttribute("link", e.Link),
                        new XText(e.Description)
                        )
                    )
                );

            return doc;
        }

        private IEnumerable<Event> GetDummyEvents()
        {
            var events = new List<Event>();

            for (var i = 0; i <= 10; i++)
            {
                events.Add(new Event
                    {
                        Start = DateTime.Now,
                        End = DateTime.Now.AddMinutes(15),
                        IsDuration = true,
                        Title = "Blah" + i,
                        Color = "Green",
                        Image = "/Content/images/test.png",
                        Link = "/test",
                        Description = "Blah blah blah."
                    });
            }

            return events;
        }
    }
}
