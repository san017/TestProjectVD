using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Serializer
{
    public static class Serialize
    {
        /// <summary>
        /// Настройки сериализации.
        /// </summary>
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public static void WriteJsonFile<T>(T item, string fileName)
        {
            File.WriteAllText(fileName, JsonSerializer.Serialize(item, _options));
        }
    }
}
