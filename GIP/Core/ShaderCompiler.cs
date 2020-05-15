using System;
using GIP.Common;
using GIP.Controls;

namespace GIP.Core
{
    public delegate void ShaderCompilerEvent(ShaderCompiler inCompiler);

    public class ShaderCompiler
    {
        public event ShaderCompilerEvent OnBeforeCompile;
        public event ShaderCompilerEvent OnAfterCompile;

        public bool Compile()
        {
            Ctrl_GLControl.MakeCurrentSomeone();

            OnBeforeCompile?.Invoke(this);
            if (Project == null) {
                CompileState = "Project is not assigned.";
                return false;
            }

            bool result = true;
            CompileState = "";
            foreach (var task in Project.ProcessTasks) {
                CompileState += $"===== {task.Name} ====={Environment.NewLine}";
                if (task.CompileAndLink()) {
                    CompileState += "Compile successed.";
                    result &= true;
                } else {
                    CompileState += $"{task.Error.Linearize()}";
                    result = false;
                }
                CompileState += Environment.NewLine;
                
            }

            OnAfterCompile?.Invoke(this);
            return true;
        }

        public Project Project
        { get; set; } = null;
        public string CompileState
        { get; private set; } = "";
    }
}
