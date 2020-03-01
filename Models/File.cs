using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAS.Models
{
    public class File
    {
        public string Libelle { get; set; }
        public string ExtentionType { get; set; }

        public File(string Libelle, string ExtentionType)
        {
            this.Libelle = Libelle;
            this.ExtentionType = ExtentionType;
        }
    }
}
