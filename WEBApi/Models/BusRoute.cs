﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.Models
{
    public class BusRoute
    {
        public string RouteID { get; set; }
        public int TerminalID { get; set; }
        public string via { get; set; }
    }
}
