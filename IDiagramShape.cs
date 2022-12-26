using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDiagramXAFComponent
{
    public interface IDiagramShape
    {
        string Id { get; set; }
        string Text { get; set; }
        string Type { get; set; }
        string Style { get; set; }

        IEnumerable<IDiagramLink> Links { get; set; }
    }
}
