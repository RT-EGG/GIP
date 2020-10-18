using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GIP.Common
{
    public interface IPathExistenceWatchReactioner
    {
        void OnDelete(string inPath);
        void OnRestore(string inPath);
    }

    public class PathExistenceWatcher
    {
        static PathExistenceWatcher m_Singleton = null;
        public static PathExistenceWatcher Singleton
        {
            get {
                if (m_Singleton == null) {
                    m_Singleton = new PathExistenceWatcher();
                }
                return m_Singleton;
            }
        }

        public PathExistenceWatcher()
        {
            Task.Run(() => {
                m_Terminated = false;
                while (!m_Terminated) {
                    lock (m_Items) {
                        foreach (var item in m_Items) {
                            bool exist = Directory.Exists(item.Key) | File.Exists(item.Key);
                            if (item.Value.Exist != exist) {
                                item.Value.Exist = exist;
                                item.Value.ReactionerList.ForEach(reactioner => {
                                    if (exist) {
                                        reactioner.OnRestore(item.Key);
                                    } else {
                                        reactioner.OnDelete(item.Key);
                                    }
                                });
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(100);
                }
            });
            return;
        }

        ~PathExistenceWatcher()
        {
            m_Terminated = true;
            return;
        }

        public void RegisterWatcher(string inPath, IPathExistenceWatchReactioner inReactioner)
        {
            lock (m_Items) {
                if (!m_Items.TryGetValue(inPath, out var item)) {
                    item = new WatchItem();
                    m_Items.Add(inPath, item);
                }
                item.Exist = Directory.Exists(inPath) | File.Exists(inPath);
                item.ReactionerList.Add(inReactioner);

                if (item.Exist) {
                    inReactioner.OnRestore(inPath);
                } else {
                    inReactioner.OnDelete(inPath);
                }
            }
            return;
        }

        public void UnregisterWatcher(string inPath, IPathExistenceWatchReactioner inReactioner)
        {
            lock (m_Items) {
                if (m_Items.TryGetValue(inPath, out var item)) {
                    item.ReactionerList.RemoveAll(a => a == inReactioner);
                    if (item.ReactionerList.Empty()) {
                        m_Items.Remove(inPath);
                    }
                }
            }
            return;
        }

        private bool m_Terminated = false;
        private Dictionary<string, WatchItem> m_Items = new Dictionary<string, WatchItem>();
        private class WatchItem
        {
            public bool Exist = false;
            public List<IPathExistenceWatchReactioner> ReactionerList = new List<IPathExistenceWatchReactioner>();
        }
    }
}
