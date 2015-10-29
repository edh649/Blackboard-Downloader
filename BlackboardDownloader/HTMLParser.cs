﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace BlackboardDownloader
{
    public static class HTMLParser
    {
        public static List<HtmlNode> GetAllLinks(string pageSource)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(pageSource);
            HtmlNodeCollection allLinks = doc.DocumentNode.SelectNodes("//a[@href]");
            return allLinks.ToList();
        }

        public static List<HtmlNode> GetModuleLinks(string pageSource)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(pageSource);
            HtmlNodeCollection allLinks = doc.DocumentNode.SelectNodes("//a[@href]");
            List<HtmlNode> moduleLinks = allLinks.Where(item => item.Attributes["href"].Value.Contains("type=Course")).ToList();
            return moduleLinks;
        }

        public static List<HtmlNode> GetContentLinks(string pageSource)
        {
            //List<HtmlNode> allLinks = GetAllLinks(pageSource);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(pageSource);

            HtmlNodeCollection contentLinks = doc.DocumentNode.SelectNodes("//li[contains(@id, 'contentListItem')]//a[@href]");
            //HtmlNodeCollection contentLinks = doc.DocumentNode.SelectNodes("//li//a[@href]");
            ////div[@class = 'myclass']//a
            //div[contains(@class, 'known-part')]
            return contentLinks.ToList();
        }

        public static HtmlNode GetMainContentLink(string pageSource)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(pageSource);
            HtmlNode contentLink = doc.DocumentNode.SelectSingleNode("//li[contains(@id, 'paletteItem')]//a[contains(@href,'listContent.jsp')]");
            return contentLink;
        }

        public static bool IsSubFolder(HtmlNode link)
        {
            if (link.Attributes["href"].Value.Contains("listContent.jsp")) { return true; }
            else { return false; }
        }
    }
}