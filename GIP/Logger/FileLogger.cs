using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace GIP
{
    public class FileLogger : ILogger, IDisposable
    {
        public FileLogger(string inFilePath)
        {
            string directory = Path.GetDirectoryName(inFilePath);
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }

            m_WriteTask = Task.Run(() => {
                using (StreamWriter writer = new StreamWriter(new FileStream(inFilePath, FileMode.OpenOrCreate, FileAccess.Write))) {
                    while (!m_Terminated) {
                        if (m_Buffer.Count > 0) {
                            lock (m_Buffer) {
                                while (m_Buffer.Count > 0) {
                                    writer.WriteLine(m_Buffer.Dequeue());
                                }
                                writer.Flush();
                            }
                        }
                        System.Threading.Thread.Sleep(1);
                    }
                }
                return;
            });
            return;
        }

        public void ClearLog(object inSource)
        {
            return;
        }

        public void PushLog(object inSource, LogData inData)
        {
            List<string> lines = new List<string>(inData.Message.Split(new string[]{ Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            lock (m_Buffer) {
                foreach (var line in lines) {
                    m_Buffer.Enqueue(line);
                }
            }
            return;
        }

        public void Dispose()
        {
            m_Terminated = true;
            if (m_WriteTask != null) {
                m_WriteTask.Wait();
                m_WriteTask = null;
            }
            return;
        }

        private Task m_WriteTask = null;
        private bool m_Terminated = false;
        private Queue<string> m_Buffer = new Queue<string>();
    }
}
