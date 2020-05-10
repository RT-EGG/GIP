using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using GIP.Common;

namespace GIP.Controls
{
    public partial class Ctrl_ListView : UserControl
    {
        public Ctrl_ListView()
        {
            InitializeComponent();
            CreateColumns();
            return;
        }

        public VirtualListItem AddNew(VirtualListItem inItem)
        {
            m_Items.Add(inItem);
            ListViewItems.DeselectAll();
            inItem.Select();
            NewItemAdded(inItem);
            return inItem;
        }

        public VirtualListItem AddNew()
        {
            return AddNew(CreateNew(ListViewItems));
        }

        public void RemoveSelected()
        {
            for (int i = m_Items.Count - 1; i >= 0; --i) {
                if (m_Items[i].Selected) {
                    RemoveItem(m_Items[i]);
                    ListViewItems.Items.RemoveAt(i);
                    m_Items.RemoveAt(i);
                }
            }
            return;
        }

        public void Clear()
        {
            foreach (var item in m_Items) {
                RemoveItem(item);
            }
            ListViewItems.Items.Clear();
            m_Items.Clear();
            return;
        }

        protected ListView Table => ListViewItems;
        protected virtual (string, int)[] CollectColumns() { return new (string, int)[] { }; }
        protected virtual VirtualListItem CreateNew(ListView inParent) { return default; }
        protected virtual void NewItemAdded(VirtualListItem inNewItem) { return; }
        protected virtual void RemoveItem(VirtualListItem inItem) { }
        protected virtual void OnItemSelected(VirtualListItem inItem) { }

        private void CreateColumns()
        {
            ListViewItems.Columns.Clear();
            foreach (var column in CollectColumns()) {
                ListViewItems.Columns.Add(column.Item1);
                ListViewItems.Columns[ListViewItems.Columns.Count - 1].Width = column.Item2;
            }
            return;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNew();
            return;
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            RemoveSelected();
            return;
        }

        private void ListViewItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            foreach (var item in m_Items) {
                if (item.Selected) {
                    OnItemSelected(item);
                    return;
                }
            }
            OnItemSelected(null);
            return;
        }

        private List<VirtualListItem> m_Items = new List<VirtualListItem>();
    }

    public class VirtualListItem
    {
        public VirtualListItem(ListView inParent)
        {
            Parent = inParent;
            Item = inParent.Items.Add("");
            return;
        }

        public void Select()
        {
            Item.Selected = true;
            return;
        }

        public void Deselect()
        {
            Item.Selected = false;
            return;
        }

        public bool Selected => Item.Selected;

        public ListView Parent
        { get; } = null;
        public ListViewItem Item
        { get; } = null;
    }
}
