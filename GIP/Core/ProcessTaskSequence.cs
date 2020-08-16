using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Reactive.Bindings;
using GIP.Common;
using GIP.IO.Json;
using GIP.IO.Project;

namespace GIP.Core
{
    public class ProcessTaskSequence : ProcessTask, IList<ProcessTask>, IReadOnlyList<ProcessTask>, IEnumerable<ProcessTask>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public override bool Execute(ILogger inLogger)
        {
            foreach (var task in this) {
                inLogger.PushLog(this, new LogData(LogLevel.Error, $"Run task \"{task.Name.Value}\"."));
                if (!task.Execute(inLogger)) {
                    return false;
                }
            }
            return true;
        }

        private ReactiveCollection<ProcessTask> m_Sequence = new ReactiveCollection<ProcessTask>();

        public ProcessTask this[int index] { get => ((IList<ProcessTask>)m_Sequence)[index]; set => ((IList<ProcessTask>)m_Sequence)[index] = value; }

        public int Count => ((IList<ProcessTask>)m_Sequence).Count;

        public bool IsReadOnly => ((IList<ProcessTask>)m_Sequence).IsReadOnly;

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add {
                ((INotifyCollectionChanged)m_Sequence).CollectionChanged += value;
            }

            remove {
                ((INotifyCollectionChanged)m_Sequence).CollectionChanged -= value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add {
                ((INotifyPropertyChanged)m_Sequence).PropertyChanged += value;
            }

            remove {
                ((INotifyPropertyChanged)m_Sequence).PropertyChanged -= value;
            }
        }

        public void Add(ProcessTask item)
        {
            ((IList<ProcessTask>)m_Sequence).Add(item);
        }

        public void Clear()
        {
            ((IList<ProcessTask>)m_Sequence).Clear();
        }

        public bool Contains(ProcessTask item)
        {
            return ((IList<ProcessTask>)m_Sequence).Contains(item);
        }

        public void CopyTo(ProcessTask[] array, int arrayIndex)
        {
            ((IList<ProcessTask>)m_Sequence).CopyTo(array, arrayIndex);
        }

        public IEnumerator<ProcessTask> GetEnumerator()
        {
            return ((IEnumerable<ProcessTask>)m_Sequence).GetEnumerator();
        }

        public int IndexOf(ProcessTask item)
        {
            return ((IList<ProcessTask>)m_Sequence).IndexOf(item);
        }

        public void Insert(int index, ProcessTask item)
        {
            ((IList<ProcessTask>)m_Sequence).Insert(index, item);
        }

        public bool Remove(ProcessTask item)
        {
            return ((IList<ProcessTask>)m_Sequence).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<ProcessTask>)m_Sequence).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<ProcessTask>)m_Sequence).GetEnumerator();
        }

        protected override JsonDataObject CreateJson() => new JsonTaskSequence();
        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            var dst = inDst as JsonTaskSequence;
            this.ForEach(t => dst.Tasks.Add(t.ExportToJson<JsonProcessTask>()));
            return;
        }
    }
}
