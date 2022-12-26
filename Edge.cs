using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDiagramXAFComponent
{
    internal class Edge : MDiagramRazorComponent.IEdge
    {
        public Edge(string id, string text, string fromId, string toId)
        {
            Id = id;
            Text = text;
            FromId = fromId;
            ToId = toId;
        }

        public string Id { get; set; }
        public string Text { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
    }
}
