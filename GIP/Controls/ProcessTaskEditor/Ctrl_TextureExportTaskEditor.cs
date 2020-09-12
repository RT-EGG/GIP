using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Specialized;
using GIP.Common;
using GIP.Core;
using GIP.Core.Tasks;
using GIP.Core.Variables;

namespace GIP.Controls.ProcessTaskEditor
{
    public partial class Ctrl_TextureExportTaskEditor : Ctrl_ProcessTaskEditor
    {
        public Ctrl_TextureExportTaskEditor()
        {
            InitializeComponent();
        }

        public override Type TaskType => typeof(TextureExportTask);

        protected override IEnumerable<IDisposable> SetData(ProcessTask inValue)
        {
            foreach (var item in base.SetData(inValue)) {
                yield return item;
            }

            var src = inValue as TextureExportTask;
            yield return src.FilePath.Subscribe(p => TextBoxFilePath.Text = p);
            yield return src.Texture.Subscribe(t => ComboTexture.Select(i => (i as ComboTextureItem).Texture == t));
            yield return src.OverwriteIfExistAlready.Subscribe(o => CheckOverwriteExistFile.Checked = o);
            yield break;
        }

        protected override IEnumerable<IDisposable> SetProject(Project inValue)
        {
            foreach (var item in base.SetProject(inValue)) {
                yield return item;
            }

            yield return inValue.Variables.SubscribeCollectionChanged(VariableCollectionChanged);
            CollectTextureVariables(inValue.Variables);
            yield break;
        }

        private void VariableCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectTextureVariables(Project?.Variables);
            return;
        }

        private void CollectTextureVariables(IEnumerable<VariableBase> inVariables)
        {
            TextureVariable current = null;
            if (ComboTexture.SelectedItem != null) {
                current = (ComboTexture.SelectedItem as ComboTextureItem).Texture;
            }

            ComboTexture.Items.Clear();
            foreach (var variable in inVariables) {
                if (variable is TextureVariable) {
                    ComboTexture.Items.Add(new ComboTextureItem(ComboTexture, variable as TextureVariable));
                }
            }

            if (current != null) {
                ComboTexture.Select(s => (s as ComboTextureItem).Texture == current);
            }
            return;
        }

        private void ButtonChooseFilePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "image file (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
            dialog.FilterIndex = 0;

            if (dialog.ShowDialog() == DialogResult.OK) {
                TextBoxFilePath.Text = dialog.FileName;
            }
            return;
        }

        private void TextBoxFilePath_TextChanged(object sender, EventArgs e)
        {
            Task.FilePath.Value = TextBoxFilePath.Text;
            return;
        }

        private void ComboTexture_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ComboTexture.SelectedItem == null) {
                Task.Texture.Value = null;
            } else {
                Task.Texture.Value = (ComboTexture.SelectedItem as ComboTextureItem).Texture;
            }
            return;
        }

        private void CheckOverwriteExistFile_CheckedChanged(object sender, EventArgs e)
        {
            Task.OverwriteIfExistAlready.Value = CheckOverwriteExistFile.Checked;
            return;
        }

        private new TextureExportTask Task => base.Task as TextureExportTask;

        private class ComboTextureItem
        {
            public ComboTextureItem(ComboBox inOwner, TextureVariable inTexture)
            {
                Owner = inOwner;
                Texture = inTexture;

                Texture.Name.Subscribe(name => {
                    var index = Owner.Items.IndexOf(this);
                    if (index > 0) {
                        Owner.Items[index] = this;
                    }
                });

                return;
            }

            public override string ToString() => Texture.Name.Value;

            private ComboBox Owner
            { get; } = null;
            public TextureVariable Texture
            { get; } = null;
        }
    }
}
