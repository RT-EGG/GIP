using System.IO;
using Reactive.Bindings;
using GIP.Core.Variables;
using GIP.IO.Project;

namespace GIP.Core
{
    public class Project
    {
        public Project(string inPath)
        {
            FilePath.Value = inPath;

            TaskSequence.Name.Value = "start";
            return;
        }

        public JsonProjectFile ExportToJson()
        {
            JsonProjectFile result = new JsonProjectFile();
            result.Variables = Variables.ExportToJson();
            return result;
        }

        public ReactiveProperty<string> FilePath
        { get; } = new ReactiveProperty<string>("");
        public string Name
        {
            get {
                return Path.GetFileNameWithoutExtension(FilePath.Value);
            }
        }

        public ReactiveCollection<ComputeShader> ComputeShaders
        { get; } = new ReactiveCollection<ComputeShader>();
        public VariableList Variables
        { get; } = new VariableList();
        public ProcessTaskSequence TaskSequence
        { get; } = new ProcessTaskSequence();
    }
}
