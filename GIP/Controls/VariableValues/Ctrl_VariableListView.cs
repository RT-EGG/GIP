using System;
using System.Windows.Forms;
using GIP.Core.Variables;

namespace GIP.Controls.VariableValues
{
    public partial class Ctrl_VariableListView : Ctrl_ListView
    {
        public Ctrl_VariableListView()
        {
            InitializeComponent();
            Data = null;
        }

        public VariableList Data
        {
            get => m_Data;
            set {
                try {
                    if (m_Data == value) {
                        return;
                    }

                    m_Data = value;
                    Clear();
                    foreach (var data in value) {
                        AddNew(new ListItem(Table, data));
                    }
                } catch (Exception e) {
                    m_Data = null;
                    throw e;

                } finally {
                    this.Enabled = m_Data != null;
                }
                
                return;
            }
        }

        protected override (string, int)[] CollectColumns()
        {
            return new (string, int)[] {
                ("Name", 80),
                ("Value", 100)
            };
        }

        protected override VirtualListItem CreateNew(ListView inParent)
        {
            return new ListItem(inParent, new TextureVariable());
        }

        protected override void NewItemAdded(VirtualListItem inNewItem)
        {
            m_Data.Add((inNewItem as ListItem).Data);
            return;
        }

        protected override void RemoveItem(VirtualListItem inItem)
        {
            m_Data.Remove((inItem as ListItem).Data);
            return;
        }

        protected override void OnItemSelected(VirtualListItem inItem) 
        {
            if (inItem == null) {
                if (m_ValueView != null) {
                    Controls.Remove(m_ValueView);
                    m_ValueView = null;
                }
            } else {
                if (m_ValueView != null) {
                    if (m_ValueView.VariableType != (inItem as ListItem).Data.GetType()) {
                        Controls.Remove(m_ValueView);
                        m_ValueView = null;
                    }
                } 
                if (m_ValueView == null) {
                    m_ValueView = Ctrl_VariableValueView.CreateView((inItem as ListItem).Data);
                    if (m_ValueView != null) {
                        Controls.Add(m_ValueView);
                        Controls.SetChildIndex(m_ValueView, 0);
                        m_ValueView.Dock = DockStyle.Top;
                    }
                }

                if (m_ValueView != null) {
                    m_ValueView.Data = (inItem as ListItem).Data;
                }
            }
            return;
        }

        private VariableList m_Data = null;
        private Ctrl_VariableValueView m_ValueView = null;

        private class ListItem : VirtualListItem
        {
            public ListItem(ListView inParent, VariableBase inData)
                : base(inParent)
            {
                Data = inData;

                Item.SubItems.Add(inData.Name.Value);
                Item.SubItems.Add(inData.ValueString.Value);
                inData.Name.Subscribe(n => {
                    Item.SubItems[0].Text = n;
                });
                inData.ValueString.Subscribe(s => {
                    Item.SubItems[1].Text = s;
                });
                return;
            }

            public VariableBase Data
            { get; private set; } = null;
        }
    }
}
