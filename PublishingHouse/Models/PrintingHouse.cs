using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.Models
{
    public class PrintingHouse
    {
        public const string Id_ = "ID_PrintingHouse";
        public const string Name_ = "NamePrintingHouse";
        public const string Address_ = "AddressPrintingHouse";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
