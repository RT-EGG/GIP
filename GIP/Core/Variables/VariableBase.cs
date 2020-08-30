using System;
using System.Collections.Generic;
using Reactive.Bindings;
using GIP.IO.Json;
using GIP.IO.Project;

namespace GIP.Core.Variables
{
    public abstract class VariableBase : DataObjectBase
    {
        public static VariableBase CreateFrom(JsonVariable inSource)
        {
            switch (inSource) {
                case JsonTextureVariable texture:
                    return new TextureVariable();
            }
            return null;
        }

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

        protected override IEnumerable<Type> ReadableJsonClass => new Type[] { typeof(JsonVariable) };
        public override bool ReadJson(JsonDataObject inSource, JsonDataReadBuffer inBuffer, ILogger inLogger)
        {
            if (!base.ReadJson(inSource, inBuffer, inLogger)) {
                return false;
            }

            var src = inSource as JsonVariable;
            Name.Value = src.Name;
            return true;
        }

        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            (inDst as JsonVariable).Name = Name.Value;
            return;
        }
    }
}
