using System;
using System.Collections.Generic;
using System.IO;

namespace GIP.Common
{
    interface IFileModificationReactioner
    {
        void OnFileChanged(FileSystemEventArgs inArgs);
        void OnFileDeleted(FileSystemEventArgs inArgs);
        void OnFileRenamed(RenamedEventArgs inArgs);
    }

    interface IFileCreationReactioner
    {
        void OnFileCreated(FileSystemEventArgs inArgs);
    }

    static class FileModificationMonitor
    {
        public static void AddModificationReactioner(string inPath, IFileModificationReactioner inValue)
        {
            var monitor = FindOrCreateMonitor(Path.GetDirectoryName(inPath));
            monitor.AddModificationReactioner(inPath, inValue);
            return;
        }

        public static void RemoveModificationReactioner(string inPath, IFileModificationReactioner inValue)
        {
            var monitor = FindOrCreateMonitor(Path.GetDirectoryName(inPath));

            monitor.RemoveModificationReactioner(inValue);
            if (monitor.Empty) {
                monitor.Dispose();
                m_Monitors.Remove(monitor);
            }
            return;
        }

        public static void AddCreationRaactioner(string inPath, IFileCreationReactioner inValue)
        {
            var monitor = FindOrCreateMonitor(inPath);
            monitor.AddCreationReactioner(inValue);
            return;
        }

        public static void RemoveCreateionReactioner(string inPath, IFileCreationReactioner inValue)
        {
            var monitor = FindOrCreateMonitor(inPath);

            monitor.RemoveCreationReactioner(inValue);
            if (monitor.Empty) {
                monitor.Dispose();
                m_Monitors.Remove(monitor);
            }
            return;
        }

        private static DirectoryMonitor FindOrCreateMonitor(string inDirectoryPath)
        {
            if (!m_Monitors.TryGetFirst(out var result, m => m.DirectoryPath == inDirectoryPath)) {
                result = new DirectoryMonitor(inDirectoryPath);
                m_Monitors.Add(result);
            }
            return result;
        }

        private static List<DirectoryMonitor> m_Monitors = new List<DirectoryMonitor>();

        private class DirectoryMonitor : IDisposable
        {
            public DirectoryMonitor(string inPath)
            {
                DirectoryPath = inPath;

                m_Watcher = new FileSystemWatcher(inPath);
                m_Watcher.IncludeSubdirectories = false;
                m_Watcher.NotifyFilter = NotifyFilters.LastWrite
                                       | NotifyFilters.FileName
                                       | NotifyFilters.DirectoryName
                                       | NotifyFilters.CreationTime;
                m_Watcher.Changed += Watcher_Changed;
                m_Watcher.Created += Watcher_Created;
                m_Watcher.Deleted += Watcher_Deleted;
                m_Watcher.Renamed += Watcher_Renamed;
                m_Watcher.EnableRaisingEvents = true;
                return;
            }

            public void AddModificationReactioner(string inFullPath, IFileModificationReactioner inValue)
            {
                m_ModificationReactionerList.Add(inFullPath, inValue);
                return;
            }

            public void RemoveModificationReactioner(IFileModificationReactioner inValue)
            {
                foreach (var entry in m_ModificationReactionerList.TryGetAll(e => e.Value == inValue)) {
                    m_ModificationReactionerList.Remove(entry.Key);
                }
                return;
            }

            public void AddCreationReactioner(IFileCreationReactioner inValue)
            {
                m_CreationReactionerList.Add(inValue);
                return;
            }

            public void RemoveCreationReactioner(IFileCreationReactioner inValue)
            {
                m_CreationReactionerList.RemoveAll(r => r.Equals(inValue));
                return;
            }

            public bool Empty => (m_ModificationReactionerList.Count == 0) && (m_CreationReactionerList.Count == 0);

            private void Watcher_Changed(object sender, FileSystemEventArgs e)
            {   
                if (m_ModificationReactionerList.TryGetValue(e.FullPath, out var reactioner)) {
                    reactioner.OnFileChanged(e);
                }
                return;
            }

            private void Watcher_Created(object sender, FileSystemEventArgs e)
            {
                foreach (var reactioner in m_CreationReactionerList) {
                    reactioner.OnFileCreated(e);
                }
                return;
            }

            private void Watcher_Deleted(object sender, FileSystemEventArgs e)
            {
                if (m_ModificationReactionerList.TryGetValue(e.FullPath, out var reactioner)) {
                    reactioner.OnFileDeleted(e);
                }
                return;
            }

            private void Watcher_Renamed(object sender, RenamedEventArgs e)
            {
                if (m_ModificationReactionerList.TryGetValue(e.OldFullPath, out var reactioner)) {
                    reactioner.OnFileRenamed(e);
                }
                return;
            }

            public void Dispose()
            {
                if (m_Watcher != null) {
                    m_Watcher.Dispose();
                    m_Watcher = null;
                }
                return;
            }

            public string DirectoryPath
            { get; } = "";

            private Dictionary<string, IFileModificationReactioner> m_ModificationReactionerList = new Dictionary<string, IFileModificationReactioner>();
            private List<IFileCreationReactioner> m_CreationReactionerList = new List<IFileCreationReactioner>();
            private FileSystemWatcher m_Watcher = null;
        }
    }
}
