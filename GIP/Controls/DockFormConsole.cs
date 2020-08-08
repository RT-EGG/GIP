using GIP.Common;

namespace GIP.Controls
{
    public partial class DockFormConsole : WeifenLuo.WinFormsUI.Docking.DockContent, ILogger
    {
        public DockFormConsole()
        {
            InitializeComponent();
        }

        public void PushLog(object inSource, LogData logData)
        {
            ConsoleText += logData.Message;
            return;
        }

        public void ClearLog(object inSource)
        {
            TextBoxState.Text = "";
            return;
        }

        public string ConsoleText
        {
            get => TextBoxState.Text;
            set => this.InvokeOnUIThread(() => TextBoxState.Text = value);
        }

        protected override string GetPersistString()
        {
            return MainDockFormType.Console.ToPersistString();
        }
    }
}
