using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APT
{
    public class ServiceDto
    {
        public string ServiceTitle { get; set; }
        public PageDto SucessPage { get; set; }
        public PageDto FailPage { get; set; }
    }
}