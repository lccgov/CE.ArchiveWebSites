﻿using CE.ArchiveWebSites.Core.Areas.Commenting.Models;
using CE.ArchiveWebSites.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CE.ArchiveWebSites.Core.Areas.Commenting.ViewComponents
{
    [ViewComponent(Name = "Core.CommentsList")]
    public class CommentsListViewComponent : ViewComponent
    {
        private readonly ArchivesDbContext db;

        public CommentsListViewComponent(ArchivesDbContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke(int mediaResourceId)
        {
            var items = GetItems(mediaResourceId);
            //View is in Views folder as Areas don't exist for View Components
            return View(items);
        }
        private IEnumerable<MediaResourceComment> GetItems(int mediaResourceId)
        {
            return db.MediaResourceComments.Where(x => x.MediaResourceId == mediaResourceId).ToList();
        }
    }
}
