using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APT.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SuceessPageId { get; set; }
        public int FailPageId { get; set; }
    }
}