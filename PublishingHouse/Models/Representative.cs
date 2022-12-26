using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.Models
{
    public class Representative
    {
        public const string Id_ = "ID_Representative";
        public const string IdEntity_ = "ID_Entity";
        public const string IdAuthor_ = "ID_Author";
        public int Id { get; set; }
        public int IdEntity { get; set; }
        public int IdAuthor { get; set; }
    }
}
