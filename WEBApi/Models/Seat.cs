using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.Models
{
    public class Seat
    {
        public string BUS_SEATID { get; set; }
        public int SeatID { get; set; }
        public string SEATNO { get; set; }
        public int Availability_of_seat { get; set; }
    }
}
