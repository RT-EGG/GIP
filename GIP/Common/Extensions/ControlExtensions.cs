using System;
using System.Windows.Forms;

namespace GIP.Common
{
    static class ControlExtensions
    {
        public static void InvokeOnUIThread(this Control inControl, Action inAction)
        {
            if (inControl.InvokeRequired) {
                inControl.Invoke((MethodInvoker)delegate { inAction(); });
            } else {
                inAction();
            }
            return;
        }
    }
}
