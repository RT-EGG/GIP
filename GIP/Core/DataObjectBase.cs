using System;
using System.Collections.Generic;
using GIP.Common;
using GIP.IO.Json;

namespace GIP.Core
{
    public interface IDataObjectBase
    {
        Guid GUID { get; }

        JsonDataObject ExportToJson();
        T ExportToJson<T>() where T : JsonDataObject;
    }

    public abstract class DataObjectBase : IDataObjectBase
    {
        public Guid GUID
        { get; private set; } = Guid.NewGuid();

        public JsonDataObject ExportToJson()
        {
            JsonDataObject result = CreateJson();
            ExportToJson(result);

            return result;
        }

        public virtual bool ReadJson(JsonDataObject inSource, JsonDataReadBuffer inBuffer, ILogger inLogger)
        {
            if (inSource == null) {
                throw new ArgumentNullException(nameof(inSource));
            }
            if (IsReadableJsonClass(inSource.GetType())) {
                inLogger.PushLog(this, new LogData(LogLevel.Error, $"{inSource.GetType()} is not readable for {GetType()}."));
                return false;
            }

            GUID = inSource.GUID;
            inBuffer.StoreData(this);
            return true;
        }

        public T ExportToJson<T>() where T : JsonDataObject
        {
            var result = ExportToJson();
            if (!(result is T)) {
                throw new InvalidCastException();
            }

            return result as T;
        }

        protected virtual void ExportToJson(JsonDataObject inDst)
        {
            inDst.GUID = GUID;
            return;
        }

        protected abstract JsonDataObject CreateJson();
        protected virtual IEnumerable<Type> ReadableJsonClass => new Type[] { typeof(JsonDataObject) };

        private bool IsReadableJsonClass(Type inType) => ReadableJsonClass.Any(t => t.IsAssignableFrom(inType));
    }
}
