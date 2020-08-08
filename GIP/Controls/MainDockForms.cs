using System.Collections.Generic;
using System.ComponentModel; 
using WeifenLuo.WinFormsUI.Docking;

namespace GIP.Controls
{
    public enum MainDockFormType
    { 
        ProjectFiles,
        CodeEditor,
        Console,
        TaskSequence,
        TaskEditor,
        VariableList,
        TextureView
    }

    public static class MainDockFormTypeExtensions
    {
        public static string ToPersistString(this MainDockFormType inType)
        {
            switch (inType) {
                case MainDockFormType.ProjectFiles:
                    return "ProjectFiles";
                case MainDockFormType.CodeEditor:
                    return "CodeEditor";
                case MainDockFormType.TaskSequence:
                    return "TaskSequence";
                case MainDockFormType.TaskEditor:
                    return "TaskEditor";
                case MainDockFormType.Console:
                    return "Compile";
                case MainDockFormType.VariableList:
                    return "Variables";
                case MainDockFormType.TextureView:
                    return "TextureView";
                default:
                    throw new InvalidEnumArgumentException("ToPersistantString(inType)", (int)inType, typeof(MainDockFormType));
            }
        }
    }

    public class MainDockForms
    {
        public MainDockForms()
        {
            m_FormList.Add(MainDockFormType.ProjectFiles, new DockFormProjectFileView());
            m_FormList.Add(MainDockFormType.CodeEditor, new DockFormCodeEditor());
            m_FormList.Add(MainDockFormType.TaskSequence, new DockFormTaskSequence());
            m_FormList.Add(MainDockFormType.TaskEditor, new DockFormTaskEditor());
            m_FormList.Add(MainDockFormType.Console, new DockFormConsole());
            m_FormList.Add(MainDockFormType.VariableList, new DockFormVariableList());
            m_FormList.Add(MainDockFormType.TextureView, new DockFormTextureView());

            foreach (var form in m_FormList.Values) {
                form.HideOnClose = true;
            }
            return;
        }

        public void ShowAll(DockPanel inParent)
        {
            foreach (var content in m_FormList.Values) {
                if (content.Visible) {
                    content.Close();
                }
                content.Show(inParent);
            }
            return;
        }

        public IDockContent Find(string inName)
        {
            foreach (var content in m_FormList) {
                if (content.Key.ToPersistString() == inName) {
                    return content.Value;
                }
            }
            return null;
        }

        public IDockContent Get(MainDockFormType inType)
        {
            if (m_FormList.TryGetValue(inType, out var result)) {
                return result;
            }
            return null;
        }

        public T Get<T>(MainDockFormType inType) where T : DockContent
        {
            var result = Get(inType);
            if ((result != null) && (result is T)) {
                return result as T;
            }
            return null;
        }

        private Dictionary<MainDockFormType, DockContent> m_FormList
        { get; } = new Dictionary<MainDockFormType, DockContent>();
    }
}
