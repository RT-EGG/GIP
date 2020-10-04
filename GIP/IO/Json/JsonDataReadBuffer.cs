using System;
using System.Collections.Generic;
using GIP.Core;

namespace GIP.IO.Json
{
    public interface IJsonDataReferenceDictionary : IReadOnlyDictionary<Guid, DataObjectBase>
    {
        bool TryGetValueAs<T>(Guid inKey, out T outValue, ILogger inLogger) where T : class, IDataObjectBase;
    }
    public delegate void JsonReferenceComplementProc(IJsonDataReferenceDictionary inDictionary, ILogger inLogger);

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
        private JsonDataReferenceDictionary m_DataList = new JsonDataReferenceDictionary();
    }

    public class JsonDataReferenceDictionary : Dictionary<Guid, DataObjectBase>, IJsonDataReferenceDictionary
    {
        public bool TryGetValueAs<T>(Guid inKey, out T outValue, ILogger inLogger) where T : class, IDataObjectBase
        {
            outValue = null;

            if (TryGetValue(inKey, out var value)) {
                if (value is T) {
                    outValue = value as T;
                } else {
                    inLogger.PushLog(this, new LogData(LogLevel.Error, $"\"{inKey}\" is not guid of \"{typeof(T).Name}\"."));
                }
            } else {
                inLogger.PushLog(this, new LogData(LogLevel.Error, $"Shader \"{inKey}\" not found."));
            }
            return outValue != null;
        }
    }
}
