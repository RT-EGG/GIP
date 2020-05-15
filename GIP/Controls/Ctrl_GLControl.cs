using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenTK;

namespace GIP.Controls
{
    public delegate void GLControlEvent(Ctrl_GLControl inControl);

    public partial class Ctrl_GLControl : GLControl
    {
        public Ctrl_GLControl()
        {
            InitializeComponent();

            m_ControlList.Add(this);
            return;
        }

        ~Ctrl_GLControl()
        {
            m_ControlList.Remove(this);
            return;
        }

        public static void MakeCurrentSomeone()
        {
            if (m_ControlList.Count > 0) {
                m_ControlList.First().MakeCurrent();
            }
            return;
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
        private static List<Ctrl_GLControl> m_ControlList = new List<Ctrl_GLControl>();

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
