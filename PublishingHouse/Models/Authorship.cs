using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.Models
{
    public class Authorship
    {
        public const string IdAuthor_ = "ID_Author";
        public const string IdPublication_ = "ID_Publication";
        public int IdPublication { get; set; }
        public int IdAuthor { get; set; }
    }
}
