using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL4;
using rtUtility.rtMath;
using GIP.Core;
using GIP.Common;
using GIP.Core.Variables;

namespace GIP.Controls.VariableValues
{
    public partial class Ctrl_TextureVariableView : Ctrl_VariableValueView
    {
        public Ctrl_TextureVariableView()
        {
            InitializeComponent();

            ComboFormat.Items.Clear();
            ComboFormat.Items.AddRange(con_SupportsTextureFormat);
            ComboFormat.SelectedIndex = 0;

            ComboDataType.Items.Clear();
            ComboDataType.Items.AddRange(con_SupportsTextureDataType);
            ComboDataType.SelectedIndex = 0;

            ComboSource.Items.Clear();
            ComboSource.Items.AddRange(con_TextureSourceType);
            ComboSource.SelectedIndex = 0;

            return;
        }

        public new TextureVariable Data
        {
            get => base.Data as TextureVariable;
            set => base.Data = value;
        }

        public override Type VariableType => typeof(TextureVariable);

        protected override void SetData(VariableBase inData)
        {
            base.SetData(inData);

            var data = inData as TextureVariable;

            m_IsDataSetting = true;
            try {
                if (Data == null) {
                    SetEnabledAll(false);
                } else {
                    SetEnabledAll(true);
                    //TextBoxName.Text = value.Name.Value;
                    ComboFormat.Select((object inItem) => {
                        return ((TexturePixelFormat)inItem).Format == data.Format.Value;
                    });
                    ComboDataType.Select((object inItem) => {
                        return ((TextureDataType)inItem).Type == data.DataType.Value;
                    });
                    if (data.PixelInitializer is TexturePixelInitializer.Color) {
                        SetColorInitializer(data.PixelInitializer as TexturePixelInitializer.Color);
                    } else if (data.PixelInitializer is TexturePixelInitializer.File) {
                        SetFileInitializer(data.PixelInitializer as TexturePixelInitializer.File);
                    }
                }
            } finally {
                m_IsDataSetting = false;
            }
            return;
        }

        private void SetColorInitializer(TexturePixelInitializer.Color inValue)
        {
            ComboSource.SelectedIndex = 0;
            UdColorInitializeAlpha.Value = (decimal)(inValue.Alpha * 100.0f);
            ButtonColorInitializeRGB.BackColor = inValue.RGB.ToSystemColor();
            return;
        }

        private void SetFileInitializer(TexturePixelInitializer.File inValue)
        {
            ComboSource.SelectedIndex = 1;
            TextBoxFileInitializePath.Text = inValue.Path;
            return;
        }

        protected override void SetEnabledAll(bool inEnabled)
        {
            base.SetEnabledAll(inEnabled);

            ComboFormat.Enabled = inEnabled;
            ComboDataType.Enabled = inEnabled;
            ComboSource.Enabled = inEnabled;
            ButtonColorInitializeRGB.Enabled = inEnabled;
            UdColorInitializeAlpha.Enabled = inEnabled;
            TextBoxFileInitializePath.Enabled = inEnabled;
            ButtonFileInitializeChoosePath.Enabled = inEnabled;
            return;
        }

        private void ComboFormat_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboFormat.SelectedItem != null) {
                UdColorInitializeAlpha.Enabled = (ComboFormat.SelectedItem as TexturePixelFormat).SupportsAlpha;
            }

            if ((!m_IsDataSetting) && (Data != null)) {
                Data.Format.Value = ((TexturePixelFormat)ComboFormat.SelectedItem).Format;
            }
            return;
        }

        private void ComboDataType_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((!m_IsDataSetting) && (Data != null)) {
                Data.DataType.Value = ((TextureDataType)ComboFormat.SelectedItem).Type;
            }
        }

        private void ComboSource_SelectedValueChanged(object sender, EventArgs e)
        {
            PanelSourceColorOptions.Visible = false;
            PanelSourceFileOptions.Visible = false;
            switch (ComboSource.SelectedIndex) {
                case 0:
                    PanelSourceColorOptions.Visible = true;
                    break;
                case 1:
                    PanelSourceFileOptions.Visible = true;
                    break;
            }

            if ((!m_IsDataSetting) && (Data != null)) {
                Data.PixelInitializer = ((TextureSourceType)ComboSource.SelectedItem).CreateInstance();
            }
            return;
        }

        private void ButtonColorInitializeRGB_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = ButtonColorInitializeRGB.BackColor;

            if (dialog.ShowDialog() == DialogResult.OK) {
                ButtonColorInitializeRGB.BackColor = dialog.Color;
                if (Data != null) {
                    (Data.PixelInitializer as TexturePixelInitializer.Color).RGB = new TColorRGB(dialog.Color);
                }
            }
            return;
        }

        private void UdColorInitializeAlpha_ValueChanged(object sender, EventArgs e)
        {
            if ((!m_IsDataSetting) && (Data != null)) {
                (Data.PixelInitializer as TexturePixelInitializer.Color).Alpha = ((float)UdColorInitializeAlpha.Value) * 0.01f;
            }
            return;
        }

        private bool m_IsDataSetting = false;

        private class TexturePixelFormat
        {
            public PixelInternalFormat Format;
            public string Text;
            public bool SupportsAlpha;

            public override string ToString()
            {
                return Text;
            }
        }

        private class TextureDataType
        {
            public PixelType Type;
            public string Text;

            public override string ToString()
            {
                return Text;
            }
        }

        private class TextureSourceType
        {
            public Type Type;
            public string Text;

            public TexturePixelInitializer CreateInstance()
            {
                return (TexturePixelInitializer)Activator.CreateInstance(Type);
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private readonly TexturePixelFormat[] con_SupportsTextureFormat = {
            new TexturePixelFormat{ Format = PixelInternalFormat.Rgb, Text = "RGB", SupportsAlpha = false },
            new TexturePixelFormat{ Format = PixelInternalFormat.Rgba, Text = "RGBA", SupportsAlpha = true }
        };

        private readonly TextureDataType[] con_SupportsTextureDataType = {
            new TextureDataType{ Type = PixelType.UnsignedByte, Text = "Unsigned byte" }
        };

        private readonly TextureSourceType[] con_TextureSourceType = {
            new TextureSourceType{ Type = typeof(TexturePixelInitializer.Color), Text = "Clear color" },
            new TextureSourceType{ Type = typeof(TexturePixelInitializer.File), Text = "Image file" }
        };
    }
}
