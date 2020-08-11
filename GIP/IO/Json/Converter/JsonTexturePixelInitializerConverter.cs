using Newtonsoft.Json;
using GIP.IO.Project;

namespace GIP.IO.Json.Converter
{
    class JsonTexturePixelInitializerConverter : JsonConverter<JsonTexturePixelInitializer>
    {
        protected override JsonTexturePixelInitializer GenerateObject(string inSubClassIdentifier)
        {
            switch (inSubClassIdentifier) {
                case "Color":
                    return new JsonTexturePixelColorInitializer();
                case "File":
                    return new JsonTexturePixelFileInitializer();
                default:
                    throw new JsonReaderException();
            }
        }
    }
}
