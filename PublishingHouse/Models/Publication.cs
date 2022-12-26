using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.Models
{
    public class Publication
    {
        public const string Id_ = "ID_Publication";
        public const string Name_ = "NamePublication";
        public const string Type_ = "PublicationType";
        public const string Size_ = "Size";
        public const string PrintingCount_ = "PrintingCount";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public int PrintingCount { get; set; }
    }
}
