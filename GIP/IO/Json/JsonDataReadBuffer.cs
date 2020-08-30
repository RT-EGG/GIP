using System;
using System.Collections.Generic;
using GIP.Core;

namespace GIP.IO.Json
{
    public delegate void JsonReferenceComplementProc(IReadOnlyDictionary<Guid, DataObjectBase> inDictionary, ILogger inLogger);

    public class JsonDataReadBuffer
    {
        public T StoreData<T>(T inData) where T : DataObjectBase
        {
            m_DataList.Add(inData.GUID, inData);
            return inData;
        }

        public void RegisterComplementTask(JsonReferenceComplementProc inTask)
        {
            m_TaskAfterImport.Enqueue(inTask);
            return;
        }

        public void ProcessComplementation(ILogger inLogger)
        {
            while (m_TaskAfterImport.Count > 0) {
                m_TaskAfterImport.Dequeue()(m_DataList, inLogger);
            }
            return;
        }

        private Queue<JsonReferenceComplementProc> m_TaskAfterImport = new Queue<JsonReferenceComplementProc>();
        private Dictionary<Guid, DataObjectBase> m_DataList = new Dictionary<Guid, DataObjectBase>();        
    }
}
