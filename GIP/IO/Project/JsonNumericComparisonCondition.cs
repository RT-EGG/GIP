using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using GIP.Core.Condition;
using GIP.IO.Json;

namespace GIP.IO.Project
{
    public class JsonNumericComparisonCondition : JsonDataObject
    {
        [JsonProperty(PropertyName = "type")]
        public string Type
        { get; set; } = "";

        [JsonProperty(PropertyName = "operator"), JsonConverter(typeof(StringEnumConverter))]
        public ComparisonOperator Operator
        { get; set; } = ComparisonOperator.Equals;

        [JsonProperty(PropertyName = "left")]
        public Guid LeftSource
        { get; set; } = Guid.Empty;

        [JsonProperty(PropertyName = "right")]
        public Guid RightSource
        { get; set; } = Guid.Empty;
    }
}
