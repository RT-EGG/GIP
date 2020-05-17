using System;
using GIP.Core;

namespace GIP.Controls
{
    public partial class DockFormCompile : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DockFormCompile()
        {
            InitializeComponent();
        }

        public void SetCompiler(ShaderCompiler inValue)
        {
            if (Compiler == inValue) {
                return;
            }
            if (Compiler != null) {
                Compiler.OnBeforeCompile -= Compiler_OnBeforeCompile;
                Compiler.OnAfterCompile -= Compiler_OnAfterCompile;
            }
            Compiler = inValue;
            if (Compiler != null) {
                Compiler.OnBeforeCompile += Compiler_OnBeforeCompile;
                Compiler.OnAfterCompile += Compiler_OnAfterCompile;
            }
            return;
        }

        public void SetTaskRunner(ImageProcessTaskRunner inValue)
        {
            if (TaskRunner == inValue) {
                return;
            }

            TaskRunner = inValue;
            return;
        }

        public ShaderCompiler Compiler
        { get; private set; } = null;
        public ImageProcessTaskRunner TaskRunner
        { get; private set; } = null;

        protected override string GetPersistString()
        {
            return MainDockFormType.Compile.ToPersistString();
        }

        private void Compiler_OnBeforeCompile(ShaderCompiler inCompiler)
        {
            return;
        }

        private void Compiler_OnAfterCompile(ShaderCompiler inCompiler)
        {
            TextBoxState.Text = Compiler.CompileState;
            return;
        }

        private void ButtonCompile_Click(object sender, EventArgs e)
        {
            Compiler.Compile();
            return;
        }

        private void ButtonCompileAndRun_Click(object sender, EventArgs e)
        {
            if (Compiler.Compile()) {
                TaskRunner.Run();
            }
            return;
        }
    }
}
