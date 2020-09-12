using System.IO;
using System.Collections.Generic;
using Reactive.Bindings;
using GIP.Common;
using GIP.Core.Variables;
using GIP.Core.Tasks;
using GIP.IO.Project;
using GIP.IO.Json;
using System;

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

        protected override IEnumerable<Type> ReadableJsonClass => new Type[] { typeof(JsonProjectFile) };
        public override bool ReadJson(JsonDataObject inSource, JsonDataReadBuffer inBuffer, ILogger inLogger)
        {
            ComputeShaders.Clear();
            Variables.Clear();
            TaskSequence.Clear();

            if (!base.ReadJson(inSource, inBuffer, inLogger)) {
                return false;
            }

            var src = inSource as JsonProjectFile;

            src.ComputeShader.ForEach(s => {
                var shader = new ComputeShader(s.FileType, s.FilePath);
                shader.ReadJson(s, inBuffer, inLogger);
                ComputeShaders.Add(shader);
            });

            src.Variables.ForEach(v => {
                var variable = VariableBase.CreateFrom(v);
                if (variable != null) {
                    variable.ReadJson(v, inBuffer, inLogger);
                    Variables.Add(variable);
                }
            });

            TaskSequence.ReadJson(src.TaskSequence, inBuffer, inLogger);

            return true;
        }

        protected override JsonDataObject CreateJson() => new JsonProjectFile();
        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            var dst = inDst as JsonProjectFile;
            dst.ComputeShader.AddRange(ComputeShaders.Convert(s => s.ExportToJson<JsonComputeShader>()));
            dst.Variables.AddRange(Variables.Convert(v => v.ExportToJson<JsonVariable>()));
            dst.TaskSequence = TaskSequence.ExportToJson<JsonTaskSequence>();

            return;
        }
    }
}
