using System;
using System.Collections.Generic;
using GIP.Core.Tasks;

namespace GIP.Controls.ProcessTaskEditor
{
    public partial class Ctrl_CountingForLoopTaskEditor : Ctrl_ProcessTaskEditor
    {
        public Ctrl_CountingForLoopTaskEditor()
        {
            InitializeComponent();
        }

        public override Type TaskType => typeof(ProcessTaskSequenceCountingForLoop);

        protected override IEnumerable<IDisposable> SetData(ProcessTask inValue)
        {
            List<IDisposable> result = new List<IDisposable>(base.SetData(inValue));
            result.Capacity += 1;

            var value = inValue as ProcessTaskSequenceCountingForLoop;
            if (value == null) {
                UdMaxLoopCount.Value = 1;
            } else {
                result.Add(value.MaxLoopCount.Subscribe(v => UdMaxLoopCount.Value = v));
            }
            return result;
        }

        private void UdMaxLoopCount_ValueChanged(object sender, EventArgs e)
        {
            if (Task != null) {
                (Task as ProcessTaskSequenceCountingForLoop).MaxLoopCount.Value = (int)UdMaxLoopCount.Value;
            }
            return;
        }
    }
}
