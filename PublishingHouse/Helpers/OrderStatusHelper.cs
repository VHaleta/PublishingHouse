using PublishingHouse.Constants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.Helpers
{
    public static class OrderStatusHelper
    {
        public static List<string> GetList()
        {
            return new List<string>()
            {
                "Complited",
                "InProcess",
                "DidntBegan",
                "Unknown"
            };
        }
        public static OrderStatus StringToEnum(string status)
        {
            switch (status)
            {
                case "Complited":
                    return OrderStatus.Complited;
                case "InProcess":
                    return OrderStatus.InProcess;
                case "DidntBegan":
                    return OrderStatus.DidntBegan;
                default:
                    return OrderStatus.Unknown;
            }
        }

        public static string EnumToString(OrderStatus status)
        {
            switch (status)
            {
                case OrderStatus.Complited:
                    return "Complited";
                case OrderStatus.InProcess:
                    return "InProcess";
                case OrderStatus.DidntBegan:
                    return "DidntBegan";
                default:
                    return "Unknown";
            }
        }
    }
}
