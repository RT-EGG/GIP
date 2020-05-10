using System;
using System.Windows.Forms;
using GIP.Core;

namespace GIP.Controls
{
    public partial class Ctrl_GlobalTextureListView : Ctrl_ListView
    {
        public Ctrl_GlobalTextureListView()
        {
            InitializeComponent();
        }

        public TextureInitializerList Data
        {
            get => m_Data;
            set {
                if (m_Data == value) {
                    return;
                }

                m_Data = value;
                Clear();
                foreach (var data in value) {
                    AddNew(new ListItem(Table, data));
                }
                
                return;
            }
        }

        protected override (string, int)[] CollectColumns()
        {
            return new (string, int)[] {
                ("Name", 80),
                ("Format", 60),
                ("DataType", 70)
            };
        }

        protected override VirtualListItem CreateNew(ListView inParent)
        {
            return new ListItem(inParent, new TextureInitializer());
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
            CtrlTextureInfoView.Data = (inItem == null) ? null : (inItem as ListItem).Data;
            return;
        }

        private TextureInitializerList m_Data = null;

        private class ListItem : VirtualListItem
        {
            public ListItem(ListView inParent, TextureInitializer inData)
                : base(inParent)
            {
                Data = inData;

                Item.SubItems.Add(inData.Name.Value);
                Item.SubItems.Add(inData.Format.Value.ToString());
                Item.SubItems.Add(inData.DataType.Value.ToString());
                inData.Name.Subscribe(_ => {
                    Item.SubItems[0].Text = Data.Name.Value;
                });
                inData.Format.Subscribe(_ => {
                    Item.SubItems[1].Text = Data.Format.Value.ToString();
                });
                inData.DataType.Subscribe(_ => {
                    Item.SubItems[2].Text = Data.DataType.Value.ToString();
                });
                return;
            }

            public TextureInitializer Data
            { get; private set; } = null;
        }
    }
}
