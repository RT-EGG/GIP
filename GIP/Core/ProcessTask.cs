using Reactive.Bindings;
using GIP.IO.Project;
using GIP.IO.Json;

namespace GIP.Core
{
    public delegate void ProcessTaskNotifyEvent(ProcessTask inValue);

    public abstract class ProcessTask : DataObjectBase
    {
        public abstract bool Execute(ILogger inLogger = null);

        public ReactiveProperty<string> Name
        { get; } = new ReactiveProperty<string>("task");

        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            (inDst as JsonProcessTask).Name = Name.Value;
            return;
        }
    }
}
