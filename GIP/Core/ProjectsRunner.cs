using System;
using System.Collections.Generic;
using System.IO;
using GIP.IO.Json;
using GIP.IO.Project;

namespace GIP.Core
{
    public class ProjectsRunner
    {
        public void RunFiles(IEnumerable<string> inFilePathes, ILogger inLogger)
        {
            foreach (var path in inFilePathes) {
                if (!File.Exists(path)) {
                    inLogger.PushLog(this, new LogData(LogLevel.Error, $"Project file \"{path}\" is not found."));
                }

                JsonProjectFile projectFile;
                try {
                    projectFile = JsonSerializable.ImportFromFile<JsonProjectFile>(path);

                } catch (Exception e) {
                    inLogger.PushLog(this, new LogData(LogLevel.Error, $"Parse project file error \"{path}\"."));
                    continue;
                }

                Project project = new Project(path);
                JsonDataReadBuffer buffer = new JsonDataReadBuffer();
                if (!project.ReadJson(projectFile, buffer, inLogger)) {
                    inLogger.PushLog(this, new LogData(LogLevel.Error, $"Read project data error \"{path}\"."));
                    continue;
                }
                buffer.ProcessComplementation(inLogger);

                ProcessTaskSequenceRunner runner = new ProcessTaskSequenceRunner(project);
                if (!runner.Run(project.TaskSequence, inLogger)) {
                    inLogger.PushLog(this, new LogData(LogLevel.Error, $"Runtime error \"{path}\"."));
                    continue;
                }

                inLogger.PushLog(this, new LogData(LogLevel.Information, $"Run sucessed \"{path}\"."));
            }

            return;
        }
    }
}
