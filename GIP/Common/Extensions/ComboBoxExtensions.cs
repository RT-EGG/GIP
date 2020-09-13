using System;
using System.Windows.Forms;

namespace GIP.Common
{
    static class ComboBoxExtensions
    {
        public static bool Select(this ComboBox inCombo, Func<object, bool> inCondition)
        {
            foreach (object item in inCombo.Items) {
                if (inCondition(item)) {
                    inCombo.SelectedItem = item;
                    return true;
                }
            }
            return false;
        }
    }
}
