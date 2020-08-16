using System;
using Newtonsoft.Json;
using GIP.IO.Json;
using GIP.IO.Json.Converter;
using Newtonsoft.Json.Converters;
using OpenTK.Graphics.OpenGL4;

namespace GIP.IO.Project
{
    [JsonConverter(typeof(JsonUniformVariableValueConverter))]
    public abstract class JsonUniformVariableValue : JsonDataObject, IJsonSubClassSerializable
    {
        public abstract string GetSubClassIdentifier();
    }

    public class JsonUniformVariableTextureValue : JsonUniformVariableValue
    {
        [JsonProperty(PropertyName = "texture")]
        public Guid TextureGuid
        { get; set; } = Guid.Empty;

        [JsonProperty(PropertyName = "Access"), JsonConverter(typeof(StringEnumConverter))]
        public TextureAccess Access
        { get; set; } = TextureAccess.ReadOnly;

        [JsonProperty(PropertyName = "InternalFormat"), JsonConverter(typeof(StringEnumConverter))]
        public SizedInternalFormat InternalFormat
        { get; set; } = SizedInternalFormat.Rgba8;

        public override string GetSubClassIdentifier() => "Texture";
    }
}
