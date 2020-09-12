using System;
using System.Windows.Forms;
using GIP.Core.Tasks;

namespace GIP.Controls
{
    public class TreeNodeProcessTask : TreeNode
    {
        public static TreeNodeProcessTask CreateNode(ProcessTask inTask)
        {
            switch (inTask) {
                case ProcessTaskSequence s:
                    return new TreeNodeTaskSequence(s);
                default:
                    return new TreeNodeProcessTask(inTask);
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
