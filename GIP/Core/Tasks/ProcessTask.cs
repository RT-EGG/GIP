using Reactive.Bindings;
using GIP.IO.Project;
using GIP.IO.Json;
using System;
using System.Collections.Generic;

namespace GIP.Core.Task
{
    public delegate void ProcessTaskNotifyEvent(ProcessTask inValue);

    public abstract class ProcessTask : DataObjectBase
    {
        public static ProcessTask CreateFrom(JsonProcessTask inSource)
        {
            switch (inSource) {
                case JsonComputeTask compute:
                    return new ComputeTask();
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
