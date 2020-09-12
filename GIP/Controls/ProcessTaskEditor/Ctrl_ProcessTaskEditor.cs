using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GIP.Core;
using GIP.Core.Tasks;
using GIP.Common;

namespace GIP.Controls.ProcessTaskEditor
{
    public partial class Ctrl_ProcessTaskEditor : UserControl
    {
        public Ctrl_ProcessTaskEditor()
        {
            InitializeComponent();
        }

        ~Ctrl_ProcessTaskEditor()
        {
            m_ProjectSubscription.DisposeAndClear();
            m_TaskSubscription.DisposeAndClear();
            return;
        }

        public virtual Type TaskType
        { get => default; }

        public ProcessTask Task
        {
            get => m_Task;
            set {
                try {
                    if (m_Task == value) {
                        return;
                    }

                    if (value.GetType() != TaskType) {
                        throw new InvalidProgramException($"Control {GetType().Name} must be set {TaskType.Name} variable.");
                    }

                    m_TaskSubscription.DisposeAndClear();

                    m_Task = value;
                    m_TaskSubscription.AddRange(SetData(m_Task));

                } catch (Exception e) {
                    m_Task = null;
                    throw e;

                } finally {
                    this.Enabled = m_Task != null;
                }
                return;
            }
        }

        public Project Project
        {
            get => m_Project;
            set {
                if (m_Project == value) {
                    return;
                }

                m_ProjectSubscription.DisposeAndClear();

                m_Project = value;
                m_ProjectSubscription.AddRange(SetProject(m_Project));
                return;
            }
        }

        protected virtual IEnumerable<IDisposable> SetData(ProcessTask inValue)
        {
            if (inValue != null) {
                yield return inValue.Name.Subscribe(n => TextBoxName.Text = n);
            } else {
                TextBoxName.Text = "";
            }
            yield break;
        }

        protected virtual IEnumerable<IDisposable> SetProject(Project inValue)
        {
            yield break;
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            if (m_Task != null) {
                m_Task.Name.Value = TextBoxName.Text;
            }
            return;
        }

        private Project m_Project = null;
        private ProcessTask m_Task = null;
        private List<IDisposable> m_ProjectSubscription = new List<IDisposable>();
        private List<IDisposable> m_TaskSubscription = new List<IDisposable>();
    }
}
