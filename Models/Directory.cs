using System.Collections.Generic;

namespace NAS.Models
{
    public class Directory
    {
        public string Name { get; set; }
        public ICollection<File> Files { get; set; }
        public ICollection<SubDirectory> SubDirectories { get; set; }
    }
}