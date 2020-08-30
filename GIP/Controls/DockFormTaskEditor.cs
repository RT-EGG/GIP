using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using GIP.Common;
using GIP.Core;

namespace GIP.Controls
{
    public partial class DockFormTaskEditor : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DockFormTaskEditor()
        {
            InitializeComponent();
            Task = null;
        }

        public Project Project
        {
            get => m_Project;
            set {
                if (m_Project == value) {
                    return;
                }

                m_ProjectSubscription.DisposeAndClear();
                m_Project = value;

                ComboShaderSource.Items.Clear();
                if (m_Project != null) {
                    Ctrl_UniformVariables.Variables = Project.Variables;

                    foreach (var source in m_Project.ComputeShaders) {
                        ComboShaderSource.Items.Add(new ComboShaderItem(ComboShaderSource, source));
                    }

                    m_ProjectSubscription.Add(m_Project.ComputeShaders.SubscribeCollectionChanged(ComputeShaderListChanged));
                } else {
                    Ctrl_UniformVariables.Variables = null;
                }
                return;
            }
        }

        public ComputeTask Task
        {
            get => m_Task;
            set {
                try {
                    if (m_Task == value) {
                        return;
                    }

                    foreach (var subscription in m_TaskSubscription) {
                        subscription.Dispose();
                    }
                    m_TaskSubscription.Clear();

                    m_Task = value;

                    if (m_Task != null) {
                        m_TaskSubscription.Add(m_Task.Name.Subscribe(n => TextBoxName.Text = n));
                        m_TaskSubscription.Add(m_Task.DispatchGroupSizeX.Subscribe(s => UdDispatchGroupSizeX.Value = s));
                        m_TaskSubscription.Add(m_Task.DispatchGroupSizeY.Subscribe(s => UdDispatchGroupSizeY.Value = s));
                        m_TaskSubscription.Add(m_Task.DispatchGroupSizeZ.Subscribe(s => UdDispatchGroupSizeZ.Value = s));
                    }

                    try {
                        TextBoxName.TextChanged -= TextBoxName_TextChanged;
                        UdDispatchGroupSizeX.ValueChanged -= OnUdDispatchGroupSizeChanged;
                        UdDispatchGroupSizeY.ValueChanged -= OnUdDispatchGroupSizeChanged;
                        UdDispatchGroupSizeZ.ValueChanged -= OnUdDispatchGroupSizeChanged;

                        TextBoxName.Text = (m_Task == null) ? "" : m_Task.Name.Value;
                        UdDispatchGroupSizeX.Value = (m_Task == null) ? 64 : m_Task.DispatchGroupSizeX.Value;
                        UdDispatchGroupSizeY.Value = (m_Task == null) ? 64 : m_Task.DispatchGroupSizeY.Value;
                        UdDispatchGroupSizeZ.Value = (m_Task == null) ? 1 : m_Task.DispatchGroupSizeZ.Value;

                    } finally {
                        TextBoxName.TextChanged += TextBoxName_TextChanged;
                        UdDispatchGroupSizeX.ValueChanged += OnUdDispatchGroupSizeChanged;
                        UdDispatchGroupSizeY.ValueChanged += OnUdDispatchGroupSizeChanged;
                        UdDispatchGroupSizeZ.ValueChanged += OnUdDispatchGroupSizeChanged;
                    }

                    Ctrl_UniformVariables.Data = (m_Task == null) ? null : m_Task.UniformVariables;

                } catch (Exception e) {
                    m_Task = null;
                    throw e;

                } finally {
                    this.Enabled = m_Task != null;
                }

                return;
            }
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            Task.Name.Value = TextBoxName.Text;
            return;
        }

        private void OnUdDispatchGroupSizeChanged(object sender, EventArgs e)
        {
            if (m_Task == null) {
                throw new NullReferenceException($"{nameof(m_Task)} is null.");
            }

            m_Task.DispatchGroupSizeX.Value = (int)Math.Truncate(UdDispatchGroupSizeX.Value + 0.5m);
            m_Task.DispatchGroupSizeY.Value = (int)Math.Truncate(UdDispatchGroupSizeY.Value + 0.5m);
            m_Task.DispatchGroupSizeZ.Value = (int)Math.Truncate(UdDispatchGroupSizeZ.Value + 0.5m);
            return;
        }

        private void ComboShaderSource_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (m_Task == null) {
                throw new NullReferenceException($"{nameof(m_Task)} is null.");
            }

            m_Task.Shader = (ComboShaderSource.SelectedItem == null) ? null : (ComboShaderSource.SelectedItem as ComboShaderItem).Shader;
            return;
        }

        private void ComputeShaderListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ComputeShader current = (ComboShaderSource.SelectedItem == null) ? null : (ComboShaderSource.SelectedItem as ComboShaderItem).Shader;

            ComboShaderSource.Items.Clear();
            foreach (var shader in m_Project.ComputeShaders) {
                ComboShaderSource.Items.Add(new ComboShaderItem(ComboShaderSource, shader));
                if (current == shader) {
                    ComboShaderSource.SelectedIndex = ComboShaderSource.Items.Count - 1;
                }
            }
            return;
        }

        protected override string GetPersistString()
        {
            return MainDockFormType.TaskEditor.ToPersistString();
        }

        private Project m_Project = null;
        private ComputeTask m_Task = null;

        private List<IDisposable> m_ProjectSubscription = new List<IDisposable>();
        private List<IDisposable> m_TaskSubscription = new List<IDisposable>();

        private class ComboShaderItem
        {
            public ComboShaderItem(ComboBox inOwner, ComputeShader inSource)
            {
                Owner = inOwner;
                Shader = inSource;

                Shader.FilePath.Subscribe(path => {
                    var index = inOwner.Items.IndexOf(this);
                    if (index >= 0) {
                        inOwner.Items[index] = this;
                    }
                });
                return;
            }

            public override string ToString()
            {
                return Path.GetFileNameWithoutExtension(Shader.FilePath.Value);
            }

            private ComboBox Owner
            { get; } = null;
            public ComputeShader Shader
            { get; } = null;
        }
    }
}
