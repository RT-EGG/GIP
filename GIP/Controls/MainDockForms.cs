using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; 
using WeifenLuo.WinFormsUI.Docking;

namespace GIP.Controls
{
    public enum MainDockFormType
    { 
        CodeEditor,
        Compile,
        TextureList,
        UniformVariables,
        TextureView
    }

    public static class MainDockFormTypeExtensions
    {
        public static string ToPersistString(this MainDockFormType inType)
        {
            switch (inType) {
                case MainDockFormType.CodeEditor:
                    return "CodeEditor";
                case MainDockFormType.Compile:
                    return "Compile";
                case MainDockFormType.TextureList:
                    return "Textures";
                case MainDockFormType.UniformVariables:
                    return "UniformVariables";
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
            m_FormList.Add(MainDockFormType.CodeEditor, new DockFormCodeEditor());
            m_FormList.Add(MainDockFormType.Compile, new DockFormCompile());
            m_FormList.Add(MainDockFormType.TextureList, new DockFormTextureList());
            m_FormList.Add(MainDockFormType.TextureView, new DockFormTextureView());
            m_FormList.Add(MainDockFormType.UniformVariables, new DockFormUniformVariable());

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
