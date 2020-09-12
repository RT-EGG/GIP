using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using GIP.Common;
using GIP.Core;
using GIP.Core.Tasks;
using GIP.Controls.ProcessTaskEditor;

namespace GIP.Controls
{
    public partial class DockFormTaskEditor : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DockFormTaskEditor()
        {
            InitializeComponent();
            Task = null;
        }

        public Project Project
        {
            get => m_Project;
            set {
                m_Project = value;
                if (m_Editor != null) {
                    m_Editor.Project = value;
                }
                return;
            }
        }

        public ProcessTask Task
        {
            get => m_Task;
            set {
                try {
                    m_Task = value;
                    if (!IsCurrentTaskFor(m_Task)) {
                        if (m_Editor != null) {
                            m_Editor.Parent = null;
                        }

                        m_Editor = CreateEditorFor(m_Task);
                        if (m_Editor != null) {
                            m_Editor.Parent = this;
                            m_Editor.Dock = DockStyle.Fill;
                            m_Editor.Project = m_Project;
                        }
                    }
                    if (m_Editor != null) {
                        m_Editor.Task = m_Task;
                    }

                } catch (Exception e) {
                    m_Task = null;
                    throw e;

                } finally {
                    this.Enabled = m_Task != null;
                }

                return;
            }
        }

        protected override string GetPersistString()
        {
            return MainDockFormType.TaskEditor.ToPersistString();
        }

        private bool IsCurrentTaskFor(ProcessTask inTask)
        {
            switch (inTask) {
                case ComputeTask compute:
                    return m_Editor is Ctrl_ComputeTaskEditor;
                case TextureExportTask export:
                    return m_Editor is Ctrl_TextureExportTaskEditor;
            }
            return false;
        }

        private Ctrl_ProcessTaskEditor CreateEditorFor(ProcessTask inTask)
        {
            switch (inTask) {
                case ComputeTask compute:
                    return new Ctrl_ComputeTaskEditor();
                case TextureExportTask export:
                    return new Ctrl_TextureExportTaskEditor();
            }
            return null;
        }

        private Project m_Project = null;
        private ProcessTask m_Task = null;
        private Ctrl_ProcessTaskEditor m_Editor = null;
    }
}
