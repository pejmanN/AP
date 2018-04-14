using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APT.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public bool IsLast { get; set; }

        public IList<Page> Pages { get; set; }
    }
}