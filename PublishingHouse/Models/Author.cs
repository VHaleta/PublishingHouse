using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.Models
{
    public class Author
    {
        public const string Id_ = "ID_Author";
        public const string AdditionalInfo_ = "AdditionalInfo";
        public int Id { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
