using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GIP.Core;
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
                if (m_Task == value) {
                    return;
                }

                if (value.GetType() != TaskType) {
                    throw new InvalidProgramException($"Control {GetType().Name} must be set {TaskType.Name} variable.");
                }

                m_TaskSubscription.DisposeAndClear();
                m_TaskSubscription.AddRange(SetData(m_Task));

                TextBoxName.Enabled = m_Task != null;
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

        private Project m_Project = null;
        private ProcessTask m_Task = null;
        private List<IDisposable> m_ProjectSubscription = new List<IDisposable>();
        private List<IDisposable> m_TaskSubscription = new List<IDisposable>();
    }
}
