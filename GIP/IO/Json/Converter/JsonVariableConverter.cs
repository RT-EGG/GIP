using Newtonsoft.Json;
using GIP.IO.Project;

namespace GIP.IO.Json.Converter
{
    class JsonVariableConverter : JsonConverter<JsonVariable>
    {
        protected override JsonVariable GenerateObject(string inSubClassIdentifier)
        {
            switch (inSubClassIdentifier) {
                case "Texture":
                    return new JsonTextureVariable();
                default:
                    throw new JsonReaderException();
            }
        }
    }
}
