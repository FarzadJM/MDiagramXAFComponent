using DevExpress.ExpressApp.Blazor.Components.Models;
using MDiagramRazorComponent;

namespace MDiagramXAFComponent
{
    public sealed class MDiagramModel : ComponentModelBase
    {
        public event EventHandler RefreshRequested;

        public Func<Task<IEnumerable<INode>>> GetNodesDataAsync
        {
            get => GetPropertyValue<Func<Task<IEnumerable<INode>>>>();
            set => SetPropertyValue(value);
        }

        public Func<Task<IEnumerable<IEdge>>> GetEdgesDataAsync
        {
            get => GetPropertyValue<Func<Task<IEnumerable<IEdge>>>>();
            set => SetPropertyValue(value);
        }

        public void Refresh() => RefreshRequested?.Invoke(this, EventArgs.Empty);
    }
}
