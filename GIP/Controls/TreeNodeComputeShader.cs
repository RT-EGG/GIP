using System.IO;
using System.Windows.Forms;
using GIP.Core;

namespace GIP.Controls
{
    class TreeNodeComputeShader : TreeNode
    {
        public TreeNodeComputeShader(ComputeShader inData)
        {
            Data = inData;
            return;
        }

        public ComputeShader Data
        {
            get => m_Data;
            private set {
                if (m_Data == value) {
                    return;
                }

                m_Data = value;
                if (m_Data == null) {
                    Text = "<N/A>";
                } else {
                    m_Data.Source.FilePath.PropertyChanged += Data_FilePath_PropertyChanged;
                    Text = Path.GetFileName(m_Data.Source.FilePath.Value);
                }
                return;
            }
        }

        private void Data_FilePath_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Text = Path.GetFileName(m_Data.Source.FilePath.Value);
            return;
        }

        private ComputeShader m_Data = null;
    }
}
