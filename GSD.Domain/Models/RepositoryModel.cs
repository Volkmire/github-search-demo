using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GSD.Domain.Models
{
    public class RepositoryModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string AvatarUrl { get; set; }
        public string Url { get; set; }
        public string Language { get; set; }
        public int StarCount { get; set; }
        public int ForkCount { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
