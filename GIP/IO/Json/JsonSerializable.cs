using System.IO;
using Newtonsoft.Json;

namespace GIP.IO.Json
{
    public abstract class JsonSerializable
    {
        public void ExportToFile(string inPath)
        {
            string output = JsonConvert.SerializeObject(this);
            using (StreamWriter writer = new StreamWriter(new FileStream(inPath, FileMode.Create, FileAccess.Write))) {
                writer.Write(output);
            }
            return;
        }

        public static T ImportFromFile<T>(string inPath) where T: JsonSerializable
        {
            return ImportFromStream<T>(new FileStream(inPath, FileMode.Open, FileAccess.Read), true);
        }

        public static T ImportFromStream<T>(Stream inStream, bool inCloseStream = false) where T : JsonSerializable
        {
            StreamReader reader = new StreamReader(inStream);
            T result = ImportFromText<T>(reader.ReadToEnd());

            if (inCloseStream) {
                reader.Close();
            }
            return result;
        }

        public static T ImportFromText<T>(string inText) where T : JsonSerializable
        {
            return JsonConvert.DeserializeObject<T>(inText);
        }
    }
}
