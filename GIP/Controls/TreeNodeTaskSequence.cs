using System.Collections.Specialized;
using GIP.Core;

namespace GIP.Controls
{
    public class TreeNodeTaskSequence : TreeNodeProcessTask
    {
        public TreeNodeTaskSequence(ProcessTaskSequence inData)
            : base (inData)
        {
            Data.CollectionChanged += Data_CollectionChanged; ;

            Nodes.Clear();
            foreach (var task in inData) {
                Nodes.Add(TreeNodeProcessTask.CreateNode(task));
            }
            return;
        }

        private void Data_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action) {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; ++i) {
                        Nodes.Insert(e.NewStartingIndex + i, TreeNodeProcessTask.CreateNode(e.NewItems[i] as ProcessTask));
                    }

                    break;

                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; ++i) {
                        Nodes.RemoveAt(e.OldStartingIndex);
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    var old = Nodes[e.OldStartingIndex];
                    Nodes.RemoveAt(e.OldStartingIndex);
                    Nodes.Insert(e.NewStartingIndex, old);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Nodes.Clear();
                    break;
            }
            return;
        }

        public new ProcessTaskSequence Data
        { get => base.Data as ProcessTaskSequence; }
    }
}
