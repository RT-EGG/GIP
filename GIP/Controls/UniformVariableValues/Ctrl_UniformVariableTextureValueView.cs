﻿using System;
using System.Data;
using System.Linq;
using System.Collections.Specialized;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL4;
using GIP.Common;
using GIP.Core;
using GIP.Core.Uniforms;
using GIP.Core.Variables;

namespace GIP.Controls.UniformVariableValues
{
    public partial class Ctrl_UniformVariableTextureValueView : Ctrl_UniformVariableValueView
    {
        public Ctrl_UniformVariableTextureValueView()
        {
            InitializeComponent();

            ComboTextureAccess.Items.Clear();
            ComboTextureAccess.Items.Add(new TextureAccessItem { Text = "ReadOnly", Access = TextureAccess.ReadOnly });
            ComboTextureAccess.Items.Add(new TextureAccessItem { Text = "WriteOnly", Access = TextureAccess.WriteOnly });
            ComboTextureAccess.Items.Add(new TextureAccessItem { Text = "ReadWrite", Access = TextureAccess.ReadWrite });

            ComboInternalFormat.Items.Clear();
            ComboInternalFormat.Items.Add(new TextureInternalFormatItem { Text = "Rgba8", Format = SizedInternalFormat.Rgba8 });

            return;
        }

        public override void SetEnabled(bool inEnabled)
        {
            base.SetEnabled(inEnabled);

            ComboTexture.Enabled = inEnabled;
            return;
        }

        protected override void DoVariableCollectionChanged()
        {
            base.DoVariableCollectionChanged();

            UpdateTextureCombobox();
            return;
        }

        protected override void SetData(UniformVariableValue inValue)
        {
            base.SetData(inValue);

            if (m_Data == inValue) {
                return;
            }
            if (inValue == null) {
                m_Data = null;
                return;
            }
            if (!(inValue is UniformVariableTextureValue)) {
                throw new NotSupportedException($"{GetType().Name} not supports {inValue.GetType().Name}.");
            }

            m_Data = inValue as UniformVariableTextureValue;
            ComboTexture.Select((object inItem) => {
                return (inItem as TextureNameItem).Texture == m_Data.Texture.Value;
            });
            ComboTextureAccess.Select((object inItem) => {
                return (inItem as TextureAccessItem).Access == m_Data.Access.Value;
            });
            ComboInternalFormat.Select((object inItem) => {
                return (inItem as TextureInternalFormatItem).Format == m_Data.InternalFormat.Value;
            });

            return;
        }

        private void UpdateTextureCombobox()
        {
            ComboTexture.Items.Clear();
            if (Variables == null) {
                return;
            }

            foreach (var variable in Variables) {
                if (variable is TextureVariable) {
                    ComboTexture.Items.Add(new TextureNameItem(ComboTexture, variable as TextureVariable));
                }
            }
            ComboTexture.Select((object inItem) => {
                return (m_Data != null) && (m_Data.Texture.Value == (inItem as TextureNameItem).Texture);
            });
            return;
        }

        private void ComboTexture_SelectedValueChanged(object sender, EventArgs e)
        {
            if (m_Data == null) {
                return;
            }

            m_Data.Texture.Value = (ComboTexture.SelectedItem == null) ?
                    null : (ComboTexture.SelectedItem as TextureNameItem).Texture;
            return;
        }

        private void ComboTextureAccess_SelectedValueChanged(object sender, EventArgs e)
        {
            if (m_Data == null) {
                return;
            }

            m_Data.Access.Value = (ComboTextureAccess.SelectedItem == null) ?
                TextureAccess.ReadOnly : (ComboTextureAccess.SelectedItem as TextureAccessItem).Access;
            return;
        }

        private void ComboInternalFormat_SelectedValueChanged(object sender, EventArgs e)
        {
            if (m_Data == null) {
                return;
            }

            m_Data.InternalFormat.Value = (ComboInternalFormat.SelectedItem == null) ?
                SizedInternalFormat.Rgba8 : (ComboInternalFormat.SelectedItem as TextureInternalFormatItem).Format;
            return;
        }

        private UniformVariableTextureValue m_Data = null;

        private class TextureNameItem
        {
            public TextureNameItem(ComboBox inOwner, TextureVariable inTexture)
            {
                Owner = inOwner;
                Texture = inTexture;

                Texture.Name.Subscribe(_ => {
                    int index = Owner.Items.IndexOf(this);
                    if (index >= 0) {
                        Owner.Items[index] = this;
                    }
                });
                return;
            }

            public ComboBox Owner
            { get; } = null;
            public TextureVariable Texture
            { get; } = null;

            public override string ToString()
            {
                return Texture.Name.Value;
            }
        }

        private class TextureAccessItem
        {
            public string Text
            { get; set; } = "";
            public TextureAccess Access
            { get; set; } = TextureAccess.ReadWrite;

            public override string ToString()
            {
                return Text;
            }
        }

        private class TextureInternalFormatItem
        {
            public string Text
            { get; set; } = "";
            public SizedInternalFormat Format
            { get; set; } = SizedInternalFormat.Rgba8;

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
