using System.Windows.Forms;

namespace GIP.Common
{
    static class ListViewExtensions
    {
        public static void DeselectAll(this ListView inList)
        {
            foreach (ListViewItem item in inList.Items) {
                item.Selected = false;
            }
            return;
        }
    }
}
