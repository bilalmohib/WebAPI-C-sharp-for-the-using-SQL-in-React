using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.Models
{
    public class Schedule
    {
        public int ListNo { get; set; }
        public string BusNo { get; set; }
        public string departureDate { get; set; }
        public string departureTime { get; set; }
        public string ArrivalTime { get; set; }
    }
}
