using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDiagramXAFComponent
{
    internal class Node : MDiagramRazorComponent.INode
    {
        public Node(string id, string text, string type, string style)
        {
            Id = id;
            Text = text;
            Type = type;
            Style = style;
        }

        public string Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Style { get; set; }
    }
}
