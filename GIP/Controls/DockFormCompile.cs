using System;
using GIP.Core;

namespace GIP.Controls
{
    public partial class DockFormCompile : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DockFormCompile(ShaderCompiler inCompiler, ImageProcessTaskRunner inRunner)
        {
            InitializeComponent();

            Compiler = inCompiler;
            Compiler.OnBeforeCompile += Compiler_OnBeforeCompile;
            Compiler.OnAfterCompile += Compiler_OnAfterCompile;

            TaskRunner = inRunner;
            return;
        }

        public ShaderCompiler Compiler
        { get; private set; } = null;
        public ImageProcessTaskRunner TaskRunner
        { get; private set; } = null;

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
