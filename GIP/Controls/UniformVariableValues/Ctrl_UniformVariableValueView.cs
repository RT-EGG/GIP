using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;
using GIP.Core;
using GIP.Common;
using GIP.Core.Uniforms;
using GIP.Core.Variables;

namespace GIP.Controls.UniformVariableValues
{
    public partial class Ctrl_UniformVariableValueView : UserControl
    {
        public Ctrl_UniformVariableValueView()
        {
            InitializeComponent();
            return;
        }

        public virtual void SetEnabled(bool inEnabled)
        {
            return;
        }

        public VariableList Variables
        {
            get => m_Variables;
            set {
                if (m_Variables == value) {
                    return;
                }

                m_VariablesSubscription.DisposeAndClear();

                m_Variables = value;
                if (m_Variables != null) {
                    m_VariablesSubscription.Add(m_Variables.SubscribeCollectionChanged((s, e) => DoVariableCollectionChanged()));
                }

                DoVariableCollectionChanged();
                return;
            }
        }

        public UniformVariableValue Data
        {
            get => m_Data;
            set {
                try {
                    if (m_Data == value) {
                        return;
                    }

                    m_Data = value;
                    SetData(m_Data);

                } catch (Exception e) {
                    m_Data = null;
                    throw e;

                } finally {
                    this.Enabled = m_Data != null;
                }
                return;
            }
        }

        protected virtual void DoVariableCollectionChanged()
        {
            return;
        }

        protected virtual void SetData(UniformVariableValue inValue)
        {
            return;
        }

        private void Variables_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            DoVariableCollectionChanged();
            return;
        }

        private List<IDisposable> m_VariablesSubscription = new List<IDisposable>();

        private VariableList m_Variables = null;
        private UniformVariableValue m_Data = null;
    }
}
