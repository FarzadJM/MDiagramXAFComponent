using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDiagramXAFComponent
{
    public interface IDiagramLink
    {
        string Id { get; set; }
        string Text { get; set; }
        IDiagramShape ToDiagrameShape { get; set; }
    }
}
