using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using MDiagramRazorComponent;
using System.Collections;
using System.ComponentModel;

namespace MDiagramXAFComponent
{
    public abstract partial class MDiagramEditor : ListEditor, IComplexListEditor
    {
        private IDiagramShape[] selectedObjects = Array.Empty<IDiagramShape>();
        private IEnumerable<IDiagramShape> data;
        private IObjectSpace objectSpace;

        public MDiagramEditor(IModelListView model) : base(model)
        {
        }

        public override SelectionType SelectionType => SelectionType.None;

        public override IList GetSelectedObjects()
        {
            return selectedObjects;
        }

        public override void Refresh()
        {
            if (Control is MDiagramHolder holder)
            {
                holder.ComponentModel.Refresh();
            }
        }

        protected override void AssignDataSourceToControl(object dataSource)
        {
            if (Control is MDiagramHolder holder)
            {
                if (data is IBindingList bindingList)
                {
                    bindingList.ListChanged -= BindingList_ListChanged;
                }

                if (dataSource is QueryableCollection queryableCollection)
                {
                    data = (queryableCollection.Queryable as IEnumerable)?.Cast<IDiagramShape>();
                }
                else if (dataSource is ProxyCollection proxyCollection)
                {
                    data = proxyCollection.Cast<IDiagramShape>();
                }

                if (dataSource is IBindingList newBindingList)
                {
                    newBindingList.ListChanged += BindingList_ListChanged;
                }
            }
        }

        private void BindingList_ListChanged(object sender, ListChangedEventArgs e)
        {
            Refresh();
        }

        protected override object CreateControlsCore()
        {
            return new MDiagramHolder(new MDiagramModel());
        }

        void IComplexListEditor.Setup(CollectionSourceBase collectionSource, XafApplication application)
        {
            objectSpace = collectionSource.ObjectSpace;
        }

        protected override void OnControlsCreated()
        {
            if (Control is MDiagramHolder diagramHolder)
            {
                diagramHolder.ComponentModel.GetNodesDataAsync = GetNodesDataAsync;
                diagramHolder.ComponentModel.GetEdgesDataAsync = GetEdgesDataAsync;
            }

            base.OnControlsCreated();
        }

        private Task<IEnumerable<INode>> GetNodesDataAsync()
        {
            var list = new List<INode>();

            if (data is not null)
            {
                list.AddRange(data.Select(x => new Node(x.Id, x.Text, x.Type, x.Style)));
            }

            return Task.FromResult(list.AsEnumerable());
        }

        private Task<IEnumerable<IEdge>> GetEdgesDataAsync()
        {
            var list = new List<IEdge>();

            if (data is not null)
            {
                var shapes = data.Where(x => x.Links.Any()).ToList();

                foreach (var shape in shapes)
                {
                    list.AddRange(shape.Links.Select(x => new Edge(x.Id, x.Text, shape.Id, x.ToDiagrameShape.Id)));
                }
            }

            return Task.FromResult(list.AsEnumerable());
        }
    }
}
