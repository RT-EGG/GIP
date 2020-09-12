using GIP.Core;
using GIP.Core.Tasks;
using GIP.Controls;

namespace GIP
{
    class MainFormEventBridge
    {
        public void Register(MainDockForms inDockForms)
        {
            m_DockForms = inDockForms;
            inDockForms.Get<DockFormProjectFileView>(MainDockFormType.ProjectFiles).OnComputeShaderSelect += MainFormEventBridge_OnComputeShaderSelect;
            inDockForms.Get<DockFormTaskSequence>(MainDockFormType.TaskSequence).OnTaskSelected += DockFormTaskSequence_OnTaskSelected;
            return;
        }

        private void MainFormEventBridge_OnComputeShaderSelect(ComputeShader inValue)
        {
            if (inValue != null) {
                m_DockForms.Get<DockFormCodeEditor>(MainDockFormType.CodeEditor).Shader = inValue;
            }
            return;
        }

        private void DockFormTaskSequence_OnTaskSelected(ProcessTask inValue)
        {
            m_DockForms.Get<DockFormTaskEditor>(MainDockFormType.TaskEditor).Task = inValue;
            return;
        }

        private MainDockForms m_DockForms = null;
    }
}
