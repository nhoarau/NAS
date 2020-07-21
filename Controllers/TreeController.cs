using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using NAS.Models;
using NAS.Services;

namespace NAS.Controllers
{
    [Route("tree")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        // [HttpGet]
        // [Route("getTree")]
        // public FileRoad getTree()
        // {
        //     string root = @"C:\Repos\aa";
        //     var folder = new FileRoad(root);

        //     var cheminGlobal = GetDirectories(root, folder);
        //     return cheminGlobal;
        // }

        // public List<Models.File> GetFiles(string path)
        // {
        //     string[] subfiles = Directory.GetFiles(path);
        //     List<Models.File> listFiles = new List<Models.File>();
        //     foreach (string sub in subfiles)
        //     {
        //         if (sub.LastIndexOf('.') > 0)
        //         {
        //             string lastWord = sub.Split('\\').Last();
        //             var extention = sub.Substring(sub.LastIndexOf('.') + 1);
        //             listFiles.Add(new Models.File(lastWord, extention));
        //         }
        //     }
        //     return listFiles;
        // }

        // public FileRoad GetDirectories(string path, FileRoad road)
        // {
        //     string[] subdirectoryEntries = Directory.GetDirectories(path);
        //     road.Files = GetFiles(path);

        //     foreach (string subD in subdirectoryEntries)
        //     {
        //         string lastWord = subD.Split('\\').Last();
        //         var newDirectorie = new FileRoad(lastWord);
        //         road.Subfolder.Add(GetDirectories(subD, newDirectorie));

        //     }

        //     return road;
        // }

        [HttpGet]
        [Route("getTree")]
        public ActionResult getTree(string path)
        {
            if (!System.IO.Directory.Exists(path))
                return NotFound();

            var name = System.IO.Path.GetDirectoryName(path);
            var files = System.IO.Directory.GetFiles(path)
                .Select(f => new Models.File
                {
                    Name = System.IO.Path.GetFileName(f),
                    Url = f
                }).ToList();
            var subDirectories = System.IO.Directory.GetDirectories(path)
                .Select(d => new SubDirectory
                {
                    Name = System.IO.Path.GetFileName(d),
                    Url = d + "\\"
                })
                .ToList();

            var directory = new Models.Directory
            {
                Name = name,
                Files = files,
                SubDirectories = subDirectories
            };

            return Ok(directory);
        }

        [HttpGet]
        [Route("downloadFile")] 
        public async Task<IActionResult> getFile(string path, string fileName)
        {
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var ext = Path.GetExtension(path).ToLowerInvariant();

            return File(memory, GetType()[ext], Path.GetFileName(path));
        }

        [HttpPost]
        [Route("uploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        System.IO.Directory.GetCurrentDirectory(),
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(path);
        }

        private Dictionary<string, string> GetType()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain" },
                {".pdf", "application/pdf" },
                {".doc", "application/vnd.ms-word" },
                {".docx", "application/vnd.ms-word" },
                {".xls", "application/vnd.ms-excel" },
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                {".png", "image/png" },
                {".jpg", "image/jpeg" },
                {".jpeg", "image/jpeg" },
                {".gif", "image/gif" },
                {".csv", "text/csv" }
            };
        }

    }
}