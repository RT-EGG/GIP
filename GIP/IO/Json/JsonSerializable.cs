using System.IO;
using Newtonsoft.Json;

namespace GIP.IO.Json
{
    public abstract class JsonSerializable
    {
        public void ExportToFile(string inPath)
        {
            string output = JsonConvert.SerializeObject(this);
            using (StreamWriter writer = new StreamWriter(new FileStream(inPath, FileMode.OpenOrCreate, FileAccess.Write))) {
                writer.Write(output);
            }
            return;
        }

        public static T ImportFromFile<T>(string inPath) where T: JsonSerializable
        {
            using (StreamReader reader = new StreamReader(new FileStream(inPath, FileMode.Open, FileAccess.Read))) {
                string input = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(input);
            }
        }
    }
}
