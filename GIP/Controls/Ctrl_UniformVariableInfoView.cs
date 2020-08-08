using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GIP.Common;
using GIP.Core.Uniforms;
using GIP.Core.Variables;
using GIP.Controls.UniformVariableValues;

namespace GIP.Controls
{
    public partial class Ctrl_UniformVariableInfoView : UserControl
    {
        public Ctrl_UniformVariableInfoView()
        {
            InitializeComponent();

            ComboType.Items.Clear();
            ComboType.Items.AddRange(con_SupportVariables);
            ComboType.SelectedIndex = -1;
            return;
        }

        public VariableList Variables
        {
            get => m_Variables;
            set {
                if (m_Variables == value) {
                    return;
                }

                m_Variables = value;
                if (m_ValueView != null) {
                    m_ValueView.Variables = m_Variables;
                }
                return;
            }
        }

        public UniformVariable Data
        {
            get => m_Data;
            set {
                if (m_Data == value) {
                    return;
                }

                m_Data = value;
                if (m_Data == null) {
                    SetEnableAll(false);
                } else {
                    SetEnableAll(true);

                    m_IsDataSetting = true;
                    try {
                        TextBoxName.Text = m_Data.UniformName.Value;
                        ComboType.Select((object inItem) => {
                            return ((inItem as VariableType).Type == m_Data.Variable.Value.GetType());
                        });

                    } finally {
                        m_IsDataSetting = false;
                    }
                }

                return;
            }
        }

        private void SetEnableAll(bool inEnable)
        {
            TextBoxName.Enabled = inEnable;
            ComboType.Enabled = inEnable;
            if (m_ValueView != null) {
                m_ValueView.SetEnabled(inEnable);
            }
            return;
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            if ((!m_IsDataSetting) && (m_Data != null)) {
                m_Data.UniformName.Value = TextBoxName.Text;
            }
            return;
        }

        private void ComboType_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((!m_IsDataSetting) && (m_Data != null)) {
                m_Data.Variable.Value = (ComboType.SelectedItem as VariableType).GenerateFunc();
            }

            if (m_ValueView != null) {
                m_ValueView.Parent = null;
                m_ValueView = null;
            }
            if ((m_Data != null) && (m_Data.Variable.Value != null)) {
                m_ValueView = m_Data.Variable.Value.CreateView();
                if (m_ValueView != null) {
                    PanelVariableValueArea.Controls.Add(m_ValueView);
                    m_ValueView.Dock = DockStyle.Top;
                    m_ValueView.AutoSize = true;
                    m_ValueView.Variables = m_Variables;
                    m_ValueView.Data = m_Data.Variable.Value;
                }
            }
            return;
        }

        private VariableList m_Variables = null;
        private UniformVariable m_Data = null;
        private bool m_IsDataSetting = false;
        private Ctrl_UniformVariableValueView m_ValueView = null;

        private class VariableType
        {
            public string Name = "";
            public Type Type = default;
            public Func<UniformVariableValue> GenerateFunc = null;

            public override string ToString()
            {
                return Name;
            }
        }

        private readonly VariableType[] con_SupportVariables = {
            new VariableType{ Name = "Texture", Type = typeof(UniformTextureVariable), GenerateFunc = () => { return new UniformTextureVariable(); } }
        };
    }
}
