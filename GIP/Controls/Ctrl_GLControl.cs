using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace GIP.Controls
{
    public delegate void GLControlEvent(Ctrl_GLControl inControl);

    public partial class Ctrl_GLControl : GLControl
    {
        public Ctrl_GLControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if ((Width <= 0) || (Height <= 0)) {
                return;
            }
            if (DesignMode) {
                e.Graphics.Clear(Color.Black);
                return;
            }

            MakeCurrent();
            OnGLPaint?.Invoke(this);

            SwapBuffers();
            return;
        }

        public event GLControlEvent OnGLPaint;

        public new bool DesignMode => GetDesignMode(this);
        private bool GetDesignMode(Control inControl)
        {
            if (inControl == null) {
                return false;
            }

            bool mode = inControl.Site == null ? false : inControl.Site.DesignMode;
            return mode | GetDesignMode(inControl.Parent);
        }
    }
}
