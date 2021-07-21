using System;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Xml.Linq;
using System.Xml.Serialization;
using RSS;

namespace InfopulseConsoleTest
{
    class Program
    {

        static void Main(string[] args)
        {
            var exit = false;
            var service = new RssService();
            while (!exit)
            {
                Console.WriteLine("1 - add feed \n 2 - remove feed \n 3 - download feed \n 4 - exit");
                var input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("input name of feed");
                        var addName = Console.ReadLine();
                        Console.WriteLine("input Url");
                        var url = Console.ReadLine();
                        service.AddFeed(new RssModel(){Name = addName, Url = url});
                        break;
                    case 2:
                    {
                        Console.WriteLine("input name of feed");
                        var removeName = Console.ReadLine();
                        service.RemoveFeed(removeName);
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("input names. Separate with \",\":");
                        var names = Console.ReadLine() ?? " ";
                        var namesArray = names.Split(",");
                        service.DownloadFeed(namesArray);
                        break;
                    }
                    case 4:
                    {
                        exit = true;
                        break;
                    }

                }
            }
        }
    }
}