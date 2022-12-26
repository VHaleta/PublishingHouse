using PublishingHouse.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.Models
{
    public class PublishingOrder
    {
        public const string Id_ = "ID_Order";
        public const string IdPrintingHouse_ = "ID_PrintingHouse";
        public const string OrderStatus_ = "OrderStatus";
        public const string IdPublication_ = "ID_Publication";
        public const string DateOrder_ = "DateOrder";
        public const string DateCompliting_ = "DateComp";
        public const string IdRepresentative_ = "ID_Representative";
        public int Id { get; set; }
        public int IdPrintingHouse { get; set; }
        public OrderStatus Status { get; set; }
        public int IdPublication { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateCompliting { get; set; }
        public int IdRepresentative { get; set; }

    }
}
