using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NAS.Models;

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
        public bool getFile(string path, string fileName)
        {
            using (var client = new System.Net.WebClient())
            {
                Uri fileUri = new Uri(fileName);
                client.DownloadFile(fileUri, "fileNametest.txt");
            }
            return true;
        }
    }
}