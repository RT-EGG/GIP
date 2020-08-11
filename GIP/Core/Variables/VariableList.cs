using System.Collections.Generic;
using Reactive.Bindings;
using GIP.IO.Project;

namespace GIP.Core.Variables
{
    public class VariableList : ReactiveCollection<VariableBase>
    {
        public List<JsonVariable> ExportToJson()
        {
            List<JsonVariable> result = new List<JsonVariable>(); ;
            foreach (var variable in this) {
                result.Add(variable.ExportToJson());
            }

            return result;
        }
    }
}
