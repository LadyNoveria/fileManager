using System;
using System.Collections.Generic;
using System.Text;

namespace fileManager
{
    class Node
    {
        public string Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }
}
