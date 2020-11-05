using System.Linq;
using HtmlAgilityPack;

namespace api
{
    public static class Tools
    {
        public static bool CheckNode(this HtmlDocument doc, string xpath)
        {
            var nodes = doc.DocumentNode.SelectNodes(xpath);
            return nodes != null;
        }

        public static string GetNode(this HtmlDocument doc, string xpath)
        {
            return doc.DocumentNode.SelectSingleNode(xpath).Attributes["content"].Value;
        }

        public static string GetTitle(this HtmlDocument doc)
        {
            if (doc.CheckNode("//meta[@name='title']")) return doc.GetNode("//meta[@name='title']");
            if (doc.CheckNode("//meta[@name='twitter:title']")) return doc.GetNode("//meta[@name='twitter:title']");
            return "";
        }

        public static string GetDescription(this HtmlDocument doc)
        {
            if (doc.CheckNode("//meta[@name='description']"))
                return doc.DocumentNode.SelectSingleNode("//meta[@name='description']").Attributes["content"].Value;
            if (doc.CheckNode("//meta[@name='twitter:description']"))
                return doc.DocumentNode.SelectSingleNode("//meta[@name='twitter:description']").Attributes["content"]
                    .Value;
            return "";
        }

        public static string GetThumbnailUrl(this HtmlDocument doc)
        {
            if (doc.CheckNode("//meta[@property='og:image']"))
                return doc.DocumentNode.SelectSingleNode("//meta[@property='og:image']").Attributes["content"].Value;
            return "";
        }
    }
}