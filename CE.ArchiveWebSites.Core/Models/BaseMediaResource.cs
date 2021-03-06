﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CE.ArchiveWebSites.Core.Models
{
    public class BaseMediaResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ResourceUrl { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public int ArchiveId { get; set; }
        public List<Link> Links { get; set; }
        public string ImageLink { get; set; }
    }
}
