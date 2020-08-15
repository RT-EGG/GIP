﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenTK.Graphics.OpenGL4;
using GIP.IO.Json;

namespace GIP.IO.Project
{
    class JsonUniformVariable : JsonDataObject
    {
        [JsonProperty(PropertyName = "UniformName")]
        public string UniformName
        { get; set; } = "";

        [JsonProperty(PropertyName = "Value")]
        public JsonUniformVariableValue Value
        { get; set; }

        [JsonProperty(PropertyName = "Access"), JsonConverter(typeof(StringEnumConverter))]
        public TextureAccess Access
        { get; set; } = TextureAccess.ReadOnly;

        [JsonProperty(PropertyName = "InternalFormat"), JsonConverter(typeof(StringEnumConverter))]
        public SizedInternalFormat InternalFormat
        { get; set; } = SizedInternalFormat.Rgba8;
    }
}
