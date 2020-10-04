using Reactive.Bindings;
using GIP.IO.Project;
using GIP.IO.Json;
using System;
using System.Collections.Generic;

namespace GIP.Core.Tasks
{
    public delegate void ProcessTaskNotifyEvent(ProcessTask inValue);

    public class ProcessTaskLogData : LogData
    {
        public ProcessTaskLogData(ProcessTask inTask, LogLevel inLevel, string inMessage)
            : base(inLevel, $"[task: {inTask.Name.Value}] {inMessage}")
        { }
    }

    public abstract class ProcessTask : DataObjectBase
    {
        public static ProcessTask CreateFrom(JsonProcessTask inSource)
        {
            switch (inSource) {
                case JsonComputeTask _:
                    return new ComputeTask();
                case JsonTextureExportTask _:
                    return new TextureExportTask();
                case JsonTaskSequenceCountingForLoop _:
                    return new ProcessTaskSequenceCountingForLoop();
            }
            return null;
        }

        public abstract bool Execute(ILogger inLogger = null);

        public ReactiveProperty<string> Name
        { get; } = new ReactiveProperty<string>("task");

        protected override IEnumerable<Type> ReadableJsonClass => new Type[] { typeof(JsonProcessTask) };
        public override bool ReadJson(JsonDataObject inSource, JsonDataReadBuffer inBuffer, ILogger inLogger)
        {
            if (!base.ReadJson(inSource, inBuffer, inLogger)) {
                return false;
            }

            Name.Value = (inSource as JsonProcessTask).Name;
            return true;
        }

        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            (inDst as JsonProcessTask).Name = Name.Value;
            return;
        }
    }
}
