﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySandbox.Main.API
{
    public class Error
    {
        public string Message { get; set; }
        public string Source { get; set; }
        public int ErrorCode { get; set; }
    }
}
