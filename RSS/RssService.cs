using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace RSS
{
    public class RssService
    {
        static object locker = new object();

        public RssService() {}

        public void AddFeed(RssModel model)
        {
            using var storage = IsolatedStorageFile.GetUserStoreForApplication();
            XDocument document;
            XElement tagRegistry = null;

            if (storage.FileExists("C:\\Infopulse\\RSS\\config.xml"))
            {
                using (var stream = storage.OpenFile("C:\\Infopulse\\RSS\\config.xml", FileMode.Open))
                {
                    document = XDocument.Load(stream);
                }

                tagRegistry = document.Descendants("ArrayOfRssModel").FirstOrDefault();
            }
            else
            {
                document = new XDocument();
            }

            if (tagRegistry == null)
            {
                tagRegistry = new XElement("ArrayOfRssModel");
                document.Add(tagRegistry);
            }

            XElement newTag =
                new XElement("RssModel", new XElement("Name", model.Name), new XElement("Url", model.Url));
            tagRegistry.Add(newTag);
            using (Stream stream = storage.OpenFile("C:\\Infopulse\\RSS\\config.xml", FileMode.OpenOrCreate))
            {
                document.Save(stream);
            }
        }

        public void RemoveFeed(string name)
        {
            using var storage = IsolatedStorageFile.GetUserStoreForApplication();
            XDocument document;
            using (var stream = storage.OpenFile("C:\\Infopulse\\RSS\\config.xml", FileMode.Open))
            {
                document = XDocument.Load(stream);
            }

            var deleteModels = document.Descendants("RssModel");
            foreach (var model in deleteModels.ToList())
            {
                var firstNode = ((XElement) model.FirstNode).FirstNode;
                if (firstNode != null && model.FirstNode != null && firstNode.ToString() == name)
                {
                    model.Remove();
                    using (var stream = storage.CreateFile("C:\\Infopulse\\RSS\\config.xml"))
                    {
                        document.Save(stream);
                    }
                }
            }
        }

        public void DownloadFeed(string[] names)
        {
            using var storage = IsolatedStorageFile.GetUserStoreForApplication();
            XDocument document;
            using (var stream = storage.OpenFile("C:\\Infopulse\\RSS\\config.xml", FileMode.Open))
            {
                document = XDocument.Load(stream);
            }

            var xElements = document.Descendants("RssModel").ToList();
            if (xElements.Count == 0)
            {
                Console.WriteLine("No feed is present in config file. Please add some");
                return;
            }
            foreach (var name in names)
            {
                bool notFound = true;
                foreach (var model in xElements)
                {
                    if (((XElement) model.FirstNode)?.FirstNode?.ToString() == name || name == " ")
                    {
                        var urlString = ((XElement) model.LastNode)?.FirstNode?.ToString();
                        var myThread = new Thread(new ParameterizedThreadStart(Load));
                        myThread.Start(urlString);
                        notFound = false;
                    }
                }
                if (notFound)
                {
                    Console.WriteLine($"Feed with name {name} was not found");
                }
            }
        }

        public void Load(object url)
        {
            byte[] data;
            using (WebClient webClient = new WebClient())
                data = webClient.DownloadData((string) url);
            string str = Encoding.Default.GetString(data);
            XDocument rssXmlDoc = XDocument.Parse(str);
            var rssNodes = rssXmlDoc.Descendants("item");
            ConsoleOutput(rssNodes);
        }

        public void ConsoleOutput(IEnumerable<XElement> rssNodes)
        {
            lock (locker)
            {
                foreach (var rssNode in rssNodes)
                {
                    var rssSubNode = rssNode.Descendants("title").FirstOrDefault();
                    string title = rssSubNode != null ? rssSubNode.Value : "";
                    Console.WriteLine(title);
                }
            }
        }
    }
}