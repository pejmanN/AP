using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APT.Models
{
    public class Page
    {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public int? PrevioudPageId { get; set; }
        public int? NextPageId { get; set; }
        public string Title { get; set; }
        public Menu Menu { get; set; }
        public bool? HasService { get; set; }
        public int? ServiceId { get; set; }

    }
}