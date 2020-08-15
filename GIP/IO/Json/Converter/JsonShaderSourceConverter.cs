using Newtonsoft.Json;
using GIP.IO.Project;

namespace GIP.IO.Json.Converter
{
    class JsonShaderSourceConverter : JsonConverter<JsonShaderSource>
    {
        protected override JsonShaderSource GenerateObject(string inSubClassIdentifier)
        {
            switch (inSubClassIdentifier) {
                case "Text":
                    return new JsonShaderTextSource();
                default:
                    throw new JsonReaderException();
            }
        }
    }
}
