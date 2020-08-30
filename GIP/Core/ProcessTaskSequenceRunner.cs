using System;

namespace GIP.Core
{
    public class ProcessTaskSequenceRunner
    {
        public ProcessTaskSequenceRunner(Project inProject)
        {
            Project = inProject;
            return;
        }

        public bool Run(ProcessTaskSequence inTasks, ILogger inLogger = null)
        {
            bool result = true;
            inLogger?.ClearLog(this);

            foreach (var shader in Project.ComputeShaders) {
                shader.GLDispose();
                inLogger?.PushLog(this, new LogData(LogLevel.Information, $"Compile shader \"{shader.FilePath.Value}\"." + Environment.NewLine));
                if (!shader.CompileAndLink(inLogger)) {
                    result = false;
                    break;
                }
            }

            if (!result) {
                inLogger?.PushLog(this, new LogData(LogLevel.Information, "Compile and link errored." + Environment.NewLine));
                return false;
            }

            inLogger?.PushLog(this, new LogData(LogLevel.Information, "Dispose all variables." + Environment.NewLine));
            foreach (var variable in Project.Variables) {
                try {
                    variable.DisposeVariable();

                } catch (Exception e) {
                    inLogger?.PushLog(this, new LogExceptionData(e));
                    result = false;
                }
            }

            if (!result) {
                return false;
            }

            inLogger?.PushLog(this, new LogData(LogLevel.Information, "Initialize all variables." + Environment.NewLine));
            foreach (var variable in Project.Variables) {
                try {
                    variable.InitializeVariable();

                } catch (Exception e) {
                    inLogger?.PushLog(this, new LogExceptionData(e));
                    result = false;
                }
            }

            if (!result) {
                return false;
            }

            return inTasks.Execute(inLogger); ;
        }

        public Project Project
        { get; } = null;
    }
}
