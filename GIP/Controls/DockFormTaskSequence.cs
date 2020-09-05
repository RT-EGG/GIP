using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GIP.Core;
using GIP.Core.Task;

namespace GIP.Controls
{
    public partial class DockFormTaskSequence : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public event ProcessTaskNotifyEvent OnTaskSelected;

        public DockFormTaskSequence()
        {
            InitializeComponent();
            Project = null;
            return;
        }

        public async Task RunSequence()
        {
            ProcessTaskSequenceRunner runner = new ProcessTaskSequenceRunner(m_Project);
            runner.Run(m_Project.TaskSequence, Logger.DefaultLogger);
            return;
        }

        public Project Project
        {
            get => m_Project;
            set {
                try {
                    if (m_Project == value) {
                        return;
                    }

                    m_Project = value;

                    tvTaskSequence.Nodes.Clear();
                    if (m_Project != null) {
                        tvTaskSequence.Nodes.Add(new TreeNodeTaskSequence(m_Project.TaskSequence));
                    }

                } catch (Exception e) {
                    m_Project = null;
                    throw e;
                    
                } finally {
                    this.Enabled = m_Project != null;
                }
            }
        }

        public TreeNode GetNodeFor(ProcessTask inTask)
        {
            return GetNodeFor(inTask, tvTaskSequence.Nodes[0]);
        }

        private TreeNode GetNodeFor(ProcessTask inTask, TreeNode inNode)
        {
            if (!(inNode is TreeNodeProcessTask)) {
                throw new InvalidProgramException("Node must be TreeNodeProcessTask.");
            }
            if ((inNode as TreeNodeProcessTask).Data == inTask) {
                return inNode;
            }

            foreach (TreeNode child in inNode.Nodes) {
                TreeNode node = GetNodeFor(inTask, child);
                if (node != null) {
                    return node;
                }
            }
            return null;
        }

        protected override string GetPersistString()
        {
            return MainDockFormType.TaskSequence.ToPersistString();
        }

        private void AddTask(ProcessTask inNewTask, ProcessTaskSequence inParent, int inIndex = -1)
        {
            if (inIndex == -1) {
                inParent.Add(inNewTask);
            } else {
                inParent.Insert(inIndex, inNewTask);
            }

            var parentNode = GetNodeFor(inParent);
            if (!parentNode.IsExpanded) {
                parentNode.Expand();
            }

            var node = GetNodeFor(inNewTask);
            tvTaskSequence.SelectedNode = node;
            return;
        }

        private void tvTaskSequence_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!(e.Node is TreeNodeProcessTask)) {
                throw new InvalidProgramException("Node of task sequence must be TreeNodeProcessTask.");
            }

            OnTaskSelected?.Invoke((e.Node as TreeNodeProcessTask).Data);
            return;
        }

        private void MenuItem_NewComputeTask_Click(object sender, EventArgs e)
        {
            if (!(tvTaskSequence.SelectedNode is TreeNodeTaskSequence)) {
                throw new InvalidProgramException("TreeNodeTaskSequence must be selected.");
            }

            TreeNodeTaskSequence sequenceNode = (tvTaskSequence.SelectedNode as TreeNodeTaskSequence);
            AddTask(new ComputeTask(), (tvTaskSequence.SelectedNode as TreeNodeTaskSequence).Data);
            return;
        }

        private void MenuItem_InsertNewComputeTask_Click(object sender, EventArgs e)
        {
            if (tvTaskSequence.SelectedNode == tvTaskSequence.Nodes[0]) {
                throw new InvalidProgramException("First node of tree must not be selected.");
            }
            if (!(tvTaskSequence.SelectedNode.Parent is TreeNodeTaskSequence)) {
                throw new InvalidProgramException("Parent of selected node must be TreeNodeTaskSequence.");
            }

            AddTask(new ComputeTask(), (tvTaskSequence.SelectedNode.Parent as TreeNodeTaskSequence).Data, tvTaskSequence.SelectedNode.Index);
            return;
        }

        private void MenuItem_Delete_Click(object sender, EventArgs e)
        {
            if (tvTaskSequence.SelectedNode == tvTaskSequence.Nodes[0]) {
                throw new InvalidProgramException("First node of tree must not be selected.");
            }

            if (!(tvTaskSequence.SelectedNode.Parent is TreeNodeTaskSequence)) {
                throw new InvalidProgramException("Parent of selected node must be TreeNodeTaskSequence.");
            }

            (tvTaskSequence.SelectedNode.Parent as TreeNodeTaskSequence).Data.RemoveAt(tvTaskSequence.SelectedNode.Index);
            return;
        }

        private void tvTaskSequence_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Button) {
                case MouseButtons.Right:
                    tvTaskSequence.SelectedNode = e.Node;
                    RequestTreeViewPopup(tvTaskSequence.PointToScreen(e.Location), e.Node);
                    break;
            }
            return;
        }

        private void RequestTreeViewPopup(Point inLocation, TreeNode inNode)
        {
            MenuItem_NewComputeTask.Visible = inNode is TreeNodeTaskSequence;
            MenuItem_InsertNewComputeTask.Visible = inNode != tvTaskSequence.Nodes[0];
            MenuItem_Delete.Visible = inNode != tvTaskSequence.Nodes[0];
            MenuTreeNodePopup.Show(inLocation);
            return;
        }

        private async void ButtonRunSequence_Click(object sender, EventArgs e)
        {
            await RunSequence();
            return;
        }

        private Project m_Project = null;
    }
}
