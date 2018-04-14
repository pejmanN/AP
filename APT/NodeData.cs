using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APT
{
    public class NodeData
    {
        public string Text { get; set; }
        public IEnumerable<NodeData> Children { get; set; }
    }
}