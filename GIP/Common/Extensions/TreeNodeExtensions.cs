using System.Collections.Generic;
using System.Windows.Forms;

namespace GIP.Common
{
    public static class TreeNodeExtensions
    {
        public static TreeNode First(this TreeNodeCollection inNodes, string inText, bool inSearchAllChildren)
        {
            var nodes = inNodes.Find(inText, inSearchAllChildren);
            if (nodes.Length > 0) {
                return nodes[0];
            }
            return null;
        }

        public static IEnumerable<TreeNode> FindByText(this TreeNodeCollection inNodes, string inText, bool inSearchAllChildren)
        {
            foreach (TreeNode child in inNodes) {
                if (child.Text == inText) {
                    yield return child;
                }

                if (inSearchAllChildren) {
                    foreach (var descendant in child.Nodes.FindByText(inText, inSearchAllChildren)) {
                        yield return descendant;
                    }
                }
            }
            yield break;
        }
    }
}
