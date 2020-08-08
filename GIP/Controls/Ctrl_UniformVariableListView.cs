using System;
using System.Windows.Forms;
using GIP.Core;
using GIP.Core.Uniforms;
using GIP.Core.Variables;

namespace GIP.Controls
{
    public partial class Ctrl_UniformVariableListView : Ctrl_ListView
    {
        public Ctrl_UniformVariableListView()
        {
            InitializeComponent();
        }

        public VariableList Variables
        {
            get => CtrlVariableInfoView.Variables;
            set => CtrlVariableInfoView.Variables = value;
        }

        public UniformVariableList Data
        {
            get => m_Data;
            set {
                try {
                    if (m_Data == value) {
                        return;
                    }

                    m_Data = value;
                    m_SetFromSelf = true;
                    Clear();
                    if (m_Data != null) {
                        foreach (var data in m_Data) {
                            AddNew(new ListItem(Table, data));
                        }
                    }

                } catch (Exception e) {
                    m_Data = null;
                    throw e;

                } finally {
                    m_SetFromSelf = false;
                    this.Enabled = m_Data != null;
                }
                return;
            }
        }

        protected override (string, int)[] CollectColumns() 
        {
            return new (string, int)[] {
                ("Uniform name", 100),
                ("Type", 60),
                ("Value", 60)
            }; 
        }

        protected override void NewItemAdded(VirtualListItem inNewItem)
        {
            base.NewItemAdded(inNewItem);
            if (!m_SetFromSelf) {
                m_Data.Add((inNewItem as ListItem).Data);
            }

            return;
        }

        protected override VirtualListItem CreateNew(ListView inParent) 
        {
            return new ListItem(inParent, new UniformVariable());
        }

        protected override void RemoveItem(VirtualListItem inItem) 
        {
            if (!m_SetFromSelf) {
                m_Data?.Remove((inItem as ListItem).Data);
            }
            return;
        }

        protected override void OnItemSelected(VirtualListItem inItem) 
        {
            CtrlVariableInfoView.Data = (inItem == null) ? null : (inItem as ListItem).Data;
            return;
        }

        private UniformVariableList m_Data = null;
        private bool m_SetFromSelf = false;

        private class ListItem : VirtualListItem
        {
            public ListItem(ListView inParent, UniformVariable inData)
                : base(inParent)
            {
                Data = inData;

                Item.SubItems.Add(inData.UniformName.Value);
                Item.SubItems.Add(inData.Variable.Value.TypeString);
                Item.SubItems.Add(inData.Variable.Value.ValueString.Value);

                inData.UniformName.Subscribe(_ => {
                    Item.SubItems[0].Text = Data.UniformName.Value;
                });
                inData.Variable.Subscribe(_ => {
                    Item.SubItems[1].Text = Data.Variable.Value.TypeString;
                    Data.Variable.Value.ValueString.Subscribe(__ => {
                        Item.SubItems[2].Text = Data.Variable.Value?.ValueString.Value;
                    });
                });
                return;
            }

            public UniformVariable Data
            { get; set; } = null;
        }
    }
}
