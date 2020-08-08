using System;
using System.Windows.Forms;
using GIP.Core.Variables;

namespace GIP.Controls.VariableValues
{
    public partial class Ctrl_VariableValueView : UserControl
    {
        public static Ctrl_VariableValueView CreateView(VariableBase inData)
        {
            switch (inData) {
                case TextureVariable _:
                    return new Ctrl_TextureVariableView();
            }
            return null;
        }

        public Ctrl_VariableValueView()
        {
            InitializeComponent();
        }

        public virtual Type VariableType
        { get => default; }
        public VariableBase Data
        {
            get => m_Data;
            set {
                if (m_Data == value) {
                    return;
                }
                if (value.GetType() != VariableType) {
                    throw new InvalidProgramException($"Control {GetType().Name} must be set {VariableType.Name} variable.");
                }

                m_Data = value;
                SetData(m_Data);
                SetEnabledAll(m_Data != null);
                return;
            }
        }

        protected virtual void SetEnabledAll(bool inEnabled)
        {
            TextBoxName.Enabled = inEnabled;
            return;
        }

        protected virtual void SetData(VariableBase inData)
        {
            TextBoxName.Text = (inData == null) ? "" : inData.Name.Value;
            return;
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            m_Data.Name.Value = TextBoxName.Text;
            return;
        }

        private VariableBase m_Data = null;
    }
}
