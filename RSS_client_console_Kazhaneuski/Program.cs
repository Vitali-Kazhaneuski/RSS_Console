using System;
using System.ServiceModel.Syndication;
using System.Linq;
using System.Xml;

namespace RSS_client_console_Kazhaneuski
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://tech.onliner.by/feed";

            XmlReader readXml = XmlReader.Create(url);

            SyndicationFeed feed = SyndicationFeed.Load(readXml);

            Console.WriteLine(feed.Title.Text);

            Console.WriteLine();
            
            foreach (SyndicationItem item in feed.Items)
            {
                string summary = item.Summary.Text;
                bool flag = true;
                string fixSummary = "";

                foreach (char itemSymbol in summary)
                {
                    if (itemSymbol != '<' && flag)
                    {
                        fixSummary = fixSummary + itemSymbol;
                    }
                    else
                    {
                        if (itemSymbol == '<')
                        {
                            flag = false;
                        }
                        else 
                        {
                            if (itemSymbol == '>')
                            {
                                flag = true;
                            }
                        }
                    }
                }
                Console.WriteLine("Название статьи: " + item.Title.Text);
                Console.WriteLine("Описание: " + fixSummary);
                Console.WriteLine("----------------");
            }

        }
    }
}
