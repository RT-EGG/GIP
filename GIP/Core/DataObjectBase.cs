using System;
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

        public T ExportToJson<T>() where T : JsonDataObject
        {
            var result = ExportToJson();
            if (!(result is T)) {
                throw new InvalidCastException();
            }

            return result as T;
        }

        protected abstract JsonDataObject CreateJson();
        protected virtual void ExportToJson(JsonDataObject inDst)
        {
            inDst.GUID = GUID;
            return;
        }
    }
}
