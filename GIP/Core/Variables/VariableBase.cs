using GIP.IO.Json;
using GIP.IO.Project;
using Reactive.Bindings;

namespace GIP.Core.Variables
{
    public abstract class VariableBase : DataObjectBase
    {
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

        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            (inDst as JsonVariable).Name = Name.Value;
            return;
        }
    }
}
