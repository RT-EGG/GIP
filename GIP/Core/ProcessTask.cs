using Reactive.Bindings;

namespace GIP.Core
{
    public delegate void ProcessTaskNotifyEvent(ProcessTask inValue);

    public abstract class ProcessTask
    {
        public abstract bool Execute(ILogger inLogger = null);

        public ReactiveProperty<string> Name
        { get; } = new ReactiveProperty<string>("task");
    }
}
