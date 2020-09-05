using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GIP.Common;
using GIP.Core;
using GIP.Core.Task;

namespace GIP.Controls.ProcessTaskEditor
{
    public partial class Ctrl_ComputeTaskEditor : Ctrl_ProcessTaskEditor
    {
        public Ctrl_ComputeTaskEditor()
        {
            InitializeComponent();
        }

        public new ComputeTask Task
        {
            get => base.Task as ComputeTask;
            set => base.Task = value;
        }

        public override Type TaskType => typeof(ComputeTask);

        protected override IEnumerable<IDisposable> SetProject(Project inValue)
        {
            base.SetProject(inValue);

            Ctrl_UniformVariables.Variables = inValue.Variables;

            yield return inValue.ComputeShaders.SubscribeCollectionChanged(ComputeShaderCollectionChanged);
            CollectShaderSourceComboBox(Project.ComputeShaders);
            yield break;
        }

        protected override IEnumerable<IDisposable> SetData(ProcessTask inValue)
        {
            base.SetData(inValue);

            if (Task != null) {
                yield return Task.DispatchGroupSizeX.Subscribe(v => this.InvokeOnUIThread(() => UdDispatchGroupSizeX.Value = v));
                yield return Task.DispatchGroupSizeY.Subscribe(v => this.InvokeOnUIThread(() => UdDispatchGroupSizeY.Value = v));
                yield return Task.DispatchGroupSizeZ.Subscribe(v => this.InvokeOnUIThread(() => UdDispatchGroupSizeZ.Value = v));
            } else {
                UdDispatchGroupSizeX.Value = 0;
                UdDispatchGroupSizeY.Value = 0;
                UdDispatchGroupSizeZ.Value = 0;
            }

            yield break;
        }

        private void ComputeShaderCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectShaderSourceComboBox(Project.ComputeShaders);
            return;
        }

        private void UdDispatchGroupSizeX_ValueChanged(object sender, EventArgs e)
        {
            Task.DispatchGroupSizeX.Value = (int)UdDispatchGroupSizeX.Value;
            return;
        }

        private void UdDispatchGroupSizeY_ValueChanged(object sender, EventArgs e)
        {
            Task.DispatchGroupSizeY.Value = (int)UdDispatchGroupSizeY.Value;
            return;
        }

        private void UdDispatchGroupSizeZ_ValueChanged(object sender, EventArgs e)
        {
            Task.DispatchGroupSizeZ.Value = (int)UdDispatchGroupSizeZ.Value;
            return;
        }

        private void CollectShaderSourceComboBox(IEnumerable<ComputeShader> inShaders)
        {
            ComputeShader currentSource = null;
            if (ComboShaderSource.SelectedItem != null) {
                currentSource = (ComboShaderSource.SelectedItem as ComboShaderItem).Data;
            }

            ComboShaderSource.Items.Clear();
            foreach (var shader in inShaders) {
                ComboShaderSource.Items.Add(new ComboShaderItem(ComboShaderSource, shader));
            }

            if (currentSource != null) {
                ComboShaderSource.Select(s => (s as ComboShaderItem).Data == currentSource);
            }
            return;
        }

        private class ComboShaderItem
        {
            public ComboShaderItem(ComboBox inOwner, ComputeShader inData)
            {
                Owner = inOwner;
                Data = inData;

                Data.FilePath.Subscribe(p => {
                    // repaint item text
                    if (Owner.SelectedItem == this) {
                        Owner.Invalidate();
                    }
                });
                return;
            }

            private ComboBox Owner
            { get; } = null;
            public ComputeShader Data
            { get; } = null;

            public override string ToString()
            {
                return Path.GetFileName(Data.FilePath.Value);
            }
        }
    }
}
