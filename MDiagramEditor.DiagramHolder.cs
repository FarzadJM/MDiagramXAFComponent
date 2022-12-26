using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.Components;
using Microsoft.AspNetCore.Components;

namespace MDiagramXAFComponent
{
    public partial class MDiagramEditor
    {
        public sealed class MDiagramHolder : IComponentContentHolder
        {
            private RenderFragment componentContent;
            public MDiagramHolder(MDiagramModel componentModel)
            {
                ComponentModel = componentModel ?? throw new ArgumentNullException(nameof(componentModel));
            }
            private RenderFragment CreateComponent() => ComponentModelObserver.Create(ComponentModel, MDiagramEditorComponent.Create(ComponentModel));
            public MDiagramModel ComponentModel { get; }
            RenderFragment IComponentContentHolder.ComponentContent => componentContent ??= CreateComponent();
        }
    }
}
