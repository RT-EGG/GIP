using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GIP.IO.Project;

namespace GIP.IO.Json.Converter
{
    class JsonProcessTaskConverter : JsonConverter<JsonProcessTask>
    {
        protected override JsonProcessTask GenerateObject(string inSubClassIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}
