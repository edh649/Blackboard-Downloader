﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackboardDownloader
{
    public class BbContentItem
    {
        private string name;
        private Uri url;
        private string filename;
        private string linkType;

        public BbContentItem(string name, Uri url, string linkType="blackboard")
        {
            this.name = name;
            this.url = url;
            this.linkType = linkType;
            filename = BbUtils.CleanFileName(name).Truncate(20);
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Uri Url
        {
            get { return url; }
            set { url = value; }
        }

        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }

        public string LinkType
        {
            get { return linkType; }
            set { linkType = value; }
        }
    }
}
