using System.Linq;
using WeifenLuo.WinFormsUI.Docking;

namespace GIP.Common
{
    public static class DockPanelSuiteExtensions
    {
        public static bool IsAutoHiding(this DockContent inContent)
        {
            return con_AutoHideState.Contains(inContent.DockState);
        }

        private static readonly DockState[] con_AutoHideState = {
            DockState.DockTopAutoHide,
            DockState.DockBottomAutoHide,
            DockState.DockLeftAutoHide,
            DockState.DockRightAutoHide
        };
    }
}
