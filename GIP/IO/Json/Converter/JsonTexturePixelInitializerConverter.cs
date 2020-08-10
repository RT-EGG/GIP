using Newtonsoft.Json.Linq;
using GIP.IO.Project;

namespace GIP.IO.Json.Converter
{
    class JsonTexturePixelInitializerConverter : JsonConverter<JsonTexturePixelInitializer>
    {
        protected override JsonTexturePixelInitializer GenerateObject(JObject inObject)
        {
            return JsonTexturePixelInitializer.ReadJson(inObject); 
        }
    }
}
