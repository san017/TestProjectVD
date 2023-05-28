using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Serializer
{
    /// <summary>
    /// Сериализация json - объекта.
    /// </summary>
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

        /// <summary>
        /// Сериализация.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="item">Тип сериализуемого объекта.</param>
        /// <param name="fileName">Имя файла.</param>
        /// <exception cref="ArgumentException">Пустое значение.</exception>
        public static void WriteJsonFile<T>(T item, string fileName)
        {
            if (item == null)
            {
                throw new ArgumentException("Пустое значение", nameof(item));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Пустое значение", nameof(fileName));
            }

            File.WriteAllText(fileName, JsonSerializer.Serialize(item, _options));
        }
    }
}
