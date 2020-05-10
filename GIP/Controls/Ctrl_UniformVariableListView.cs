using System;
using System.Windows.Forms;
using GIP.Core;
using GIP.Core.Uniforms;

namespace GIP.Controls
{
    public partial class Ctrl_UniformVariableListView : Ctrl_ListView
    {
        public Ctrl_UniformVariableListView()
        {
            InitializeComponent();
        }

        public ShaderResourceInitializers Resources
        {
            get => m_Resources;
            set {
                if (m_Resources == value) {
                    return;
                }

                m_Resources = value;
                return;
            }
        }

        public UniformVariableList Data
        {
            get => m_Data;
            set {
                if (m_Data == value) {
                    return;
                }

                m_Data = value;
                foreach (var data in m_Data) {
                    AddNew(new ListItem(Table, data));
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
            m_Data.Add((inNewItem as ListItem).Data);

            return;
        }

        protected override VirtualListItem CreateNew(ListView inParent) 
        {
            return new ListItem(inParent, new UniformVariable());
        }

        protected override void RemoveItem(VirtualListItem inItem) 
        {
            m_Data.Remove((inItem as ListItem).Data);
            return;
        }

        protected override void OnItemSelected(VirtualListItem inItem) 
        {
            CtrlVariableInfoView.Resources = m_Resources;
            CtrlVariableInfoView.Data = (inItem == null) ? null : (inItem as ListItem).Data;
            return;
        }

        private ShaderResourceInitializers m_Resources = null;
        private UniformVariableList m_Data = null;

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
