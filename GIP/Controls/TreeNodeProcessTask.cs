using System;
using System.Windows.Forms;
using GIP.Core;

namespace GIP.Controls
{
    public abstract class TreeNodeProcessTask : TreeNode
    {
        public static TreeNodeProcessTask CreateNode(ProcessTask inTask)
        {
            switch (inTask) {
                case ComputeTask c:
                    return new TreeNodeComputeTask(c);
                case ProcessTaskSequence s:
                    return new TreeNodeTaskSequence(s);
            }

            throw new NotSupportedException($"{inTask.GetType().Name}.");
        }

        public TreeNodeProcessTask(ProcessTask inData)
        {
            Data = inData;
            Data.Name.Subscribe(s => Text = s);
            return;
        }

        public ProcessTask Data
        { get; } = null;
    }
}
