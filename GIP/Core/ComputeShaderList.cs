using System;
using Reactive.Bindings;
using GIP.Common;

namespace GIP.Core
{
    public class ComputeShaderList : ReactiveCollection<ComputeShader>
    {
        protected override void InsertItem(int index, ComputeShader item)
        {
            if (Contains(item)) {
                throw new InvalidOperationException("Duplicate item.");
            }

            item.OnFileDeleted += Shader_OnFileDeleted;
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            this[index].OnFileDeleted -= Shader_OnFileDeleted;
            this[index].Dispose();
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, ComputeShader item)
        {
            base.SetItem(index, item);
        }

        protected override void ClearItems()
        {
            this.ForEach(s => {
                s.OnFileDeleted -= Shader_OnFileDeleted;
                s.Dispose();
            });

            base.ClearItems();
        }

        private void Shader_OnFileDeleted(ComputeShader inValue)
        {
            Remove(inValue);
            return;
        }
    }
}
