using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAS.Models
{
    public class FileRoad
    {
        public string Libelle { get; set; }
        public List<File> Files { get; set; }
        public List<FileRoad> Subfolder { get; set; }

        public FileRoad(string libelle)
        {
            this.Libelle = libelle;
            this.Files = new List<File>();
            this.Subfolder = new List<FileRoad>();
        }
    }
}
