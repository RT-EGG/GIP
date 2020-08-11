using GIP.IO.Project;
using Reactive.Bindings;

namespace GIP.Core.Variables
{
    public abstract class VariableBase
    {
        public abstract JsonVariable ExportToJson();

        public virtual void InitializeVariable()
        {
            return;
        }

        public virtual void DisposeVariable()
        {
            return;
        }

        public ReactiveProperty<string> Name
        { get; } = new ReactiveProperty<string>("Variable");

        public abstract IReadOnlyReactiveProperty<string> ValueString
        { get; }

        // public object InitialValue
    }
}
