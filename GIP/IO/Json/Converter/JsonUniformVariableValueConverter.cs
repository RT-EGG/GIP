using Newtonsoft.Json;
using GIP.IO.Project;

namespace GIP.IO.Json.Converter
{
    class JsonUniformVariableValueConverter : JsonConverter<JsonUniformVariableValue>
    {
        protected override JsonUniformVariableValue GenerateObject(string inSubClassIdentifier)
        {
            switch (inSubClassIdentifier) {
                case "Texture":
                    return new JsonUniformVariableTextureValue();
                default:
                    throw new JsonReaderException();
            }
        }
    }
}
