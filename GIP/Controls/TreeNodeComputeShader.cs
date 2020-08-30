using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GIP.Common;
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

                m_Subscription.DisposeAndClear();

                m_Data = value;
                if (m_Data == null) {
                    Text = "<N/A>";
                } else {
                    m_Subscription.Add(m_Data.FilePath.Subscribe(path => {
                        Text = Path.GetFileName(m_Data.FilePath.Value);
                    }));
                }
                return;
            }
        }

        private ComputeShader m_Data = null;
        private List<IDisposable> m_Subscription = new List<IDisposable>();
    }
}
