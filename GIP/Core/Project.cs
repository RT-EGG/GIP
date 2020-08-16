using System.IO;
using System.Collections.Generic;
using Reactive.Bindings;
using GIP.Common;
using GIP.Core.Variables;
using GIP.IO.Project;
using GIP.IO.Json;

namespace GIP.Core
{
    public class Project : DataObjectBase
    {
        public Project(string inPath)
        {
            FilePath.Value = inPath;

            TaskSequence.Name.Value = "start";
            return;
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

        protected override JsonDataObject CreateJson() => new JsonProjectFile();
        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            var dst = inDst as JsonProjectFile;
            dst.ShaderSources.AddRange(ComputeShaders.Convert(s => s.Source.ExportToJson<JsonShaderSource>()));
            dst.Variables.AddRange(Variables.Convert(v => v.ExportToJson<JsonVariable>()));
            dst.TaskSequence = TaskSequence.ExportToJson<JsonTaskSequence>();

            return;
        }
    }
}
