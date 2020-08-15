using GIP.IO.Json;
using GIP.IO.Json.Converter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIP.IO.Project
{
    abstract class JsonProcessTask : JsonSerializable, IJsonSubClassSerializable
    {
        public abstract string GetSubClassIdentifier();
    }

    class JsonComputeTask : JsonProcessTask
    {
        public override string GetSubClassIdentifier() => "Compute";
    }
}
