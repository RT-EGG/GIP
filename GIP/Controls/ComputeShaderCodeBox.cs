using System.ComponentModel;
using System.Windows.Forms;

namespace GIP.Controls
{
    public partial class ComputeShaderCodeBox : TextBox
    {
        public ComputeShaderCodeBox()
        {
            InitializeComponent();

            return;
        }

        public ComputeShaderCodeBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
