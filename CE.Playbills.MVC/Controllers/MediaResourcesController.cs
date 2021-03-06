﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CE.Playbills.MVC.Models;
using System.Net.Http;
using System.Net;
using CE.ArchiveWebSites.Core.Helpers;

namespace CE.Playbills.MVC.Controllers
{
    public class MediaResourcesController : Controller
    {
        public async Task<IActionResult> SearchResults()
        {
            var mediaResources = await HttpClientHelper.GetFromLMARApi<List<MediaResource>>("https://localhost:44300/api/v1/archives/2/mediarecords");
            if (mediaResources == null)
            {
                return NotFound();
            }
            foreach (var mr in mediaResources)
            {
                mr.ImageLink = mr.Links.FirstOrDefault(l => l.Rel == "Thumbnail").Href;
            };
            //Need to update API instead
            //var playbillsMediaResources = mediaResources.Where(ai => ai.ArchiveId == 2);
            return View(mediaResources);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaResource = await HttpClientHelper.GetFromLMARApi<MediaResource>($"https://localhost:44300/api/v1/archives/2/mediarecords/{id}");

            if (mediaResource == null)
            {
                return NotFound();
            }

            mediaResource.ImageLink = mediaResource.Links.FirstOrDefault(l => l.Rel == "Thumbnail").Href;

            return View(mediaResource);
        }
    }
}