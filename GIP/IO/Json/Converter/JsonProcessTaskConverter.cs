using Newtonsoft.Json;
using GIP.IO.Project;

namespace GIP.IO.Json.Converter
{
    class JsonProcessTaskConverter : JsonConverter<JsonProcessTask>
    {
        protected override JsonProcessTask GenerateObject(string inSubClassIdentifier)
        {
            switch (inSubClassIdentifier) {
                case "Compute":
                    return new JsonComputeTask();
                case "TextureExport":
                    return new JsonTextureExportTask();
                case "Sequence":
                    return new JsonTaskSequence();
                case "CountingFor":
                    return new JsonTaskSequenceCountingForLoop();
                default:
                    throw new JsonReaderException();
            }
        }
    }
}
